using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Mapping;
using ConstructionManagementAssistant_Core.Models.Response;
using RepositoryWithUWO.EF.Repositories;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class SiteEngineerRepository(AppDbContext context) : BaseRepository<SiteEngineer>(context), ISiteEngineerRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<PagedResult<GetSiteEngineerDto>> GetAllSiteEngineers(int pageNumber = 1, int pageSize = 10, string? searchTerm = null, bool? isAvailable = null)
        {
            var query = _context.SiteEngineers.AsNoTracking();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(se => se.FirstName.Contains(searchTerm)
                || se.SecondName.Contains(searchTerm)
                || se.ThirdName.Contains(searchTerm)
                || se.LastName.Contains(searchTerm)
                || se.Email.Contains(searchTerm)
                || se.PhoneNumber.Contains(searchTerm)
                || se.Address.Contains(searchTerm));


            if (isAvailable.HasValue)
                query = query.Where(se => se.IsAvailable == isAvailable.Value);


            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var items = await query
                .OrderBy(c => c.FirstName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => c.ToGetSiteEngineerDto())
                .ToListAsync();

            return new PagedResult<GetSiteEngineerDto>
            {
                Items = items,
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<GetSiteEngineerDto> GetSiteEngineerById(int id)
        {
            var query = await _context.SiteEngineers.Where(x => x.Id == id)
            .Select(c => c.ToGetSiteEngineerDto()).SingleOrDefaultAsync();
            return query;
        }


        public async Task<BaseResponse<string>> AddSiteEngineerAsync(AddSiteEngineerDto siteEngineerDto)
        {
            if (await _context.SiteEngineers.AnyAsync(c => c.Email == siteEngineerDto.Email))
                return new BaseResponse<string>
                {
                    Message = "البريد الإلكتروني موجود بالفعل",
                    Success = false
                };

            if (await _context.SiteEngineers.AnyAsync(c => c.PhoneNumber == siteEngineerDto.PhoneNumber))
                return new BaseResponse<string>
                {
                    Message = "رقم الهاتف موجود بالفعل",
                    Success = false
                };

            if (await _context.SiteEngineers.AnyAsync(c => c.NationalNumber == siteEngineerDto.NationalNumber))
                return new BaseResponse<string>
                {
                    Message = "رقم الهوية موجود بالفعل",
                    Success = false
                };


            var newSiteEngineer = siteEngineerDto.ToSiteEngineer();
            await _context.AddAsync(newSiteEngineer);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Message = "تم إضافة المهندس بنجاح",
                Success = true
            };
        }


        public async Task<BaseResponse<string>> UpdateSiteEngineerAsync(UpdateSiteEngineerDto siteEngineerDto)
        {
            var siteEngineer = _context.SiteEngineers.Where(x => x.Id == siteEngineerDto.Id).FirstOrDefault();
            if (siteEngineer is null)
                return new BaseResponse<string>
                {
                    Message = "المهندس غير موجود",
                    Success = false
                };

            if (await _context.SiteEngineers.AnyAsync(c => c.Email == siteEngineerDto.Email && c.Id != siteEngineerDto.Id))
            {
                return new BaseResponse<string>
                {
                    Message = "البريد الإلكتروني موجود بالفعل",
                    Success = false
                };
            }

            if (await _context.SiteEngineers.AnyAsync(c => c.PhoneNumber == siteEngineerDto.PhoneNumber && c.Id != siteEngineerDto.Id))
            {
                return new BaseResponse<string>
                {
                    Message = "رقم الهاتف موجود بالفعل",
                    Success = false
                };
            }

            if (await _context.SiteEngineers.AnyAsync(c => c.NationalNumber == siteEngineerDto.NationalNumber && c.Id != siteEngineerDto.Id))
            {
                return new BaseResponse<string>
                {
                    Message = "رقم الهوية موجود بالفعل",
                    Success = false
                };
            }

            siteEngineer = siteEngineerDto.ToSiteEngineer();

            _context.Update(siteEngineer);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Message = "تم تحديث المهندس بنجاح",
                Success = true
            };
        }


        public async Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id)
        {
            var siteEngineer = _context.SiteEngineers.Where(x => x.Id == id).FirstOrDefault();
            if (siteEngineer is null)
                return new BaseResponse<string>
                {
                    Message = "المهندس غير موجود",
                    Success = false
                };

            siteEngineer.IsDeleted = true;
            await _context.SaveChangesAsync();
            return new BaseResponse<string>
            {
                Message = "تم حذف المهندس بنجاح",
                Success = true
            };
        }

    }
}
