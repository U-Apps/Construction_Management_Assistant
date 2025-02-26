﻿using ConstructionManagementAssistant_Core.Interfaces;
using ConstructionManagementAssistant_EF.Data;

namespace ConstructionManagementAssistant_EF.Repositories;

public class UnitOfWork(AppDbContext _appDbContext) : IUnitOfWork
{
    public IClientRepository Clients { get; private set; } = new ClientRepository(_appDbContext);
    public ISiteEngineerRepository SiteEngineers { get; private set; } = new SiteEngineerRepository(_appDbContext);
    public IWorkerSpecialtyRepository WorkerSpecialties { get; private set; } = new WorkerSpecialtyRepository(_appDbContext);
    public IWorkerRepository Workers { get; private set; } = new WorkerRepository(_appDbContext);

    public void Dispose()
    {
        _appDbContext.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}
