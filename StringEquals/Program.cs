using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Jobs;

BenchmarkRunner.Run<StringTest>();

public class StringTest
{
    readonly string string1 = new string('a', 10);
    readonly string string2 = new string('a', 10);

    [Params(10, 100)]
    public int numIterations;

    [Benchmark]
    public bool EqualsObject()
    {
        bool result = false;
        for (int i = 0; i < numIterations; i++)
        {
            result = string1.Equals((object)string2);
        }
        return result;
    }

    [Benchmark]
    public bool EqualsString()
    {
        bool result = false;
        for (int i = 0; i < numIterations; i++)
        {
            result = string1.Equals(string2);
        }
        return result;
    }

    [Benchmark]
    public bool EqualsStringExplicitOrdinal()
    {
        bool result = false;
        for (int i = 0; i < numIterations; i++)
        {
            result = string1.Equals(string2, StringComparison.Ordinal);
        }
        return result;
    }

    [Benchmark]
    public bool EqualsStringOperator()
    {
        bool result = false;
        for (int i = 0; i < numIterations; i++)
        {
            result = string1 == string2;
        }
        return result;
    }
}
