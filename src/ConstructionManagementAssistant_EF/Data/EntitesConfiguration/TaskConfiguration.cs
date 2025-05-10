using ConstructionManagementAssistant.Core.Constants;
using ConstructionManagementAssistant.EF.Data.Seading;
namespace ConstructionManagementAssistant.EF.Data.EntitesConfiguration
{
    internal class TaskConfiguration : IEntityTypeConfiguration<ConstructionManagementAssistant.Core.Entites.Task>
    {
        public void Configure(EntityTypeBuilder<ConstructionManagementAssistant.Core.Entites.Task> builder)
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

            //builder.HasIndex(t => new { t.Name, t.StageId })
            //    .IsUnique()
            //    .HasDatabaseName("IX_Task_Name_StageId");


            builder.HasData(SeedData.SeedTasks());
            builder.HasMany(x => x.Documents).WithOne(x => x.Task).HasForeignKey(x => x.TaskId);

        }
    }
}
