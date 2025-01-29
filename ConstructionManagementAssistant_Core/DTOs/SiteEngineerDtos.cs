namespace ConstructionManagementAssistant_Core.DTOs
{
    public class GetSiteEngineerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsAvailable { get; set; }

    }

    public class AddSiteEngineerDto
    {
        [Length(3,20)]
        public required string FirstName { get; set; }
        [Length(3, 20)]
        public required string SecondName { get; set; }
        [Length(3, 20)]
        public required string ThirdName { get; set; }
        [Length(3, 20)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [Phone]
        public required string PhoneNumber { get; set; }
        public string NationalNumber { get; set; }
        public string Address { get; set; }
        public DateOnly HireDate { get; set; }

    }

    public class UpdateSiteEngineerDto
    {
        public int Id { get; set; }
        [Length(3, 20)]
        public required string FirstName { get; set; }
        [Length(3, 20)]
        public required string SecondName { get; set; }
        [Length(3, 20)]
        public required string ThirdName { get; set; }
        [Length(3, 20)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [Phone]
        public required string PhoneNumber { get; set; }
        public string NationalNumber { get; set; }
        public string Address { get; set; }
        public DateOnly HireDate { get; set; }
    }
}
