using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Extentions;
using ConstructionManagementAssistant_Core.Interfaces;
using ConstructionManagementAssistant_Core.Models.Response;
using ConstructionManagementAssistant_EF.Data;
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

        public async Task<GetClientDto> GetClientById(int id)
        {
            var query = _appDbContext.clients.Where(x => x.Id == id)
          .Select(c => new GetClientDto
          {
              Id = c.Id,
              FullName = c.FullName,
              Email = c.Email,
              PhoneNumber = c.PhoneNumber,
              ClientType = c.ClientType.GetDisplayName(),
          });
            return await query.FirstOrDefaultAsync();
        }

        public async Task<PagedResult<GetClientDto>> GetAllClients(int pageNumber = 1, int pageSize = 10)
        {
            var query = _appDbContext.clients
                .Select(c => new GetClientDto
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    ClientType = c.ClientType.GetDisplayName(),
                });

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

        public async Task<BaseResponse<string>> AddClientAsync(AddClientDto clientDto)
        {
            try
            {
                var emailExists = await _appDbContext.clients.AnyAsync(c => c.Email == clientDto.Email);
                if (emailExists)
                {
                    return new BaseResponse<string>(null, "البريد الإلكتروني موجود بالفعل", null, false);
                }

                var phoneExists = await _appDbContext.clients.AnyAsync(c => c.PhoneNumber == clientDto.PhoneNumber);
                if (phoneExists)
                {
                    return new BaseResponse<string>(null, "رقم الهاتف موجود بالفعل", null, false);
                }

                var newClient = new Client
                {
                    FullName = clientDto.FullName,
                    Email = clientDto.Email,
                    PhoneNumber = clientDto.PhoneNumber,
                    ClientType = clientDto.ClientType
                };
                await _appDbContext.AddAsync(newClient);
                await _appDbContext.SaveChangesAsync();

                return new BaseResponse<string>(null, "تم إضافة العميل بنجاح");
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(null, "لم تتم إضافة العميل ", new List<string> { ex.Message }, false);
            }
        }

        public async Task<BaseResponse<string>> UpdateClientAsync(UpdateClientDto clientDto)
        {
            var client = _appDbContext.clients.Where(x => x.Id == clientDto.Id).FirstOrDefault();
            if (client is null)
                return new BaseResponse<string>(null, "العميل غير موجود", null, false);


            var emailExists = await _appDbContext.clients.AnyAsync(c => c.Email == clientDto.Email);
            if (emailExists && clientDto.Email != client.Email)
            {
                return new BaseResponse<string>(null, "البريد الإلكتروني موجود بالفعل", null, false);
            }

            var phoneExists = await _appDbContext.clients.AnyAsync(c => c.PhoneNumber == clientDto.PhoneNumber);
            if (phoneExists && clientDto.Email != client.Email)
            {
                return new BaseResponse<string>(null, "رقم الهاتف موجود بالفعل", null, false);
            }

            try
            {
                client.FullName = clientDto.FullName;
                client.Email = clientDto.Email;
                client.PhoneNumber = clientDto.PhoneNumber;
                client.ModifiedDate = DateTime.Now;

                _appDbContext.Update(client);
                await _appDbContext.SaveChangesAsync();

                return new BaseResponse<string>(null, "تم تحديث العميل بنجاح");
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(null, "لم تتم عميلة التعديل", [ex.Message], false);
            }

        }

        public async Task<BaseResponse<string>> DeleteClientAsync(int id)
        {
            var client = _appDbContext.clients.Where(x => x.Id == id).FirstOrDefault();
            if (client is null)
                return new BaseResponse<string>(null, "العميل غير موجود", null, false);

            client.IsDeleted = true;
            await _appDbContext.SaveChangesAsync();
            return new BaseResponse<string>(null, "تم حذف العميل بنجاح");
        }

    }
}
