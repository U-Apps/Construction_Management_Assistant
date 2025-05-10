namespace ConstructionManagementAssistant.EF.Repositories
{
    public class SiteEngineerRepository : BaseRepository<SiteEngineer>, ISiteEngineerRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SiteEngineerRepository> _logger;

        public SiteEngineerRepository(AppDbContext context, ILogger<SiteEngineerRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<SiteEngineerDetailsDto?> GetSiteEngineerById(int id)
        {
            var siteEngineer = await FindWithSelectionAsync(
                selector: SiteEngineerProfile.ToSiteEngineerDetailsDto(),
                criteria: x => x.Id == id);
            if (siteEngineer == null)
            {
                _logger.LogWarning("siteEngineer with ID: {Id} not found", id);
                return null;

            }

            return siteEngineer;

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
            try
            {
                _logger.LogInformation("Adding a new site engineer: {EngineerName}", siteEngineerDto.FirstName);
                var propertiesToCheck = new Dictionary<string, object?>
                {
                    { nameof(SiteEngineer.PhoneNumber), siteEngineerDto.PhoneNumber },
                    { nameof(SiteEngineer.Email), siteEngineerDto.Email },
                    { nameof(SiteEngineer.NationalNumber), siteEngineerDto.NationalNumber },
                };

                var duplicateCheck = await CheckDuplicatePropertiesAsync(propertiesToCheck);

                if (!duplicateCheck.Success)
                {
                    _logger.LogWarning("Duplicate site engineer properties detected: {EngineerName}", siteEngineerDto.FirstName);
                    return duplicateCheck;
                }

                var newSiteEngineer = siteEngineerDto.ToSiteEngineer();
                await AddAsync(newSiteEngineer);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Site engineer added successfully: {EngineerName}", siteEngineerDto.FirstName);
                return new BaseResponse<string>
                {
                    Message = "تم إضافة المهندس بنجاح",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a site engineer: {EngineerName}", siteEngineerDto.FirstName);
                return new BaseResponse<string>
                {
                    Message = "حدث خطأ أثناء إضافة المهندس",
                    Success = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<BaseResponse<string>> UpdateSiteEngineerAsync(UpdateSiteEngineerDto siteEngineerDto)
        {
            var siteEngineer = await GetByIdAsync(siteEngineerDto.Id);

            if (siteEngineer is null)
                return new BaseResponse<string> { Message = "المهندس غير موجود", Success = false };


            var propertiesToCheck = new Dictionary<string, object?>
            {
                { nameof(SiteEngineer.PhoneNumber), siteEngineerDto.PhoneNumber },
                { nameof(SiteEngineer.Email), siteEngineerDto.Email },
                { nameof(SiteEngineer.NationalNumber), siteEngineerDto.NationalNumber },
            };

            var duplicateCheck = await CheckDuplicatePropertiesAsync(propertiesToCheck, siteEngineerDto.Id);

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
