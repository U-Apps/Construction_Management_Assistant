using ConstructionManagementAssistant_Core.DTOs;
using System.Linq.Expressions;

namespace ConstructionManagementAssistant_Core.Mapping;

public static class WorkerProfile
{
    public static Expression<Func<Worker, GetWorkerDto>> ToGetWorkerDto()
    {
        return worker => new GetWorkerDto
        {
            Id = worker.Id,
            FullName = worker.GetFullName(),
            Specialty = worker.Specialty.Name,
            IsAvailable = worker.IsAvailable,
        };
    }

    public static Expression<Func<Worker, WorkerDetailsDto>> ToWorkerDetailsDto()
    {
        return worker => new WorkerDetailsDto
        {
            Id = worker.Id,
            FullName = worker.GetFullName(),
            Email = worker.Email,
            PhoneNumber = worker.PhoneNumber,
            NationalNumber = worker.NationalNumber,
            Address = worker.Address,
            Specialty = worker.Specialty.Name,
            IsAvailable = worker.IsAvailable,
        };
    }

    public static Worker ToWorker(this AddWorkerDto addWorkerDto)
    {
        return new Worker
        {
            FirstName = addWorkerDto.FirstName,
            SecondName = addWorkerDto.SecondName,
            ThirdName = addWorkerDto.ThirdName,
            LastName = addWorkerDto.LastName,
            Email = addWorkerDto.Email,
            PhoneNumber = addWorkerDto.PhoneNumber,
            NationalNumber = addWorkerDto.NationalNumber,
            Address = addWorkerDto.Address,
            SpecialtyId = addWorkerDto.SpecialtyId,
            IsAvailable = true
        };
    }

    public static void UpdateWorker(this UpdateWorkerDto updateWorkerDto, Worker worker)
    {
        worker.Id = updateWorkerDto.Id;
        worker.FirstName = updateWorkerDto.FirstName;
        worker.SecondName = updateWorkerDto.SecondName;
        worker.ThirdName = updateWorkerDto.ThirdName;
        worker.LastName = updateWorkerDto.LastName;
        worker.Email = updateWorkerDto.Email;
        worker.PhoneNumber = updateWorkerDto.PhoneNumber;
        worker.NationalNumber = updateWorkerDto.NationalNumber;
        worker.Address = updateWorkerDto.Address;
        worker.SpecialtyId = updateWorkerDto.SpecialtyId;
        worker.ModifiedDate = DateTime.Now;
    }
}
