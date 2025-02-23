namespace ConstructionManagementAssistant_Core.Entites;


public class Client : IEntity
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public ClientType ClientType { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Project> Projects { get; set; }
}
