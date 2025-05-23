namespace ConstructionManagementAssistant.Core.Entites;

public class Person : IEntity, ISoftDeletable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? SecondName { get; set; }  // todo : delete second and third name
    public string? ThirdName { get; set; }
    public string LastName { get; set; }
    public string? NationalNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {SecondName} {ThirdName} {LastName}".Replace("  ", " ").Trim();
    }
}

