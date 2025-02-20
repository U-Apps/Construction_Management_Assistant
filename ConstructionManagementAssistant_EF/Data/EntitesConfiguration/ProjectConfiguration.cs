using ConstructionManagementAssistant_Core.Enums;
using ConstructionManagementAssistant_EF.Extensions;

namespace ConstructionManagementAssistant_EF.Data.Configuration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.SiteAddress)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(p => p.GeographicalCoordinates)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.SiteEngineerId)
                .IsRequired();

            builder.Property(p => p.ClientId)
                .IsRequired();

            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(p => p.DateModified)
                .HasDefaultValueSql("CURRENT_DATE");

            builder.Property(p => p.DateCreated)
                .HasDefaultValueSql("CURRENT_DATE");

            builder.Property(p => p.Startdate)
                .IsRequired();

            builder.Property(p => p.ExpectedEndDate)
                .IsRequired();

            builder.Property(p => p.CancelationReason)
                .HasMaxLength(500);

            // Nullable properties
            builder.Property(p => p.CancelationDate);
            builder.Property(p => p.CompletionDate);
            builder.Property(p => p.HandoverDate);
            builder.Property(p => p.CancelledAtStage);

            builder.HasOne<Client>()
            .WithOne()
            .HasForeignKey<Project>(p => p.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<SiteEngineer>()
                .WithOne()
                .HasForeignKey<Project>(p => p.SiteEngineerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.AddEnumCheckConstraint<ProjectStatus>("Projects", "Status");

            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
