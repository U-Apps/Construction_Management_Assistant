
using ConstructionManagementAssistant.Core.Helper.Attributes;
using System.Text.Json.Serialization;

namespace ConstructionManagementAssistant.Core.DTOs
{
    public class AddProjectDto
    {
        [MaxLength(200)]
        public required string ProjectName { get; init; }
        [MaxLength(1000)]
        public string? Description { get; init; }
        [MaxLength(500)]
        public string? SiteAddress { get; init; }
        [MaxLength(100)]
        public string? GeographicalCoordinates { get; init; }
        [Range(1, int.MaxValue)]
        public int? SiteEngineerId { get; init; }
        [Range(1, int.MaxValue)]
        public required int ClientId { get; init; }
        [FutureDate]
        public DateOnly? StartDate { get; init; }
        [FutureDate(nameof(StartDate))]
        public DateOnly? ExpectedEndDate { get; init; }
    }

    public class UpdateProjectDto
    {
        [Range(1, int.MaxValue)]
        public required int Id { get; init; }
        [MaxLength(200)]
        public string? ProjectName { get; init; }
        [MaxLength(1000)]
        public string? Description { get; init; }
        [MaxLength(500)]
        public string? SiteAddress { get; init; }
        [MaxLength(100)]
        public string? GeographicalCoordinates { get; init; }


        // we will look at them later
        //public DateOnly? StartDate { get; init; }
        //public DateOnly? ExpectedEndDate { get; init; }
    }

    public class GetProjectsDto
    {
        public required int Id { get; init; }
        public required string ProjectName { get; init; }
        public string? SiteAddress { get; init; }
        public required string ClientName { get; init; }
        public required string ProjectStatus { get; init; }
    }


    public class ProjectNameDto
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
    }

    public class ProjectDetailsDto
    {
        public required int Id { get; init; }
        public required string ProjectName { get; init; }
        public string? Description { get; init; }
        public string? SiteAddress { get; init; }
        public string? GeographicalCoordinates { get; init; }
        public required string ProjectStatus { get; init; }
        public string? SiteEngineerName { get; init; }
        public required string ClientName { get; init; }
        public DateOnly? StartDate { get; init; }
        public DateOnly? ExpectedEndDate { get; init; }



        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CancellationReason { get; init; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateOnly? CancellationDate { get; init; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public string? CancelledAtStage { get; init; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateOnly? CompletionDate { get; init; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateOnly? HandoverDate { get; init; }
    }

    public class CancelProjectRequest
    {
        [MaxLength(500)]
        public required string CancelationReason { get; init; }
        [PastOrPresentDate]
        public required DateOnly CancelationDate { get; init; }
    }

    public class CompleteProjectRequest
    {
        [PastOrPresentDate]
        public required DateOnly CompletionDate { get; init; }
        [PastOrPresentDate]
        public DateOnly? HandoverDate { get; init; }
    }
}
