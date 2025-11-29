# Enumerating array vs. ReadOnlyCollection wrapper around the array.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]   : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job      | Runtime  | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |--------- |--------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| EnumerateArray              | .NET 7.0 | .NET 7.0 | 100   |        NA |       NA |       NA |     ? |       ? |     NA |        NA |           ? |
| EnumerateArrayAsEnumerable  | .NET 7.0 | .NET 7.0 | 100   |        NA |       NA |       NA |     ? |       ? |     NA |        NA |           ? |
| EnumerateReadOnlyCollection | .NET 7.0 | .NET 7.0 | 100   |        NA |       NA |       NA |     ? |       ? |     NA |        NA |           ? |
| EnumerateArray              | .NET 8.0 | .NET 8.0 | 100   |        NA |       NA |       NA |     ? |       ? |     NA |        NA |           ? |
| EnumerateArrayAsEnumerable  | .NET 8.0 | .NET 8.0 | 100   |        NA |       NA |       NA |     ? |       ? |     NA |        NA |           ? |
| EnumerateReadOnlyCollection | .NET 8.0 | .NET 8.0 | 100   |        NA |       NA |       NA |     ? |       ? |     NA |        NA |           ? |
| EnumerateArray              | .NET 9.0 | .NET 9.0 | 100   |  40.94 ns | 0.427 ns | 0.356 ns |  0.37 |    0.01 |      - |         - |        0.00 |
| EnumerateArrayAsEnumerable  | .NET 9.0 | .NET 9.0 | 100   |  43.48 ns | 0.892 ns | 1.821 ns |  0.39 |    0.02 |      - |         - |        0.00 |
| EnumerateReadOnlyCollection | .NET 9.0 | .NET 9.0 | 100   | 110.84 ns | 1.498 ns | 1.402 ns |  1.00 |    0.02 | 0.0019 |      32 B |        1.00 |

Benchmarks with issues:
  Benchmark.EnumerateArray: .NET 7.0(Runtime=.NET 7.0) [Count=100]
  Benchmark.EnumerateArrayAsEnumerable: .NET 7.0(Runtime=.NET 7.0) [Count=100]
  Benchmark.EnumerateReadOnlyCollection: .NET 7.0(Runtime=.NET 7.0) [Count=100]
  Benchmark.EnumerateArray: .NET 8.0(Runtime=.NET 8.0) [Count=100]
  Benchmark.EnumerateArrayAsEnumerable: .NET 8.0(Runtime=.NET 8.0) [Count=100]
  Benchmark.EnumerateReadOnlyCollection: .NET 8.0(Runtime=.NET 8.0) [Count=100]
