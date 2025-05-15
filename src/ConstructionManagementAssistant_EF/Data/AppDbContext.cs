using ConstructionManagementAssistant.Core.Constants;
using ConstructionManagementAssistant.EF.Data.Seading;
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
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<Documnet> Documnets { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentAssignment> EquipmentAssignments { get; set; }
        #endregion

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

            #region Person Configuration
            modelBuilder.Entity<Person>(builder =>
            {
                builder.ToTable(TablesNames.People);

                builder.Property(e => e.FirstName).HasMaxLength(50);
                builder.Property(e => e.SecondName).HasMaxLength(50).IsRequired(false);
                builder.Property(e => e.ThirdName).HasMaxLength(50).IsRequired(false);
                builder.Property(e => e.LastName).HasMaxLength(50);
                builder.Property(e => e.NationalNumber).HasMaxLength(15);
                builder.Property(e => e.PhoneNumber).HasMaxLength(20);
                builder.Property(e => e.Email).HasMaxLength(255);
                builder.Property(e => e.Address).HasMaxLength(255);

                builder.HasIndex(e => e.NationalNumber, "UniqueNationalNumber").IsUnique();
                builder.HasIndex(e => e.PhoneNumber, "UniquePhoneNumber").IsUnique();
                builder.HasIndex(e => e.Email, "UniqueEmail").IsUnique();

                builder.HasQueryFilter(e => !e.IsDeleted);
            });
            #endregion

            #region SiteEngineer Configuration
            modelBuilder.Entity<SiteEngineer>(builder =>
            {
                builder.ToTable(TablesNames.SiteEngineers);
                builder.HasData(SeedData.SeedSiteEngineers());
            });
            #endregion

            #region Worker Configuration
            modelBuilder.Entity<Worker>(builder =>
            {
                builder.ToTable(TablesNames.Workers);
                builder.HasData(SeedData.SeedWorkers());
            });
            #endregion

            #region WorkerSpecialty Configuration
            modelBuilder.Entity<WorkerSpecialty>(builder =>
            {
                builder.ToTable(TablesNames.WorkerSpecialties);
                builder.Property(e => e.Name).HasMaxLength(100);
                builder.HasIndex(e => e.Name, "UniqueSpecialtyName").IsUnique(true);
                builder.HasData(SeedData.SeedWorkerSpecialties());
            });
            #endregion

            #region Client Configuration
            modelBuilder.Entity<Client>(builder =>
            {
                builder.ToTable(TablesNames.Clients);
                builder.Property(e => e.FullName).HasMaxLength(100);
                builder.Property(e => e.PhoneNumber).HasMaxLength(20);
                builder.Property(e => e.Email).HasMaxLength(255);
                builder.HasIndex(e => e.PhoneNumber, "UniquePhoneNumber").IsUnique();
                builder.HasIndex(e => e.Email, "UniqueEmail").IsUnique();
                builder.AddEnumCheckConstraint<ClientType>(TablesNames.Clients, nameof(Client.ClientType));
                builder.HasQueryFilter(e => !e.IsDeleted);
                builder.HasData(SeedData.SeedClients());
            });
            #endregion

            #region Project Configuration
            modelBuilder.Entity<Project>(builder =>
            {
                builder.ToTable(TablesNames.Projects, t =>
                {
                    t.HasCheckConstraint("CK_Project_CancelationCompletionDate", "[CancelationDate] IS NULL OR [CompletionDate] IS NULL");
                });

                builder.Property(p => p.Name).HasMaxLength(200);
                builder.Property(p => p.Description).HasMaxLength(1000);
                builder.Property(p => p.SiteAddress).HasMaxLength(500);
                builder.Property(p => p.GeographicalCoordinates).HasMaxLength(100);
                builder.Property(p => p.CancelationReason).HasMaxLength(500);
                builder.AddEnumCheckConstraint<ProjectStatus>(TablesNames.Projects, nameof(Project.Status));
                builder.HasQueryFilter(e => !e.IsDeleted);
                builder.HasData(SeedData.SeedProjects());
            });
            #endregion

            #region Stage Configuration
            modelBuilder.Entity<Stage>(builder =>
            {
                builder.ToTable(TablesNames.Stages);
                builder.Property(s => s.Name).HasMaxLength(200);
                builder.Property(s => s.Description).HasMaxLength(1000);
                builder.HasData(SeedData.SeedStages());
            });
            #endregion

            #region Task Configuration
            modelBuilder.Entity<Task>(builder =>
            {
                builder.ToTable(TablesNames.Tasks);
                builder.Property(t => t.Name).HasMaxLength(200);
                builder.Property(t => t.Description).HasMaxLength(1000);
                builder.HasData(SeedData.SeedTasks());
            });
            #endregion

            #region TaskAssignment Configuration
            modelBuilder.Entity<TaskAssignment>(builder =>
            {
                builder.HasKey(ta => new { ta.TaskId, ta.WorkerId });

                builder.HasOne(ta => ta.Task)
                    .WithMany(t => t.TaskAssignments)
                    .HasForeignKey(ta => ta.TaskId);

                builder.HasOne(ta => ta.Worker)
                    .WithMany(w => w.TaskAssignments)
                    .HasForeignKey(ta => ta.WorkerId);

                //builder.HasData(SeedData.SeedTaskAssignments());
            });
            #endregion

            #region Documnet Configuration
            modelBuilder.Entity<Documnet>(builder =>
            {
                builder.ToTable(TablesNames.Documents);
                builder.Property(e => e.Name).HasMaxLength(50);
                builder.Property(e => e.Description).HasMaxLength(255);
                builder.Property(e => e.Path).HasMaxLength(255);

                builder.HasIndex(e => e.Path, "UniquePath").IsUnique();
                builder.HasIndex(e => e.Name, "UniqueTitle").IsUnique();
            });
            #endregion

            #region DocumentClassification Configuration
            modelBuilder.Entity<DocumentClassification>(builder =>
            {
                builder.ToTable(TablesNames.DocumentClassification);
                builder.Property(e => e.Type).HasMaxLength(50);
                builder.HasIndex(e => e.Type, "UniqueType").IsUnique();
                builder.HasData(SeedData.SeedDocumentClassifications());
            });
            #endregion

            #region Equipment Configuration
            modelBuilder.Entity<Equipment>(builder =>
            {
                builder.ToTable(TablesNames.Equipments);
                builder.Property(e => e.Name).HasMaxLength(100);
                builder.Property(e => e.Model).HasMaxLength(100);
                builder.Property(e => e.SerialNumber).HasMaxLength(100);
                builder.Property(e => e.Notes).HasMaxLength(1000);
                builder.AddEnumCheckConstraint<EquipmentStatus>(TablesNames.Equipments, nameof(Equipment.Status));

                builder.HasMany(e => e.Assignments)
                    .WithOne(a => a.Equipment)
                    .HasForeignKey(a => a.EquipmentId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasData(SeedData.SeedEquipment());
            });
            #endregion

            #region EquipmentAssignment Configuration
            modelBuilder.Entity<EquipmentAssignment>(builder =>
            {
                builder.ToTable(TablesNames.EquipmentAssignments);
                builder.HasKey(ea => ea.Id);

                builder.Property(ea => ea.BookDate).IsRequired();
                builder.Property(ea => ea.ExpectedReturnDate).IsRequired();

                builder.HasOne(ea => ea.Equipment)
                    .WithMany(e => e.Assignments)
                    .HasForeignKey(ea => ea.EquipmentId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(ea => ea.Project)
                    .WithMany(p => p.EquipmentAssignments)
                    .HasForeignKey(ea => ea.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                //builder.HasData(SeedData.SeedEquipmentAssignments());

            });
            #endregion
        }

    }
}

