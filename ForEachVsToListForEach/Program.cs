using BenchmarkDotNet.Running;
using Test;

#if RELEASE
BenchmarkRunner.Run<Benchmark>();
#else

var b = new Benchmark();
b.Count = 1_000_000;
b.GlobalSetup();
var first = b.ForEach();
var second = b.ToListDotForEach();
Console.WriteLine($"{first} <-> {second}");
#endif
