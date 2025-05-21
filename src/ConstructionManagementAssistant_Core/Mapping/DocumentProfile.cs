namespace ConstructionManagementAssistant.Core.Mapping
{
    public static class DocumentProfile
    {
        public static Expression<Func<Documnet, DocumentResponse>> ToDocumentResponse()
        {
            return document =>
             new DocumentResponse()
             {


                 Id = document.Id,
                 Name = document.Name,
                 Description = document.Description,
                 TaskId = document.TaskId,
                 TaskName = document.Task != null ? document.Task.Name : null,
                 ProjectId = document.ProjectId,
                 ProjectName = document.Project.Name,
                 CreatedDate = document.CreatedDate
             };

        }
        public static Expression<Func<Documnet, DocumentDetailsResponse>> ToDocumentDetailsResponse()
        {
            return document =>
             new DocumentDetailsResponse()
             {
                 Id = document.Id,
                 Name = document.Name,
                 Description = document.Description,
                 TaskId = document.TaskId,
                 TaskName = document.Task != null ? document.Task.Name : null,
                 ProjectId = document.ProjectId,
                 ProjectName = document.Project.Name,
                 CreatedDate = document.CreatedDate,
                 FileType = document.FileType,
                 FileUrl = document.Path
             };

        }
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
                CreatedDate = DateTime.Now
            };
        }
    }
}
