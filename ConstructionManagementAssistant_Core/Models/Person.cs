
namespace ConstructionManagementAssistant_Core.Models
{
    public class Person: Entity<int>
    {
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? ThirdName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string NationalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }

        public Person(int id,
                      string firstName,
                      string secondName,
                      string? thirdName,
                      string lastName,
                      string? nationalNumber,
                      string? phoneNumber,
                      string? email,
                      string? address) : base(id)
        {
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            NationalNumber = nationalNumber;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }
    }
}

