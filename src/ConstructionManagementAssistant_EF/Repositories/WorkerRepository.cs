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
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,
            bool? isAvailable = null)
        {
            Expression<Func<Worker, bool>> filter = x => true;

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

            if (isAvailable.HasValue)
                filter = filter.AndAlso(w => w.IsAvailable == isAvailable.Value);


            var pagedResult = await GetPagedDataWithSelectionAsync(
                orderBy: x => x.FirstName,
                selector: WorkerProfile.ToGetWorkerDto(),
                criteria: filter,
                pageNumber: pageNumber,
                pageSize: pageSize);

            return pagedResult;
        }

        public async Task<WorkerDetailsDto?> GetWorkerById(int id)
        {
            var worker = await FindWithSelectionAsync(
                selector: WorkerProfile.ToWorkerDetailsDto(),
                criteria: x => x.Id == id);
            if (worker == null)
            {
                _logger.LogWarning("worker with ID: {Id} not found", id);
                return null;

            }

            return worker;
        }

        public async Task<BaseResponse<string>> AddWorkerAsync(AddWorkerDto workerDto)
        {
            try
            {
                _logger.LogInformation("Adding a new worker: {WorkerName}", workerDto.FirstName);
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
            ;
        }

        public async Task<BaseResponse<string>> UpdateWorkerAsync(UpdateWorkerDto workerDto)
        {
            var worker = await GetByIdAsync(workerDto.Id);

            if (worker is null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العامل غير موجود"
                };

            var propertiesToCheck = new Dictionary<string, object?>
            {
                { nameof(Worker.PhoneNumber), workerDto.PhoneNumber },
                { nameof(Worker.Email), workerDto.Email },
                { nameof(Worker.NationalNumber), workerDto.NationalNumber },
            };

            var duplicateCheck = await CheckDuplicatePropertiesAsync(propertiesToCheck, workerDto.Id);

            if (!duplicateCheck.Success)
                return duplicateCheck;

            workerDto.UpdateWorker(worker);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث العامل بنجاح"
            };
        }

        public async Task<BaseResponse<string>> DeleteWorkerAsync(int id)
        {
            var worker = await GetByIdAsync(id);
            if (worker is null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العامل غير موجود"
                };

            Delete(worker);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف العامل بنجاح"
            };
        }
    }
}
