using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Interfaces;
using ConstructionManagementAssistant_Core.Models.Response;
using ConstructionManagementAssistant_EF.Data;
using RepositoryWithUWO.EF.Repositories;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class SiteEngineerRepository(AppDbContext context) : BaseRepository<SiteEngineer>(context), ISiteEngineerRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<BaseResponse<string>> AddSiteEngineerAsync(AddSiteEngineerDto siteEngineerDto)
        {
            try
            {
                var emailExists = await _context.SiteEngineers.AnyAsync(c => c.Email == siteEngineerDto.Email);
                if (emailExists)
                {
                    return new BaseResponse<string>(null, "البريد الإلكتروني موجود بالفعل", null, false);
                }

                var phoneExists = await _context.SiteEngineers.AnyAsync(c => c.PhoneNumber == siteEngineerDto.PhoneNumber);
                if (phoneExists)
                {
                    return new BaseResponse<string>(null, "رقم الهاتف موجود بالفعل", null, false);
                }
                var nationalNumberExists = await _context.SiteEngineers.AnyAsync(c => c.NationalNumber == siteEngineerDto.NationalNumber);
                if (nationalNumberExists)
                {
                    return new BaseResponse<string>(null, "رقم الهوية موجود بالفعل", null, false);
                }

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

                return new BaseResponse<string>(null, "تم إضافة المهندس بنجاح");
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(null, "لم تتم إضافة المهندس ", new List<string> { ex.Message }, false);
            }
        }

        public async Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id)
        {
            var siteEngineer = _context.SiteEngineers.Where(x => x.Id == id).FirstOrDefault();
            if (siteEngineer is null)
                return new BaseResponse<string>(null, "المهندس غير موجود", null, false);

            siteEngineer.IsDeleted = true;
            await _context.SaveChangesAsync();
            return new BaseResponse<string>(null, "تم حذف المهندس بنجاح");
        }
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
            var query = _context.SiteEngineers.Where(x => x.Id == id)
        .Select(c => new GetSiteEngineerDto
        {
            Id = c.Id,
            FullName = $"{c.FirstName} {c.SecondName} {c.ThirdName} {c.LastName}",
            IsAvailable = c.IsAvailable,

        });
            return await query.FirstOrDefaultAsync();
        }

        public async Task<BaseResponse<string>> UpdateSiteEngineerAsync(UpdateSiteEngineerDto siteEngineerDto)
        {
            var siteEngineer = _context.SiteEngineers.Where(x => x.Id == siteEngineerDto.Id).FirstOrDefault();
            if (siteEngineer is null)
                return new BaseResponse<string>(null, "المهندس غير موجود", null, false);


            var emailExists = await _context.SiteEngineers.AnyAsync(c => c.Email == siteEngineerDto.Email);
            if (emailExists && siteEngineerDto.Email != siteEngineer.Email)
            {
                return new BaseResponse<string>(null, "البريد الإلكتروني موجود بالفعل", null, false);
            }

            var phoneExists = await _context.SiteEngineers.AnyAsync(c => c.PhoneNumber == siteEngineerDto.PhoneNumber);
            if (phoneExists && siteEngineerDto.PhoneNumber != siteEngineer.PhoneNumber)
            {
                return new BaseResponse<string>(null, "رقم الهاتف موجود بالفعل", null, false);
            }

            var nationalNumberExists = await _context.SiteEngineers.AnyAsync(c => c.NationalNumber == siteEngineerDto.NationalNumber);
            if (nationalNumberExists && siteEngineerDto.NationalNumber != siteEngineer.NationalNumber)
            {
                return new BaseResponse<string>(null, "رقم الهوية موجود بالفعل", null, false);
            }

            try
            {
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

                return new BaseResponse<string>(null, "تم تحديث المهندس بنجاح");
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>(null, "لم تتم عميلة التعديل", [ex.Message], false);
            }

        }
    }
}
