﻿

namespace ConstructionManagementAssistant_Core.Entites;
public class Project:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly ExpectedEndDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int SiteEngineerId { get; set; }
    public int ClientId { get; set; }
    public string? SiteAddress { get; set; }
    public string? GeographicalCoordinates { get; set; }
    public bool IsDeleted { get; set; }
    public string? CancelationReason { get; set; }
    public DateOnly? CancelationDate { get; set; }
    public int? CancelledAtStage { get; set; }
    public DateOnly? CompletionDate { get; set; }
    public DateOnly? HandoverDate { get; set; }
    public SiteEngineer SiteEngineer { get; set; }
    public Client Client { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
