using ConstructionManagementAssistant_Core.Enums;
using ConstructionManagementAssistant_Core.Mapping;
using ConstructionManagementAssistant_EF.Extensions;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetClientDto> GetClientById(int id)
        {
            return await FindWithSelectionAsync(
                selector: ClientProfile.ToGetClientDto(),
                criteria: x => x.Id == id);
        }

        public async Task<PagedResult<GetClientDto>> GetAllClients(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,,
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
            var duplicateCheck = await CheckDuplicatePhoneEmailForClientAsync(
                phoneNumber: clientDto.PhoneNumber,
                email: clientDto.Email);

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
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العميل غير موجود"
                };

            var duplicateCheck = await CheckDuplicatePhoneEmailForClientAsync(
                phoneNumber: clientDto.PhoneNumber,
                email: clientDto.Email,
                id: clientDto.Id);

            if (!duplicateCheck.Success)
            {
                return duplicateCheck;
            }

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
    }
}

