using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class Context : DbContext
{
    public DbSet<Person> People { get; set; }

    private ChangeTrackingStrategy _changeTrackingStrategy;

    public Context(ChangeTrackingStrategy changeTrackingStrategy)
    {
        _changeTrackingStrategy = changeTrackingStrategy;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("EfcChangeTrackingStrategies");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasChangeTrackingStrategy(_changeTrackingStrategy);
    }
}

public class Person : INotifyPropertyChanged, INotifyPropertyChanging
{
    private long _id;

    public long Id
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                this.OnPropertyChanging();
                this._id = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _fullName;

    public string? FullName
    {
        get => _fullName;
        set
        {

            if (_fullName != value)
            {
                this.OnPropertyChanging();
                this._fullName = value;
                this.OnPropertyChanged();
            }
        }
    }

    public event PropertyChangingEventHandler? PropertyChanging;
    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void OnPropertyChanging([CallerMemberName] string? propertyName = null)
    {
        if (PropertyChanging != null)
        {
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

public static class PocoLoadingExtensions
{
    public static ICollection<TRelated> Load<TRelated>(
        this Action<object, string> loader,
        object entity,
        ref ICollection<TRelated> navigationField,
        [CallerMemberName] string navigationName = "")
        where TRelated : class
    {
        loader?.Invoke(entity, navigationName);
        navigationField ??= new ObservableCollection<TRelated>();

        return navigationField;
    }
}