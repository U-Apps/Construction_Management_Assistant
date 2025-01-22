
namespace ConstructionManagementAssistant_Core.Models
{
    public class Client:Entity<int>
    {
    
        public string FullName {  get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string ClientType { get; set; }

        public Client(int id,string fullname ,string email , string phoneNumber , string clientType):base(id)
        {
            this.FullName = fullname;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.ClientType = clientType;
        }
    }
}
