using ConstructionManagementAssistant.Core.DTOs;
using ConstructionManagementAssistant.Core.Entites;
using System.Linq.Expressions;

namespace ConstructionManagementAssistant.Core.Mapping
{
    public static class WorkerSpecialtyProfile
    {

        public static Expression<Func<WorkerSpecialty, GetWorkerSpecialtyDto>> ToGetWorkerSpecialtyDto()
        {
            return specialty => new GetWorkerSpecialtyDto
            {
                Id = specialty.Id,
                Name = specialty.Name
            };
        }

        public static WorkerSpecialty ToWorkerSpecialty(this AddWorkerSpecialtyDto specialtyDto)
        {
            return new WorkerSpecialty
            {
                Name = specialtyDto.Name
            };
        }

        public static void UpdateWorkerSpecialty(this UpdateWorkerSpecialtyDto workerSpecialtyDto, WorkerSpecialty worker)
        {
            worker.Id = workerSpecialtyDto.Id;
            worker.Name = workerSpecialtyDto.Name;
        }


    }
}
