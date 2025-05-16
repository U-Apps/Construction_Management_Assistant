using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant.Core.Mapping
{
    public static class DocumentProfile
    {
        public static DocumentResponse ToDocumentResponse(this Documnet document)
        {
            var r = new DocumentResponse();


            r.Id = document.Id;
            r.Name = document.Name;
            r.Description = document.Description;
            r.TaskId = document.TaskId;
            r.TaskName = document.Task != null ? document.Task.Name : null;
            r.ProjectId = document.ProjectId;
            r.ProjectName = document.Project.Name;
            r.ClassificationId = document.ClassificationId;
            r.ClassificationName = document.Classification != null ? document.Classification.Type : string.Empty;
            r.CreatedDate = document.CreatedDate;

            return r;
            
        }
        public static Documnet ToDocument(this UploadFileRequest request)
        {
            return new Documnet
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                TaskId = request.TaskId,
                ProjectId = request.ProjectId,
                ClassificationId = request.ClassificationId,
                CreatedDate = DateTime.Now
            };
        }
    }
}
