using Microsoft.AspNetCore.Identity;

namespace ConstructionManagementAssistant.EF.Data
{
    //public class ApplicationIdentity : IdentityUser, IApplicationIdentity
    //{

    //    public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
