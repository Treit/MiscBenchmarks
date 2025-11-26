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
| ManySmallFiles | 1000  | 79,391.7 μs | 1,396.47 μs | 1,306.26 μs | 428.5714 | 7943.72 KB |
| OneBigFile     | 1000  |    107.2 μs |     2.08 μs |     1.95 μs |   2.1973 |   38.98 KB |
