using ConstructionManagementAssistant.Core.DTOs.ReportDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;
using QuestPDF.Fluent;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
[Authorize]
public class ReportsController : ControllerBase
{
    private readonly string _apiKey;
    private readonly IUnitOfWork _unitOfWork;
    public ReportsController(IOptions<OpenAIOptions> apiKey, IUnitOfWork unitOfWork)
    {
        _apiKey = apiKey.Value.ApiKey;
        _unitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }


    private static string BuildProjectReportPrompt(ProjectDtoForFreportDto project)
    {
        // Use the static prompt template, replacing the placeholder with the serialized project JSON
        var projectJson = JsonSerializer.Serialize(project, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var promptTemplate =
            "You are a construction project management assistant. Analyze the following JSON construction project data and generate a professional and comprehensive status report. " +
            "Structure the report using clear section headers, bullet points, and tables where helpful.\r\n\r\n" +
            "The report must include the following sections:\r\n\r\n" +
            "1. Project Overview and Current Status\r\n" +
            "List all projects with:\r\n\r\n" +
            "Project Name\r\n\r\n" +
            "Associated Client (if available in data)\r\n\r\n" +
            "Site Engineer\r\n\r\n" +
            "Summarize for each project:\r\n\r\n" +
            "Current stage\r\n\r\n" +
            "Percent completion\r\n\r\n" +
            "Overall project status (e.g., On Track, Delayed, Completed)\r\n\r\n" +
            "2. Stage Completion Analysis\r\n" +
            "For each project:\r\n\r\n" +
            "Break down all stages with:\r\n\r\n" +
            "Stage Name\r\n\r\n" +
            "Percent completion\r\n\r\n" +
            "Schedule status: On Track, Behind Schedule, or Ahead of Schedule (Compare stage start and expected end dates with current date)\r\n\r\n" +
            "3. Task Progress and Bottlenecks\r\n" +
            "Under each stage, list all tasks with:\r\n\r\n" +
            "Task Name\r\n\r\n" +
            "Current status: Not Started, In Progress, or Completed (based on IsCompleted flag and dates)\r\n\r\n" +
            "Highlight any delayed or blocked tasks and provide possible reasons (e.g., unassigned workers, no equipment reservation, exceeded expected dates)\r\n\r\n" +
            "4. Resource Allocation\r\n" +
            "Workers\r\n\r\n" +
            "Show task assignments per worker\r\n\r\n" +
            "Flag over-allocated (assigned to multiple concurrent tasks) and idle workers (not assigned)\r\n\r\n" +
            "Equipment\r\n\r\n" +
            "List equipment per project/task with:\r\n\r\n" +
            "Reservation status: In Use, Reserved, Idle\r\n\r\n" +
            "Usage conflicts or underutilization\r\n\r\n" +
            "5. Risks and Recommendations\r\n" +
            "Identify current or potential risks:\r\n\r\n" +
            "Labor shortages\r\n\r\n" +
            "Equipment scheduling conflicts\r\n\r\n" +
            "Delays in stages or key dependencies\r\n\r\n" +
            "Provide clear, actionable recommendations:\r\n\r\n" +
            "Reassign or redistribute workers\r\n\r\n" +
            "Reserve backup equipment\r\n\r\n" +
            "Adjust task priorities or stage schedules\r\n\r\n" +
            "Project details:\r\n{0}";

        return string.Format(promptTemplate, projectJson);
    }






    // well document for both languages
    [HttpGet(SystemApiRouts.Reports.DownloadProjectReprot)]
    public async Task<IActionResult> GenerateReport(int projectId)
    {

        var project = await _unitOfWork.Projects.GetProjectReport(projectId);

        var prompt = BuildProjectReportPrompt(project);


        OpenAIClient client = new OpenAIClient(_apiKey);
        ChatClient chatService = client.GetChatClient("gpt-4o-mini");

        var result = await chatService.CompleteChatAsync(prompt);
        var rawText = result.Value.Content[0].Text;

        // Clean and split lines
        var lines = rawText
            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();

        // Generate PDF using QuestPDF
        byte[] pdfBytes;
        using (var stream = new MemoryStream())
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Header().AlignCenter().PaddingBottom(15).Text($"Report: {project.Name}")
                        .FontSize(20)
                        .Bold()
                        .Underline();

                    page.Content().Column(column =>
                    {
                        bool inList = false;

                        foreach (var line in lines)
                        {
                            // Handle section headers (markdown ## or ###)
                            if (line.StartsWith("## "))
                            {
                                column.Item().PaddingBottom(10).Text(line.Replace("## ", ""))
                                    .FontSize(18)
                                    .Bold();
                                inList = false;
                            }
                            else if (line.StartsWith("### "))
                            {
                                column.Item().PaddingBottom(8).Text(line.Replace("### ", ""))
                                    .FontSize(16)
                                    .Bold();
                                inList = false;
                            }
                            // Handle numbered lists
                            else if (Regex.IsMatch(line, @"^\d+\.\s"))
                            {
                                var item = column.Item();
                                if (!inList) item = item.PaddingTop(5);
                                item.PaddingLeft(15).Text(line).FontSize(12);
                                inList = true;
                            }
                            // Handle bullet lists (markdown * or -)
                            else if (line.StartsWith("* ") || line.StartsWith("- "))
                            {
                                var item = column.Item();
                                if (!inList) item = item.PaddingTop(5);
                                item.Row(row =>
                                {
                                    row.AutoItem().Text("•");
                                    row.RelativeItem().PaddingLeft(5).Text(line.Substring(2).Trim());
                                });
                                inList = true;
                            }
                            // Handle code blocks (markdown ```)
                            else if (line.StartsWith("```"))
                            {
                                // Skip the code block markers
                                inList = false;
                            }
                            else
                            {
                                // Regular paragraph
                                column.Item().PaddingBottom(8).Text(line)
                                    .FontSize(12)
                                    .LineHeight(1.2f);
                                inList = false;
                            }
                        }
                    });

                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Page ").FontSize(10);
                        text.CurrentPageNumber().FontSize(10);
                        text.Span($" | Generated on {DateTime.UtcNow:yyyy-MM-dd HH:mm} UTC").FontSize(10);
                    });
                });
            }).GeneratePdf(stream);

            pdfBytes = stream.ToArray();
        }

        var fileName = $"{project.Name} Report_{DateTime.UtcNow:yyyyMMddHHmmss}.pdf";
        return File(pdfBytes, "application/pdf", fileName);
    }




    // well document style

    //[HttpPost(SystemApiRouts.Reports.GetProjectReprot)]
    //public async Task<IActionResult> GenerateReport([FromBody] ReportRequestDto request)
    //{
    //    var prompt = $"Generate a detailed report about {request.Topic}. Details: {request.AdditionalDetails}";

    //    OpenAIClient client = new OpenAIClient(_apiKey);
    //    ChatClient chatService = client.GetChatClient("gpt-4o-mini");

    //    var result = await chatService.CompleteChatAsync(prompt);
    //    var rawText = result.Value.Content[0].Text;

    //    // Clean and split lines
    //    var lines = rawText
    //        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
    //        .Select(line => line.Trim())
    //        .Where(line => !string.IsNullOrWhiteSpace(line))
    //        .ToList();

    //    // Generate PDF using QuestPDF
    //    byte[] pdfBytes;
    //    using (var stream = new MemoryStream())
    //    {
    //        Document.Create(container =>
    //        {
    //            container.Page(page =>
    //            {
    //                page.Margin(30);
    //                page.Content().Column(column =>
    //                {
    //                    // Title
    //                    column.Item().PaddingBottom(10).Text($"Report: {request.Topic}")
    //                        .FontSize(20)
    //                        .Bold()
    //                        .Underline();

    //                    // Each line of content
    //                    foreach (var line in lines)
    //                    {
    //                        if (line.Length < 60 && !line.StartsWith(".") && !Regex.IsMatch(line, @"^\d+\."))
    //                        {
    //                            // Section headers
    //                            column.Item().PaddingBottom(6).Text(text =>
    //                            {
    //                                text.Span(line).FontSize(14).Bold();
    //                            });
    //                        }
    //                        else if (Regex.IsMatch(line, @"^\d+\."))
    //                        {
    //                            // Numbered list
    //                            column.Item().PaddingBottom(4).Text(text =>
    //                            {
    //                                text.Span(line).FontSize(12);
    //                            });
    //                        }
    //                        else if (line.StartsWith("."))
    //                        {
    //                            // Bullet list
    //                            column.Item().PaddingBottom(4).Row(row =>
    //                            {
    //                                row.AutoItem().Text("•");
    //                                row.RelativeItem().Text(line.TrimStart('.'));
    //                            });
    //                        }
    //                        else
    //                        {
    //                            // Paragraph
    //                            column.Item().PaddingBottom(5).Text(text =>
    //                            {
    //                                text.Span(line).FontSize(12);
    //                            });
    //                        }
    //                    }
    //                });
    //            });
    //        }).GeneratePdf(stream);

    //        pdfBytes = stream.ToArray();
    //    }

    //    var fileName = $"Report_{request.Topic}_{DateTime.UtcNow:yyyyMMddHHmmss}.pdf";
    //    return File(pdfBytes, "application/pdf", fileName);
    //}












    //[HttpPost(SystemApiRouts.Reports.GetProjectReprot)]
    //public async Task<string> GenerateReport([FromBody] ReportRequestDto request)
    //{
    //    var prompt = $"Generate a detailed report about {request.Topic}. Details: {request.AdditionalDetails}";


    //    OpenAIClient client = new OpenAIClient(_apiKey);
    //    ChatClient chatService = client.GetChatClient("gpt-4o-mini");

    //    var result = await chatService.CompleteChatAsync(prompt);
    //    var rawText = result.Value.Content[0].Text;

    //    // Reshape the text: trim, replace multiple newlines with a single newline, and optionally format as a report
    //    var lines = rawText
    //        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
    //        .Select(line => line.Trim())
    //        .Where(line => !string.IsNullOrWhiteSpace(line));

    //    var formattedReport = string.Join(Environment.NewLine, lines);

    //    return formattedReport;
    //}


    //[HttpPost(SystemApiRouts.Reports.DownloadProjectReprot)]
    //public IActionResult DownloadFile()
    //{
    //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/reports", "ef.png");
    //    var fileStream = System.IO.File.OpenRead(filePath);

    //    return File(fileStream, "application/png", "ef2.png");
    //    // The third parameter is the suggested filename
    //}
}