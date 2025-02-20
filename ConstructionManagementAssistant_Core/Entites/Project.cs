

namespace ConstructionManagementAssistant_Core.Entites;
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly Startdate { get; set; }
    public DateOnly ExpectedEndDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int SiteEngineerId { get; set; }
    public int ClientId { get; set; }
    public string? SiteAddress { get; set; }
    public string? GeographicalCoordinates { get; set; }
    public bool IsDeleted { get; set; }
    public DateOnly DateModified { get; set; }
    public DateOnly DateCreated { get; set; }
    public string? CancelationReason { get; set; }
    public DateOnly? CancelationDate { get; set; }
    public int? CancelledAtStage { get; set; }
    public DateOnly? CompletionDate { get; set; }
    public DateOnly? HandoverDate { get; set; }
    public SiteEngineer SiteEngineer { get; set; }
    public Client Client { get; set; }
}
