using ConstructionManagementAssistant_Core.Entites;

namespace ConstructionManagementAssistant_EF.Configurations;
internal class WorkerSpecialtyConfiguration : IEntityTypeConfiguration<WorkerSpecialty>
{
    public void Configure(EntityTypeBuilder<WorkerSpecialty> builder)
    {
        builder.ToTable("WorkerSpecialties");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
        .HasColumnName("Name")
        .HasMaxLength(100)
        .IsUnicode(true)
        .IsRequired(true);

        builder.HasIndex(e => e.Name, "UniqueSpecialtyName")
        .IsUnique(true);

        builder.HasQueryFilter(e => !e.IsDeleted);

    }
}