using System.Text.Json.Serialization;

namespace ConstructionManagementAssistant.Core.Entites
{
    public class DocumentClassification
    {
        public int Id { get; set; }

        public string? Type { get; set; }

        [JsonIgnore]
        public List<Documnet>? Documnets { get; set; }
    }
}
