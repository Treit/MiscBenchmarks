using BenchmarkDotNet.Running;
using Test;

BenchmarkRunner.Run<SmallBenchmark>();
BenchmarkRunner.Run<BigBenchmark>();