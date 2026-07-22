using System;
using System.Linq.Expressions;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Test;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Params(100, 10_000_000)]
    public int Size { get; set; }

    private Calculator _calculator = null!;
    private Func<int, int, int> _createDelegate = null!;
    private Func<int, int, int> _expressionCompiledDelegate = null!;
    private int _left;
    private int _right;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _calculator = new Calculator(Size % 97);
        _left = Size;
        _right = (Size / 2) + 3;

        var method = typeof(Calculator).GetMethod(nameof(Calculator.Combine))!;
        _createDelegate = method.CreateDelegate<Func<int, int, int>>(_calculator);
        _expressionCompiledDelegate = CreateExpressionDelegate(method, _calculator);
    }

    [Benchmark(Baseline = true)]
    public int MethodInfoCreateDelegate() => _createDelegate(_left, _right);

    [Benchmark]
    public int ExpressionCompiledDelegate() => _expressionCompiledDelegate(_left, _right);

    private static Func<int, int, int> CreateExpressionDelegate(MethodInfo method, Calculator calculator)
    {
        var left = Expression.Parameter(typeof(int), "left");
        var right = Expression.Parameter(typeof(int), "right");
        var call = Expression.Call(Expression.Constant(calculator), method, left, right);

        return Expression.Lambda<Func<int, int, int>>(call, left, right).Compile();
    }

    public sealed class Calculator(int offset)
    {
        public int Combine(int left, int right) => unchecked((left * 31) + right + offset);
    }
}
