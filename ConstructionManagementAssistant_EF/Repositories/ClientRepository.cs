using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Mapping;
using ConstructionManagementAssistant_Core.Models.Response;
using RepositoryWithUWO.EF.Repositories;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PagedResult<GetClientDto>> GetAllClients(int pageNumber = 1, int pageSize = 10)
        {
            var query = _appDbContext.clients
                .Select(c => c.ToGetClientDto());

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<GetClientDto>
            {
                Items = items,
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<GetClientDto> GetClientById(int id)
        {
            var query = await _appDbContext.clients.Where(x => x.Id == id)
            .Select(c => c.ToGetClientDto()).SingleOrDefaultAsync();

            return query;
        }

        public async Task<BaseResponse<string>> AddClientAsync(AddClientDto clientDto)
        {

            if (await _appDbContext.clients.AnyAsync(c => c.Email == clientDto.Email))
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "البريد الإلكتروني موجود بالفعل",
                };
            }

            if (await _appDbContext.clients.AnyAsync(c => c.PhoneNumber == clientDto.PhoneNumber))
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "رقم الهاتف موجود بالفعل",
                };
            }

            var newClient = clientDto.ToClient();

            await _appDbContext.AddAsync(newClient);
            await _appDbContext.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Message = "تم إضافة العميل بنجاح",
                Success = true
            };
        }

        public async Task<BaseResponse<string>> UpdateClientAsync(UpdateClientDto clientDto)
        {
            var client = _appDbContext.clients.Where(x => x.Id == clientDto.Id).FirstOrDefault();
            if (client is null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العميل غير موجود"
                };

            if (await _appDbContext.clients.AnyAsync(c => c.Email == clientDto.Email && c.Id != clientDto.Id))
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "البريد الإلكتروني موجود بالفعل"
                };
            }

            if (await _appDbContext.clients.AnyAsync(c => c.PhoneNumber == clientDto.PhoneNumber && c.Id != clientDto.Id))
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "رقم الهاتف موجود بالفعل"
                };
            }

            client = clientDto.ToClient();

            _appDbContext.Update(client);
            await _appDbContext.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث العميل بنجاح"
            };

        }

        public async Task<BaseResponse<string>> DeleteClientAsync(int id)
        {
            var client = _appDbContext.clients.Where(x => x.Id == id).FirstOrDefault();
            if (client is null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العميل غير موجود"
                };

            client.IsDeleted = true;
            await _appDbContext.SaveChangesAsync();
            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف العميل بنجاح"
            };
        }

    }
}
