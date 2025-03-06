using ConstructionManagementAssistant_Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConstructionManagementAssistant_Core.DTOs.StageDtos;

namespace ConstructionManagementAssistant_Core.Mapping
{
    public static class StageProfile
    {
        public static Stage ToStage(this AddStageDto addStageDto)
        {
            return new Stage
            {
                Name = addStageDto.Name,
                Description = addStageDto.Description,
                StartDate = addStageDto.StartDate,
                EndDate = addStageDto.EndDate,
                ProjectId = addStageDto.ProjectId
            };
        }
    }
}
