﻿using ConstructionManagementAssistant_Core.Constants;

namespace ConstructionManagementAssistant_EF.Configurations;
internal class WorkerSpecialtyConfiguration : IEntityTypeConfiguration<WorkerSpecialty>
{
    public void Configure(EntityTypeBuilder<WorkerSpecialty> builder)
    {
        builder.ToTable(TablesNames.WorkerSpecialties);


        builder.Property(e => e.Name)
        .HasMaxLength(100);

        builder.HasIndex(e => e.Name, "UniqueSpecialtyName")
        .IsUnique(true);

        builder.HasQueryFilter(e => !e.IsDeleted);

    }
}