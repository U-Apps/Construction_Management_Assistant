namespace ConstructionManagementAssistant_Core.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }

        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
