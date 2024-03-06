using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.database;
public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Site> Sites { get; set; }

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
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Development" },
            new Service { Id = 2, Name = "Marketing" },
            new Service { Id = 3, Name = "Commercial" }
        );

        modelBuilder.Entity<Site>().HasData(
            new Site { Id = 1, City = "Paris" },
            new Site { Id = 2, City = "Nantes" },
            new Site { Id = 3, City = "Toulouse" },
            new Site { Id = 4, City = "Nice" },
            new Site { Id = 5, City = "Lile" }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Firstname = "John", Lastname = "Doe", HomePhone = "0123456789", CellPhone = "0123456789", Email = "john@doe.com", ServiceId = 1, SiteId = 1 },
            new Employee { Id = 2, Firstname = "Jane", Lastname = "Smith", HomePhone = "9876543210", CellPhone = "9876543210", Email = "jane@smith.com", ServiceId = 2, SiteId = 2 },
            new Employee { Id = 3, Firstname = "Michael", Lastname = "Johnson", HomePhone = "1234567890", CellPhone = "1234567890", Email = "michael@johnson.com", ServiceId = 3, SiteId = 3 }
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