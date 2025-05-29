using System.Text.Json.Serialization;

namespace ConstructionManagementAssistant.Core.DTOs
{
    /// <summary>
    /// Basic document response DTO.
    /// </summary>
    public class DocumentResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TaskId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TaskName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string? FileUrl { get; set; }
        public string? FileType { get; set; }
    }
}