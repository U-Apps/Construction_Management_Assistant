using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Enums;
using ConstructionManagementAssistant_EF.Extentions;

namespace ConstructionManagementAssistant_EF.Data.Configuration
{
    internal class SiteEngineerConfiguration : IEntityTypeConfiguration<SiteEngineer>
    {
        public void Configure(EntityTypeBuilder<SiteEngineer> builder)
        {
            builder.ToTable("SiteEngineers");

            builder.HasBaseType<Person>();

            builder.Property(e => e.HireDate)
                   .IsRequired();

            builder.Property(e => e.IsAvailable)
                   .IsRequired();
        }
    }
}
