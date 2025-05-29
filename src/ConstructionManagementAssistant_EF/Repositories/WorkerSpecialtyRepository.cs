public class WorkerSpecialtyRepository : BaseRepository<WorkerSpecialty>, IWorkerSpecialtyRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<WorkerSpecialtyRepository> _logger;

    public WorkerSpecialtyRepository(AppDbContext context, ILogger<WorkerSpecialtyRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<GetWorkerSpecialtyDto>> GetAllWorkerSpecialties(string userId)
    {
        _logger.LogInformation("Getting all worker specialties for userId: {UserId}", userId);
        try
        {
            var result = await GetAllDataWithSelectionAsync(
                orderBy: x => x.Name,
                criteria: x => x.UserId == int.Parse(userId),
                selector: WorkerSpecialtyProfile.ToGetWorkerSpecialtyDto());
            _logger.LogInformation("Retrieved {Count} worker specialties for userId: {UserId}", result.Count, userId);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all worker specialties for userId: {UserId}", userId);
            throw;
        }
    }

    public async Task<GetWorkerSpecialtyDto?> GetWorkerSpecialtyById(int id)
    {
        _logger.LogInformation("Getting worker specialty by id: {Id}", id);
        try
        {
            var result = await FindWithSelectionAsync(
                selector: WorkerSpecialtyProfile.ToGetWorkerSpecialtyDto(),
                criteria: x => x.Id == id);
            if (result == null)
                _logger.LogWarning("Worker specialty not found for id: {Id}", id);
            else
                _logger.LogInformation("Worker specialty found for id: {Id}", id);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting worker specialty by id: {Id}", id);
            throw;
        }
    }

    public async Task<BaseResponse<string>> AddWorkerSpecialtyAsync(string userId, AddWorkerSpecialtyDto specialtyInfo)
    {
        _logger.LogInformation("Adding a new worker specialty: {SpecialtyName} for userId: {UserId}", specialtyInfo.Name, userId);
        try
        {
            var isSpecialtyExists = await AnyAsync(c => c.Name == specialtyInfo.Name);

            if (isSpecialtyExists)
            {
                _logger.LogWarning("Worker specialty already exists: {SpecialtyName}", specialtyInfo.Name);
                return new BaseResponse<string> { Success = false, Message = "لم تتم اضافة التخصص, التخصص موجود مسبقا" };
            }

            var newSpecialty = specialtyInfo.ToWorkerSpecialty();
            newSpecialty.UserId = int.Parse(userId);
            await AddAsync(newSpecialty);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Worker specialty added successfully: {SpecialtyName}", specialtyInfo.Name);
            return new BaseResponse<string> { Success = true, Message = "تم إضافة التخصص بنجاح" };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding worker specialty: {SpecialtyName} for userId: {UserId}", specialtyInfo.Name, userId);
            throw;
        }
    }

    public async Task<BaseResponse<string>> UpdateWorkerSpecialtyAsync(UpdateWorkerSpecialtyDto specialtyInfo)
    {
        _logger.LogInformation("Updating worker specialty with id: {Id}", specialtyInfo.Id);
        try
        {
            var specialty = await GetByIdAsync(specialtyInfo.Id);

            if (specialty is null)
            {
                _logger.LogWarning("Worker specialty not found for update. Id: {Id}", specialtyInfo.Id);
                return new BaseResponse<string> { Success = false, Message = $"لم يتم تحديث التخصص. لا يوجد تخصص بالمعرف {specialtyInfo.Id}" };
            }

            var specialtyExist = await AnyAsync(c => c.Name == specialtyInfo.Name && c.Id != specialtyInfo.Id);
            if (specialtyExist)
            {
                _logger.LogWarning("Worker specialty with the same name already exists: {SpecialtyName}", specialtyInfo.Name);
                return new BaseResponse<string> { Success = false, Message = "لم يتم تحديث التخصص, يوجد تخصص بنفس الاسم" };
            }

            specialtyInfo.UpdateWorkerSpecialty(specialty);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Worker specialty updated successfully. Id: {Id}", specialtyInfo.Id);
            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث التخصص بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating worker specialty. Id: {Id}", specialtyInfo.Id);
            throw;
        }
    }

    public async Task<BaseResponse<string>> DeleteWorkerSpecialtyAsync(int id)
    {
        _logger.LogInformation("Deleting worker specialty with id: {Id}", id);
        try
        {
            var specialty = await GetByIdAsync(id);
            if (specialty is null)
            {
                _logger.LogWarning("Worker specialty not found for deletion. Id: {Id}", id);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "التخصص غير موجود"
                };
            }

            Delete(specialty);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Worker specialty deleted successfully. Id: {Id}", id);
            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف التخصص بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting worker specialty. Id: {Id}", id);
            throw;
        }
    }
}
