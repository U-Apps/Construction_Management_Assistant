namespace ConstructionManagementAssistant.Core.DTOs.Auth
{
    public class AuthResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        //public string lastName { get; set; }
        public string AccessToken { get; set; }
        public string RefereshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}

