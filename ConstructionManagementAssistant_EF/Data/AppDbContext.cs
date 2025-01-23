using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_EF.Data.Configuration;
namespace ConstructionManagementAssistant_EF.Data
{
    internal class AppDbContext:DbContext
    {
        public DbSet<Client> clients { get; set; }
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");



            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);

        }

    }
}
