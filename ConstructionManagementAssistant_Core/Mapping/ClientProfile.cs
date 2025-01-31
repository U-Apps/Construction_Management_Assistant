using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Extentions;

namespace ConstructionManagementAssistant_Core.Mapping;

public static class ClientProfile
{
    public static GetClientDto ToGetClientDto(this Client client)
    {
        return new GetClientDto
        {
            Id = client.Id,
            FullName = client.FullName,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            ClientType = client.ClientType.GetDisplayName(),
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

    public static Client ToClient(this UpdateClientDto updateClientDto)
    {
        return new Client
        {
            Id = updateClientDto.Id,
            FullName = updateClientDto.FullName,
            Email = updateClientDto.Email,
            PhoneNumber = updateClientDto.PhoneNumber,
            ModifiedDate = DateTime.Now,
        };
    }
}
