using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Enums;
using ConstructionManagementAssistant_EF.Extentions;

namespace ConstructionManagementAssistant_EF.Data.Configuration
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FullName)
                .HasMaxLength(30)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.ClientType)
                .IsRequired();

            builder.HasIndex(e => e.PhoneNumber, "UniquePhoneNumber")
                .IsUnique();

            builder.HasIndex(e => e.Email, "UniqueEmail")
                .IsUnique();

            builder.AddEnumCheckConstraint<ClientType>("Client", "ClientType");

            // Global filter to exclude deleted clients
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
