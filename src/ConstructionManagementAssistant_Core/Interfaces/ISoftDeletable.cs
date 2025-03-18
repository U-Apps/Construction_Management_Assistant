namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedDate { get; set; }

    }
}
