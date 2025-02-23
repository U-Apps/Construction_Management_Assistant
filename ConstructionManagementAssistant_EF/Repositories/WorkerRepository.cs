using ConstructionManagementAssistant_Core.Mapping;
using ConstructionManagementAssistant_EF.Extensions;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class WorkerRepository(AppDbContext _context) : BaseRepository<Worker>(_context), IWorkerRepository
    {

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

        public async Task<WorkerDetailsDto> GetWorkerById(int id)
        {
            return await FindWithSelectionAsync(
                selector: WorkerProfile.ToWorkerDetailsDto(),
                criteria: x => x.Id == id);
        }

        public async Task<BaseResponse<string>> AddWorkerAsync(AddWorkerDto workerDto)
        {
            var duplicateCheck = await CheckDuplicatePhoneEmailNationalNumberAsync(
                phoneNumber: workerDto.PhoneNumber,
                email: workerDto.Email,
                nationalNumber: workerDto.NationalNumber);

            if (!duplicateCheck.Success)
                return duplicateCheck;

            var newWorker = workerDto.ToWorker();
            await AddAsync(newWorker);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم إضافة العامل بنجاح"
            };
        }

        public async Task<BaseResponse<string>> UpdateWorkerAsync(UpdateWorkerDto workerInfo)
        {
            var worker = await GetByIdAsync(workerInfo.Id);

            if (worker is null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العامل غير موجود"
                };


            var duplicateCheck = await CheckDuplicatePhoneEmailNationalNumberAsync(
                phoneNumber: workerInfo.PhoneNumber,
                email: workerInfo.Email,
                nationalNumber: workerInfo.NationalNumber,
                id: workerInfo.Id);

            if (!duplicateCheck.Success)
                return duplicateCheck;

            workerInfo.UpdateWorker(worker);
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
