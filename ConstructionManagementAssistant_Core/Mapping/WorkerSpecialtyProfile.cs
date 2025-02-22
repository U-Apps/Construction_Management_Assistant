using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant_Core.Mapping
{
    public static class WorkerSpecialtyProfile
    {
        public static WorkerSpecialty ToWorkerSpecialty(this AddWorkerSpecialtyDto workerDto)
        => new()
        {
            Name = workerDto.SpecialtyName,
        };

        public static void MapToWorkerSpecialty(this UpdateWorkerSpecialtyDto workerSpecialtyDto, WorkerSpecialty worker )
        {
            worker.Id = workerSpecialtyDto.Id;
            worker.Name = workerSpecialtyDto.SpecialtyName;
        }

        public static GetWorkerSpecialtyDto ToGetWorkerSpecialtyDto(this WorkerSpecialty worker)
        => new()
        {
            Id = worker.Id,
            SpecialtyName = worker.Name
        };
    }
}
