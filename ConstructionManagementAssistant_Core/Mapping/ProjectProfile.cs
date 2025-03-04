using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Extentions;
using System.Linq.Expressions;

namespace ConstructionManagementAssistant_Core.Mapping;

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
        };
    }

    public static Project ToProject(this AddProjectDto addProjectDto)
    {
        return new Project
        {
            Name=addProjectDto.ProjectName,
            Description = addProjectDto.Description,
            SiteAddress = addProjectDto.SiteAddress,
            GeographicalCoordinates = addProjectDto.GeographicalCoordinates,
            SiteEngineerId = addProjectDto.SiteEngineerId,
            ClientId= addProjectDto.ClientId,
            StartDate = addProjectDto.StartDate,
            ExpectedEndDate = addProjectDto.ExpectedEndDate
        };
    }

    public static void UpdateProject(this Project project, UpdateProjectDto updateProjectDto)
    {
        project.Name = updateProjectDto.ProjectName;
        project.Description = updateProjectDto.Description;
        project.SiteAddress = updateProjectDto.SiteAddress;
        project.GeographicalCoordinates = updateProjectDto.GeographicalCoordinates;
        if (updateProjectDto.ProjectStatus != null)
            project.Status =(ProjectStatus) updateProjectDto.ProjectStatus.ToEnumByDisplayName<ProjectStatus>();
        if (updateProjectDto.SiteEngineerId != null)
            project.SiteEngineerId = updateProjectDto.SiteEngineerId;
        project.ModifiedDate = DateTime.Now;
    }
}
