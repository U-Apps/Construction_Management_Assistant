using ConstructionManagementAssistant_Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static Expression<Func<Stage, GetAllStagesDto>> ToGetStageDto()
        {
            return stage => new GetAllStagesDto
            {
                Id = stage.Id,
                Name = stage.Name,
                Description = stage.Description,
                StartDate = stage.StartDate,
                EndDate = stage.EndDate,
            };
        }
    }
}
