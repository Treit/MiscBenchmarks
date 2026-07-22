using System;
using BenchmarkDotNet.Running;
using Test;

#if RELEASE
BenchmarkRunner.Run<Benchmark>();
#else
var b = new Benchmark();
b.Size = 100;
b.GlobalSetup();
var createDelegateResult = b.MethodInfoCreateDelegate();
var expressionCompiledResult = b.ExpressionCompiledDelegate();
if (createDelegateResult != expressionCompiledResult)
{
    throw new InvalidOperationException("Delegates produced different results.");
}

Console.WriteLine(expressionCompiledResult);
#endif