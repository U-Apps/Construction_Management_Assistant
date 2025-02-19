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
