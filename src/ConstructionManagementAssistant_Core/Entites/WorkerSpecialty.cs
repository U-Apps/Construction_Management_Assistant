namespace ConstructionManagementAssistant.Core.Entites
{
    public class WorkerSpecialty : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public ICollection<Worker>? Workers { get; set; }
    }
}