using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

public interface IContext
{
    DbSet<SmallPerson> SmallPeople { get; }
    ChangeTracker ChangeTracker { get; }
    DatabaseFacade Database { get; }
    int SaveChanges();
}

public class SnapshotContext : DbContext, IContext
{
    public DbSet<SmallPerson> SmallPeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=db.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.Snapshot);
    }
}

public class ChangingAndChangedNotificationsContext : DbContext, IContext
{
    public DbSet<SmallPerson> SmallPeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=db.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications);
    }
}

public class ChangedNotificationsContext : DbContext, IContext
{
    public DbSet<SmallPerson> SmallPeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=db.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
    }
}

public class ChangingAndChangedNotificationsWithOriginalValuesContext : DbContext, IContext
{
    public DbSet<SmallPerson> SmallPeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=db.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
    }
}
