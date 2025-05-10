namespace ConstructionManagementAssistant.Core.Entites
{
    public class Equipment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentStatus Status { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
