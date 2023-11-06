using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Text.Json;

public class Context : DbContext
{
    public DbSet<SmallPerson> SmallPeople { get; set; }
    public DbSet<BigPerson> BigPeople { get; set; }

    private ChangeTrackingStrategy _changeTrackingStrategy;

    public Context()
    {

    }
    public Context(ChangeTrackingStrategy changeTrackingStrategy)
    {
        _changeTrackingStrategy = changeTrackingStrategy;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Integrated Security=sspi; Initial Catalog=EfcChangeTrackingStrategies;Encrypt=false");
        //optionsBuilder.UseInMemoryDatabase("EfcChangeTrackingStrategies");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasChangeTrackingStrategy(_changeTrackingStrategy);
    }
}
