﻿namespace ConstructionManagementAssistant_EF.Repositories;

public class WorkerSpecialtyRepository : BaseRepository<WorkerSpecialty>, IWorkerSpecialtyRepository
{
    protected readonly AppDbContext _appDbContext;
    public WorkerSpecialtyRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<GetWorkerSpecialtyDto>> GetAllWorkerSpecialties()
    {
        return await _appDbContext.Set<WorkerSpecialty>()
            .Select(c => new GetWorkerSpecialtyDto
            {
                Id = c.Id,
                SpecialtyName = c.Name
            })
            .ToListAsync();
    }

    public async Task<GetWorkerSpecialtyDto?> GetWorkerSpecialtyById(int id)
    {
        var query = _appDbContext.Set<WorkerSpecialty>().Where(x => x.Id == id)
      .Select(c => new GetWorkerSpecialtyDto
      {
          Id = c.Id,
          SpecialtyName = c.Name
      });
        return await query.FirstOrDefaultAsync();
    }

    public async Task<BaseResponse<string>> AddWorkerSpecialtyAsync(AddWorkerSpecialtyDto specialtyInfo)
    {
        try
        {
            var isSpecialtyExists = await _appDbContext.Set<WorkerSpecialty>().AnyAsync(c => c.Name == specialtyInfo.SpecialtyName);
            if (isSpecialtyExists)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "لم تتم اضافة التخصص",
                    Errors = ["التخصص موجود مسبقا"]
                };
            }

            var newSpecialty = new WorkerSpecialty
            {
                Name = specialtyInfo.SpecialtyName,
            };
            await _appDbContext.AddAsync(newSpecialty);
            await _appDbContext.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم إضافة التخصص بنجاح"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "لم تتم إضافة التخصص",
                Errors = new List<string> { ex.Message }
            };
        }

    }


    public async Task<BaseResponse<string>> UpdateWorkerSpecialtyAsync(UpdateWorkerSpecialtyDto specialtyInfo)
    {
        var Specialty = await _appDbContext.Set<WorkerSpecialty>().Where(c => c.Id == specialtyInfo.Id).FirstOrDefaultAsync();
        if (Specialty is null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "لم تتم اضافة التخصص",
                Errors = [$"لا يوجد تخصص بالمعرف {specialtyInfo.Id}"]
            };
        }

        var specialtyExist = await _appDbContext.Set<WorkerSpecialty>()
                .AnyAsync(c => c.Name == specialtyInfo.SpecialtyName);

        if (specialtyExist && specialtyInfo.SpecialtyName != Specialty.Name)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "لم تتم اضافة التخصص",
                Errors = ["يوجد تخصص بنفس الاسم"]
            };
        }

        Specialty.Name = specialtyInfo.SpecialtyName;

        try
        {
            _appDbContext.Update(Specialty);
            await _appDbContext.SaveChangesAsync();
            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث التخصص بنجاح"
            };
        }
        catch (Exception)
        {

            return new BaseResponse<string>
            {
                Success = false,
                Message = "لم يتم تحديث التخصص",
                Errors = ["حصل خطأ"]
            };

        }
    }

    public async Task<BaseResponse<string>> DeleteWorkerSpecialtyAsync(int id)
    {
        var Specialty = _appDbContext.Set<WorkerSpecialty>().Where(x => x.Id == id).FirstOrDefault();
        if (Specialty is null)
            return new BaseResponse<string>
            {
                Success = false,
                Message = "التخصص غير موجود"
            };

        Specialty.IsDeleted = true;
        await _appDbContext.SaveChangesAsync();
        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم حذف التخصص بنجاح"
        };
    }
}