using ConstructionManagementAssistant.Core.Constants;
using ConstructionManagementAssistant.Core.Identity;
using ConstructionManagementAssistant.EF.Data.Seading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectTask = ConstructionManagementAssistant.Core.Entites.ProjectTask;

namespace ConstructionManagementAssistant.EF.Data;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    #region DbSets

    public DbSet<Person> People { get; set; }
    //public DbSet<SiteEngineer> SiteEngineers { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<WorkerSpecialty> WorkerSpecialties { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Stage> Stages { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }
    public DbSet<TaskAssignment> TaskAssignments { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<EquipmentReservation> EquipmentReservations { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    #endregion

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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

        //#region SiteEngineer Configuration
        //modelBuilder.Entity<SiteEngineer>(builder =>
        //{
        //    builder.ToTable(TablesNames.SiteEngineers);
        //    builder.HasData(SeedData.SeedSiteEngineers());

        //    builder.HasOne(e => e.User)
        //      .WithMany(a => a.SiteEngineers)
        //      .HasForeignKey(a => a.UserId)
        //      .OnDelete(DeleteBehavior.Cascade);
        //});
        //#endregion

        #region Worker Configuration
        modelBuilder.Entity<Worker>(builder =>
        {
            builder.ToTable(TablesNames.Workers);
            builder.HasData(SeedData.SeedWorkers());

            builder.HasOne(e => e.User)
              .WithMany(a => a.Workers)
              .HasForeignKey(a => a.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

        });
        #endregion

        #region WorkerSpecialty Configuration
        modelBuilder.Entity<WorkerSpecialty>(builder =>
        {
            builder.ToTable(TablesNames.WorkerSpecialties);
            builder.Property(e => e.Name).HasMaxLength(100);
            //builder.HasIndex(e => e.Name, "UniqueSpecialtyName").IsUnique(true); // could be duplicated between officess
            builder.HasData(SeedData.SeedWorkerSpecialties());

            builder.HasOne(e => e.User)
              .WithMany(a => a.WorkerSpecialties)
              .HasForeignKey(a => a.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
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

            builder.HasOne(e => e.User)
                  .WithMany(a => a.Clients)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        #endregion

        #region Project Configuration
        modelBuilder.Entity<Project>(builder =>
        {
            builder.ToTable(TablesNames.Projects, t =>
            {
                t.HasCheckConstraint(
                    "CK_Project_StatusDatesAndReason",
                    @"
                            (
                                ([Status] IN (0, 1)) AND [CompletionDate] IS NULL AND [CancelationDate] IS NULL AND [CancelationReason] IS NULL
                            )
                            OR
                            (
                                ([Status] = 2) AND [CompletionDate] IS NOT NULL AND [CancelationDate] IS NULL AND [CancelationReason] IS NULL
                            )
                            OR
                            (
                                ([Status] = 3) AND [CompletionDate] IS NULL AND [CancelationDate] IS NOT NULL AND [CancelationReason] IS NOT NULL
                            )
                        "
                );
            });

            builder.Property(p => p.Name).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.SiteAddress).HasMaxLength(500);
            builder.Property(p => p.GeographicalCoordinates).HasMaxLength(100);
            builder.Property(p => p.CancelationReason).HasMaxLength(500);
            builder.AddEnumCheckConstraint<ProjectStatus>(TablesNames.Projects, nameof(Project.Status));
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasData(SeedData.SeedProjects());


            // builder.HasOne(e => e.User)
            //.WithMany(a => a.Projects)
            //.HasForeignKey(a => a.UserId)
            //.OnDelete(DeleteBehavior.Cascade);

            // builder.HasOne(e => e.SiteEngineer)
            //.WithMany(a => a.Projects)
            //.HasForeignKey(a => a.SiteEngineerId)
            //.OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Client)
              .WithMany(a => a.Projects)
              .HasForeignKey(a => a.ClientId)
              .OnDelete(DeleteBehavior.Cascade);
        });
        #endregion

        #region Stage Configuration
        modelBuilder.Entity<Stage>(builder =>
        {
            builder.ToTable(TablesNames.Stages);
            builder.Property(s => s.Name).HasMaxLength(200);
            builder.Property(s => s.Description).HasMaxLength(1000);
            builder.HasData(SeedData.SeedStages());

            builder.HasOne(e => e.Project)
               .WithMany(a => a.Stages)
               .HasForeignKey(a => a.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        });
        #endregion

        #region Task Configuration
        modelBuilder.Entity<ProjectTask>(builder =>
        {
            builder.ToTable(TablesNames.Tasks);
            builder.Property(t => t.Name).HasMaxLength(200);
            builder.Property(t => t.Description).HasMaxLength(1000);
            builder.HasData(SeedData.SeedTasks());

            builder.HasOne(e => e.Stage)
               .WithMany(a => a.Tasks)
               .HasForeignKey(a => a.StageId)
               .OnDelete(DeleteBehavior.Cascade);
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
                .HasForeignKey(ta => ta.WorkerId).OnDelete(DeleteBehavior.NoAction);

            //builder.HasData(SeedData.SeedTaskAssignments());
        });
        #endregion

        #region Documnet Configuration
        modelBuilder.Entity<Document>(builder =>
        {
            builder.ToTable(TablesNames.Documents);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(255);
            builder.Property(e => e.Path).HasMaxLength(255);
            builder.Property(e => e.FileType).HasMaxLength(10);

            builder.HasIndex(e => e.Path, "UniquePath").IsUnique();
            builder.HasIndex(e => e.Name, "UniqueTitle").IsUnique();

            builder.HasQueryFilter(e => !e.IsDeleted);
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

            builder.HasMany(e => e.Assignments)
                .WithOne(a => a.Equipment)
                .HasForeignKey(a => a.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.User)
               .WithMany(a => a.Equipments)
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(SeedData.SeedEquipment());
        });
        #endregion

        #region EquipmentReservation Configuration
        modelBuilder.Entity<EquipmentReservation>(builder =>
        {
            builder.ToTable(TablesNames.EquipmentReservations);
            builder.HasKey(ea => ea.Id);

            builder.Property(ea => ea.StartDate).IsRequired();
            builder.Property(ea => ea.EndDate).IsRequired();

            builder.HasOne(ea => ea.Equipment)
                .WithMany(e => e.Assignments)
                .HasForeignKey(ea => ea.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ea => ea.Project)
                .WithMany(p => p.EquipmentReservations)
                .HasForeignKey(ea => ea.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasData(SeedData.SeedEquipmentReservations());



        });
        #endregion

        #region App User
        modelBuilder.Entity<AppUser>(builder =>
        {

            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).
            IsRequired(true).
            HasMaxLength(100).
            IsUnicode(true);


            builder.HasOne(e => e.BelongToUser)
           .WithMany(a => a.AppUsers)
           .HasForeignKey(a => a.BelongToUserId)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();
            builder.HasData(SeedData.SeedAppUsers());
            builder.HasData(SeedData.SeedSiteEnginners());

        });
        #endregion

        #region App Role
        modelBuilder.Entity<AppRole>(builder =>
        {
            builder.ToTable("Roles");

            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasData(SeedData.SeedRoles());
        });
        #endregion

        #region Refersh Tokens
        modelBuilder.Entity<RefreshToken>(builder =>
        {
            builder.ToTable(TablesNames.RefershToekns);
        });
        #endregion

        #region User Roles
        modelBuilder.Entity<IdentityUserRole<int>>(builder =>
        {
            builder.HasData(SeedData.SeedUserRoles());
        });
        #endregion

    }

}

