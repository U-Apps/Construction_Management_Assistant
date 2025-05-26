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
        var projectJson = JsonSerializer.Serialize(project, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var promptTemplate =
            "You are a construction project management expert analyzing project data to generate comprehensive reports. " +
            "Follow these guidelines strictly:\n\n" +

            "### Report Structure Requirements:\n" +
            "1. **Executive Summary** (3-5 bullet points)\n" +
            "   - Overall project health status (use: ✅ On Track, ⚠️ At Risk, or ❌ Off Track)\n" +
            "   - Key milestones reached/upcoming\n" +
            "   - Critical risks needing attention\n\n" +

            "2. **Project Overview**\n" +
            "   - Table format with columns: Project | Client | Site Engineer | % Complete | Status\n" +
            "   - Status indicators: (🟢 On Track) (🟡 Minor Delays) (🔴 Significant Delay)\n\n" +

            "3. **Stage Analysis**\n" +
            "   - For each stage, include:\n" +
            "     - Visual progress bar [=====    ] 60%\n" +
            "     - Timeline comparison: Planned vs Actual (use 📅 icon)\n" +
            "     - Critical path identification\n\n" +

            "4. **Resource Allocation**\n" +
            "   - Worker utilization heatmap (High/Medium/Low)\n" +
            "   - Equipment conflict matrix\n" +
            "   - Highlight:\n" +
            "     - Over-utilized resources (❗ icon)\n" +
            "     - Underutilized resources (💤 icon)\n\n" +

            "5. **Risk Matrix**\n" +
            "   - Table with: Risk | Impact (H/M/L) | Probability (H/M/L) | Mitigation Strategy\n" +
            "   - Flag top 3 critical risks with 🚨\n\n" +

            "6. **Recommendations**\n" +
            "   - Categorized as:\n" +
            "     - 🚀 Quick Wins\n" +
            "     - 🛠️ Process Improvements\n" +
            "     - 🔄 Resource Reallocations\n\n" +

            "### Formatting Rules:\n" +
            "- Use markdown formatting\n" +
            "- Include emoji for visual scanning\n" +
            "- Never use placeholder text - show 'N/A' if data missing\n" +
            "- Prioritize actionable insights over raw data\n\n" +

            "### Project Data:\n{0}";

        return string.Format(promptTemplate, projectJson);
    }


    // well document for both languages
    [HttpGet(SystemApiRouts.Reports.DownloadProjectReprot)]
    public async Task<IActionResult> GenerateReport(int projectId)
    {
        // Theme colors (adjust based on your actual app theme)
        var primaryColor = "#2E86AB";  // Blue-ish
        var secondaryColor = "#A23B72"; // Purple-ish
        var accentColor = "#F18F01";   // Orange
        var successColor = "#3BB273";   // Green
        var warningColor = "#F4A259";   // Yellow-orange
        var dangerColor = "#E94F37";    // Red
        var textColor = "#333333";      // Dark gray
        var lightBgColor = "#F8F9FA";   // Light gray

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

        byte[] pdfBytes;
        using (var stream = new MemoryStream())
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    // Page styling
                    page.DefaultTextStyle(x => x.FontSize(12).FontColor(textColor));
                    page.Margin(30);

                    // Header with theme colors
                    page.Header().PaddingBottom(15).Row(row =>
                    {
                        row.RelativeItem().Background(primaryColor).Padding(10).AlignCenter().Text($"Report: {project.Name}")
                            .FontColor("#FFFFFF")
                            .FontSize(20)
                            .Bold();
                    });

                    page.Content().Column(column =>
                    {
                        bool inList = false;
                        bool inTable = false;

                        foreach (var line in lines)
                        {
                            // Handle section headers
                            if (line.StartsWith("## "))
                            {
                                column.Item().PaddingBottom(10).PaddingTop(15).Text(line.Replace("## ", ""))
                                    .FontColor(primaryColor)
                                    .FontSize(18)
                                    .Bold();
                                inList = false;
                            }
                            else if (line.StartsWith("### "))
                            {
                                column.Item().PaddingBottom(8).Text(line.Replace("### ", ""))
                                    .FontColor(secondaryColor)
                                    .FontSize(16)
                                    .Bold();
                                inList = false;
                            }
                            // Handle status indicators
                            else if (line.Contains("🟢") || line.Contains("✅"))
                            {
                                column.Item().PaddingBottom(5).Text(line)
                                    .FontColor(successColor);
                            }
                            else if (line.Contains("🟡") || line.Contains("⚠️"))
                            {
                                column.Item().PaddingBottom(5).Text(line)
                                    .FontColor(warningColor);
                            }
                            else if (line.Contains("🔴") || line.Contains("❌"))
                            {
                                column.Item().PaddingBottom(5).Text(line)
                                    .FontColor(dangerColor);
                            }
                            // Handle progress bars
                            else if (line.Contains("[") && line.Contains("%"))
                            {
                                var progressText = line;
                                var percentMatch = Regex.Match(line, @"(\d+)%");
                                var percent = percentMatch.Success ? int.Parse(percentMatch.Groups[1].Value) : 0;

                                column.Item().PaddingVertical(5).Stack(stack =>
                                {
                                    stack.Item().Text(progressText);
                                    stack.Item().PaddingTop(2).Height(8).Background(lightBgColor).Width(percent * 2)
                                        .Background(percent > 70 ? successColor : percent > 30 ? warningColor : dangerColor);
                                });
                            }
                            // Handle bullet lists
                            else if (line.StartsWith("* ") || line.StartsWith("- ") || line.StartsWith("• "))
                            {
                                var item = column.Item();
                                if (!inList) item = item.PaddingTop(5);
                                item.Row(row =>
                                {
                                    row.AutoItem().Text("•").FontColor(accentColor);
                                    row.RelativeItem().PaddingLeft(5).Text(line.Substring(2).Trim());
                                });
                                inList = true;
                            }
                            // Handle tables
                            else if (line.Contains("|") && line.Split('|').Length > 2)
                            {
                                if (!inTable)
                                {
                                    // First line of table - assumed to be headers
                                    var headers = line.Split('|')
                                        .Select(c => c.Trim())
                                        .Where(c => !string.IsNullOrEmpty(c))
                                        .ToArray();

                                    column.Item().PaddingTop(10).Table(table =>
                                    {
                                        // Define columns (all equal width in this example)
                                        table.ColumnsDefinition(columns =>
                                        {
                                            for (int i = 0; i < headers.Length; i++)
                                            {
                                                columns.RelativeColumn();
                                            }
                                        });

                                        // Add header row
                                        table.Header(header =>
                                        {
                                            foreach (var headerText in headers)
                                            {
                                                header.Cell()
                                                    .Background(primaryColor)
                                                    .Padding(5)
                                                    .Text(headerText)
                                                    .FontColor("#FFFFFF")
                                                    .Bold();
                                            }
                                        });

                                        inTable = true;
                                    });
                                }
                                else
                                {
                                    // Table content rows
                                    var cells = line.Split('|')
                                        .Select(c => c.Trim())
                                        .Where(c => !string.IsNullOrEmpty(c))
                                        .ToArray();

                                    column.Item().Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            for (int i = 0; i < cells.Length; i++)
                                            {
                                                columns.RelativeColumn();
                                            }
                                        });

                                        table.Cell().BorderBottom(1)
                                            .BorderColor(lightBgColor)
                                            .Padding(5)
                                            .Text(cells[0]);

                                        for (int i = 1; i < cells.Length; i++)
                                        {
                                            table.Cell().BorderBottom(1)
                                                .BorderColor(lightBgColor)
                                                .Padding(5)
                                                .Text(cells[i]);
                                        }
                                    });
                                }
                            }
                            else
                            {
                                // Regular paragraph
                                column.Item().PaddingBottom(8).Text(line)
                                    .FontSize(12)
                                    .LineHeight(1.2f);
                                inList = false;
                                inTable = false;
                            }
                        }

                        // Add visual summary at end
                        column.Item().PaddingTop(20).Background(lightBgColor).Padding(15).Column(summaryColumn =>
                        {
                            summaryColumn.Item().Text("Project Summary").FontSize(16).Bold().FontColor(primaryColor);
                            summaryColumn.Item().PaddingTop(5).Text($"Generated on {DateTime.UtcNow:yyyy-MM-dd HH:mm} UTC").Italic();
                        });
                    });

                    // Footer with theme colors
                    page.Footer().Background(primaryColor).Padding(10).Row(row =>
                    {
                        row.RelativeItem().AlignCenter().Text(text =>
                        {
                            text.Span("Page ").FontColor("#FFFFFF").FontSize(10);
                            text.CurrentPageNumber().FontColor("#FFFFFF").FontSize(10);
                            text.Span($" | {project.Name} Report").FontColor("#FFFFFF").FontSize(10);
                        });
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