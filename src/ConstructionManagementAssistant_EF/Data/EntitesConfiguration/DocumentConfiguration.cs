using ConstructionManagementAssistant.Core.Constants;

namespace ConstructionManagementAssistant.EF.Data.Configuration
{
    internal class DocumentConfiguration : IEntityTypeConfiguration<Documnet>
    {
        public void Configure(EntityTypeBuilder<Documnet> builder)
        {
            builder.ToTable(TablesNames.Documents);

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Title)
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasMaxLength(255);

            builder.Property(e => e.Path)
                .HasMaxLength(255);

            builder.HasOne(x => x.Classification).WithMany(x => x.Documnets).HasForeignKey(x => x.ClassificationId);
            builder.HasOne(x => x.Project).WithMany(x => x.Documents).HasForeignKey(x => x.ProjectId);
            builder.HasOne(x => x.Task).WithMany(x => x.Documents).HasForeignKey(x => x.TaskId);

            builder.HasIndex(e => e.Path, "UniquePath")
                .IsUnique();
            builder.HasIndex(e => e.Title, "UniqueTitle")
                .IsUnique();
        }
    }
}
