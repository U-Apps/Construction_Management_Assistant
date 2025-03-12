using ConstructionManagementAssistant_Core.Constants;
using ConstructionManagementAssistant_EF.Data.Seading;
namespace ConstructionManagementAssistant_EF.Data.EntitesConfiguration
{
    internal class TaskConfiguration : IEntityTypeConfiguration<ConstructionManagementAssistant_Core.Entites.Task>
    {
        public void Configure(EntityTypeBuilder<ConstructionManagementAssistant_Core.Entites.Task> builder)
        {
            builder.ToTable(TablesNames.Tasks);

            builder.Property(t => t.Name)
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasMaxLength(1000);

            //builder.HasOne(t => t.Stage)
            //    .WithMany(s => s.Tasks)
            //    .HasForeignKey(t => t.StageId)
            //    .IsRequired();

            builder.HasIndex(t => new { t.Name, t.StageId })
                .IsUnique()
                .HasDatabaseName("IX_Task_Name_StageId");

            // Global filter to exclude deleted tasks
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasData(SeedData.SeedTasks());
        }
    }
}
