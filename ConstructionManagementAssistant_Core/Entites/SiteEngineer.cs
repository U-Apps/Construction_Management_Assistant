
namespace ConstructionManagementAssistant_Core.Entites;

public class SiteEngineer:Person,IEntity
{
    public int PersonId { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsAvailable { get; set; }
}
