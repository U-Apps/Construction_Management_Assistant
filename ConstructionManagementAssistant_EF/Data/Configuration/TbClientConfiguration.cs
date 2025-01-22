using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant_EF.Data.Configuration
{
    internal class TbClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("tbClient");

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

            builder.Property(c => c.ClientType)
                .HasConversion<string>();


            builder.HasIndex(e => e.PhoneNumber, "UniquePhoneNumber")
                .IsUnique();

            builder.HasIndex(e => e.Email, "UniqueEmail")
                .IsUnique();
        }
    }
}
