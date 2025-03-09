namespace ConstructionManagementAssistant_EF.Repositories;

public class ClientRepository(AppDbContext _context) : BaseRepository<Client>(_context), IClientRepository
{
    public async Task<GetClientDto> GetClientById(int id)
    {
        return await FindWithSelectionAsync(
            selector: ClientProfile.ToGetClientDto(),
            criteria: x => x.Id == id);
    }

    public async Task<PagedResult<GetClientDto>> GetAllClients(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null,
        ClientType? clientType = null)
    {
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

        return pagedResult;
    }

    public async Task<BaseResponse<string>> AddClientAsync(AddClientDto clientDto)
    {
        var propertiesToCheck = new Dictionary<string, object?>
        {
            { nameof(Client.PhoneNumber), clientDto.PhoneNumber },
            { nameof(Client.Email), clientDto.Email }
        };

        var duplicateCheck = await CheckDuplicatePropertiesAsync(propertiesToCheck);

        if (!duplicateCheck.Success)
            return duplicateCheck;

        var newClient = clientDto.ToClient();
        await AddAsync(newClient);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم إضافة العميل بنجاح"
        };
    }

    public async Task<BaseResponse<string>> UpdateClientAsync(UpdateClientDto clientDto)
    {
        var client = await GetByIdAsync(clientDto.Id);
        if (client is null)
            return new BaseResponse<string> { Success = false, Message = "العميل غير موجود" };


        var properties = new Dictionary<string, object?>
        {
            { nameof(Client.PhoneNumber), clientDto.PhoneNumber },
            { nameof(Client.Email), clientDto.Email }
        };

        var duplicateCheck = await CheckDuplicatePropertiesAsync(properties, clientDto.Id);

        if (!duplicateCheck.Success)
            return duplicateCheck;

        client.UpdateClient(clientDto);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث العميل بنجاح"
        };
    }


    public async Task<BaseResponse<string>> DeleteClientAsync(int id)
    {
        var client = await GetByIdAsync(id);
        if (client is null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "العميل غير موجود"
            };
        }

        Delete(client);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم حذف العميل بنجاح"
        };
    }


    private async Task<BaseResponse<string>> CheckDuplicatePhoneEmailForClientAsync(
    string? phoneNumber,
    string? email,
    int? id = null)
    {
        if (phoneNumber != null && await _context.Clients.IgnoreQueryFilters().AnyAsync(g => g.PhoneNumber == phoneNumber && (!id.HasValue || g.Id != id.Value)))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "A client with the same phone number already exists.",
            };
        }

        if (email != null && await _context.Clients.IgnoreQueryFilters().AnyAsync(g => g.Email == email && (!id.HasValue || g.Id != id.Value)))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "A client with the same email already exists.",
            };
        }

        return new BaseResponse<string> { Success = true };
    }

}