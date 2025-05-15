using ConstructionManagementAssistant.Core.Constants;

namespace ConstructionManagementAssistant.EF.Data.Configuration
{
    internal class DocumentClassificationConfiguration : IEntityTypeConfiguration<DocumentClassification>
    {
        public void Configure(EntityTypeBuilder<DocumentClassification> builder)
        {
            builder.ToTable(TablesNames.DocumentClassification);

            builder.HasKey(t => t.Id);

            builder.Property(e => e.DocumentType)
                .HasMaxLength(50);

            builder.HasMany(x => x.Documnets).WithOne(x => x.Classification).HasForeignKey(x => x.ClassificationId);

            builder.HasIndex(e => e.DocumentType, "UniqueType")
                .IsUnique();
        }
    }
}
