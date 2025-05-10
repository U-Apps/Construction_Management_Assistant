namespace ConstructionManagementAssistant.Core.Entites
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EquipmentStatus Status { get; set; }

        public DateOnly PurchaseDate { get; set; }
    }
}
