using Microsoft.AspNetCore.Identity;
namespace ConstructionManagementAssistant.EF.Data
{
    public class ApplicationIdentity : IdentityUser, IApplicationIdentity
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
