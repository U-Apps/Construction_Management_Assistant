namespace ConstructionManagementAssistant.EF.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IClientRepository Clients { get; private set; }
    public IProjectRepository Projects { get; private set; }
    public ISiteEngineerRepository SiteEngineers { get; private set; }
    public IWorkerSpecialtyRepository WorkerSpecialties { get; private set; }
    public IWorkerRepository Workers { get; private set; }
    public IStageRepository Stages { get; private set; }
    public ITaskRepository Tasks { get; private set; }
    public ITaskAssignmentRepository TaskAssignments { get; private set; }
    public IEquipmentRepository Equipment { get; private set; }
    public IEquipmentAssignmentRepository EquipmentAssignments { get; private set; }

    private readonly AppDbContext _appDbContext;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(AppDbContext appDbContext, IServiceProvider serviceProvider)
    {
        _appDbContext = appDbContext;
        _logger = serviceProvider.GetRequiredService<ILogger<UnitOfWork>>();

        Clients = new ClientRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<ClientRepository>>());
        Projects = new ProjectRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<ProjectRepository>>());
        SiteEngineers = new SiteEngineerRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<SiteEngineerRepository>>());
        WorkerSpecialties = new WorkerSpecialtyRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<WorkerSpecialtyRepository>>());
        Workers = new WorkerRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<WorkerRepository>>());
        Stages = new StageRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<StageRepository>>());
        Tasks = new TaskRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<TaskRepository>>());
        TaskAssignments = new TaskAssignmentRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<TaskAssignmentRepository>>());
        Equipment = new EquipmentRepository(_appDbContext);
        EquipmentAssignments = new EquipmentAssignmentRepository(_appDbContext, serviceProvider.GetRequiredService<ILogger<EquipmentAssignmentRepository>>());
    }

    public void Dispose()
    {
        _logger.LogInformation("Disposing UnitOfWork.");
        _appDbContext.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        _logger.LogInformation("Saving changes to the database.");
        return await _appDbContext.SaveChangesAsync();
    }
}
