namespace ConstructionManagementAssistant_Core.Entites
{
    public class WorkerSpecialty : IEntity, ISoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public ICollection<Worker>? Workers { get; set; }
    }
}