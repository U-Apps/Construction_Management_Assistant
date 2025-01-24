namespace ConstructionManagementAssistant_Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }

    Task<int> SaveAsync();

}

