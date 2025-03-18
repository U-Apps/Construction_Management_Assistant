using ConstructionManagementAssistant.Core.Constants;
using ConstructionManagementAssistant.EF.Data.Seading;

namespace ConstructionManagementAssistant.EF.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.ToTable(TablesNames.Workers);
        builder.HasData(SeedData.SeedWorkers());
    }
}
