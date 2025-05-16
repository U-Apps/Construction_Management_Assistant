using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant.Core.DTOs
{
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
        public string ProjectName { get; set; }
        public int ClassificationId { get; set; }
        public string ClassificationName { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class DocumentDetailsResponse : DocumentResponse
    {
        public string? FileUrl { get; set; }
        public string? FileType { get; set; }
    }
}