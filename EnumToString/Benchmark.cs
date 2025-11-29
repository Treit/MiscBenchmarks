namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

public enum SomeEnum
{
    SomeValueA,
    SomeValueB,
    SomeValueC,
    SomeValueD,
    SomeNewValue
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    Dictionary<SomeEnum, string> _dictionaryLookup;
    string[] _arrayLookup;

    [Params(10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _dictionaryLookup = new Dictionary<SomeEnum, string>
        {
            { SomeEnum.SomeValueA, "SomeValueA" },
            { SomeEnum.SomeValueB, "SomeValueB" },
            { SomeEnum.SomeValueC, "SomeValueC" },
            { SomeEnum.SomeValueD, "SomeValueD" },
            { SomeEnum.SomeNewValue, "SomeNewValue" }
        };

        _arrayLookup =
        [
            "SomeValueA",
            "SomeValueB",
            "SomeValueC",
            "SomeValueD",
            "SomeNewValue"
        ];
    }

    [Benchmark]
    public int EnumToString()
    {
        int result = 0;

        for (var i = 0; i < Count; i++)
        {
            var a = SomeEnum.SomeValueA.ToString();
            var b = SomeEnum.SomeValueB.ToString();
            var c = SomeEnum.SomeValueC.ToString();
            var d = SomeEnum.SomeValueD.ToString();
            var e = SomeEnum.SomeNewValue.ToString();

            result += a.Length + b.Length + c.Length + d.Length + e.Length;
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public int Nameof()
    {
        int result = 0;

        for (var i = 0; i < Count; i++)
        {
            var a = nameof(SomeEnum.SomeValueA);
            var b = nameof(SomeEnum.SomeValueB);
            var c = nameof(SomeEnum.SomeValueC);
            var d = nameof(SomeEnum.SomeValueD);
            var e = nameof(SomeEnum.SomeNewValue);

            result += a.Length + b.Length + c.Length + d.Length + e.Length;
        }

        return result;
    }

    [Benchmark]
    public int CustomGetStringUsingSwitch()
    {
        int result = 0;

        for (var i = 0; i < Count; i++)
        {
            var a = GetEnumString(SomeEnum.SomeValueA);
            var b = GetEnumString(SomeEnum.SomeValueB);
            var c = GetEnumString(SomeEnum.SomeValueC);
            var d = GetEnumString(SomeEnum.SomeValueD);
            var e = GetEnumString(SomeEnum.SomeNewValue);

            result += a.Length + b.Length + c.Length + d.Length + e.Length;
        }

        return result;
    }

    [Benchmark]
    public int EnumVariableToString()
    {
        int result = 0;

        for (var i = 0; i < Count; i++)
        {
            var enumVariableA = SomeEnum.SomeValueA;
            var enumVariableB = SomeEnum.SomeValueB;
            var enumVariableC = SomeEnum.SomeValueC;
            var enumVariableD = SomeEnum.SomeValueD;
            var enumVariableE = SomeEnum.SomeNewValue;

            result += enumVariableA.ToString().Length
                + enumVariableB.ToString().Length
                + enumVariableC.ToString().Length
                + enumVariableD.ToString().Length
                + enumVariableE.ToString().Length;
        }

        return result;
    }

    [Benchmark]
    public int EnumVariableDictionaryLookup()
    {
        int result = 0;

        for (var i = 0; i < Count; i++)
        {
            var enumVariableA = SomeEnum.SomeValueA;
            var enumVariableB = SomeEnum.SomeValueB;
            var enumVariableC = SomeEnum.SomeValueC;
            var enumVariableD = SomeEnum.SomeValueD;
            var enumVariableE = SomeEnum.SomeNewValue;

            result += _dictionaryLookup[enumVariableA].Length
                + _dictionaryLookup[enumVariableB].Length
                + _dictionaryLookup[enumVariableC].Length
                + _dictionaryLookup[enumVariableD].Length
                + _dictionaryLookup[enumVariableE].Length;
        }

        return result;
    }

    [Benchmark]
    public int EnumVariableArrayLookup()
    {
        int result = 0;

        for (var i = 0; i < Count; i++)
        {
            var enumVariableA = SomeEnum.SomeValueA;
            var enumVariableB = SomeEnum.SomeValueB;
            var enumVariableC = SomeEnum.SomeValueC;
            var enumVariableD = SomeEnum.SomeValueD;
            var enumVariableE = SomeEnum.SomeNewValue;

            result += _arrayLookup[(int)enumVariableA].Length
                + _arrayLookup[(int)enumVariableB].Length
                + _arrayLookup[(int)enumVariableC].Length
                + _arrayLookup[(int)enumVariableD].Length
                + _arrayLookup[(int)enumVariableE].Length;
        }

        return result;
    }

    static string GetEnumString(SomeEnum e)
    {
        return e switch
        {
            SomeEnum.SomeValueA => "SomeValueA",
            SomeEnum.SomeValueB => "SomeValueB",
            SomeEnum.SomeValueC => "SomeValueC",
            SomeEnum.SomeValueD => "SomeValueD",
            _ => e.ToString()
        };
    }

}
