

using ConstructionManagementAssistant_Core.Constants;
using ConstructionManagementAssistant_EF.Data.Seading;

namespace ConstructionManagementAssistant_EF.Data.EntitesConfiguration
{
    internal class StageConfiguration : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.ToTable(TablesNames.Stages);

            builder.Property(s => s.Name)
                .HasMaxLength(200);

            builder.Property(s => s.Description)
                .HasMaxLength(1000);

            //builder.HasOne(s => s.Project)
            //    .WithMany()
            //    .HasForeignKey(s => s.ProjectId)
            //    .IsRequired();

            //builder.HasIndex(s => new { s.Name, s.ProjectId })
            //    .IsUnique()
            //    .HasDatabaseName("IX_Stage_Name_ProjectId");


            builder.HasData(SeedData.SeedStages());

        }
    }
}
