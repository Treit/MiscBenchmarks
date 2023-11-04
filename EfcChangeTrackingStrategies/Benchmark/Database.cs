using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

public class SmallPerson : INotifyPropertyChanged, INotifyPropertyChanging
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

    private bool _isInit;

    public bool IsInit
    {
        get => _isInit;
        set
        {

            if (_isInit != value)
            {
                this.OnPropertyChanging();
                this._isInit = value;
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

public class BigPerson : INotifyPropertyChanged, INotifyPropertyChanging
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

    private bool _isInit;

    public bool IsInit
    {
        get => _isInit;
        set
        {

            if (_isInit != value)
            {
                this.OnPropertyChanging();
                this._isInit = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property1;

    public string? Property1
    {
        get => _property1;
        set
        {
            if (_property1 != value)
            {
                this.OnPropertyChanging();
                this._property1 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property2;

    public string? Property2
    {
        get => _property2;
        set
        {
            if (_property2 != value)
            {
                this.OnPropertyChanging();
                this._property2 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property3;

    public string? Property3
    {
        get => _property3;
        set
        {
            if (_property3 != value)
            {
                this.OnPropertyChanging();
                this._property3 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property4;

    public string? Property4
    {
        get => _property4;
        set
        {
            if (_property4 != value)
            {
                this.OnPropertyChanging();
                this._property4 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property5;

    public string? Property5
    {
        get => _property5;
        set
        {
            if (_property5 != value)
            {
                this.OnPropertyChanging();
                this._property5 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property6;

    public string? Property6
    {
        get => _property6;
        set
        {
            if (_property6 != value)
            {
                this.OnPropertyChanging();
                this._property6 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property7;

    public string? Property7
    {
        get => _property7;
        set
        {
            if (_property7 != value)
            {
                this.OnPropertyChanging();
                this._property7 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property8;

    public string? Property8
    {
        get => _property8;
        set
        {
            if (_property8 != value)
            {
                this.OnPropertyChanging();
                this._property8 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property9;

    public string? Property9
    {
        get => _property9;
        set
        {
            if (_property9 != value)
            {
                this.OnPropertyChanging();
                this._property9 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property10;

    public string? Property10
    {
        get => _property10;
        set
        {
            if (_property10 != value)
            {
                this.OnPropertyChanging();
                this._property10 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property11;

    public string? Property11
    {
        get => _property11;
        set
        {
            if (_property11 != value)
            {
                this.OnPropertyChanging();
                this._property11 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property12;

    public string? Property12
    {
        get => _property12;
        set
        {
            if (_property12 != value)
            {
                this.OnPropertyChanging();
                this._property12 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property13;

    public string? Property13
    {
        get => _property13;
        set
        {
            if (_property13 != value)
            {
                this.OnPropertyChanging();
                this._property13 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property14;

    public string? Property14
    {
        get => _property14;
        set
        {
            if (_property14 != value)
            {
                this.OnPropertyChanging();
                this._property14 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property15;

    public string? Property15
    {
        get => _property15;
        set
        {
            if (_property15 != value)
            {
                this.OnPropertyChanging();
                this._property15 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property16;

    public string? Property16
    {
        get => _property16;
        set
        {
            if (_property16 != value)
            {
                this.OnPropertyChanging();
                this._property16 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property17;

    public string? Property17
    {
        get => _property17;
        set
        {
            if (_property17 != value)
            {
                this.OnPropertyChanging();
                this._property17 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property18;

    public string? Property18
    {
        get => _property18;
        set
        {
            if (_property18 != value)
            {
                this.OnPropertyChanging();
                this._property18 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property19;

    public string? Property19
    {
        get => _property19;
        set
        {
            if (_property19 != value)
            {
                this.OnPropertyChanging();
                this._property19 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property20;

    public string? Property20
    {
        get => _property20;
        set
        {
            if (_property20 != value)
            {
                this.OnPropertyChanging();
                this._property20 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property21;

    public string? Property21
    {
        get => _property21;
        set
        {
            if (_property21 != value)
            {
                this.OnPropertyChanging();
                this._property21 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property22;

    public string? Property22
    {
        get => _property22;
        set
        {
            if (_property22 != value)
            {
                this.OnPropertyChanging();
                this._property22 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property23;

    public string? Property23
    {
        get => _property23;
        set
        {
            if (_property23 != value)
            {
                this.OnPropertyChanging();
                this._property23 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property24;

    public string? Property24
    {
        get => _property24;
        set
        {
            if (_property24 != value)
            {
                this.OnPropertyChanging();
                this._property24 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property25;

    public string? Property25
    {
        get => _property25;
        set
        {
            if (_property25 != value)
            {
                this.OnPropertyChanging();
                this._property25 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property26;

    public string? Property26
    {
        get => _property26;
        set
        {
            if (_property26 != value)
            {
                this.OnPropertyChanging();
                this._property26 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property27;

    public string? Property27
    {
        get => _property27;
        set
        {
            if (_property27 != value)
            {
                this.OnPropertyChanging();
                this._property27 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property28;

    public string? Property28
    {
        get => _property28;
        set
        {
            if (_property28 != value)
            {
                this.OnPropertyChanging();
                this._property28 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property29;

    public string? Property29
    {
        get => _property29;
        set
        {
            if (_property29 != value)
            {
                this.OnPropertyChanging();
                this._property29 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property30;

    public string? Property30
    {
        get => _property30;
        set
        {
            if (_property30 != value)
            {
                this.OnPropertyChanging();
                this._property30 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property31;

    public string? Property31
    {
        get => _property31;
        set
        {
            if (_property31 != value)
            {
                this.OnPropertyChanging();
                this._property31 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property32;

    public string? Property32
    {
        get => _property32;
        set
        {
            if (_property32 != value)
            {
                this.OnPropertyChanging();
                this._property32 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property33;

    public string? Property33
    {
        get => _property33;
        set
        {
            if (_property33 != value)
            {
                this.OnPropertyChanging();
                this._property33 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property34;

    public string? Property34
    {
        get => _property34;
        set
        {
            if (_property34 != value)
            {
                this.OnPropertyChanging();
                this._property34 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property35;

    public string? Property35
    {
        get => _property35;
        set
        {
            if (_property35 != value)
            {
                this.OnPropertyChanging();
                this._property35 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property36;

    public string? Property36
    {
        get => _property36;
        set
        {
            if (_property36 != value)
            {
                this.OnPropertyChanging();
                this._property36 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property37;

    public string? Property37
    {
        get => _property37;
        set
        {
            if (_property37 != value)
            {
                this.OnPropertyChanging();
                this._property37 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property38;

    public string? Property38
    {
        get => _property38;
        set
        {
            if (_property38 != value)
            {
                this.OnPropertyChanging();
                this._property38 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property39;

    public string? Property39
    {
        get => _property39;
        set
        {
            if (_property39 != value)
            {
                this.OnPropertyChanging();
                this._property39 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property40;

    public string? Property40
    {
        get => _property40;
        set
        {
            if (_property40 != value)
            {
                this.OnPropertyChanging();
                this._property40 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property41;

    public string? Property41
    {
        get => _property41;
        set
        {
            if (_property41 != value)
            {
                this.OnPropertyChanging();
                this._property41 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property42;

    public string? Property42
    {
        get => _property42;
        set
        {
            if (_property42 != value)
            {
                this.OnPropertyChanging();
                this._property42 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property43;

    public string? Property43
    {
        get => _property43;
        set
        {
            if (_property43 != value)
            {
                this.OnPropertyChanging();
                this._property43 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property44;

    public string? Property44
    {
        get => _property44;
        set
        {
            if (_property44 != value)
            {
                this.OnPropertyChanging();
                this._property44 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property45;

    public string? Property45
    {
        get => _property45;
        set
        {
            if (_property45 != value)
            {
                this.OnPropertyChanging();
                this._property45 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property46;

    public string? Property46
    {
        get => _property46;
        set
        {
            if (_property46 != value)
            {
                this.OnPropertyChanging();
                this._property46 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property47;

    public string? Property47
    {
        get => _property47;
        set
        {
            if (_property47 != value)
            {
                this.OnPropertyChanging();
                this._property47 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property48;

    public string? Property48
    {
        get => _property48;
        set
        {
            if (_property48 != value)
            {
                this.OnPropertyChanging();
                this._property48 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property49;

    public string? Property49
    {
        get => _property49;
        set
        {
            if (_property49 != value)
            {
                this.OnPropertyChanging();
                this._property49 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property50;

    public string? Property50
    {
        get => _property50;
        set
        {
            if (_property50 != value)
            {
                this.OnPropertyChanging();
                this._property50 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property51;

    public string? Property51
    {
        get => _property51;
        set
        {
            if (_property51 != value)
            {
                this.OnPropertyChanging();
                this._property51 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property52;

    public string? Property52
    {
        get => _property52;
        set
        {
            if (_property52 != value)
            {
                this.OnPropertyChanging();
                this._property52 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property53;

    public string? Property53
    {
        get => _property53;
        set
        {
            if (_property53 != value)
            {
                this.OnPropertyChanging();
                this._property53 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property54;

    public string? Property54
    {
        get => _property54;
        set
        {
            if (_property54 != value)
            {
                this.OnPropertyChanging();
                this._property54 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property55;

    public string? Property55
    {
        get => _property55;
        set
        {
            if (_property55 != value)
            {
                this.OnPropertyChanging();
                this._property55 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property56;

    public string? Property56
    {
        get => _property56;
        set
        {
            if (_property56 != value)
            {
                this.OnPropertyChanging();
                this._property56 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property57;

    public string? Property57
    {
        get => _property57;
        set
        {
            if (_property57 != value)
            {
                this.OnPropertyChanging();
                this._property57 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property58;

    public string? Property58
    {
        get => _property58;
        set
        {
            if (_property58 != value)
            {
                this.OnPropertyChanging();
                this._property58 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property59;

    public string? Property59
    {
        get => _property59;
        set
        {
            if (_property59 != value)
            {
                this.OnPropertyChanging();
                this._property59 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property60;

    public string? Property60
    {
        get => _property60;
        set
        {
            if (_property60 != value)
            {
                this.OnPropertyChanging();
                this._property60 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property61;

    public string? Property61
    {
        get => _property61;
        set
        {
            if (_property61 != value)
            {
                this.OnPropertyChanging();
                this._property61 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property62;

    public string? Property62
    {
        get => _property62;
        set
        {
            if (_property62 != value)
            {
                this.OnPropertyChanging();
                this._property62 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property63;

    public string? Property63
    {
        get => _property63;
        set
        {
            if (_property63 != value)
            {
                this.OnPropertyChanging();
                this._property63 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property64;

    public string? Property64
    {
        get => _property64;
        set
        {
            if (_property64 != value)
            {
                this.OnPropertyChanging();
                this._property64 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property65;

    public string? Property65
    {
        get => _property65;
        set
        {
            if (_property65 != value)
            {
                this.OnPropertyChanging();
                this._property65 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property66;

    public string? Property66
    {
        get => _property66;
        set
        {
            if (_property66 != value)
            {
                this.OnPropertyChanging();
                this._property66 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property67;

    public string? Property67
    {
        get => _property67;
        set
        {
            if (_property67 != value)
            {
                this.OnPropertyChanging();
                this._property67 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property68;

    public string? Property68
    {
        get => _property68;
        set
        {
            if (_property68 != value)
            {
                this.OnPropertyChanging();
                this._property68 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property69;

    public string? Property69
    {
        get => _property69;
        set
        {
            if (_property69 != value)
            {
                this.OnPropertyChanging();
                this._property69 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property70;

    public string? Property70
    {
        get => _property70;
        set
        {
            if (_property70 != value)
            {
                this.OnPropertyChanging();
                this._property70 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property71;

    public string? Property71
    {
        get => _property71;
        set
        {
            if (_property71 != value)
            {
                this.OnPropertyChanging();
                this._property71 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property72;

    public string? Property72
    {
        get => _property72;
        set
        {
            if (_property72 != value)
            {
                this.OnPropertyChanging();
                this._property72 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property73;

    public string? Property73
    {
        get => _property73;
        set
        {
            if (_property73 != value)
            {
                this.OnPropertyChanging();
                this._property73 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property74;

    public string? Property74
    {
        get => _property74;
        set
        {
            if (_property74 != value)
            {
                this.OnPropertyChanging();
                this._property74 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property75;

    public string? Property75
    {
        get => _property75;
        set
        {
            if (_property75 != value)
            {
                this.OnPropertyChanging();
                this._property75 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property76;

    public string? Property76
    {
        get => _property76;
        set
        {
            if (_property76 != value)
            {
                this.OnPropertyChanging();
                this._property76 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property77;

    public string? Property77
    {
        get => _property77;
        set
        {
            if (_property77 != value)
            {
                this.OnPropertyChanging();
                this._property77 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property78;

    public string? Property78
    {
        get => _property78;
        set
        {
            if (_property78 != value)
            {
                this.OnPropertyChanging();
                this._property78 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property79;

    public string? Property79
    {
        get => _property79;
        set
        {
            if (_property79 != value)
            {
                this.OnPropertyChanging();
                this._property79 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property80;

    public string? Property80
    {
        get => _property80;
        set
        {
            if (_property80 != value)
            {
                this.OnPropertyChanging();
                this._property80 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property81;

    public string? Property81
    {
        get => _property81;
        set
        {
            if (_property81 != value)
            {
                this.OnPropertyChanging();
                this._property81 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property82;

    public string? Property82
    {
        get => _property82;
        set
        {
            if (_property82 != value)
            {
                this.OnPropertyChanging();
                this._property82 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property83;

    public string? Property83
    {
        get => _property83;
        set
        {
            if (_property83 != value)
            {
                this.OnPropertyChanging();
                this._property83 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property84;

    public string? Property84
    {
        get => _property84;
        set
        {
            if (_property84 != value)
            {
                this.OnPropertyChanging();
                this._property84 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property85;

    public string? Property85
    {
        get => _property85;
        set
        {
            if (_property85 != value)
            {
                this.OnPropertyChanging();
                this._property85 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property86;

    public string? Property86
    {
        get => _property86;
        set
        {
            if (_property86 != value)
            {
                this.OnPropertyChanging();
                this._property86 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property87;

    public string? Property87
    {
        get => _property87;
        set
        {
            if (_property87 != value)
            {
                this.OnPropertyChanging();
                this._property87 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property88;

    public string? Property88
    {
        get => _property88;
        set
        {
            if (_property88 != value)
            {
                this.OnPropertyChanging();
                this._property88 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property89;

    public string? Property89
    {
        get => _property89;
        set
        {
            if (_property89 != value)
            {
                this.OnPropertyChanging();
                this._property89 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property90;

    public string? Property90
    {
        get => _property90;
        set
        {
            if (_property90 != value)
            {
                this.OnPropertyChanging();
                this._property90 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property91;

    public string? Property91
    {
        get => _property91;
        set
        {
            if (_property91 != value)
            {
                this.OnPropertyChanging();
                this._property91 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property92;

    public string? Property92
    {
        get => _property92;
        set
        {
            if (_property92 != value)
            {
                this.OnPropertyChanging();
                this._property92 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property93;

    public string? Property93
    {
        get => _property93;
        set
        {
            if (_property93 != value)
            {
                this.OnPropertyChanging();
                this._property93 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property94;

    public string? Property94
    {
        get => _property94;
        set
        {
            if (_property94 != value)
            {
                this.OnPropertyChanging();
                this._property94 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property95;

    public string? Property95
    {
        get => _property95;
        set
        {
            if (_property95 != value)
            {
                this.OnPropertyChanging();
                this._property95 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property96;

    public string? Property96
    {
        get => _property96;
        set
        {
            if (_property96 != value)
            {
                this.OnPropertyChanging();
                this._property96 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property97;

    public string? Property97
    {
        get => _property97;
        set
        {
            if (_property97 != value)
            {
                this.OnPropertyChanging();
                this._property97 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property98;

    public string? Property98
    {
        get => _property98;
        set
        {
            if (_property98 != value)
            {
                this.OnPropertyChanging();
                this._property98 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property99;

    public string? Property99
    {
        get => _property99;
        set
        {
            if (_property99 != value)
            {
                this.OnPropertyChanging();
                this._property99 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property100;

    public string? Property100
    {
        get => _property100;
        set
        {
            if (_property100 != value)
            {
                this.OnPropertyChanging();
                this._property100 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property101;

    public string? Property101
    {
        get => _property101;
        set
        {
            if (_property101 != value)
            {
                this.OnPropertyChanging();
                this._property101 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property102;

    public string? Property102
    {
        get => _property102;
        set
        {
            if (_property102 != value)
            {
                this.OnPropertyChanging();
                this._property102 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property103;

    public string? Property103
    {
        get => _property103;
        set
        {
            if (_property103 != value)
            {
                this.OnPropertyChanging();
                this._property103 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property104;

    public string? Property104
    {
        get => _property104;
        set
        {
            if (_property104 != value)
            {
                this.OnPropertyChanging();
                this._property104 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property105;

    public string? Property105
    {
        get => _property105;
        set
        {
            if (_property105 != value)
            {
                this.OnPropertyChanging();
                this._property105 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property106;

    public string? Property106
    {
        get => _property106;
        set
        {
            if (_property106 != value)
            {
                this.OnPropertyChanging();
                this._property106 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property107;

    public string? Property107
    {
        get => _property107;
        set
        {
            if (_property107 != value)
            {
                this.OnPropertyChanging();
                this._property107 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property108;

    public string? Property108
    {
        get => _property108;
        set
        {
            if (_property108 != value)
            {
                this.OnPropertyChanging();
                this._property108 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property109;

    public string? Property109
    {
        get => _property109;
        set
        {
            if (_property109 != value)
            {
                this.OnPropertyChanging();
                this._property109 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property110;

    public string? Property110
    {
        get => _property110;
        set
        {
            if (_property110 != value)
            {
                this.OnPropertyChanging();
                this._property110 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property111;

    public string? Property111
    {
        get => _property111;
        set
        {
            if (_property111 != value)
            {
                this.OnPropertyChanging();
                this._property111 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property112;

    public string? Property112
    {
        get => _property112;
        set
        {
            if (_property112 != value)
            {
                this.OnPropertyChanging();
                this._property112 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property113;

    public string? Property113
    {
        get => _property113;
        set
        {
            if (_property113 != value)
            {
                this.OnPropertyChanging();
                this._property113 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property114;

    public string? Property114
    {
        get => _property114;
        set
        {
            if (_property114 != value)
            {
                this.OnPropertyChanging();
                this._property114 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property115;

    public string? Property115
    {
        get => _property115;
        set
        {
            if (_property115 != value)
            {
                this.OnPropertyChanging();
                this._property115 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property116;

    public string? Property116
    {
        get => _property116;
        set
        {
            if (_property116 != value)
            {
                this.OnPropertyChanging();
                this._property116 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property117;

    public string? Property117
    {
        get => _property117;
        set
        {
            if (_property117 != value)
            {
                this.OnPropertyChanging();
                this._property117 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property118;

    public string? Property118
    {
        get => _property118;
        set
        {
            if (_property118 != value)
            {
                this.OnPropertyChanging();
                this._property118 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property119;

    public string? Property119
    {
        get => _property119;
        set
        {
            if (_property119 != value)
            {
                this.OnPropertyChanging();
                this._property119 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property120;

    public string? Property120
    {
        get => _property120;
        set
        {
            if (_property120 != value)
            {
                this.OnPropertyChanging();
                this._property120 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property121;

    public string? Property121
    {
        get => _property121;
        set
        {
            if (_property121 != value)
            {
                this.OnPropertyChanging();
                this._property121 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property122;

    public string? Property122
    {
        get => _property122;
        set
        {
            if (_property122 != value)
            {
                this.OnPropertyChanging();
                this._property122 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property123;

    public string? Property123
    {
        get => _property123;
        set
        {
            if (_property123 != value)
            {
                this.OnPropertyChanging();
                this._property123 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property124;

    public string? Property124
    {
        get => _property124;
        set
        {
            if (_property124 != value)
            {
                this.OnPropertyChanging();
                this._property124 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property125;

    public string? Property125
    {
        get => _property125;
        set
        {
            if (_property125 != value)
            {
                this.OnPropertyChanging();
                this._property125 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property126;

    public string? Property126
    {
        get => _property126;
        set
        {
            if (_property126 != value)
            {
                this.OnPropertyChanging();
                this._property126 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property127;

    public string? Property127
    {
        get => _property127;
        set
        {
            if (_property127 != value)
            {
                this.OnPropertyChanging();
                this._property127 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property128;

    public string? Property128
    {
        get => _property128;
        set
        {
            if (_property128 != value)
            {
                this.OnPropertyChanging();
                this._property128 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property129;

    public string? Property129
    {
        get => _property129;
        set
        {
            if (_property129 != value)
            {
                this.OnPropertyChanging();
                this._property129 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property130;

    public string? Property130
    {
        get => _property130;
        set
        {
            if (_property130 != value)
            {
                this.OnPropertyChanging();
                this._property130 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property131;

    public string? Property131
    {
        get => _property131;
        set
        {
            if (_property131 != value)
            {
                this.OnPropertyChanging();
                this._property131 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property132;

    public string? Property132
    {
        get => _property132;
        set
        {
            if (_property132 != value)
            {
                this.OnPropertyChanging();
                this._property132 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property133;

    public string? Property133
    {
        get => _property133;
        set
        {
            if (_property133 != value)
            {
                this.OnPropertyChanging();
                this._property133 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property134;

    public string? Property134
    {
        get => _property134;
        set
        {
            if (_property134 != value)
            {
                this.OnPropertyChanging();
                this._property134 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property135;

    public string? Property135
    {
        get => _property135;
        set
        {
            if (_property135 != value)
            {
                this.OnPropertyChanging();
                this._property135 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property136;

    public string? Property136
    {
        get => _property136;
        set
        {
            if (_property136 != value)
            {
                this.OnPropertyChanging();
                this._property136 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property137;

    public string? Property137
    {
        get => _property137;
        set
        {
            if (_property137 != value)
            {
                this.OnPropertyChanging();
                this._property137 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property138;

    public string? Property138
    {
        get => _property138;
        set
        {
            if (_property138 != value)
            {
                this.OnPropertyChanging();
                this._property138 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property139;

    public string? Property139
    {
        get => _property139;
        set
        {
            if (_property139 != value)
            {
                this.OnPropertyChanging();
                this._property139 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property140;

    public string? Property140
    {
        get => _property140;
        set
        {
            if (_property140 != value)
            {
                this.OnPropertyChanging();
                this._property140 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property141;

    public string? Property141
    {
        get => _property141;
        set
        {
            if (_property141 != value)
            {
                this.OnPropertyChanging();
                this._property141 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property142;

    public string? Property142
    {
        get => _property142;
        set
        {
            if (_property142 != value)
            {
                this.OnPropertyChanging();
                this._property142 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property143;

    public string? Property143
    {
        get => _property143;
        set
        {
            if (_property143 != value)
            {
                this.OnPropertyChanging();
                this._property143 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property144;

    public string? Property144
    {
        get => _property144;
        set
        {
            if (_property144 != value)
            {
                this.OnPropertyChanging();
                this._property144 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property145;

    public string? Property145
    {
        get => _property145;
        set
        {
            if (_property145 != value)
            {
                this.OnPropertyChanging();
                this._property145 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property146;

    public string? Property146
    {
        get => _property146;
        set
        {
            if (_property146 != value)
            {
                this.OnPropertyChanging();
                this._property146 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property147;

    public string? Property147
    {
        get => _property147;
        set
        {
            if (_property147 != value)
            {
                this.OnPropertyChanging();
                this._property147 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property148;

    public string? Property148
    {
        get => _property148;
        set
        {
            if (_property148 != value)
            {
                this.OnPropertyChanging();
                this._property148 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property149;

    public string? Property149
    {
        get => _property149;
        set
        {
            if (_property149 != value)
            {
                this.OnPropertyChanging();
                this._property149 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property150;

    public string? Property150
    {
        get => _property150;
        set
        {
            if (_property150 != value)
            {
                this.OnPropertyChanging();
                this._property150 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property151;

    public string? Property151
    {
        get => _property151;
        set
        {
            if (_property151 != value)
            {
                this.OnPropertyChanging();
                this._property151 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property152;

    public string? Property152
    {
        get => _property152;
        set
        {
            if (_property152 != value)
            {
                this.OnPropertyChanging();
                this._property152 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property153;

    public string? Property153
    {
        get => _property153;
        set
        {
            if (_property153 != value)
            {
                this.OnPropertyChanging();
                this._property153 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property154;

    public string? Property154
    {
        get => _property154;
        set
        {
            if (_property154 != value)
            {
                this.OnPropertyChanging();
                this._property154 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property155;

    public string? Property155
    {
        get => _property155;
        set
        {
            if (_property155 != value)
            {
                this.OnPropertyChanging();
                this._property155 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property156;

    public string? Property156
    {
        get => _property156;
        set
        {
            if (_property156 != value)
            {
                this.OnPropertyChanging();
                this._property156 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property157;

    public string? Property157
    {
        get => _property157;
        set
        {
            if (_property157 != value)
            {
                this.OnPropertyChanging();
                this._property157 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property158;

    public string? Property158
    {
        get => _property158;
        set
        {
            if (_property158 != value)
            {
                this.OnPropertyChanging();
                this._property158 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property159;

    public string? Property159
    {
        get => _property159;
        set
        {
            if (_property159 != value)
            {
                this.OnPropertyChanging();
                this._property159 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property160;

    public string? Property160
    {
        get => _property160;
        set
        {
            if (_property160 != value)
            {
                this.OnPropertyChanging();
                this._property160 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property161;

    public string? Property161
    {
        get => _property161;
        set
        {
            if (_property161 != value)
            {
                this.OnPropertyChanging();
                this._property161 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property162;

    public string? Property162
    {
        get => _property162;
        set
        {
            if (_property162 != value)
            {
                this.OnPropertyChanging();
                this._property162 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property163;

    public string? Property163
    {
        get => _property163;
        set
        {
            if (_property163 != value)
            {
                this.OnPropertyChanging();
                this._property163 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property164;

    public string? Property164
    {
        get => _property164;
        set
        {
            if (_property164 != value)
            {
                this.OnPropertyChanging();
                this._property164 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property165;

    public string? Property165
    {
        get => _property165;
        set
        {
            if (_property165 != value)
            {
                this.OnPropertyChanging();
                this._property165 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property166;

    public string? Property166
    {
        get => _property166;
        set
        {
            if (_property166 != value)
            {
                this.OnPropertyChanging();
                this._property166 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property167;

    public string? Property167
    {
        get => _property167;
        set
        {
            if (_property167 != value)
            {
                this.OnPropertyChanging();
                this._property167 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property168;

    public string? Property168
    {
        get => _property168;
        set
        {
            if (_property168 != value)
            {
                this.OnPropertyChanging();
                this._property168 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property169;

    public string? Property169
    {
        get => _property169;
        set
        {
            if (_property169 != value)
            {
                this.OnPropertyChanging();
                this._property169 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property170;

    public string? Property170
    {
        get => _property170;
        set
        {
            if (_property170 != value)
            {
                this.OnPropertyChanging();
                this._property170 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property171;

    public string? Property171
    {
        get => _property171;
        set
        {
            if (_property171 != value)
            {
                this.OnPropertyChanging();
                this._property171 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property172;

    public string? Property172
    {
        get => _property172;
        set
        {
            if (_property172 != value)
            {
                this.OnPropertyChanging();
                this._property172 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property173;

    public string? Property173
    {
        get => _property173;
        set
        {
            if (_property173 != value)
            {
                this.OnPropertyChanging();
                this._property173 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property174;

    public string? Property174
    {
        get => _property174;
        set
        {
            if (_property174 != value)
            {
                this.OnPropertyChanging();
                this._property174 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property175;

    public string? Property175
    {
        get => _property175;
        set
        {
            if (_property175 != value)
            {
                this.OnPropertyChanging();
                this._property175 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property176;

    public string? Property176
    {
        get => _property176;
        set
        {
            if (_property176 != value)
            {
                this.OnPropertyChanging();
                this._property176 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property177;

    public string? Property177
    {
        get => _property177;
        set
        {
            if (_property177 != value)
            {
                this.OnPropertyChanging();
                this._property177 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property178;

    public string? Property178
    {
        get => _property178;
        set
        {
            if (_property178 != value)
            {
                this.OnPropertyChanging();
                this._property178 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property179;

    public string? Property179
    {
        get => _property179;
        set
        {
            if (_property179 != value)
            {
                this.OnPropertyChanging();
                this._property179 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property180;

    public string? Property180
    {
        get => _property180;
        set
        {
            if (_property180 != value)
            {
                this.OnPropertyChanging();
                this._property180 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property181;

    public string? Property181
    {
        get => _property181;
        set
        {
            if (_property181 != value)
            {
                this.OnPropertyChanging();
                this._property181 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property182;

    public string? Property182
    {
        get => _property182;
        set
        {
            if (_property182 != value)
            {
                this.OnPropertyChanging();
                this._property182 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property183;

    public string? Property183
    {
        get => _property183;
        set
        {
            if (_property183 != value)
            {
                this.OnPropertyChanging();
                this._property183 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property184;

    public string? Property184
    {
        get => _property184;
        set
        {
            if (_property184 != value)
            {
                this.OnPropertyChanging();
                this._property184 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property185;

    public string? Property185
    {
        get => _property185;
        set
        {
            if (_property185 != value)
            {
                this.OnPropertyChanging();
                this._property185 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property186;

    public string? Property186
    {
        get => _property186;
        set
        {
            if (_property186 != value)
            {
                this.OnPropertyChanging();
                this._property186 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property187;

    public string? Property187
    {
        get => _property187;
        set
        {
            if (_property187 != value)
            {
                this.OnPropertyChanging();
                this._property187 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property188;

    public string? Property188
    {
        get => _property188;
        set
        {
            if (_property188 != value)
            {
                this.OnPropertyChanging();
                this._property188 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property189;

    public string? Property189
    {
        get => _property189;
        set
        {
            if (_property189 != value)
            {
                this.OnPropertyChanging();
                this._property189 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property190;

    public string? Property190
    {
        get => _property190;
        set
        {
            if (_property190 != value)
            {
                this.OnPropertyChanging();
                this._property190 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property191;

    public string? Property191
    {
        get => _property191;
        set
        {
            if (_property191 != value)
            {
                this.OnPropertyChanging();
                this._property191 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property192;

    public string? Property192
    {
        get => _property192;
        set
        {
            if (_property192 != value)
            {
                this.OnPropertyChanging();
                this._property192 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property193;

    public string? Property193
    {
        get => _property193;
        set
        {
            if (_property193 != value)
            {
                this.OnPropertyChanging();
                this._property193 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property194;

    public string? Property194
    {
        get => _property194;
        set
        {
            if (_property194 != value)
            {
                this.OnPropertyChanging();
                this._property194 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property195;

    public string? Property195
    {
        get => _property195;
        set
        {
            if (_property195 != value)
            {
                this.OnPropertyChanging();
                this._property195 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property196;

    public string? Property196
    {
        get => _property196;
        set
        {
            if (_property196 != value)
            {
                this.OnPropertyChanging();
                this._property196 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property197;

    public string? Property197
    {
        get => _property197;
        set
        {
            if (_property197 != value)
            {
                this.OnPropertyChanging();
                this._property197 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property198;

    public string? Property198
    {
        get => _property198;
        set
        {
            if (_property198 != value)
            {
                this.OnPropertyChanging();
                this._property198 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property199;

    public string? Property199
    {
        get => _property199;
        set
        {
            if (_property199 != value)
            {
                this.OnPropertyChanging();
                this._property199 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property200;

    public string? Property200
    {
        get => _property200;
        set
        {
            if (_property200 != value)
            {
                this.OnPropertyChanging();
                this._property200 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property201;

    public string? Property201
    {
        get => _property201;
        set
        {
            if (_property201 != value)
            {
                this.OnPropertyChanging();
                this._property201 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property202;

    public string? Property202
    {
        get => _property202;
        set
        {
            if (_property202 != value)
            {
                this.OnPropertyChanging();
                this._property202 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property203;

    public string? Property203
    {
        get => _property203;
        set
        {
            if (_property203 != value)
            {
                this.OnPropertyChanging();
                this._property203 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property204;

    public string? Property204
    {
        get => _property204;
        set
        {
            if (_property204 != value)
            {
                this.OnPropertyChanging();
                this._property204 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property205;

    public string? Property205
    {
        get => _property205;
        set
        {
            if (_property205 != value)
            {
                this.OnPropertyChanging();
                this._property205 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property206;

    public string? Property206
    {
        get => _property206;
        set
        {
            if (_property206 != value)
            {
                this.OnPropertyChanging();
                this._property206 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property207;

    public string? Property207
    {
        get => _property207;
        set
        {
            if (_property207 != value)
            {
                this.OnPropertyChanging();
                this._property207 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property208;

    public string? Property208
    {
        get => _property208;
        set
        {
            if (_property208 != value)
            {
                this.OnPropertyChanging();
                this._property208 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property209;

    public string? Property209
    {
        get => _property209;
        set
        {
            if (_property209 != value)
            {
                this.OnPropertyChanging();
                this._property209 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property210;

    public string? Property210
    {
        get => _property210;
        set
        {
            if (_property210 != value)
            {
                this.OnPropertyChanging();
                this._property210 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property211;

    public string? Property211
    {
        get => _property211;
        set
        {
            if (_property211 != value)
            {
                this.OnPropertyChanging();
                this._property211 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property212;

    public string? Property212
    {
        get => _property212;
        set
        {
            if (_property212 != value)
            {
                this.OnPropertyChanging();
                this._property212 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property213;

    public string? Property213
    {
        get => _property213;
        set
        {
            if (_property213 != value)
            {
                this.OnPropertyChanging();
                this._property213 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property214;

    public string? Property214
    {
        get => _property214;
        set
        {
            if (_property214 != value)
            {
                this.OnPropertyChanging();
                this._property214 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property215;

    public string? Property215
    {
        get => _property215;
        set
        {
            if (_property215 != value)
            {
                this.OnPropertyChanging();
                this._property215 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property216;

    public string? Property216
    {
        get => _property216;
        set
        {
            if (_property216 != value)
            {
                this.OnPropertyChanging();
                this._property216 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property217;

    public string? Property217
    {
        get => _property217;
        set
        {
            if (_property217 != value)
            {
                this.OnPropertyChanging();
                this._property217 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property218;

    public string? Property218
    {
        get => _property218;
        set
        {
            if (_property218 != value)
            {
                this.OnPropertyChanging();
                this._property218 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property219;

    public string? Property219
    {
        get => _property219;
        set
        {
            if (_property219 != value)
            {
                this.OnPropertyChanging();
                this._property219 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property220;

    public string? Property220
    {
        get => _property220;
        set
        {
            if (_property220 != value)
            {
                this.OnPropertyChanging();
                this._property220 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property221;

    public string? Property221
    {
        get => _property221;
        set
        {
            if (_property221 != value)
            {
                this.OnPropertyChanging();
                this._property221 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property222;

    public string? Property222
    {
        get => _property222;
        set
        {
            if (_property222 != value)
            {
                this.OnPropertyChanging();
                this._property222 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property223;

    public string? Property223
    {
        get => _property223;
        set
        {
            if (_property223 != value)
            {
                this.OnPropertyChanging();
                this._property223 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property224;

    public string? Property224
    {
        get => _property224;
        set
        {
            if (_property224 != value)
            {
                this.OnPropertyChanging();
                this._property224 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property225;

    public string? Property225
    {
        get => _property225;
        set
        {
            if (_property225 != value)
            {
                this.OnPropertyChanging();
                this._property225 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property226;

    public string? Property226
    {
        get => _property226;
        set
        {
            if (_property226 != value)
            {
                this.OnPropertyChanging();
                this._property226 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property227;

    public string? Property227
    {
        get => _property227;
        set
        {
            if (_property227 != value)
            {
                this.OnPropertyChanging();
                this._property227 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property228;

    public string? Property228
    {
        get => _property228;
        set
        {
            if (_property228 != value)
            {
                this.OnPropertyChanging();
                this._property228 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property229;

    public string? Property229
    {
        get => _property229;
        set
        {
            if (_property229 != value)
            {
                this.OnPropertyChanging();
                this._property229 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property230;

    public string? Property230
    {
        get => _property230;
        set
        {
            if (_property230 != value)
            {
                this.OnPropertyChanging();
                this._property230 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property231;

    public string? Property231
    {
        get => _property231;
        set
        {
            if (_property231 != value)
            {
                this.OnPropertyChanging();
                this._property231 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property232;

    public string? Property232
    {
        get => _property232;
        set
        {
            if (_property232 != value)
            {
                this.OnPropertyChanging();
                this._property232 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property233;

    public string? Property233
    {
        get => _property233;
        set
        {
            if (_property233 != value)
            {
                this.OnPropertyChanging();
                this._property233 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property234;

    public string? Property234
    {
        get => _property234;
        set
        {
            if (_property234 != value)
            {
                this.OnPropertyChanging();
                this._property234 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property235;

    public string? Property235
    {
        get => _property235;
        set
        {
            if (_property235 != value)
            {
                this.OnPropertyChanging();
                this._property235 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property236;

    public string? Property236
    {
        get => _property236;
        set
        {
            if (_property236 != value)
            {
                this.OnPropertyChanging();
                this._property236 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property237;

    public string? Property237
    {
        get => _property237;
        set
        {
            if (_property237 != value)
            {
                this.OnPropertyChanging();
                this._property237 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property238;

    public string? Property238
    {
        get => _property238;
        set
        {
            if (_property238 != value)
            {
                this.OnPropertyChanging();
                this._property238 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property239;

    public string? Property239
    {
        get => _property239;
        set
        {
            if (_property239 != value)
            {
                this.OnPropertyChanging();
                this._property239 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property240;

    public string? Property240
    {
        get => _property240;
        set
        {
            if (_property240 != value)
            {
                this.OnPropertyChanging();
                this._property240 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property241;

    public string? Property241
    {
        get => _property241;
        set
        {
            if (_property241 != value)
            {
                this.OnPropertyChanging();
                this._property241 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property242;

    public string? Property242
    {
        get => _property242;
        set
        {
            if (_property242 != value)
            {
                this.OnPropertyChanging();
                this._property242 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property243;

    public string? Property243
    {
        get => _property243;
        set
        {
            if (_property243 != value)
            {
                this.OnPropertyChanging();
                this._property243 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property244;

    public string? Property244
    {
        get => _property244;
        set
        {
            if (_property244 != value)
            {
                this.OnPropertyChanging();
                this._property244 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property245;

    public string? Property245
    {
        get => _property245;
        set
        {
            if (_property245 != value)
            {
                this.OnPropertyChanging();
                this._property245 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property246;

    public string? Property246
    {
        get => _property246;
        set
        {
            if (_property246 != value)
            {
                this.OnPropertyChanging();
                this._property246 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property247;

    public string? Property247
    {
        get => _property247;
        set
        {
            if (_property247 != value)
            {
                this.OnPropertyChanging();
                this._property247 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property248;

    public string? Property248
    {
        get => _property248;
        set
        {
            if (_property248 != value)
            {
                this.OnPropertyChanging();
                this._property248 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property249;

    public string? Property249
    {
        get => _property249;
        set
        {
            if (_property249 != value)
            {
                this.OnPropertyChanging();
                this._property249 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property250;

    public string? Property250
    {
        get => _property250;
        set
        {
            if (_property250 != value)
            {
                this.OnPropertyChanging();
                this._property250 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property251;

    public string? Property251
    {
        get => _property251;
        set
        {
            if (_property251 != value)
            {
                this.OnPropertyChanging();
                this._property251 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property252;

    public string? Property252
    {
        get => _property252;
        set
        {
            if (_property252 != value)
            {
                this.OnPropertyChanging();
                this._property252 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property253;

    public string? Property253
    {
        get => _property253;
        set
        {
            if (_property253 != value)
            {
                this.OnPropertyChanging();
                this._property253 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property254;

    public string? Property254
    {
        get => _property254;
        set
        {
            if (_property254 != value)
            {
                this.OnPropertyChanging();
                this._property254 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property255;

    public string? Property255
    {
        get => _property255;
        set
        {
            if (_property255 != value)
            {
                this.OnPropertyChanging();
                this._property255 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property256;

    public string? Property256
    {
        get => _property256;
        set
        {
            if (_property256 != value)
            {
                this.OnPropertyChanging();
                this._property256 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property257;

    public string? Property257
    {
        get => _property257;
        set
        {
            if (_property257 != value)
            {
                this.OnPropertyChanging();
                this._property257 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property258;

    public string? Property258
    {
        get => _property258;
        set
        {
            if (_property258 != value)
            {
                this.OnPropertyChanging();
                this._property258 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property259;

    public string? Property259
    {
        get => _property259;
        set
        {
            if (_property259 != value)
            {
                this.OnPropertyChanging();
                this._property259 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property260;

    public string? Property260
    {
        get => _property260;
        set
        {
            if (_property260 != value)
            {
                this.OnPropertyChanging();
                this._property260 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property261;

    public string? Property261
    {
        get => _property261;
        set
        {
            if (_property261 != value)
            {
                this.OnPropertyChanging();
                this._property261 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property262;

    public string? Property262
    {
        get => _property262;
        set
        {
            if (_property262 != value)
            {
                this.OnPropertyChanging();
                this._property262 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property263;

    public string? Property263
    {
        get => _property263;
        set
        {
            if (_property263 != value)
            {
                this.OnPropertyChanging();
                this._property263 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property264;

    public string? Property264
    {
        get => _property264;
        set
        {
            if (_property264 != value)
            {
                this.OnPropertyChanging();
                this._property264 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property265;

    public string? Property265
    {
        get => _property265;
        set
        {
            if (_property265 != value)
            {
                this.OnPropertyChanging();
                this._property265 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property266;

    public string? Property266
    {
        get => _property266;
        set
        {
            if (_property266 != value)
            {
                this.OnPropertyChanging();
                this._property266 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property267;

    public string? Property267
    {
        get => _property267;
        set
        {
            if (_property267 != value)
            {
                this.OnPropertyChanging();
                this._property267 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property268;

    public string? Property268
    {
        get => _property268;
        set
        {
            if (_property268 != value)
            {
                this.OnPropertyChanging();
                this._property268 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property269;

    public string? Property269
    {
        get => _property269;
        set
        {
            if (_property269 != value)
            {
                this.OnPropertyChanging();
                this._property269 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property270;

    public string? Property270
    {
        get => _property270;
        set
        {
            if (_property270 != value)
            {
                this.OnPropertyChanging();
                this._property270 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property271;

    public string? Property271
    {
        get => _property271;
        set
        {
            if (_property271 != value)
            {
                this.OnPropertyChanging();
                this._property271 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property272;

    public string? Property272
    {
        get => _property272;
        set
        {
            if (_property272 != value)
            {
                this.OnPropertyChanging();
                this._property272 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property273;

    public string? Property273
    {
        get => _property273;
        set
        {
            if (_property273 != value)
            {
                this.OnPropertyChanging();
                this._property273 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property274;

    public string? Property274
    {
        get => _property274;
        set
        {
            if (_property274 != value)
            {
                this.OnPropertyChanging();
                this._property274 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property275;

    public string? Property275
    {
        get => _property275;
        set
        {
            if (_property275 != value)
            {
                this.OnPropertyChanging();
                this._property275 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property276;

    public string? Property276
    {
        get => _property276;
        set
        {
            if (_property276 != value)
            {
                this.OnPropertyChanging();
                this._property276 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property277;

    public string? Property277
    {
        get => _property277;
        set
        {
            if (_property277 != value)
            {
                this.OnPropertyChanging();
                this._property277 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property278;

    public string? Property278
    {
        get => _property278;
        set
        {
            if (_property278 != value)
            {
                this.OnPropertyChanging();
                this._property278 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property279;

    public string? Property279
    {
        get => _property279;
        set
        {
            if (_property279 != value)
            {
                this.OnPropertyChanging();
                this._property279 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property280;

    public string? Property280
    {
        get => _property280;
        set
        {
            if (_property280 != value)
            {
                this.OnPropertyChanging();
                this._property280 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property281;

    public string? Property281
    {
        get => _property281;
        set
        {
            if (_property281 != value)
            {
                this.OnPropertyChanging();
                this._property281 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property282;

    public string? Property282
    {
        get => _property282;
        set
        {
            if (_property282 != value)
            {
                this.OnPropertyChanging();
                this._property282 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property283;

    public string? Property283
    {
        get => _property283;
        set
        {
            if (_property283 != value)
            {
                this.OnPropertyChanging();
                this._property283 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property284;

    public string? Property284
    {
        get => _property284;
        set
        {
            if (_property284 != value)
            {
                this.OnPropertyChanging();
                this._property284 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property285;

    public string? Property285
    {
        get => _property285;
        set
        {
            if (_property285 != value)
            {
                this.OnPropertyChanging();
                this._property285 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property286;

    public string? Property286
    {
        get => _property286;
        set
        {
            if (_property286 != value)
            {
                this.OnPropertyChanging();
                this._property286 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property287;

    public string? Property287
    {
        get => _property287;
        set
        {
            if (_property287 != value)
            {
                this.OnPropertyChanging();
                this._property287 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property288;

    public string? Property288
    {
        get => _property288;
        set
        {
            if (_property288 != value)
            {
                this.OnPropertyChanging();
                this._property288 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property289;

    public string? Property289
    {
        get => _property289;
        set
        {
            if (_property289 != value)
            {
                this.OnPropertyChanging();
                this._property289 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property290;

    public string? Property290
    {
        get => _property290;
        set
        {
            if (_property290 != value)
            {
                this.OnPropertyChanging();
                this._property290 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property291;

    public string? Property291
    {
        get => _property291;
        set
        {
            if (_property291 != value)
            {
                this.OnPropertyChanging();
                this._property291 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property292;

    public string? Property292
    {
        get => _property292;
        set
        {
            if (_property292 != value)
            {
                this.OnPropertyChanging();
                this._property292 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property293;

    public string? Property293
    {
        get => _property293;
        set
        {
            if (_property293 != value)
            {
                this.OnPropertyChanging();
                this._property293 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property294;

    public string? Property294
    {
        get => _property294;
        set
        {
            if (_property294 != value)
            {
                this.OnPropertyChanging();
                this._property294 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property295;

    public string? Property295
    {
        get => _property295;
        set
        {
            if (_property295 != value)
            {
                this.OnPropertyChanging();
                this._property295 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property296;

    public string? Property296
    {
        get => _property296;
        set
        {
            if (_property296 != value)
            {
                this.OnPropertyChanging();
                this._property296 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property297;

    public string? Property297
    {
        get => _property297;
        set
        {
            if (_property297 != value)
            {
                this.OnPropertyChanging();
                this._property297 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property298;

    public string? Property298
    {
        get => _property298;
        set
        {
            if (_property298 != value)
            {
                this.OnPropertyChanging();
                this._property298 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property299;

    public string? Property299
    {
        get => _property299;
        set
        {
            if (_property299 != value)
            {
                this.OnPropertyChanging();
                this._property299 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property300;

    public string? Property300
    {
        get => _property300;
        set
        {
            if (_property300 != value)
            {
                this.OnPropertyChanging();
                this._property300 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property301;

    public string? Property301
    {
        get => _property301;
        set
        {
            if (_property301 != value)
            {
                this.OnPropertyChanging();
                this._property301 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property302;

    public string? Property302
    {
        get => _property302;
        set
        {
            if (_property302 != value)
            {
                this.OnPropertyChanging();
                this._property302 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property303;

    public string? Property303
    {
        get => _property303;
        set
        {
            if (_property303 != value)
            {
                this.OnPropertyChanging();
                this._property303 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property304;

    public string? Property304
    {
        get => _property304;
        set
        {
            if (_property304 != value)
            {
                this.OnPropertyChanging();
                this._property304 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property305;

    public string? Property305
    {
        get => _property305;
        set
        {
            if (_property305 != value)
            {
                this.OnPropertyChanging();
                this._property305 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property306;

    public string? Property306
    {
        get => _property306;
        set
        {
            if (_property306 != value)
            {
                this.OnPropertyChanging();
                this._property306 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property307;

    public string? Property307
    {
        get => _property307;
        set
        {
            if (_property307 != value)
            {
                this.OnPropertyChanging();
                this._property307 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property308;

    public string? Property308
    {
        get => _property308;
        set
        {
            if (_property308 != value)
            {
                this.OnPropertyChanging();
                this._property308 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property309;

    public string? Property309
    {
        get => _property309;
        set
        {
            if (_property309 != value)
            {
                this.OnPropertyChanging();
                this._property309 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property310;

    public string? Property310
    {
        get => _property310;
        set
        {
            if (_property310 != value)
            {
                this.OnPropertyChanging();
                this._property310 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property311;

    public string? Property311
    {
        get => _property311;
        set
        {
            if (_property311 != value)
            {
                this.OnPropertyChanging();
                this._property311 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property312;

    public string? Property312
    {
        get => _property312;
        set
        {
            if (_property312 != value)
            {
                this.OnPropertyChanging();
                this._property312 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property313;

    public string? Property313
    {
        get => _property313;
        set
        {
            if (_property313 != value)
            {
                this.OnPropertyChanging();
                this._property313 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property314;

    public string? Property314
    {
        get => _property314;
        set
        {
            if (_property314 != value)
            {
                this.OnPropertyChanging();
                this._property314 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property315;

    public string? Property315
    {
        get => _property315;
        set
        {
            if (_property315 != value)
            {
                this.OnPropertyChanging();
                this._property315 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property316;

    public string? Property316
    {
        get => _property316;
        set
        {
            if (_property316 != value)
            {
                this.OnPropertyChanging();
                this._property316 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property317;

    public string? Property317
    {
        get => _property317;
        set
        {
            if (_property317 != value)
            {
                this.OnPropertyChanging();
                this._property317 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property318;

    public string? Property318
    {
        get => _property318;
        set
        {
            if (_property318 != value)
            {
                this.OnPropertyChanging();
                this._property318 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property319;

    public string? Property319
    {
        get => _property319;
        set
        {
            if (_property319 != value)
            {
                this.OnPropertyChanging();
                this._property319 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property320;

    public string? Property320
    {
        get => _property320;
        set
        {
            if (_property320 != value)
            {
                this.OnPropertyChanging();
                this._property320 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property321;

    public string? Property321
    {
        get => _property321;
        set
        {
            if (_property321 != value)
            {
                this.OnPropertyChanging();
                this._property321 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property322;

    public string? Property322
    {
        get => _property322;
        set
        {
            if (_property322 != value)
            {
                this.OnPropertyChanging();
                this._property322 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property323;

    public string? Property323
    {
        get => _property323;
        set
        {
            if (_property323 != value)
            {
                this.OnPropertyChanging();
                this._property323 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property324;

    public string? Property324
    {
        get => _property324;
        set
        {
            if (_property324 != value)
            {
                this.OnPropertyChanging();
                this._property324 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property325;

    public string? Property325
    {
        get => _property325;
        set
        {
            if (_property325 != value)
            {
                this.OnPropertyChanging();
                this._property325 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property326;

    public string? Property326
    {
        get => _property326;
        set
        {
            if (_property326 != value)
            {
                this.OnPropertyChanging();
                this._property326 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property327;

    public string? Property327
    {
        get => _property327;
        set
        {
            if (_property327 != value)
            {
                this.OnPropertyChanging();
                this._property327 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property328;

    public string? Property328
    {
        get => _property328;
        set
        {
            if (_property328 != value)
            {
                this.OnPropertyChanging();
                this._property328 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property329;

    public string? Property329
    {
        get => _property329;
        set
        {
            if (_property329 != value)
            {
                this.OnPropertyChanging();
                this._property329 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property330;

    public string? Property330
    {
        get => _property330;
        set
        {
            if (_property330 != value)
            {
                this.OnPropertyChanging();
                this._property330 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property331;

    public string? Property331
    {
        get => _property331;
        set
        {
            if (_property331 != value)
            {
                this.OnPropertyChanging();
                this._property331 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property332;

    public string? Property332
    {
        get => _property332;
        set
        {
            if (_property332 != value)
            {
                this.OnPropertyChanging();
                this._property332 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property333;

    public string? Property333
    {
        get => _property333;
        set
        {
            if (_property333 != value)
            {
                this.OnPropertyChanging();
                this._property333 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property334;

    public string? Property334
    {
        get => _property334;
        set
        {
            if (_property334 != value)
            {
                this.OnPropertyChanging();
                this._property334 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property335;

    public string? Property335
    {
        get => _property335;
        set
        {
            if (_property335 != value)
            {
                this.OnPropertyChanging();
                this._property335 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property336;

    public string? Property336
    {
        get => _property336;
        set
        {
            if (_property336 != value)
            {
                this.OnPropertyChanging();
                this._property336 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property337;

    public string? Property337
    {
        get => _property337;
        set
        {
            if (_property337 != value)
            {
                this.OnPropertyChanging();
                this._property337 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property338;

    public string? Property338
    {
        get => _property338;
        set
        {
            if (_property338 != value)
            {
                this.OnPropertyChanging();
                this._property338 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property339;

    public string? Property339
    {
        get => _property339;
        set
        {
            if (_property339 != value)
            {
                this.OnPropertyChanging();
                this._property339 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property340;

    public string? Property340
    {
        get => _property340;
        set
        {
            if (_property340 != value)
            {
                this.OnPropertyChanging();
                this._property340 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property341;

    public string? Property341
    {
        get => _property341;
        set
        {
            if (_property341 != value)
            {
                this.OnPropertyChanging();
                this._property341 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property342;

    public string? Property342
    {
        get => _property342;
        set
        {
            if (_property342 != value)
            {
                this.OnPropertyChanging();
                this._property342 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property343;

    public string? Property343
    {
        get => _property343;
        set
        {
            if (_property343 != value)
            {
                this.OnPropertyChanging();
                this._property343 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property344;

    public string? Property344
    {
        get => _property344;
        set
        {
            if (_property344 != value)
            {
                this.OnPropertyChanging();
                this._property344 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property345;

    public string? Property345
    {
        get => _property345;
        set
        {
            if (_property345 != value)
            {
                this.OnPropertyChanging();
                this._property345 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property346;

    public string? Property346
    {
        get => _property346;
        set
        {
            if (_property346 != value)
            {
                this.OnPropertyChanging();
                this._property346 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property347;

    public string? Property347
    {
        get => _property347;
        set
        {
            if (_property347 != value)
            {
                this.OnPropertyChanging();
                this._property347 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property348;

    public string? Property348
    {
        get => _property348;
        set
        {
            if (_property348 != value)
            {
                this.OnPropertyChanging();
                this._property348 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property349;

    public string? Property349
    {
        get => _property349;
        set
        {
            if (_property349 != value)
            {
                this.OnPropertyChanging();
                this._property349 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property350;

    public string? Property350
    {
        get => _property350;
        set
        {
            if (_property350 != value)
            {
                this.OnPropertyChanging();
                this._property350 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property351;

    public string? Property351
    {
        get => _property351;
        set
        {
            if (_property351 != value)
            {
                this.OnPropertyChanging();
                this._property351 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property352;

    public string? Property352
    {
        get => _property352;
        set
        {
            if (_property352 != value)
            {
                this.OnPropertyChanging();
                this._property352 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property353;

    public string? Property353
    {
        get => _property353;
        set
        {
            if (_property353 != value)
            {
                this.OnPropertyChanging();
                this._property353 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property354;

    public string? Property354
    {
        get => _property354;
        set
        {
            if (_property354 != value)
            {
                this.OnPropertyChanging();
                this._property354 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property355;

    public string? Property355
    {
        get => _property355;
        set
        {
            if (_property355 != value)
            {
                this.OnPropertyChanging();
                this._property355 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property356;

    public string? Property356
    {
        get => _property356;
        set
        {
            if (_property356 != value)
            {
                this.OnPropertyChanging();
                this._property356 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property357;

    public string? Property357
    {
        get => _property357;
        set
        {
            if (_property357 != value)
            {
                this.OnPropertyChanging();
                this._property357 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property358;

    public string? Property358
    {
        get => _property358;
        set
        {
            if (_property358 != value)
            {
                this.OnPropertyChanging();
                this._property358 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property359;

    public string? Property359
    {
        get => _property359;
        set
        {
            if (_property359 != value)
            {
                this.OnPropertyChanging();
                this._property359 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property360;

    public string? Property360
    {
        get => _property360;
        set
        {
            if (_property360 != value)
            {
                this.OnPropertyChanging();
                this._property360 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property361;

    public string? Property361
    {
        get => _property361;
        set
        {
            if (_property361 != value)
            {
                this.OnPropertyChanging();
                this._property361 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property362;

    public string? Property362
    {
        get => _property362;
        set
        {
            if (_property362 != value)
            {
                this.OnPropertyChanging();
                this._property362 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property363;

    public string? Property363
    {
        get => _property363;
        set
        {
            if (_property363 != value)
            {
                this.OnPropertyChanging();
                this._property363 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property364;

    public string? Property364
    {
        get => _property364;
        set
        {
            if (_property364 != value)
            {
                this.OnPropertyChanging();
                this._property364 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property365;

    public string? Property365
    {
        get => _property365;
        set
        {
            if (_property365 != value)
            {
                this.OnPropertyChanging();
                this._property365 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property366;

    public string? Property366
    {
        get => _property366;
        set
        {
            if (_property366 != value)
            {
                this.OnPropertyChanging();
                this._property366 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property367;

    public string? Property367
    {
        get => _property367;
        set
        {
            if (_property367 != value)
            {
                this.OnPropertyChanging();
                this._property367 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property368;

    public string? Property368
    {
        get => _property368;
        set
        {
            if (_property368 != value)
            {
                this.OnPropertyChanging();
                this._property368 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property369;

    public string? Property369
    {
        get => _property369;
        set
        {
            if (_property369 != value)
            {
                this.OnPropertyChanging();
                this._property369 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property370;

    public string? Property370
    {
        get => _property370;
        set
        {
            if (_property370 != value)
            {
                this.OnPropertyChanging();
                this._property370 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property371;

    public string? Property371
    {
        get => _property371;
        set
        {
            if (_property371 != value)
            {
                this.OnPropertyChanging();
                this._property371 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property372;

    public string? Property372
    {
        get => _property372;
        set
        {
            if (_property372 != value)
            {
                this.OnPropertyChanging();
                this._property372 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property373;

    public string? Property373
    {
        get => _property373;
        set
        {
            if (_property373 != value)
            {
                this.OnPropertyChanging();
                this._property373 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property374;

    public string? Property374
    {
        get => _property374;
        set
        {
            if (_property374 != value)
            {
                this.OnPropertyChanging();
                this._property374 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property375;

    public string? Property375
    {
        get => _property375;
        set
        {
            if (_property375 != value)
            {
                this.OnPropertyChanging();
                this._property375 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property376;

    public string? Property376
    {
        get => _property376;
        set
        {
            if (_property376 != value)
            {
                this.OnPropertyChanging();
                this._property376 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property377;

    public string? Property377
    {
        get => _property377;
        set
        {
            if (_property377 != value)
            {
                this.OnPropertyChanging();
                this._property377 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property378;

    public string? Property378
    {
        get => _property378;
        set
        {
            if (_property378 != value)
            {
                this.OnPropertyChanging();
                this._property378 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property379;

    public string? Property379
    {
        get => _property379;
        set
        {
            if (_property379 != value)
            {
                this.OnPropertyChanging();
                this._property379 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property380;

    public string? Property380
    {
        get => _property380;
        set
        {
            if (_property380 != value)
            {
                this.OnPropertyChanging();
                this._property380 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property381;

    public string? Property381
    {
        get => _property381;
        set
        {
            if (_property381 != value)
            {
                this.OnPropertyChanging();
                this._property381 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property382;

    public string? Property382
    {
        get => _property382;
        set
        {
            if (_property382 != value)
            {
                this.OnPropertyChanging();
                this._property382 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property383;

    public string? Property383
    {
        get => _property383;
        set
        {
            if (_property383 != value)
            {
                this.OnPropertyChanging();
                this._property383 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property384;

    public string? Property384
    {
        get => _property384;
        set
        {
            if (_property384 != value)
            {
                this.OnPropertyChanging();
                this._property384 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property385;

    public string? Property385
    {
        get => _property385;
        set
        {
            if (_property385 != value)
            {
                this.OnPropertyChanging();
                this._property385 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property386;

    public string? Property386
    {
        get => _property386;
        set
        {
            if (_property386 != value)
            {
                this.OnPropertyChanging();
                this._property386 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property387;

    public string? Property387
    {
        get => _property387;
        set
        {
            if (_property387 != value)
            {
                this.OnPropertyChanging();
                this._property387 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property388;

    public string? Property388
    {
        get => _property388;
        set
        {
            if (_property388 != value)
            {
                this.OnPropertyChanging();
                this._property388 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property389;

    public string? Property389
    {
        get => _property389;
        set
        {
            if (_property389 != value)
            {
                this.OnPropertyChanging();
                this._property389 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property390;

    public string? Property390
    {
        get => _property390;
        set
        {
            if (_property390 != value)
            {
                this.OnPropertyChanging();
                this._property390 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property391;

    public string? Property391
    {
        get => _property391;
        set
        {
            if (_property391 != value)
            {
                this.OnPropertyChanging();
                this._property391 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property392;

    public string? Property392
    {
        get => _property392;
        set
        {
            if (_property392 != value)
            {
                this.OnPropertyChanging();
                this._property392 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property393;

    public string? Property393
    {
        get => _property393;
        set
        {
            if (_property393 != value)
            {
                this.OnPropertyChanging();
                this._property393 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property394;

    public string? Property394
    {
        get => _property394;
        set
        {
            if (_property394 != value)
            {
                this.OnPropertyChanging();
                this._property394 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property395;

    public string? Property395
    {
        get => _property395;
        set
        {
            if (_property395 != value)
            {
                this.OnPropertyChanging();
                this._property395 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property396;

    public string? Property396
    {
        get => _property396;
        set
        {
            if (_property396 != value)
            {
                this.OnPropertyChanging();
                this._property396 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property397;

    public string? Property397
    {
        get => _property397;
        set
        {
            if (_property397 != value)
            {
                this.OnPropertyChanging();
                this._property397 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property398;

    public string? Property398
    {
        get => _property398;
        set
        {
            if (_property398 != value)
            {
                this.OnPropertyChanging();
                this._property398 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property399;

    public string? Property399
    {
        get => _property399;
        set
        {
            if (_property399 != value)
            {
                this.OnPropertyChanging();
                this._property399 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property400;

    public string? Property400
    {
        get => _property400;
        set
        {
            if (_property400 != value)
            {
                this.OnPropertyChanging();
                this._property400 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property401;

    public string? Property401
    {
        get => _property401;
        set
        {
            if (_property401 != value)
            {
                this.OnPropertyChanging();
                this._property401 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property402;

    public string? Property402
    {
        get => _property402;
        set
        {
            if (_property402 != value)
            {
                this.OnPropertyChanging();
                this._property402 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property403;

    public string? Property403
    {
        get => _property403;
        set
        {
            if (_property403 != value)
            {
                this.OnPropertyChanging();
                this._property403 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property404;

    public string? Property404
    {
        get => _property404;
        set
        {
            if (_property404 != value)
            {
                this.OnPropertyChanging();
                this._property404 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property405;

    public string? Property405
    {
        get => _property405;
        set
        {
            if (_property405 != value)
            {
                this.OnPropertyChanging();
                this._property405 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property406;

    public string? Property406
    {
        get => _property406;
        set
        {
            if (_property406 != value)
            {
                this.OnPropertyChanging();
                this._property406 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property407;

    public string? Property407
    {
        get => _property407;
        set
        {
            if (_property407 != value)
            {
                this.OnPropertyChanging();
                this._property407 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property408;

    public string? Property408
    {
        get => _property408;
        set
        {
            if (_property408 != value)
            {
                this.OnPropertyChanging();
                this._property408 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property409;

    public string? Property409
    {
        get => _property409;
        set
        {
            if (_property409 != value)
            {
                this.OnPropertyChanging();
                this._property409 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property410;

    public string? Property410
    {
        get => _property410;
        set
        {
            if (_property410 != value)
            {
                this.OnPropertyChanging();
                this._property410 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property411;

    public string? Property411
    {
        get => _property411;
        set
        {
            if (_property411 != value)
            {
                this.OnPropertyChanging();
                this._property411 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property412;

    public string? Property412
    {
        get => _property412;
        set
        {
            if (_property412 != value)
            {
                this.OnPropertyChanging();
                this._property412 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property413;

    public string? Property413
    {
        get => _property413;
        set
        {
            if (_property413 != value)
            {
                this.OnPropertyChanging();
                this._property413 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property414;

    public string? Property414
    {
        get => _property414;
        set
        {
            if (_property414 != value)
            {
                this.OnPropertyChanging();
                this._property414 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property415;

    public string? Property415
    {
        get => _property415;
        set
        {
            if (_property415 != value)
            {
                this.OnPropertyChanging();
                this._property415 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property416;

    public string? Property416
    {
        get => _property416;
        set
        {
            if (_property416 != value)
            {
                this.OnPropertyChanging();
                this._property416 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property417;

    public string? Property417
    {
        get => _property417;
        set
        {
            if (_property417 != value)
            {
                this.OnPropertyChanging();
                this._property417 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property418;

    public string? Property418
    {
        get => _property418;
        set
        {
            if (_property418 != value)
            {
                this.OnPropertyChanging();
                this._property418 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property419;

    public string? Property419
    {
        get => _property419;
        set
        {
            if (_property419 != value)
            {
                this.OnPropertyChanging();
                this._property419 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property420;

    public string? Property420
    {
        get => _property420;
        set
        {
            if (_property420 != value)
            {
                this.OnPropertyChanging();
                this._property420 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property421;

    public string? Property421
    {
        get => _property421;
        set
        {
            if (_property421 != value)
            {
                this.OnPropertyChanging();
                this._property421 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property422;

    public string? Property422
    {
        get => _property422;
        set
        {
            if (_property422 != value)
            {
                this.OnPropertyChanging();
                this._property422 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property423;

    public string? Property423
    {
        get => _property423;
        set
        {
            if (_property423 != value)
            {
                this.OnPropertyChanging();
                this._property423 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property424;

    public string? Property424
    {
        get => _property424;
        set
        {
            if (_property424 != value)
            {
                this.OnPropertyChanging();
                this._property424 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property425;

    public string? Property425
    {
        get => _property425;
        set
        {
            if (_property425 != value)
            {
                this.OnPropertyChanging();
                this._property425 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property426;

    public string? Property426
    {
        get => _property426;
        set
        {
            if (_property426 != value)
            {
                this.OnPropertyChanging();
                this._property426 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property427;

    public string? Property427
    {
        get => _property427;
        set
        {
            if (_property427 != value)
            {
                this.OnPropertyChanging();
                this._property427 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property428;

    public string? Property428
    {
        get => _property428;
        set
        {
            if (_property428 != value)
            {
                this.OnPropertyChanging();
                this._property428 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property429;

    public string? Property429
    {
        get => _property429;
        set
        {
            if (_property429 != value)
            {
                this.OnPropertyChanging();
                this._property429 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property430;

    public string? Property430
    {
        get => _property430;
        set
        {
            if (_property430 != value)
            {
                this.OnPropertyChanging();
                this._property430 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property431;

    public string? Property431
    {
        get => _property431;
        set
        {
            if (_property431 != value)
            {
                this.OnPropertyChanging();
                this._property431 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property432;

    public string? Property432
    {
        get => _property432;
        set
        {
            if (_property432 != value)
            {
                this.OnPropertyChanging();
                this._property432 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property433;

    public string? Property433
    {
        get => _property433;
        set
        {
            if (_property433 != value)
            {
                this.OnPropertyChanging();
                this._property433 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property434;

    public string? Property434
    {
        get => _property434;
        set
        {
            if (_property434 != value)
            {
                this.OnPropertyChanging();
                this._property434 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property435;

    public string? Property435
    {
        get => _property435;
        set
        {
            if (_property435 != value)
            {
                this.OnPropertyChanging();
                this._property435 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property436;

    public string? Property436
    {
        get => _property436;
        set
        {
            if (_property436 != value)
            {
                this.OnPropertyChanging();
                this._property436 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property437;

    public string? Property437
    {
        get => _property437;
        set
        {
            if (_property437 != value)
            {
                this.OnPropertyChanging();
                this._property437 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property438;

    public string? Property438
    {
        get => _property438;
        set
        {
            if (_property438 != value)
            {
                this.OnPropertyChanging();
                this._property438 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property439;

    public string? Property439
    {
        get => _property439;
        set
        {
            if (_property439 != value)
            {
                this.OnPropertyChanging();
                this._property439 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property440;

    public string? Property440
    {
        get => _property440;
        set
        {
            if (_property440 != value)
            {
                this.OnPropertyChanging();
                this._property440 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property441;

    public string? Property441
    {
        get => _property441;
        set
        {
            if (_property441 != value)
            {
                this.OnPropertyChanging();
                this._property441 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property442;

    public string? Property442
    {
        get => _property442;
        set
        {
            if (_property442 != value)
            {
                this.OnPropertyChanging();
                this._property442 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property443;

    public string? Property443
    {
        get => _property443;
        set
        {
            if (_property443 != value)
            {
                this.OnPropertyChanging();
                this._property443 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property444;

    public string? Property444
    {
        get => _property444;
        set
        {
            if (_property444 != value)
            {
                this.OnPropertyChanging();
                this._property444 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property445;

    public string? Property445
    {
        get => _property445;
        set
        {
            if (_property445 != value)
            {
                this.OnPropertyChanging();
                this._property445 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property446;

    public string? Property446
    {
        get => _property446;
        set
        {
            if (_property446 != value)
            {
                this.OnPropertyChanging();
                this._property446 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property447;

    public string? Property447
    {
        get => _property447;
        set
        {
            if (_property447 != value)
            {
                this.OnPropertyChanging();
                this._property447 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property448;

    public string? Property448
    {
        get => _property448;
        set
        {
            if (_property448 != value)
            {
                this.OnPropertyChanging();
                this._property448 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property449;

    public string? Property449
    {
        get => _property449;
        set
        {
            if (_property449 != value)
            {
                this.OnPropertyChanging();
                this._property449 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property450;

    public string? Property450
    {
        get => _property450;
        set
        {
            if (_property450 != value)
            {
                this.OnPropertyChanging();
                this._property450 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property451;

    public string? Property451
    {
        get => _property451;
        set
        {
            if (_property451 != value)
            {
                this.OnPropertyChanging();
                this._property451 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property452;

    public string? Property452
    {
        get => _property452;
        set
        {
            if (_property452 != value)
            {
                this.OnPropertyChanging();
                this._property452 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property453;

    public string? Property453
    {
        get => _property453;
        set
        {
            if (_property453 != value)
            {
                this.OnPropertyChanging();
                this._property453 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property454;

    public string? Property454
    {
        get => _property454;
        set
        {
            if (_property454 != value)
            {
                this.OnPropertyChanging();
                this._property454 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property455;

    public string? Property455
    {
        get => _property455;
        set
        {
            if (_property455 != value)
            {
                this.OnPropertyChanging();
                this._property455 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property456;

    public string? Property456
    {
        get => _property456;
        set
        {
            if (_property456 != value)
            {
                this.OnPropertyChanging();
                this._property456 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property457;

    public string? Property457
    {
        get => _property457;
        set
        {
            if (_property457 != value)
            {
                this.OnPropertyChanging();
                this._property457 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property458;

    public string? Property458
    {
        get => _property458;
        set
        {
            if (_property458 != value)
            {
                this.OnPropertyChanging();
                this._property458 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property459;

    public string? Property459
    {
        get => _property459;
        set
        {
            if (_property459 != value)
            {
                this.OnPropertyChanging();
                this._property459 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property460;

    public string? Property460
    {
        get => _property460;
        set
        {
            if (_property460 != value)
            {
                this.OnPropertyChanging();
                this._property460 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property461;

    public string? Property461
    {
        get => _property461;
        set
        {
            if (_property461 != value)
            {
                this.OnPropertyChanging();
                this._property461 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property462;

    public string? Property462
    {
        get => _property462;
        set
        {
            if (_property462 != value)
            {
                this.OnPropertyChanging();
                this._property462 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property463;

    public string? Property463
    {
        get => _property463;
        set
        {
            if (_property463 != value)
            {
                this.OnPropertyChanging();
                this._property463 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property464;

    public string? Property464
    {
        get => _property464;
        set
        {
            if (_property464 != value)
            {
                this.OnPropertyChanging();
                this._property464 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property465;

    public string? Property465
    {
        get => _property465;
        set
        {
            if (_property465 != value)
            {
                this.OnPropertyChanging();
                this._property465 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property466;

    public string? Property466
    {
        get => _property466;
        set
        {
            if (_property466 != value)
            {
                this.OnPropertyChanging();
                this._property466 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property467;

    public string? Property467
    {
        get => _property467;
        set
        {
            if (_property467 != value)
            {
                this.OnPropertyChanging();
                this._property467 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property468;

    public string? Property468
    {
        get => _property468;
        set
        {
            if (_property468 != value)
            {
                this.OnPropertyChanging();
                this._property468 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property469;

    public string? Property469
    {
        get => _property469;
        set
        {
            if (_property469 != value)
            {
                this.OnPropertyChanging();
                this._property469 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property470;

    public string? Property470
    {
        get => _property470;
        set
        {
            if (_property470 != value)
            {
                this.OnPropertyChanging();
                this._property470 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property471;

    public string? Property471
    {
        get => _property471;
        set
        {
            if (_property471 != value)
            {
                this.OnPropertyChanging();
                this._property471 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property472;

    public string? Property472
    {
        get => _property472;
        set
        {
            if (_property472 != value)
            {
                this.OnPropertyChanging();
                this._property472 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property473;

    public string? Property473
    {
        get => _property473;
        set
        {
            if (_property473 != value)
            {
                this.OnPropertyChanging();
                this._property473 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property474;

    public string? Property474
    {
        get => _property474;
        set
        {
            if (_property474 != value)
            {
                this.OnPropertyChanging();
                this._property474 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property475;

    public string? Property475
    {
        get => _property475;
        set
        {
            if (_property475 != value)
            {
                this.OnPropertyChanging();
                this._property475 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property476;

    public string? Property476
    {
        get => _property476;
        set
        {
            if (_property476 != value)
            {
                this.OnPropertyChanging();
                this._property476 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property477;

    public string? Property477
    {
        get => _property477;
        set
        {
            if (_property477 != value)
            {
                this.OnPropertyChanging();
                this._property477 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property478;

    public string? Property478
    {
        get => _property478;
        set
        {
            if (_property478 != value)
            {
                this.OnPropertyChanging();
                this._property478 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property479;

    public string? Property479
    {
        get => _property479;
        set
        {
            if (_property479 != value)
            {
                this.OnPropertyChanging();
                this._property479 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property480;

    public string? Property480
    {
        get => _property480;
        set
        {
            if (_property480 != value)
            {
                this.OnPropertyChanging();
                this._property480 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property481;

    public string? Property481
    {
        get => _property481;
        set
        {
            if (_property481 != value)
            {
                this.OnPropertyChanging();
                this._property481 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property482;

    public string? Property482
    {
        get => _property482;
        set
        {
            if (_property482 != value)
            {
                this.OnPropertyChanging();
                this._property482 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property483;

    public string? Property483
    {
        get => _property483;
        set
        {
            if (_property483 != value)
            {
                this.OnPropertyChanging();
                this._property483 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property484;

    public string? Property484
    {
        get => _property484;
        set
        {
            if (_property484 != value)
            {
                this.OnPropertyChanging();
                this._property484 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property485;

    public string? Property485
    {
        get => _property485;
        set
        {
            if (_property485 != value)
            {
                this.OnPropertyChanging();
                this._property485 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property486;

    public string? Property486
    {
        get => _property486;
        set
        {
            if (_property486 != value)
            {
                this.OnPropertyChanging();
                this._property486 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property487;

    public string? Property487
    {
        get => _property487;
        set
        {
            if (_property487 != value)
            {
                this.OnPropertyChanging();
                this._property487 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property488;

    public string? Property488
    {
        get => _property488;
        set
        {
            if (_property488 != value)
            {
                this.OnPropertyChanging();
                this._property488 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property489;

    public string? Property489
    {
        get => _property489;
        set
        {
            if (_property489 != value)
            {
                this.OnPropertyChanging();
                this._property489 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property490;

    public string? Property490
    {
        get => _property490;
        set
        {
            if (_property490 != value)
            {
                this.OnPropertyChanging();
                this._property490 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property491;

    public string? Property491
    {
        get => _property491;
        set
        {
            if (_property491 != value)
            {
                this.OnPropertyChanging();
                this._property491 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property492;

    public string? Property492
    {
        get => _property492;
        set
        {
            if (_property492 != value)
            {
                this.OnPropertyChanging();
                this._property492 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property493;

    public string? Property493
    {
        get => _property493;
        set
        {
            if (_property493 != value)
            {
                this.OnPropertyChanging();
                this._property493 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property494;

    public string? Property494
    {
        get => _property494;
        set
        {
            if (_property494 != value)
            {
                this.OnPropertyChanging();
                this._property494 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property495;

    public string? Property495
    {
        get => _property495;
        set
        {
            if (_property495 != value)
            {
                this.OnPropertyChanging();
                this._property495 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property496;

    public string? Property496
    {
        get => _property496;
        set
        {
            if (_property496 != value)
            {
                this.OnPropertyChanging();
                this._property496 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property497;

    public string? Property497
    {
        get => _property497;
        set
        {
            if (_property497 != value)
            {
                this.OnPropertyChanging();
                this._property497 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property498;

    public string? Property498
    {
        get => _property498;
        set
        {
            if (_property498 != value)
            {
                this.OnPropertyChanging();
                this._property498 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property499;

    public string? Property499
    {
        get => _property499;
        set
        {
            if (_property499 != value)
            {
                this.OnPropertyChanging();
                this._property499 = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string? _property500;

    public string? Property500
    {
        get => _property500;
        set
        {
            if (_property500 != value)
            {
                this.OnPropertyChanging();
                this._property500 = value;
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