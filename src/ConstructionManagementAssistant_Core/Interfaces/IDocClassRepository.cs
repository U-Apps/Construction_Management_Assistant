using ConstructionManagementAssistant.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IDocClassRepository
    {
        Task<BaseResponse<DocumentClassification>> CreateAsync(string Type);
        Task<BaseResponse<DocumentClassification>> GetAsync(int id);
        Task<BaseResponse<List<DocumentClassification>>> GetAllAsync();
        Task<BaseResponse<string>> UpdateAsync(DocumentClassification Type);
        Task<BaseResponse<string>> DeleteAsync(int id);
    }
}
