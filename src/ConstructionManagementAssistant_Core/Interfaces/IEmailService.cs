namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string bodyHtml);
    }
}
