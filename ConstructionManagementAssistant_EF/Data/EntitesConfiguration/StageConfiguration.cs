

using ConstructionManagementAssistant_Core.Constants;
using Microsoft.EntityFrameworkCore;

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

            builder.HasOne(s => s.Project)
                .WithMany()
                .HasForeignKey(s => s.ProjectId)
                .IsRequired();

            // Global filter to exclude deleted clients
            builder.HasQueryFilter(e => !e.IsDeleted);

        }
    }
}
