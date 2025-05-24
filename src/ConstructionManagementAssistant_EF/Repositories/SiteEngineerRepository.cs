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
            _logger.LogInformation("Fetching site engineer with ID: {Id}", id);

            try
            {
                var siteEngineer = await FindWithSelectionAsync(
                    selector: SiteEngineerProfile.ToSiteEngineerDetailsDto(),
                    criteria: x => x.Id == id);
                if (siteEngineer == null)
                {
                    _logger.LogWarning("Site engineer with ID: {Id} not found", id);
                    return null;
                }

                _logger.LogInformation("Site engineer with ID: {Id} fetched successfully", id);
                return siteEngineer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching site engineer with ID: {Id}", id);
                throw;
            }
        }

        public async Task<PagedResult<GetSiteEngineerDto>> GetAllSiteEngineers(
            string userId,
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,
            bool? isAvailable = null)
        {
            _logger.LogInformation("Fetching all site engineers for userId: {UserId}, page: {PageNumber}, size: {PageSize}, search: {SearchTerm}", userId, pageNumber, pageSize, searchTerm);

            try
            {
                Expression<Func<SiteEngineer, bool>> filter = x => true;
                filter = filter.AndAlso(x => x.UserId == int.Parse(userId));

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

                var pagedResult = await GetPagedDataWithSelectionAsync(
                    orderBy: x => x.FirstName,
                    selector: SiteEngineerProfile.ToGetSiteEngineerDto(),
                    criteria: filter,
                    pageNumber: pageNumber,
                    pageSize: pageSize);

                _logger.LogInformation("Fetched {Count} site engineers for userId: {UserId}", pagedResult.Items.Count, userId);

                return pagedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching site engineers for userId: {UserId}", userId);
                throw;
            }
        }

        public async Task<List<SiteEngineerNameDto>> GetSiteEngineersNames(string userId)
        {
            _logger.LogInformation("Fetching site engineer names for userId: {UserId}", userId);

            try
            {
                var result = await GetAllDataWithSelectionAsync(
                    orderBy: x => x.FirstName,
                    criteria: x => x.UserId == int.Parse(userId),
                    selector: SiteEngineerProfile.ToGetSiteEngineerNameDto());

                _logger.LogInformation("Fetched {Count} site engineer names for userId: {UserId}", result.Count, userId);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching site engineer names for userId: {UserId}", userId);
                throw;
            }
        }

        public async Task<BaseResponse<string>> AddSiteEngineerAsync(string userId, AddSiteEngineerDto siteEngineerDto)
        {
            _logger.LogInformation("Adding a new site engineer: {EngineerName} for userId: {UserId}", siteEngineerDto.FirstName, userId);

            try
            {
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
                newSiteEngineer.UserId = int.Parse(userId);
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
            _logger.LogInformation("Updating site engineer with ID: {Id}", siteEngineerDto.Id);

            try
            {
                var siteEngineer = await GetByIdAsync(siteEngineerDto.Id);

                if (siteEngineer is null)
                {
                    _logger.LogWarning("Site engineer with ID: {Id} not found for update", siteEngineerDto.Id);
                    return new BaseResponse<string> { Message = "المهندس غير موجود", Success = false };
                }

                var propertiesToCheck = new Dictionary<string, object?>
                {
                    { nameof(SiteEngineer.PhoneNumber), siteEngineerDto.PhoneNumber },
                    { nameof(SiteEngineer.Email), siteEngineerDto.Email },
                    { nameof(SiteEngineer.NationalNumber), siteEngineerDto.NationalNumber },
                };

                var duplicateCheck = await CheckDuplicatePropertiesAsync(propertiesToCheck, siteEngineerDto.Id);

                if (!duplicateCheck.Success)
                {
                    _logger.LogWarning("Duplicate site engineer properties detected during update: {EngineerName}", siteEngineerDto.FirstName);
                    return duplicateCheck;
                }

                siteEngineer.UpdateSiteEngineer(siteEngineerDto);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Site engineer with ID: {Id} updated successfully", siteEngineerDto.Id);

                return new BaseResponse<string> { Message = "تم تحديث المهندس بنجاح", Success = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating site engineer with ID: {Id}", siteEngineerDto.Id);
                return new BaseResponse<string>
                {
                    Message = "حدث خطأ أثناء تحديث المهندس",
                    Success = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id)
        {
            _logger.LogInformation("Deleting site engineer with ID: {Id}", id);

            try
            {
                var siteEngineer = await GetByIdAsync(id);

                if (siteEngineer is null)
                {
                    _logger.LogWarning("Site engineer with ID: {Id} not found for delete", id);
                    return new BaseResponse<string> { Message = "المهندس غير موجود", Success = false };
                }

                Delete(siteEngineer);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Site engineer with ID: {Id} deleted successfully", id);

                return new BaseResponse<string> { Message = "تم حذف المهندس بنجاح", Success = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting site engineer with ID: {Id}", id);
                return new BaseResponse<string>
                {
                    Message = "حدث خطأ أثناء حذف المهندس",
                    Success = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
