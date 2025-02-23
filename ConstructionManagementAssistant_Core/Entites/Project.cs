namespace ConstructionManagementAssistant_Core.Entites;

public class Project : IEntity
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? ExpectedEndDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int? SiteEngineerId { get; set; }
    public int ClientId { get; set; }
    public string? SiteAddress { get; set; }
    public string? GeographicalCoordinates { get; set; }
    public bool IsDeleted { get; set; }
    public string? CancelationReason { get; set; }
    public DateOnly? CancelationDate { get; set; }
    public DateOnly? CompletionDate { get; set; }
    public DateOnly? HandoverDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    #endregion

    #region Navigation Properties

    public SiteEngineer? SiteEngineer { get; set; }
    public Client Client { get; set; }

    #endregion
}

