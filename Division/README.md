# Dividing






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Job       | Runtime   | Count  | Mean            | Error        | StdDev       | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |---------- |---------- |------- |----------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **DivideUsingFloat**   | **.NET 10.0** | **.NET 10.0** | **100**    |        **60.13 ns** |     **0.518 ns** |     **0.484 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DivideUsingDouble  | .NET 10.0 | .NET 10.0 | 100    |        60.12 ns |     0.529 ns |     0.494 ns |  1.00 |    0.01 |         - |          NA |
| DivideUsingDecimal | .NET 10.0 | .NET 10.0 | 100    |     2,545.11 ns |    16.016 ns |    14.981 ns | 42.33 |    0.41 |         - |          NA |
| DivideUsingInt     | .NET 10.0 | .NET 10.0 | 100    |        79.13 ns |     0.410 ns |     0.383 ns |  1.32 |    0.01 |         - |          NA |
|                    |           |           |        |                 |              |              |       |         |           |             |
| DivideUsingFloat   | .NET 9.0  | .NET 9.0  | 100    |        59.76 ns |     0.552 ns |     0.516 ns |  1.00 |    0.01 |         - |          NA |
| DivideUsingDouble  | .NET 9.0  | .NET 9.0  | 100    |        60.25 ns |     0.584 ns |     0.546 ns |  1.01 |    0.01 |         - |          NA |
| DivideUsingDecimal | .NET 9.0  | .NET 9.0  | 100    |     2,546.24 ns |    11.933 ns |    11.162 ns | 42.61 |    0.40 |         - |          NA |
| DivideUsingInt     | .NET 9.0  | .NET 9.0  | 100    |        79.21 ns |     0.513 ns |     0.479 ns |  1.33 |    0.01 |         - |          NA |
|                    |           |           |        |                 |              |              |       |         |           |             |
| **DivideUsingFloat**   | **.NET 10.0** | **.NET 10.0** | **100000** |    **93,415.11 ns** |   **372.210 ns** |   **348.165 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DivideUsingDouble  | .NET 10.0 | .NET 10.0 | 100000 |    93,442.53 ns |   388.007 ns |   362.942 ns |  1.00 |    0.01 |         - |          NA |
| DivideUsingDecimal | .NET 10.0 | .NET 10.0 | 100000 | 1,067,070.21 ns | 8,928.272 ns | 8,351.511 ns | 11.42 |    0.10 |         - |          NA |
| DivideUsingInt     | .NET 10.0 | .NET 10.0 | 100000 |    93,357.86 ns |   368.778 ns |   344.955 ns |  1.00 |    0.01 |         - |          NA |
|                    |           |           |        |                 |              |              |       |         |           |             |
| DivideUsingFloat   | .NET 9.0  | .NET 9.0  | 100000 |    93,498.28 ns |   342.538 ns |   320.411 ns |  1.00 |    0.00 |         - |          NA |
| DivideUsingDouble  | .NET 9.0  | .NET 9.0  | 100000 |    93,619.80 ns |   396.360 ns |   370.755 ns |  1.00 |    0.01 |         - |          NA |
| DivideUsingDecimal | .NET 9.0  | .NET 9.0  | 100000 | 1,067,316.13 ns | 9,611.653 ns | 8,990.746 ns | 11.42 |    0.10 |         - |          NA |
| DivideUsingInt     | .NET 9.0  | .NET 9.0  | 100000 |    93,414.17 ns |   401.960 ns |   375.994 ns |  1.00 |    0.01 |         - |          NA |
