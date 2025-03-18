using ConstructionManagementAssistant.Core.Constants;

namespace ConstructionManagementAssistant.EF.Data.Configuration
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(TablesNames.People);


            builder.Property(e => e.FirstName)
                .HasMaxLength(50);

            builder.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.ThirdName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.LastName)
                .HasMaxLength(50);

            builder.Property(e => e.NationalNumber)
                .HasMaxLength(15);


            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20);


            builder.Property(e => e.Email)
                .HasMaxLength(255);


            builder.Property(e => e.Address)
                .HasMaxLength(255);


            builder.HasIndex(e => e.NationalNumber, "UniqueNationalNumber")
                .IsUnique();


            builder.HasIndex(e => e.PhoneNumber, "UniquePhoneNumber")
                .IsUnique();

            builder.HasIndex(e => e.Email, "UniqueEmail")
                .IsUnique();

            //builder.UseTptMappingStrategy(); // by convention used

            // Global filter to exclude deleted clients
            builder.HasQueryFilter(e => !e.IsDeleted);



        }
    }
}
