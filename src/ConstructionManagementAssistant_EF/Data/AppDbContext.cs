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
        public DbSet<TaskAssignment> TaskAssignments { get; set; }

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

            modelBuilder.Entity<TaskAssignment>()
                .HasKey(ta => new { ta.TaskId, ta.WorkerId });

            modelBuilder.Entity<TaskAssignment>()
                .HasOne(ta => ta.Task)
                .WithMany(t => t.TaskAssignments)
                .HasForeignKey(ta => ta.TaskId);

            modelBuilder.Entity<TaskAssignment>()
                .HasOne(ta => ta.Worker)
                .WithMany(w => w.TaskAssignments)
                .HasForeignKey(ta => ta.WorkerId);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);
        }

        #endregion
    }
}

