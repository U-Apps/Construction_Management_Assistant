namespace ConstructionManagementAssistant_Core.DTOs;

public class GetClientDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ClientType { get; set; }
}

public class AddClientDto
{
    public required string FullName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public required string PhoneNumber { get; set; }

    [Range(1, 2)]
    public required ClientType ClientType { get; set; }
}

public class UpdateClientDto
{
    public int Id { get; set; }

    public required string FullName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public required string PhoneNumber { get; set; }

    [Range(1, 2)]
    public ClientType ClientType { get; set; }
}
