using ConstructionManagementAssistant_Core.Constants;
using ConstructionManagementAssistant_Core.Enums;
using ConstructionManagementAssistant_EF.Extensions;

namespace ConstructionManagementAssistant_EF.Data.Configuration
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(TablesNames.Clients);


            builder.Property(e => e.FullName)
                .HasMaxLength(100);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .HasMaxLength(255);


            builder.HasIndex(e => e.PhoneNumber, "UniquePhoneNumber")
                .HasFilter("[IsDeleted] = 0") // Ensures uniqueness only for active records
                .IsUnique();

            builder.HasIndex(e => e.Email, "UniqueEmail")
                .HasFilter("[IsDeleted] = 0") // Ensures uniqueness only for active records
                .IsUnique();

            builder.AddEnumCheckConstraint<ClientType>(TablesNames.Clients, nameof(Client.ClientType));

            // Global filter to exclude deleted clients
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
