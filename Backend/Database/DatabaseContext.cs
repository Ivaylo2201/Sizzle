using Microsoft.EntityFrameworkCore;

namespace Backend.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    // public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new ProductConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}