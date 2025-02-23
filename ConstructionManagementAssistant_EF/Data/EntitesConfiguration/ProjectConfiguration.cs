using ConstructionManagementAssistant_Core.Constants;
using ConstructionManagementAssistant_Core.Enums;
using ConstructionManagementAssistant_EF.Extensions;

namespace ConstructionManagementAssistant_EF.Data.Configuration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(TablesNames.Projects);


            builder.Property(p => p.Name)
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.SiteAddress)
                .HasMaxLength(500);

            builder.Property(p => p.GeographicalCoordinates)
                .HasMaxLength(100);


            builder.Property(p => p.CancelationReason)
                .HasMaxLength(500);

            //builder.HasOne<Client>()
            //.WithOne()
            //.HasForeignKey<Project>(p => p.ClientId)
            //.OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<SiteEngineer>()
            //    .WithOne()
            //    .HasForeignKey<Project>(p => p.SiteEngineerId)
            //    .OnDelete(DeleteBehavior.Cascade);                 by convention EF will create a one to one relationship

            builder.AddEnumCheckConstraint<ProjectStatus>(TablesNames.Projects, nameof(Project.Status));

            // Add a check constraint to ensure that either CancelationDate or CompletionDate can have a value, but not both
            builder.HasCheckConstraint("CK_Project_CancelationCompletionDate",
                "([CancelationDate] IS NULL OR [CompletionDate] IS NULL)");

            // Add a check constraint to ensure that HandoverDate is after CompletionDate if both have values
            //builder.HasCheckConstraint("CK_Project_HandoverAfterCompletion",
            //    "([HandoverDate] IS NULL OR [CompletionDate] IS NULL OR [HandoverDate] > [CompletionDate])");

            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
