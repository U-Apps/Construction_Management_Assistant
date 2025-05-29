using Microsoft.AspNetCore.Identity;

namespace ConstructionManagementAssistant.Core.Identity;

public class AppUser : IdentityUser<int>
{
    public required string Name { get; set; }  // the name of the user, user could be office or individual
    public int? BelongToUserId { get; set; }
    public AppUser? BelongToUser { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<Client> Clients { get; set; } = new List<Client>();
    public ICollection<Worker> Workers { get; set; } = new List<Worker>();
    public ICollection<WorkerSpecialty> WorkerSpecialties { get; set; } = new List<WorkerSpecialty>();
    public ICollection<AppUser>? AppUsers { get; set; } = new List<AppUser>();
    public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
