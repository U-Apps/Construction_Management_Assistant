using Task = ConstructionManagementAssistant.Core.Entites.Task;

namespace ConstructionManagementAssistant.EF.Data
{
    public class AppDbContext : DbContext
    {
        #region DbSets

        public DbSet<Person> People { get; set; }
        public DbSet<SiteEngineer> SiteEngineers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerSpecialty> WorkerSpecialties { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Task> Tasks { get; set; }


        #endregion

        #region Constructors

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);
        }

        #endregion
    }
}

