

using ConstructionManagementAssistant_Core.Constants;

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

            // Global filter to exclude deleted clients
            builder.HasQueryFilter(e => !e.IsDeleted);

        }
    }
}
