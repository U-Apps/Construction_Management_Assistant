namespace ConstructionManagementAssistant_Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    ISiteEngineerRepository SiteEngineers { get; }
    IWorkerSpecialtyRepository WorkerSpecialties { get; }


    Task<int> SaveAsync();

}

