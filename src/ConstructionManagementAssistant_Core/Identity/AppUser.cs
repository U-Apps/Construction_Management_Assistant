using Microsoft.AspNetCore.Identity;

namespace ConstructionManagementAssistant.Core.Identity;

public class AppUser : IdentityUser<int>
{
    public required string Name { get; set; }  // the name of the user, user could be office or individual

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<Client> Clients { get; set; } = new List<Client>();
    public ICollection<Worker> Workers { get; set; } = new List<Worker>();
    public ICollection<WorkerSpecialty> WorkerSpecialties { get; set; } = new List<WorkerSpecialty>();
    public ICollection<SiteEngineer> SiteEngineers { get; set; } = new List<SiteEngineer>();
    public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
}
