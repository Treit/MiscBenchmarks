# Dividing





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Count  | Mean            | Error        | StdDev       | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |------- |----------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **DivideUsingFloat**   | **100**    |        **60.05 ns** |     **0.572 ns** |     **0.535 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DivideUsingDouble  | 100    |        60.08 ns |     0.603 ns |     0.564 ns |  1.00 |    0.01 |         - |          NA |
| DivideUsingDecimal | 100    |     2,541.90 ns |    11.687 ns |    10.932 ns | 42.33 |    0.41 |         - |          NA |
| DivideUsingInt     | 100    |        79.06 ns |     0.439 ns |     0.410 ns |  1.32 |    0.01 |         - |          NA |
|                    |        |                 |              |              |       |         |           |             |
| **DivideUsingFloat**   | **100000** |    **93,314.15 ns** |   **353.886 ns** |   **295.511 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| DivideUsingDouble  | 100000 |    93,300.00 ns |   339.800 ns |   317.849 ns |  1.00 |    0.00 |         - |          NA |
| DivideUsingDecimal | 100000 | 1,063,040.47 ns | 7,825.042 ns | 7,319.549 ns | 11.39 |    0.08 |         - |          NA |
| DivideUsingInt     | 100000 |    93,309.15 ns |   356.091 ns |   333.088 ns |  1.00 |    0.00 |         - |          NA |
