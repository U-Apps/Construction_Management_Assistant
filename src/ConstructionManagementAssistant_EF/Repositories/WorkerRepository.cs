namespace ConstructionManagementAssistant.EF.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        private readonly ILogger<WorkerRepository> _logger;
        private readonly AppDbContext _context;

        public WorkerRepository(AppDbContext context, ILogger<WorkerRepository> logger) : base(context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<PagedResult<GetWorkerDto>> GetAllWorkers(
            string userId,
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,
            bool? isAvailable = null)
        {
            _logger.LogInformation("Fetching workers for userId: {UserId}, page: {PageNumber}, size: {PageSize}, search: {SearchTerm}", userId, pageNumber, pageSize, searchTerm);

            try
            {
                Expression<Func<Worker, bool>> filter = x => true;
                filter = filter.AndAlso(x => x.UserId == int.Parse(userId));

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filter = filter.AndAlso(w =>
                        w.FirstName.Contains(searchTerm) ||
                        w.SecondName.Contains(searchTerm) ||
                        w.ThirdName.Contains(searchTerm) ||
                        w.LastName.Contains(searchTerm) ||
                        w.Email.Contains(searchTerm) ||
                        w.PhoneNumber.Contains(searchTerm) ||
                        w.Address.Contains(searchTerm));
                }

                var pagedResult = await GetPagedDataWithSelectionAsync(
                    orderBy: x => x.FirstName,
                    selector: WorkerProfile.ToGetWorkerDto(),
                    criteria: filter,
                    pageNumber: pageNumber,
                    pageSize: pageSize);

                _logger.LogInformation("Fetched {Count} workers for userId: {UserId}", pagedResult.Items.Count, userId);

                return pagedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching workers for userId: {UserId}", userId);
                throw;
            }
        }

        public async Task<List<WorkerNameDto>> GetWorkersNames(string userId)
        {
            _logger.LogInformation("Fetching worker names for userId: {UserId}", userId);

            try
            {
                var result = await GetAllDataWithSelectionAsync(
                    orderBy: x => x.FirstName,
                    criteria: x => x.UserId == int.Parse(userId),
                    selector: WorkerProfile.ToGetWorkerNameDto());

                _logger.LogInformation("Fetched {Count} worker names for userId: {UserId}", result.Count, userId);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching worker names for userId: {UserId}", userId);
                throw;
            }
        }

        public async Task<WorkerDetailsDto?> GetWorkerById(int id)
        {
            _logger.LogInformation("Fetching worker with ID: {Id}", id);

            try
            {
                var worker = await FindWithSelectionAsync(
                    selector: WorkerProfile.ToWorkerDetailsDto(),
                    criteria: x => x.Id == id);
                if (worker == null)
                {
                    _logger.LogWarning("Worker with ID: {Id} not found", id);
                    return null;
                }

                _logger.LogInformation("Worker with ID: {Id} fetched successfully", id);
                return worker;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching worker with ID: {Id}", id);
                throw;
            }
        }

        public async Task<BaseResponse<string>> AddWorkerAsync(string userId, AddWorkerDto workerDto)
        {
            _logger.LogInformation("Adding a new worker: {WorkerName} for userId: {UserId}", workerDto.FirstName, userId);

            try
            {
                var propertiesToCheck = new Dictionary<string, object?>
                {
                    { nameof(Worker.PhoneNumber), workerDto.PhoneNumber },
                    { nameof(Worker.Email), workerDto.Email },
                    { nameof(Worker.NationalNumber), workerDto.NationalNumber },
                };

                var duplicateCheck = await CheckDuplicatePropertiesAsync(propertiesToCheck);

                if (!duplicateCheck.Success)
                {
                    _logger.LogWarning("Duplicate worker properties detected: {WorkerName}", workerDto.FirstName);
                    return duplicateCheck;
                }

                var newWorker = workerDto.ToWorker();
                newWorker.UserId = int.Parse(userId);
                await AddAsync(newWorker);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Worker added successfully: {WorkerName}", workerDto.FirstName);
                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "تم إضافة العامل بنجاح"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a worker: {WorkerName}", workerDto.FirstName);
                throw;
            }
        }

        public async Task<BaseResponse<string>> UpdateWorkerAsync(UpdateWorkerDto workerDto)
        {
            _logger.LogInformation("Updating worker with ID: {Id}", workerDto.Id);

            try
            {
                var worker = await GetByIdAsync(workerDto.Id);

                if (worker is null)
                {
                    _logger.LogWarning("Worker with ID: {Id} not found for update", workerDto.Id);
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "العامل غير موجود"
                    };
                }

                var propertiesToCheck = new Dictionary<string, object?>
                {
                    { nameof(Worker.PhoneNumber), workerDto.PhoneNumber },
                    { nameof(Worker.Email), workerDto.Email },
                    { nameof(Worker.NationalNumber), workerDto.NationalNumber },
                };

                var duplicateCheck = await CheckDuplicatePropertiesAsync(propertiesToCheck, workerDto.Id);

                if (!duplicateCheck.Success)
                {
                    _logger.LogWarning("Duplicate worker properties detected during update: {WorkerName}", workerDto.FirstName);
                    return duplicateCheck;
                }

                workerDto.UpdateWorker(worker);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Worker with ID: {Id} updated successfully", workerDto.Id);

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "تم تحديث العامل بنجاح"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating worker with ID: {Id}", workerDto.Id);
                throw;
            }
        }

        public async Task<BaseResponse<string>> DeleteWorkerAsync(int id)
        {
            _logger.LogInformation("Deleting worker with ID: {Id}", id);

            try
            {
                var worker = await GetByIdAsync(id);
                if (worker is null)
                {
                    _logger.LogWarning("Worker with ID: {Id} not found for delete", id);
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "العامل غير موجود"
                    };
                }

                Delete(worker);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Worker with ID: {Id} deleted successfully", id);

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "تم حذف العامل بنجاح"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting worker with ID: {Id}", id);
                throw;
            }
        }
    }
}
