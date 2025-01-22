
namespace ConstructionManagementAssistant_Core.Models
{
    public class Person(int id,
                  string firstName,
                  string secondName,
                  string? thirdName,
                  string lastName,
                  string? nationalNumber,
                  string? phoneNumber,
                  string? email,
                  string? address) : Entity<int>(id)
    {
        public string FirstName { get; set; } = firstName;
        public string SecondName { get; set; } = secondName;
        public string? ThirdName { get; set; } = thirdName;
        public string LastName { get; set; } = lastName;
        public string NationalNumber { get; set; } = nationalNumber;
        public string PhoneNumber { get; set; } = phoneNumber;
        public string? Email { get; set; } = email;
        public string Address { get; set; } = address;
    }
}

