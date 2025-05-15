
namespace ConstructionManagementAssistant.Core.Entites;

public class SiteEngineer : Person
{
    public DateOnly HireDate { get; set; }
    public ICollection<Project>? Projects { get; set; }

}

