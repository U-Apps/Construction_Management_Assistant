namespace ConstructionManagementAssistant.Core.Entites
{
    public class Documnet
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateOnly Created { set; get; }

        public string Path { get; set; }
    }
}
