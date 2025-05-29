using ConstructionManagementAssistant.Core.Extentions;

namespace ConstructionManagementAssistant.EF.Repositories;

public class ClientRepository(AppDbContext _context, ILogger<ClientRepository> _logger)
    : BaseRepository<Client>(_context), IClientRepository
{
    public async Task<ClientDetailsDto?> GetClientById(int id)
    {
        _logger.LogInformation("Fetching client with ID: {Id}", id);

        try
        {
            var client = await FindWithSelectionAsync(
                selector: ClientProfile.ToClientDetailsDto(),
                criteria: x => x.Id == id);

            if (client == null)
            {
                _logger.LogWarning("Client with ID: {Id} not found", id);
                return null;
            }

            _logger.LogInformation("Client with ID: {Id} fetched successfully", id);
            return client;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching client with ID: {Id}", id);
            throw;
        }
    }

    public async Task<PagedResult<GetClientDto>> GetAllClients(
        string UserId,
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null,
        ClientType? clientType = null)
    {
        _logger.LogInformation("Fetching all clients with filters - Page: {PageNumber}, Size: {PageSize}, SearchTerm: {SearchTerm}, ClientType: {ClientType}, UserId: {UserId}",
            pageNumber, pageSize, searchTerm, clientType, UserId);

        try
        {
            Expression<Func<Client, bool>> filter = x => true;

            filter = filter.AndAlso(c => c.UserId == int.Parse(UserId));

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filter = filter.AndAlso(c =>
                    c.FullName.Contains(searchTerm) ||
                    c.Email.Contains(searchTerm) ||
                    c.PhoneNumber.Contains(searchTerm));
            }

            if (clientType is not null)
                filter = filter.AndAlso(c => c.ClientType == clientType);

            var pagedResult = await GetPagedDataWithSelectionAsync(
                orderBy: x => x.FullName,
                selector: ClientProfile.ToGetClientDto(),
                criteria: filter,
                pageNumber: pageNumber,
                pageSize: pageSize);

            _logger.LogInformation("Fetched {Count} clients for UserId: {UserId}", pagedResult.Items.Count, UserId);

            return pagedResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching clients for UserId: {UserId}", UserId);
            throw;
        }
    }

    public async Task<BaseResponse<string>> AddClientAsync(string UserId, AddClientDto clientDto)
    {
        _logger.LogInformation("Adding a new client: {FullName} for UserId: {UserId}", clientDto.FullName, UserId);

        try
        {
            var propertiesToCheck = new Dictionary<string, object?>
            {
                { nameof(Client.PhoneNumber), clientDto.PhoneNumber },
                { nameof(Client.Email), clientDto.Email }
            };

            var duplicateCheck = await CheckDuplicatePropertiesAsync(propertiesToCheck);

            if (!duplicateCheck.Success)
            {
                _logger.LogWarning("Duplicate client detected: {Errors}", string.Join(", ", duplicateCheck.Errors ?? new List<string>()));
                return duplicateCheck;
            }

            var clientType = clientDto.ClientType.ToEnum<ClientType>();
            if (clientType == null)
            {
                _logger.LogWarning("Invalid ClientType provided: {ClientType}", clientDto.ClientType);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "نوع العميل غير صالح"
                };
            }

            var newClient = clientDto.ToClient();
            newClient.ClientType = clientType.Value;
            newClient.UserId = int.Parse(UserId);

            await AddAsync(newClient);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Client added successfully: {FullName}", clientDto.FullName);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم إضافة العميل بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding client: {FullName}", clientDto.FullName);
            throw;
        }
    }

    public async Task<BaseResponse<string>> UpdateClientAsync(UpdateClientDto clientDto)
    {
        _logger.LogInformation("Updating client with ID: {Id}", clientDto.Id);

        try
        {
            var client = await GetByIdAsync(clientDto.Id);
            if (client is null)
            {
                _logger.LogWarning("Client with ID: {Id} not found", clientDto.Id);
                return new BaseResponse<string> { Success = false, Message = "العميل غير موجود" };
            }

            var properties = new Dictionary<string, object?>
            {
                { nameof(Client.PhoneNumber), clientDto.PhoneNumber },
                { nameof(Client.Email), clientDto.Email }
            };

            var duplicateCheck = await CheckDuplicatePropertiesAsync(properties, clientDto.Id);

            if (!duplicateCheck.Success)
            {
                _logger.LogWarning("Duplicate client detected during update: {Errors}", string.Join(", ", duplicateCheck.Errors ?? new List<string>()));
                return duplicateCheck;
            }

            var clientType = clientDto.ClientType.ToEnum<ClientType>();
            if (clientType == null)
            {
                _logger.LogWarning("Invalid ClientType provided: {ClientType}", clientDto.ClientType);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "نوع العميل غير صالح"
                };
            }
            client.ClientType = clientType.Value;
            client.UpdateClient(clientDto);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Client updated successfully: {Id}", clientDto.Id);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث العميل بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating client with ID: {Id}", clientDto.Id);
            throw;
        }
    }

    public async Task<BaseResponse<string>> DeleteClientAsync(int id)
    {
        _logger.LogInformation("Deleting client with ID: {Id}", id);

        try
        {
            var client = await GetByIdAsync(id);
            if (client is null)
            {
                _logger.LogWarning("Client with ID: {Id} not found", id);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العميل غير موجود"
                };
            }

            Delete(client);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Client deleted successfully: {Id}", id);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف العميل بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting client with ID: {Id}", id);
            throw;
        }
    }

    public async Task<List<ClientNameDto>> GetClientsNames(string UserId)
    {
        _logger.LogInformation("Fetching client names for UserId: {UserId}", UserId);

        try
        {
            var pagedResult = await GetAllDataWithSelectionAsync(
                orderBy: x => x.FullName,
                criteria: x => x.UserId == int.Parse(UserId),
                selector: ClientProfile.ToGetClientNameDto());

            _logger.LogInformation("Fetched {Count} client names for UserId: {UserId}", pagedResult.Count, UserId);

            return pagedResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching client names for UserId: {UserId}", UserId);
            throw;
        }
    }
}
