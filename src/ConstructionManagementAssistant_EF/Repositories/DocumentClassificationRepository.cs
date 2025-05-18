using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant.EF.Repositories
{
    public class DocumentClassificationRepository(AppDbContext _context, ILogger<DocumentRepository> _logger) :
        BaseRepository<DocumentClassification>(_context), IDocClassRepository
    {

        public async Task<BaseResponse<DocumentClassification>> CreateAsync(string type)
        {
            var cls = new DocumentClassification() { Type = type};
            // Check if the classification already exists
            var existingClassification = await _context.Set<DocumentClassification>()
                .FirstOrDefaultAsync(c => c.Type == type);
            if (existingClassification != null)
            {
                return new BaseResponse<DocumentClassification>
                {
                    Success = false,
                    Message = "التصنيف موجود مسبقا"
                };
            }

            var result = await AddAsync(cls);
            await _context.SaveChangesAsync();
            return new BaseResponse<DocumentClassification>
            {
                Success = true,
                Data = result,
                Message = "تم اضافة التصنيف بنجاح"
            };

        }

        public async Task<BaseResponse<DocumentClassification>> GetAsync(int id)
        {

            var result = await GetByIdAsync(id);
            if (result == null)
            {
                return new BaseResponse<DocumentClassification>
                {
                    Success = false,
                    Message = "لا يوجد تصنيف بهذا المعرف"
                };
            }

            return new BaseResponse<DocumentClassification>
            {
                Success = true,
                Message = "تم جلب التصنيف بنجاح",
                Data = result
            };
            
        }

        public async Task<BaseResponse<string>> UpdateAsync(DocumentClassification entity)
        {
            var existingEntity = await GetByIdAsync(entity.Id);
            if (existingEntity == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "لا يوجد تصنيف بهذا المعرف"
                };
            }

            // Check if the classification already exists
            if (await FindAsync(c => c.Type == entity.Type && c.Id != entity.Id) is not null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "التصنيف موجود مسبقا"
                };
            }

            existingEntity.Type = entity.Type;
            Update(existingEntity);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث التصنيف بنجاح"
            };

        }

        public async Task<BaseResponse<string>> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "لا يوجد تصنيف بهذا المعرف"
                };
            }

            Delete(entity);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف التصنيف بنجاح"
            };
        }

        public async Task<BaseResponse<List<DocumentClassification>>> GetAllAsync()
        {
            var classifications = await _context.Set<DocumentClassification>().ToListAsync();

            if (classifications == null || !classifications.Any())
            {
                return new BaseResponse<List<DocumentClassification>>
                {
                    Success = false,
                    Message = "لا توجد تصنيفات متاحة"
                };
            }

            return new BaseResponse<List<DocumentClassification>>
            {
                Success = true,
                Message = "تم جلب جميع التصنيفات بنجاح",
                Data = classifications
            };
        }
    }
}
