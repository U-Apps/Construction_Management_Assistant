namespace ConstructionManagementAssistant_EF.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.ToTable("Workers");

    }
}
