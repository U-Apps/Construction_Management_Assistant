using ConstructionManagementAssistant.Core.Extentions;

namespace ConstructionManagementAssistant.Core.Mapping;

public static class ProjectProfile
{
    public static Expression<Func<Project, GetProjectsDto>> ToGetProjectDto()
    {
        return project => new GetProjectsDto
        {
            Id = project.Id,
            ProjectName = project.Name,
            SiteAddress = project.SiteAddress,
            ClientName = project.Client.FullName,
            ProjectStatus = (project.Status).GetDisplayName(),
            Progress =
                project.Stages != null && project.Stages.Any(s => s.Tasks != null && s.Tasks.Any())
                    ? (int)(
                        (project.Stages
                            .SelectMany(s => s.Tasks)
                            .Where(t => t.IsCompleted)
                            .Count() * 100.0) /
                        (project.Stages
                            .SelectMany(s => s.Tasks)
                            .Count() == 0
                            ? 1
                            : project.Stages
                                .SelectMany(s => s.Tasks)
                                .Count())
                      )
                    : 0,

        };
    }


    public static Expression<Func<Project, ProjectNameDto>> ToGetProjectNameDto()
    {
        return project => new ProjectNameDto
        {
            Id = project.Id,
            Name = project.Name
        };
    }



    public static Project ToProject(this AddProjectDto addProjectDto)
    {
        return new Project
        {
            Name = addProjectDto.ProjectName,
            Description = addProjectDto.Description,
            SiteAddress = addProjectDto.SiteAddress,
            GeographicalCoordinates = addProjectDto.GeographicalCoordinates,
            SiteEngineerId = addProjectDto.SiteEngineerId,
            ClientId = addProjectDto.ClientId,
            StartDate = addProjectDto.StartDate,
            ExpectedEndDate = addProjectDto.ExpectedEndDate

        };
    }
    public static Expression<Func<Project, ProjectDetailsDto>> ToProjectDetails()
    {
        return Project => new ProjectDetailsDto
        {
            Id = Project.Id,
            ProjectName = Project.Name,
            Description = Project.Description,
            SiteAddress = Project.SiteAddress,
            GeographicalCoordinates = Project.GeographicalCoordinates,
            SiteEngineerName = Project.SiteEngineer != null ? Project.SiteEngineer.Name : null,
            ClientName = Project.Client != null ? Project.Client.FullName : string.Empty,
            StartDate = Project.StartDate,
            ExpectedEndDate = Project.ExpectedEndDate,
            ProjectStatus = Project.Status.GetDisplayName(),
            Progress =
                Project.Stages != null && Project.Stages.Any(s => s.Tasks != null && s.Tasks.Any())
                    ? (int)(
                        (Project.Stages
                            .SelectMany(s => s.Tasks)
                            .Where(t => t.IsCompleted)
                            .Count() * 100.0) /
                        (Project.Stages
                            .SelectMany(s => s.Tasks)
                            .Count() == 0
                            ? 1
                            : Project.Stages
                                .SelectMany(s => s.Tasks)
                                .Count())
                      )
                    : 0,
            CancellationReason = Project.CancelationReason,
            CancellationDate = Project.CancelationDate,
            CompletionDate = Project.CompletionDate,
            HandoverDate = Project.HandoverDate,
        };
    }
    public static void UpdateProject(this Project project, UpdateProjectDto updateProjectDto)
    {
        project.Name = updateProjectDto.ProjectName;
        project.Description = updateProjectDto.Description;
        project.SiteAddress = updateProjectDto.SiteAddress;
        project.GeographicalCoordinates = updateProjectDto.GeographicalCoordinates;
        //if (updateProjectDto.ProjectStatus != null)
        //    project.Status =(ProjectStatus) updateProjectDto.ProjectStatus.ToEnumByDisplayName<ProjectStatus>();
        //if (updateProjectDto.SiteEngineerId != null)
        //    project.SiteEngineerId = updateProjectDto.SiteEngineerId;
        project.ModifiedDate = DateTime.Now;
    }
}
