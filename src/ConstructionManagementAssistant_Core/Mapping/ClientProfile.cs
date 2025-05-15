using ConstructionManagementAssistant.Core.Extentions;

namespace ConstructionManagementAssistant.Core.Mapping;

public static class ClientProfile
{
    public static Expression<Func<Client, GetClientDto>> ToGetClientDto()
    {
        return client => new GetClientDto
        {
            Id = client.Id,
            FullName = client.FullName,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            ClientType = (client.ClientType).GetDisplayName(),
        };
    }


    public static Expression<Func<Client, ClientNameDto>> ToGetClientNameDto()
    {
        return client => new ClientNameDto
        {
            Id = client.Id,
            FullName = client.FullName
        };
    }

    public static Expression<Func<Client, ClientDetailsDto>> ToClientDetailsDto()
    {
        return client => new ClientDetailsDto
        {
            Id = client.Id,
            FullName = client.FullName,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            ClientType = client.ClientType.GetDisplayName(),
            Projects = client.Projects.Select(p => new ProjectNameDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList()
        };
    }

    public static Client ToClient(this AddClientDto addClientDto)
    {
        return new Client
        {
            FullName = addClientDto.FullName,
            Email = addClientDto.Email,
            PhoneNumber = addClientDto.PhoneNumber,
        };
    }



    public static void UpdateClient(this Client client, UpdateClientDto updateClientDto)
    {
        client.FullName = updateClientDto.FullName;
        client.Email = updateClientDto.Email;
        client.PhoneNumber = updateClientDto.PhoneNumber;
        //client.ClientType = updateClientDto.ClientType;
        client.ModifiedDate = DateTime.Now;
    }
}
