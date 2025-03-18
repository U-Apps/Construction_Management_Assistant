using ConstructionManagementAssistant.Core.DTOs;
using ConstructionManagementAssistant.Core.Entites;
using ConstructionManagementAssistant.Core.Extentions;
using System.Linq.Expressions;

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

    public static Client ToClient(this AddClientDto addClientDto)
    {
        return new Client
        {
            FullName = addClientDto.FullName,
            Email = addClientDto.Email,
            PhoneNumber = addClientDto.PhoneNumber,
            ClientType = addClientDto.ClientType
        };
    }

    public static void UpdateClient(this Client client, UpdateClientDto updateClientDto)
    {
        client.FullName = updateClientDto.FullName;
        client.Email = updateClientDto.Email;
        client.PhoneNumber = updateClientDto.PhoneNumber;
        client.ClientType = updateClientDto.ClientType;
        client.ModifiedDate = DateTime.Now;
    }
}
