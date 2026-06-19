using BenchmarkDotNet.Running;
using Test;

#if RELEASE
BenchmarkRunner.Run<Benchmark>();
#else
var b = new Benchmark();
b.GlobalSetup();
var json = b.JsonSerialize();
var linq = b.LinqWhere();
Console.WriteLine($"JSON length: {json.Length}");
Console.WriteLine($"LINQ count: {linq}");
#endif