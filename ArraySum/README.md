# Summing up multi-dimensional and jagged arrays.



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host] : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|    Method | Size | Mean | Error |
|---------- |----- |-----:|------:|
| SumJagged | 1000 |   NA |    NA |

Benchmarks with issues:
  Benchmark.SumJagged: .NET 7.0(Runtime=.NET 7.0) [Size=1000]
