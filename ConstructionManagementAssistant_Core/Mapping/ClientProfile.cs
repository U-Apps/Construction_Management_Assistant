﻿using ConstructionManagementAssistant_Core.DTOs;
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

    public static void UpdateClient(this Client client, UpdateClientDto updateClientDto)
    {
        client.FullName = updateClientDto.FullName;
        client.Email = updateClientDto.Email;
        client.PhoneNumber = updateClientDto.PhoneNumber;
        client.ClientType = updateClientDto.ClientType;
        client.ModifiedDate = DateTime.Now;
    }
}
