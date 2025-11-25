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
| **DivideUsingFloat**   | **100**    |        **59.97 ns** |     **0.451 ns** |     **0.422 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| DivideUsingDouble  | 100    |        59.92 ns |     0.574 ns |     0.537 ns |  1.00 |    0.01 |         - |          NA |
| DivideUsingDecimal | 100    |     2,535.18 ns |    13.037 ns |    12.195 ns | 42.28 |    0.35 |         - |          NA |
| DivideUsingInt     | 100    |        78.87 ns |     0.339 ns |     0.318 ns |  1.32 |    0.01 |         - |          NA |
|                    |        |                 |              |              |       |         |           |             |
| **DivideUsingFloat**   | **100000** |    **93,277.20 ns** |   **330.897 ns** |   **309.521 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| DivideUsingDouble  | 100000 |    93,263.76 ns |   347.541 ns |   290.212 ns |  1.00 |    0.00 |         - |          NA |
| DivideUsingDecimal | 100000 | 1,062,376.68 ns | 7,786.064 ns | 7,283.089 ns | 11.39 |    0.08 |         - |          NA |
| DivideUsingInt     | 100000 |    93,292.90 ns |   274.200 ns |   243.071 ns |  1.00 |    0.00 |         - |          NA |
