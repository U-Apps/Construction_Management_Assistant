using ConstructionManagementAssistant_Core;
using ConstructionManagementAssistant_Core.Entites;

namespace ConstructionManagementAssistant_EF.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.ToTable("Workers");

        builder.Property(w => w.IsAvailable)
        .HasColumnName("IsAvailable")
        .IsRequired(true);

        builder.Property(w => w.SpecialtyId)
        .HasColumnName("SpecialtyId")
        .IsRequired(false);

        builder.HasOne(w => w.Specialty)
        .WithMany()
        .HasForeignKey(w => w.SpecialtyId)
        .IsRequired(false)
        .OnDelete(DeleteBehavior.SetNull);
    }
}
