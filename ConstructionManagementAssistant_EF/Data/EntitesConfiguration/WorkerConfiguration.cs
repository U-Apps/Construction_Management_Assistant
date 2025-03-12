using ConstructionManagementAssistant_Core.Constants;
using ConstructionManagementAssistant_EF.Data.Seading;

namespace ConstructionManagementAssistant_EF.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.ToTable(TablesNames.Workers);
        builder.HasData(SeedData.SeedWorkers());
    }
}
