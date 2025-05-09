namespace ConstructionManagementAssistant.EF.Repositories;

public class ClientRepository(AppDbContext _context, ILogger<ClientRepository> _logger)
    : BaseRepository<Client>(_context), IClientRepository
{

    public async Task<GetClientDto> GetClientById(int id)
    {
        _logger.LogInformation("Fetching client with ID: {Id}", id);

        var client = await FindWithSelectionAsync(
            selector: ClientProfile.ToGetClientDto(),
            criteria: x => x.Id == id);

        if (client == null)
        {
            _logger.LogWarning("Client with ID: {Id} not found", id);
        }

        return client;
    }

    public async Task<PagedResult<GetClientDto>> GetAllClients(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null,
        ClientType? clientType = null)
    {
        _logger.LogInformation("Fetching all clients with filters - Page: {PageNumber}, Size: {PageSize}, SearchTerm: {SearchTerm}, ClientType: {ClientType}",
            pageNumber, pageSize, searchTerm, clientType);

        Expression<Func<Client, bool>> filter = x => true;

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

        _logger.LogInformation("Fetched {Count} clients", pagedResult.Items.Count);

        return pagedResult;
    }

    public async Task<BaseResponse<string>> AddClientAsync(AddClientDto clientDto)
    {
        _logger.LogInformation("Adding a new client: {FullName}", clientDto.FullName);

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

        var newClient = clientDto.ToClient();
        await AddAsync(newClient);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Client added successfully: {FullName}", clientDto.FullName);

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم إضافة العميل بنجاح"
        };
    }

    public async Task<BaseResponse<string>> UpdateClientAsync(UpdateClientDto clientDto)
    {
        _logger.LogInformation("Updating client with ID: {Id}", clientDto.Id);

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

        client.UpdateClient(clientDto);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Client updated successfully: {Id}", clientDto.Id);

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث العميل بنجاح"
        };
    }

    public async Task<BaseResponse<string>> DeleteClientAsync(int id)
    {
        _logger.LogInformation("Deleting client with ID: {Id}", id);

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
}
