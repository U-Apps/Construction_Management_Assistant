namespace ConstructionManagementAssistant.EF.Repositories;

public class WorkerSpecialtyRepository : BaseRepository<WorkerSpecialty>, IWorkerSpecialtyRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<WorkerSpecialtyRepository> _logger;

    public WorkerSpecialtyRepository(AppDbContext context, ILogger<WorkerSpecialtyRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<GetWorkerSpecialtyDto>> GetAllWorkerSpecialties()
    {
        return await GetAllDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: WorkerSpecialtyProfile.ToGetWorkerSpecialtyDto());
    }

    public async Task<GetWorkerSpecialtyDto?> GetWorkerSpecialtyById(int id)
    {
        return await FindWithSelectionAsync(
            selector: WorkerSpecialtyProfile.ToGetWorkerSpecialtyDto(),
            criteria: x => x.Id == id);
    }

    public async Task<BaseResponse<string>> AddWorkerSpecialtyAsync(AddWorkerSpecialtyDto specialtyInfo)
    {

        _logger.LogInformation("Adding a new worker specialty: {SpecialtyName}", specialtyInfo.Name);
        var isSpecialtyExists = await AnyAsync(c => c.Name == specialtyInfo.Name);

        if (isSpecialtyExists)
        {
            _logger.LogWarning("Worker specialty already exists: {SpecialtyName}", specialtyInfo.Name);
            return new BaseResponse<string> { Success = false, Message = "لم تتم اضافة التخصص, التخصص موجود مسبقا" };
        }

        var newSpecialty = specialtyInfo.ToWorkerSpecialty();
        await AddAsync(newSpecialty);
        await _context.SaveChangesAsync();


        _logger.LogInformation("Worker specialty added successfully: {SpecialtyName}", specialtyInfo.Name);
        return new BaseResponse<string> { Success = true, Message = "تم إضافة التخصص بنجاح" };
    }

    public async Task<BaseResponse<string>> UpdateWorkerSpecialtyAsync(UpdateWorkerSpecialtyDto specialtyInfo)
    {
        var specialty = await GetByIdAsync(specialtyInfo.Id);

        if (specialty is null)
            return new BaseResponse<string> { Success = false, Message = $"لم يتم تحديث التخصص. لا يوجد تخصص بالمعرف {specialtyInfo.Id}" };


        var specialtyExist = await AnyAsync(c => c.Name == specialtyInfo.Name && c.Id != specialtyInfo.Id);
        if (specialtyExist)
        {
            return new BaseResponse<string> { Success = false, Message = "لم يتم تحديث التخصص, يوجد تخصص بنفس الاسم" };
        }


        specialtyInfo.UpdateWorkerSpecialty(specialty);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث التخصص بنجاح"
        };
    }

    public async Task<BaseResponse<string>> DeleteWorkerSpecialtyAsync(int id)
    {
        var specialty = await GetByIdAsync(id);
        if (specialty is null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "التخصص غير موجود"
            };
        }

        Delete(specialty);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم حذف التخصص بنجاح"
        };
    }
}
