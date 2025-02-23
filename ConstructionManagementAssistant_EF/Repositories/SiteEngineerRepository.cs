using ConstructionManagementAssistant_Core.Mapping;
using ConstructionManagementAssistant_EF.Extensions;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class SiteEngineerRepository : BaseRepository<SiteEngineer>, ISiteEngineerRepository
    {
        private readonly AppDbContext _context;

        public SiteEngineerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetSiteEngineerDto> GetSiteEngineerById(int id)
        {
            return await FindWithSelectionAsync(
                selector: SiteEngineerProfile.ToGetSiteEngineerDto(),
                criteria: x => x.Id == id);
        }

        public async Task<PagedResult<GetSiteEngineerDto>> GetAllSiteEngineers(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,
            bool? isAvailable = null)
        {
            Expression<Func<SiteEngineer, bool>> filter = x => true;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filter = filter.AndAlso(se =>
                    se.FirstName.Contains(searchTerm) ||
                    se.SecondName.Contains(searchTerm) ||
                    se.ThirdName.Contains(searchTerm) ||
                    se.LastName.Contains(searchTerm) ||
                    se.Email.Contains(searchTerm) ||
                    se.PhoneNumber.Contains(searchTerm) ||
                    se.Address.Contains(searchTerm));
            }

            if (isAvailable.HasValue)
                filter = filter.AndAlso(se => se.IsAvailable == isAvailable.Value);

            return await GetPagedDataWithSelectionAsync(
                orderBy: x => x.FirstName,
                selector: SiteEngineerProfile.ToGetSiteEngineerDto(),
                criteria: filter,
                pageNumber: pageNumber,
                pageSize: pageSize);
        }

        public async Task<BaseResponse<string>> AddSiteEngineerAsync(AddSiteEngineerDto siteEngineerDto)
        {
            var duplicateCheck = await CheckDuplicatePhoneEmailNationalNumberAsync(
                phoneNumber: siteEngineerDto.PhoneNumber,
                email: siteEngineerDto.Email,
                nationalNumber: siteEngineerDto.NationalNumber);

            if (!duplicateCheck.Success)
                return duplicateCheck;

            var newSiteEngineer = siteEngineerDto.ToSiteEngineer();
            await AddAsync(newSiteEngineer);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Message = "تم إضافة المهندس بنجاح",
                Success = true
            };
        }

        public async Task<BaseResponse<string>> UpdateSiteEngineerAsync(UpdateSiteEngineerDto siteEngineerDto)
        {
            var siteEngineer = await GetByIdAsync(siteEngineerDto.Id);

            if (siteEngineer is null)
                return new BaseResponse<string> { Message = "المهندس غير موجود", Success = false };


            var duplicateCheck = await CheckDuplicatePhoneEmailNationalNumberAsync(
                phoneNumber: siteEngineerDto.PhoneNumber,
                email: siteEngineerDto.Email,
                nationalNumber: siteEngineerDto.NationalNumber,
                id: siteEngineerDto.Id);

            if (!duplicateCheck.Success)
                return duplicateCheck;

            siteEngineer.UpdateSiteEngineer(siteEngineerDto);
            await _context.SaveChangesAsync();

            return new BaseResponse<string> { Message = "تم تحديث المهندس بنجاح", Success = true };
        }

        public async Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id)
        {
            var siteEngineer = await GetByIdAsync(id);

            if (siteEngineer is null)
                return new BaseResponse<string> { Message = "المهندس غير موجود", Success = false };


            Delete(siteEngineer);
            await _context.SaveChangesAsync();

            return new BaseResponse<string> { Message = "تم حذف المهندس بنجاحالمهندس غير موجود", Success = true };
        }
    }
}
