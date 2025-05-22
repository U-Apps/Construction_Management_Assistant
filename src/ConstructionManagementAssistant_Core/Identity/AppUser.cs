using Microsoft.AspNetCore.Identity;

namespace ConstructionManagementAssistant.Core.Identity;

public class AppUser : IdentityUser<int>
{
    public required string Name { get; set; }  // the name of the user, user could be office or individual

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
