using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=WorkerSystemDb;Username=postgres;Password=Tala2005");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>().HasKey(w => w.WorkerId);
    }
}