namespace ConstructionManagementAssistant.Core.DTOs;

public class AddStageDto
{
    [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
    public required string Name { get; set; }
    [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
    public string? Description { get; set; }
    //[PastOrPresentDate(ErrorMessage = "Start date must be in the past or present.")]
    public DateOnly? StartDate { get; set; }
    //[FutureDate(nameof(StartDate), ErrorMessage = "End date must be after the start date.")]
    public DateOnly? ExpectedEndDate { get; set; }
    [Range(1, int.MaxValue)]
    public required int ProjectId { get; set; }
}

public class GetStageDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? ExpectedEndDate { get; set; }
    public int Progress { get; set; }
}

public class GetStageDetailsDto : GetStageDto
{
    public string ProjectName { get; set; }
}

public class UpdateStageDto
{
    [Range(1, int.MaxValue)]
    public required int Id { get; set; }

    [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
    public required string Name { get; set; }

    [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
    public string? Description { get; set; }

    //[PastOrPresentDate(ErrorMessage = "Start date must be in the past or present.")]
    public DateOnly? StartDate { get; set; }

    //[FutureDate(nameof(StartDate), ErrorMessage = "End date must be after the start date.")]
    public DateOnly? ExpectedEndDate { get; set; }
}

