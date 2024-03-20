using api.Department.Model;
using api.Employee.Model;
using api.Model;
using api.Site.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Database;
public class ApplicationContext : DbContext
{
    public DbSet<EmployeeModel> Employees { get; set; }
    public DbSet<DepartmentModel> Departments { get; set; }
    public DbSet<SiteModel> Sites { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    // <summary>
    // Override OnModelCreating to configure seeding and enums to string 
    // </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentModel>().HasData(
            new DepartmentModel { Id = 1, Name = "Development", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new DepartmentModel { Id = 2, Name = "Marketing", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new DepartmentModel { Id = 3, Name = "Commercial", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        );

        modelBuilder.Entity<SiteModel>().HasData(
            new SiteModel { Id = 1, City = "Paris", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new SiteModel { Id = 2, City = "Nantes", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new SiteModel { Id = 3, City = "Toulouse", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new SiteModel { Id = 4, City = "Nice", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new SiteModel { Id = 5, City = "Lile", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        );

        modelBuilder.Entity<EmployeeModel>().HasData(
            new EmployeeModel { Id = 1, Firstname = "John", Lastname = "Doe", HomePhone = "0123456789", CellPhone = "0123456789", Email = "john@doe.com", DepartmentId = 1, SiteId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new EmployeeModel { Id = 2, Firstname = "Jane", Lastname = "Smith", HomePhone = "9876543210", CellPhone = "9876543210", Email = "jane@smith.com", DepartmentId = 2, SiteId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new EmployeeModel { Id = 3, Firstname = "Michael", Lastname = "Johnson", HomePhone = "1234567890", CellPhone = "1234567890", Email = "michael@johnson.com", DepartmentId = 3, SiteId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        );
    }



    // <summary>
    // Override SaveChangesAsync to update timestamps before saving changes
    // </summary>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }


    // <summary>
    // Override SaveChangesAsync to update timestamps before saving changes
    // </summary>
    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    // <summary>
    // Update timestamps for entities that inherit from BaseModel
    // When entity is added it will set CreatedAt and UpdatedAt to DateTime.Now
    // When entity is modified it will set UpdatedAt to DateTime.Now
    // </summary>
    private void UpdateTimestamps()
    {
        // Get all entities that inherit from BaseModel
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

        // Update timestamps
        foreach (var entityEntry in entities)
        {
            ((BaseModel)entityEntry.Entity).UpdatedAt = DateTime.Now;

            // Set CreatedAt only when entity is added
            if (entityEntry.State == EntityState.Added)
            {
                ((BaseModel)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
        }

    }




}