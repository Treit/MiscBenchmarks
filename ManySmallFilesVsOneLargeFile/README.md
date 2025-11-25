# Reading many small files vs. one large file.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method         | Count | Mean        | Error       | StdDev      | Gen0     | Allocated  |
|--------------- |------ |------------:|------------:|------------:|---------:|-----------:|
| ManySmallFiles | 1000  | 78,602.1 μs | 1,366.15 μs | 1,402.93 μs | 428.5714 | 7943.72 KB |
| OneBigFile     | 1000  |    105.3 μs |     2.09 μs |     1.96 μs |   2.1973 |   38.98 KB |
