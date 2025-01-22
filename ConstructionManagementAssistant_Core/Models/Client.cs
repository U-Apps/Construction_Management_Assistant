
namespace ConstructionManagementAssistant_Core.Models
{
    public enum enClientType
    {
        Company,
        individual
    }
    public class Client(int id, string FullName, string email, string phoneNumber, enClientType clientType) : Entity<int>(id)
    {

        public string FullName { get; set; } = FullName;
        public string Email { get; set; } = email;
        public string PhoneNumber { get; set; } = phoneNumber;

        public enClientType ClientType { get; set; } = clientType;
    }
}
