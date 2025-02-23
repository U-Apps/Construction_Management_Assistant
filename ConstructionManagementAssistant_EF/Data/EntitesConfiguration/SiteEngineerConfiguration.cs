using ConstructionManagementAssistant_Core.Constants;

namespace ConstructionManagementAssistant_EF.Data.Configuration
{
    internal class SiteEngineerConfiguration : IEntityTypeConfiguration<SiteEngineer>
    {
        public void Configure(EntityTypeBuilder<SiteEngineer> builder)
        {
            builder.ToTable(TablesNames.SiteEngineers);

            //builder.HasBaseType<Person>(); // no need, by conventions is configured

            //builder.Property(e => e.HireDate)
            //       .IsRequired();

            //builder.Property(e => e.IsAvailable)  // by convention is configured
            //       .IsRequired();
        }
    }
}
