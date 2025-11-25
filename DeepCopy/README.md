# Deep cloning an object.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Count | Mean         | Error        | StdDev       | Ratio | RatioSD | Gen0      | Gen1      | Gen2     | Allocated   | Alloc Ratio |
|------------------------- |------ |-------------:|-------------:|-------------:|------:|--------:|----------:|----------:|---------:|------------:|------------:|
| **CloneWithBinaryFormatter** | **10**    |           **NA** |           **NA** |           **NA** |     **?** |       **?** |        **NA** |        **NA** |       **NA** |          **NA** |           **?** |
| CloneWithJson            | 10    |     25.53 μs |     0.143 μs |     0.127 μs |  1.00 |    0.01 |    1.8921 |    0.1831 |        - |    30.98 KB |        1.00 |
|                          |       |              |              |              |       |         |           |           |          |             |             |
| **CloneWithBinaryFormatter** | **10000** |           **NA** |           **NA** |           **NA** |     **?** |       **?** |        **NA** |        **NA** |       **NA** |          **NA** |           **?** |
| CloneWithJson            | 10000 | 57,855.95 μs | 1,146.441 μs | 1,407.932 μs |  1.00 |    0.03 | 1444.4444 | 1333.3333 | 444.4444 | 30126.46 KB |        1.00 |

Benchmarks with issues:
  Benchmark.CloneWithBinaryFormatter: DefaultJob [Count=10]
  Benchmark.CloneWithBinaryFormatter: DefaultJob [Count=10000]
