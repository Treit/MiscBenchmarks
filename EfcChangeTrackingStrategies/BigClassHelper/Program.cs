using System.Text;

var builder = new StringBuilder();
builder.AppendLine("public class BigPerson : INotifyPropertyChanged, INotifyPropertyChanging");
builder.AppendLine("{");
builder.AppendLine("""
    private long _id;
    public long Id { get => _id; set { if (_id != value) { this.OnPropertyChanging(); this._id = value; this.OnPropertyChanged(); } } }

    private bool _isInit;
    public bool IsInit { get => _isInit; set { if (_isInit != value) { this.OnPropertyChanging(); this._isInit = value; this.OnPropertyChanged(); } } }

    """);


for (int i = 1; i < 251; i++)
{
    builder.AppendLine($$$"""
    private int _property{{{i}}};
    public int Property{{{i}}} { get => _property{{{i}}}; set { if (_property{{{i}}} != value) { this.OnPropertyChanging(); this._property{{{i}}} = value; this.OnPropertyChanged(); } } }

    """);
}
for (int i = 252; i < 501; i++)
{
    builder.AppendLine($$$"""
    private string? _property{{{i}}};
    public string? Property{{{i}}} { get => _property{{{i}}}; set { if (_property{{{i}}} != value) { this.OnPropertyChanging(); this._property{{{i}}} = value; this.OnPropertyChanged(); } } }

    """);
}

builder.AppendLine(
"""

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
""");

builder.AppendLine("}");

File.WriteAllText("output.txt", builder.ToString());
