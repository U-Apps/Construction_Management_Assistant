namespace ConstructionManagementAssistant_EF.Repositories;

public class UnitOfWork(AppDbContext _appDbContext) : IUnitOfWork
{
    public IClientRepository Clients { get; private set; } = new ClientRepository(_appDbContext);
    public IProjectRepository Projects { get; private set; } = new ProjectRepository(_appDbContext);
    public ISiteEngineerRepository SiteEngineers { get; private set; } = new SiteEngineerRepository(_appDbContext);
    public IWorkerSpecialtyRepository WorkerSpecialties { get; private set; } = new WorkerSpecialtyRepository(_appDbContext);
    public IWorkerRepository Workers { get; private set; } = new WorkerRepository(_appDbContext);
    public IStageRepository Stages { get; } = new StageRepository(_appDbContext);
    public ITaskRepository Tasks { get; } = new TaskRepository(_appDbContext);


    public void Dispose()
    {
        _appDbContext.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}
