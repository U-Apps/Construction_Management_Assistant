using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Models.Response;
using RepositoryWithUWO.EF.Repositories;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class SiteEngineerRepository(AppDbContext context) : BaseRepository<SiteEngineer>(context), ISiteEngineerRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<PagedResult<GetSiteEngineerDto>> GetAllSiteEngineers(int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.SiteEngineers
                  .Select(c => new GetSiteEngineerDto
                  {
                      Id = c.Id,
                      FullName = $"{c.FirstName} {c.SecondName} {c.ThirdName} {c.LastName}",
                      IsAvailable = c.IsAvailable,
                  });

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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
            .Select(c => new GetSiteEngineerDto
            {
                Id = c.Id,
                FullName = c.GetFullName(),
                IsAvailable = c.IsAvailable,

            }).FirstOrDefaultAsync();
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


            var newSiteEngineer = new SiteEngineer
            {
                FirstName = siteEngineerDto.FirstName,
                SecondName = siteEngineerDto.SecondName,
                ThirdName = siteEngineerDto.ThirdName,
                LastName = siteEngineerDto.LastName,
                Email = siteEngineerDto.Email,
                PhoneNumber = siteEngineerDto.PhoneNumber,
                NationalNumber = siteEngineerDto.NationalNumber,
                Address = siteEngineerDto.Address,
                HireDate = siteEngineerDto.HireDate
            };
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

            siteEngineer.FirstName = siteEngineerDto.FirstName;
            siteEngineer.SecondName = siteEngineerDto.SecondName;
            siteEngineer.ThirdName = siteEngineerDto.ThirdName;
            siteEngineer.LastName = siteEngineerDto.LastName;
            siteEngineer.Email = siteEngineerDto.Email;
            siteEngineer.PhoneNumber = siteEngineerDto.PhoneNumber;
            siteEngineer.NationalNumber = siteEngineerDto.NationalNumber;
            siteEngineer.Address = siteEngineerDto.Address;
            siteEngineer.HireDate = siteEngineerDto.HireDate;
            siteEngineer.ModifiedDate = DateTime.Now;

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
