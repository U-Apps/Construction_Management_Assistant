
using ConstructionManagementAssistant_Core.Entites;

namespace ConstructionManagementAssistant_EF.Data.Configuration
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(e => e.ThirdName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(false);

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(e => e.NationalNumber)
                .HasColumnName("NationalNumber")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);



            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(true);


            builder.HasIndex(e => e.NationalNumber, "UniqueNationalNumber")
                .IsUnique();


            builder.HasIndex(e => e.PhoneNumber, "UniquePhoneNumber")
                .IsUnique();

            builder.HasIndex(e => e.Email, "UniqueEmail")
                .IsUnique();

            builder.UseTptMappingStrategy();



        }
    }
}
