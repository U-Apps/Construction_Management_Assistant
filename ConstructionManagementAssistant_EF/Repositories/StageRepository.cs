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

        public async Task<BaseResponse<string>> DeleteStageAsync(int id)
        {
            var stage = await GetByIdAsync(id);
            if (stage == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المرحلة غير موجوده"
                };
            }

            Delete(stage);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف المرحلة بنجاح"
            };
        }

        public async Task<GetStageDto> GetStageByIdAsync(int Id)
        {
            return await FindWithSelectionAsync(
            selector: StageProfile.ToGetStageDto(),
            criteria: x => x.Id == Id);
        }

        public async Task<PagedResult<GetAllStagesDto>> GetStagesByProjectIdAsync(int projectId, int pageNumber = 1, int pageSize = 10)
        {
            Expression<Func<Stage, bool>> filter = s => s.ProjectId == projectId;

            var pagedResult = await GetPagedDataWithSelectionAsync(
                orderBy: s => s.Name,
                selector: StageProfile.ToGetAllStagesDto(),
                criteria: filter,
                pageNumber: pageNumber,
                pageSize: pageSize);

            return pagedResult;
        }

        public async Task<BaseResponse<string>> UpdateStageAsync(UpdateStageDto stageInfo)
        {
            var stage = await GetByIdAsync(stageInfo.Id);
            if (stage == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المرحلة غير موجوده"
                };
            }

            if (!await IsStageNameUniqueAsync(stageInfo.Name, stageInfo.ProjectId))
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "يوجد مرحلة بنفس الاسم"
                };
            }

            stage.UpdateStage(stageInfo);
            Update(stage);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث المرحلة بنجاح"
            };
        }

        private async Task<bool> IsStageNameUniqueAsync(string name, int projectId)
        {
            return !await AnyAsync(s => s.Name == name && s.ProjectId == projectId);
        }
    }
}
