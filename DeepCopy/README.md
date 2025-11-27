# Deep cloning an object.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Count | Mean         | Error        | StdDev       | Ratio | RatioSD | Gen0      | Gen1      | Gen2     | Allocated   | Alloc Ratio |
|------------------------- |---------- |---------- |------ |-------------:|-------------:|-------------:|------:|--------:|----------:|----------:|---------:|------------:|------------:|
| **CloneWithBinaryFormatter** | **.NET 10.0** | **.NET 10.0** | **10**    |           **NA** |           **NA** |           **NA** |     **?** |       **?** |        **NA** |        **NA** |       **NA** |          **NA** |           **?** |
| CloneWithJson            | .NET 10.0 | .NET 10.0 | 10    |     26.08 μs |     0.204 μs |     0.191 μs |  1.00 |    0.01 |    1.8921 |    0.1831 |        - |    30.98 KB |        1.00 |
|                          |           |           |       |              |              |              |       |         |           |           |          |             |             |
| CloneWithBinaryFormatter | .NET 9.0  | .NET 9.0  | 10    |           NA |           NA |           NA |     ? |       ? |        NA |        NA |       NA |          NA |           ? |
| CloneWithJson            | .NET 9.0  | .NET 9.0  | 10    |     26.08 μs |     0.184 μs |     0.163 μs |  1.00 |    0.01 |    1.8921 |    0.1831 |        - |    30.98 KB |        1.00 |
|                          |           |           |       |              |              |              |       |         |           |           |          |             |             |
| **CloneWithBinaryFormatter** | **.NET 10.0** | **.NET 10.0** | **10000** |           **NA** |           **NA** |           **NA** |     **?** |       **?** |        **NA** |        **NA** |       **NA** |          **NA** |           **?** |
| CloneWithJson            | .NET 10.0 | .NET 10.0 | 10000 | 56,101.97 μs | 1,102.443 μs | 1,471.730 μs |  1.00 |    0.04 | 1444.4444 | 1333.3333 | 444.4444 | 30126.69 KB |        1.00 |
|                          |           |           |       |              |              |              |       |         |           |           |          |             |             |
| CloneWithBinaryFormatter | .NET 9.0  | .NET 9.0  | 10000 |           NA |           NA |           NA |     ? |       ? |        NA |        NA |       NA |          NA |           ? |
| CloneWithJson            | .NET 9.0  | .NET 9.0  | 10000 | 56,720.35 μs | 1,129.451 μs | 1,468.605 μs |  1.00 |    0.04 | 1444.4444 | 1333.3333 | 444.4444 | 30126.46 KB |        1.00 |

Benchmarks with issues:
  Benchmark.CloneWithBinaryFormatter: .NET 10.0(Runtime=.NET 10.0) [Count=10]
  Benchmark.CloneWithBinaryFormatter: .NET 9.0(Runtime=.NET 9.0) [Count=10]
  Benchmark.CloneWithBinaryFormatter: .NET 10.0(Runtime=.NET 10.0) [Count=10000]
  Benchmark.CloneWithBinaryFormatter: .NET 9.0(Runtime=.NET 9.0) [Count=10000]
