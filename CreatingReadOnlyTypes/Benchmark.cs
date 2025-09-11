namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

[MemoryDiagnoser]
public class PropertyAccessorBenchmark
{
    [Params(1, 1_000, 100_000)]
    public int Count { get; set; }

    private string _first = "John";
    private string _last = "Doe";

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark(Baseline = true)]
    public int New_ClassInit()
    {
        int sum = 0;
        for (int i = 0; i < Count; i++)
        {
            var p = new PersonClass(_first, _last);
            // access properties to avoid dead-code elimination
            sum += p.FirstName.Length + p.LastName.Length;
        }
        return sum;
    }

    [Benchmark]
    public int New_RecordPositional()
    {
        int sum = 0;
        for (int i = 0; i < Count; i++)
        {
            var p = new PersonRecordPos(_first, _last);
            sum += p.FirstName.Length + p.LastName.Length;
        }
        return sum;
    }

    [Benchmark]
    public int New_RecordInitProperties()
    {
        int sum = 0;
        for (int i = 0; i < Count; i++)
        {
            var p = new PersonRecordInit(_first, _last);
            sum += p.FirstName.Length + p.LastName.Length;
        }
        return sum;
    }

    [Benchmark]
    public int New_ClassExpressionBodied()
    {
        int sum = 0;
        for (int i = 0; i < Count; i++)
        {
            var p = new PersonClassExpression(_first, _last);
            // access expression-bodied members rather than string properties
            sum += p.FirstNameLength + p.LastNameLength;
        }
        return sum;
    }

    [Benchmark]
    public int New_ClassPrimaryConstructor()
    {
        int sum = 0;
        for (int i = 0; i < Count; i++)
        {
            var p = new PersonPrimaryConstructor(_first, _last);
            sum += p.FirstName.Length + p.LastName.Length;
        }
        return sum;
    }
}

// Types under test
public class PersonClass
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public PersonClass(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);
}

public record PersonRecordPos(string FirstName, string LastName);

public record PersonRecordInit
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public PersonRecordInit(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);
}

public class PersonClassExpression
{
    private readonly string _first;
    private readonly string _last;

    public PersonClassExpression(string firstName, string lastName)
        => (_first, _last) = (firstName, lastName);

    // expression-bodied property-like members returning lengths
    public int FirstNameLength => _first.Length;
    public int LastNameLength => _last.Length;
}

public class PersonPrimaryConstructor(string firstName, string lastName)
{
    // expression-bodied properties that return the primary-constructor parameters
    public string FirstName => firstName;
    public string LastName => lastName;
}