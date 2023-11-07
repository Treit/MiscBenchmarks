using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
