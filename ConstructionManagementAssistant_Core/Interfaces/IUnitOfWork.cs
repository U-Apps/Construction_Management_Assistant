namespace ConstructionManagementAssistant_Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    IProjectRepository Projects { get; }
    ISiteEngineerRepository SiteEngineers { get; }
    IWorkerSpecialtyRepository WorkerSpecialties { get; }
    IWorkerRepository Workers { get; }
    IStageRepository Stages { get; }

    Task<int> SaveAsync();

}

