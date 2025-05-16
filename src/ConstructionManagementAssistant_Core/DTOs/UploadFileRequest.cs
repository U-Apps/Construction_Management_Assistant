using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant.Core.DTOs
{
    public class UploadFileRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? TaskId { get; set; }
        public int ProjectId { get; set; }
        public int ClassificationId { get; set; }
        public IFormFile? File { get; set; }
    }
}
