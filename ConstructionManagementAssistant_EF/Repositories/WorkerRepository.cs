using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionManagementAssistant_Core;
using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Interfaces;
using ConstructionManagementAssistant_Core.Models.Response;
using ConstructionManagementAssistant_EF.Data;
using RepositoryWithUWO.EF.Repositories;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        protected readonly AppDbContext _appDbContext;
        public WorkerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BaseResponse<string>> AddWorkerAsync(AddWorkerDto workerInfo)
        {
            try
            {
                var emailExists = await _appDbContext.Set<Worker>().AnyAsync(c => c.Email != null && c.Email == workerInfo.Email);
                if (emailExists)
                {
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "البريد الإلكتروني موجود بالفعل",
                    };
                }

                var phoneExists = await _appDbContext.Set<Worker>().AnyAsync(c => c.PhoneNumber != null && c.PhoneNumber == workerInfo.PhoneNumber);
                if (phoneExists)
                {
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "رقم الهاتف موجود بالفعل",
                    };
                }

                var NationalNumberExists = await _appDbContext.Set<Worker>().AnyAsync(c => c.NationalNumber != null && c.NationalNumber == workerInfo.NationalNumber);
                if (phoneExists)
                {
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "رقم الهوية موجود بالفعل"
                    };
                }

                var newWorker = new Worker
                {
                    FirstName = workerInfo.FirstName,
                    SecondName = workerInfo.SecondName,
                    ThirdName = workerInfo.ThirdName,
                    LastName = workerInfo.LastName,
                    Email = workerInfo.Email,
                    PhoneNumber = workerInfo.PhoneNumber,
                    NationalNumber = workerInfo.PhoneNumber,
                    Address = workerInfo.Address,
                    SpecialtyId = workerInfo.SpecialtyId,
                    IsAvailable = true
                };

                await _appDbContext.AddAsync(newWorker);
                await _appDbContext.SaveChangesAsync();

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "تم إضافة العامل بنجاح"
                };
            }
            catch (Exception)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "لم تتم إضافة العامل ",
                    Errors = ["حصل خطأ"]
                };
            }

        }

        public async Task<BaseResponse<string>> DeleteWorkerAsync(int id)
        {
            var worker = _appDbContext.Set<Worker>().Where(x => x.Id == id).FirstOrDefault();
            if (worker is null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العامل غير موجود"
                };

            worker.IsDeleted = true;
            await _appDbContext.SaveChangesAsync();
            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف العامل بنجاح"
            };
        }

        public async Task<PagedResult<GetWorkerDto>> GetAllWorkers(int pageNumber = 1, int pageSize = 10)
        {
            var query = _appDbContext.Set<Worker>().AsQueryable();
            var totalItems = await query.CountAsync();
            var workers = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(w => new GetWorkerDto
            {
                Id = w.Id,
                FullName = w.FirstName + " " + w.SecondName + " " + w.ThirdName + " " + w.LastName,
                Specialty = w.Specialty.Name,
                IsAvailable = w.IsAvailable
            }).ToListAsync();

            return new PagedResult<GetWorkerDto>
            {
                Items = workers,
                TotalCount = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                CurrentPage = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<BaseResponse<string>> UpdateWorkerAsync(UpdateWorkerDto workerInfo)
        {
            var worker = await _appDbContext.Set<Worker>().Where(w => w.Id == workerInfo.Id).FirstOrDefaultAsync();
            if (worker is null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "العامل غير موجود"
                };

            var emailExists = await _appDbContext.Set<Worker>().AnyAsync(c => c.Email != null && c.Email == workerInfo.Email);
            if (emailExists && workerInfo.Email != worker.Email)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "البريد الإلكتروني موجود بالفعل"
                };
            }

            var phoneExists = await _appDbContext.Set<Worker>().AnyAsync(c => c.PhoneNumber != null && c.PhoneNumber == workerInfo.PhoneNumber);
            if (phoneExists && workerInfo.PhoneNumber != worker.PhoneNumber)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "رقم الهاتف موجود بالفعل"
                };
            }

            var NationalNumberExists = await _appDbContext.Set<Worker>().AnyAsync(c => c.NationalNumber != null && c.NationalNumber == workerInfo.NationalNumber);
            if (phoneExists && workerInfo.NationalNumber != worker.NationalNumber)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "رقم الهوية موجود بالفعل"
                };
            }
            try
            {
                worker.FirstName = workerInfo.FirstName;
                worker.SecondName = workerInfo.SecondName;
                worker.ThirdName = workerInfo.ThirdName;
                worker.LastName = workerInfo.LastName;
                worker.Email = workerInfo.Email;
                worker.PhoneNumber = workerInfo.PhoneNumber;
                worker.NationalNumber = workerInfo.PhoneNumber;
                worker.Address = workerInfo.Address;
                worker.SpecialtyId = workerInfo.SpecialtyId;


                _appDbContext.Update(worker);
                await _appDbContext.SaveChangesAsync();

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "تم تحديث العامل بنجاح"
                };
            }
            catch (Exception)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "لم تتم عميلة التعديل",
                    Errors = ["حصل خطأ"]
                };
            }
        }
    }
}