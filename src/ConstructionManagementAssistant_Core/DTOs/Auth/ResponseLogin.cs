namespace ConstructionManagementAssistant.Core.DTOs.Auth
{
    public class ResponseLogin
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        //public string lastName { get; set; }
        public string Token { get; set; }
        public string RefereshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}

