namespace ConstructionManagementAssistant.Core.DTOs.Auth
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}



