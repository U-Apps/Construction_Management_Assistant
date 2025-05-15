namespace ConstructionManagementAssistant.Core.Mapping;

public static class StageProfile
{
    public static Stage ToStage(this AddStageDto addStageDto)
    {
        return new Stage
        {
            Name = addStageDto.Name,
            Description = addStageDto.Description,
            StartDate = addStageDto.StartDate,
            ExpectedEndDate = addStageDto.ExpectedEndDate,
            ProjectId = addStageDto.ProjectId
        };
    }

    public static void UpdateStage(this Stage stage, UpdateStageDto updateStageDto)
    {
        stage.Name = updateStageDto.Name;
        stage.Description = updateStageDto.Description;
        stage.StartDate = updateStageDto.StartDate;
        stage.ExpectedEndDate = updateStageDto.ExpectedEndDate;
        stage.ModifiedDate = DateTime.Now;
    }
    public static Expression<Func<Stage, GetStageDto>> ToGetAllStagesDto()
    {
        return stage => new GetStageDto
        {
            Id = stage.Id,
            Name = stage.Name,
            Description = stage.Description,
            StartDate = stage.StartDate,
            ExpectedEndDate = stage.ExpectedEndDate,
            Progress = stage.Tasks.Count == 0
                ? 0
                : (int)Math.Round(stage.Tasks.Count(x => x.IsCompleted) * 100.0 / stage.Tasks.Count)
        };
    }

    public static Expression<Func<Stage, GetStageDetailsDto>> ToGetStageDto()
    {
        return stage => new GetStageDetailsDto
        {
            Id = stage.Id,
            Name = stage.Name,
            Description = stage.Description,
            StartDate = stage.StartDate,
            ExpectedEndDate = stage.ExpectedEndDate,
            ProjectName = stage.Project.Name
        };
    }
}
