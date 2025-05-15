namespace ConstructionManagementAssistant.Core.Entites
{
    public class DocumentClassification
    {
        public int Id { get; set; }

        public string? DocumentType { get; set; }

        public List<Documnet>? Documnets { get; set; }
    }
}
