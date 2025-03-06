using ConstructionManagementAssistant_Core.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConstructionManagementAssistant_Core.DTOs.StageDtos;

namespace ConstructionManagementAssistant_EF.Repositories
{
    public class StageRepository(AppDbContext _context) : BaseRepository<Stage>(_context), IStageRepository
    {
        public async Task<BaseResponse<string>> AddStageAsync(AddStageDto stageDto)
        {
            if (!await IsStageNameUniqueAsync(stageDto.Name, stageDto.ProjectId))
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "يوجد مرحلة بنفس الاسم"
                };
            }
            var newStage = stageDto.ToStage();

            await AddAsync(newStage);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Stage added successfully."
            };
        }

        private async Task<bool> IsStageNameUniqueAsync(string name, int projectId)
        {
            return !await AnyAsync(s => s.Name == name && s.ProjectId == projectId);
        }
    }
}
