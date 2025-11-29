# Finding matches using Dictionary vs Linear Search using LINQ.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Job       | Runtime   | Count | Mean             | Error          | StdDev         | Ratio  | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------------- |---------- |---------- |------ |-----------------:|---------------:|---------------:|-------:|--------:|--------:|----------:|------------:|
| **FindMatchesUsingDictionary**            | **.NET 10.0** | **.NET 10.0** | **10**    |         **28.81 ns** |       **0.346 ns** |       **0.289 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | .NET 10.0 | .NET 10.0 | 10    |        143.57 ns |       2.862 ns |       2.811 ns |   4.98 |    0.11 |  0.0525 |     880 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | .NET 10.0 | .NET 10.0 | 10    |        103.72 ns |       1.310 ns |       1.225 ns |   3.60 |    0.05 |  0.0381 |     640 B |          NA |
|                                       |           |           |       |                  |                |                |        |         |         |           |             |
| FindMatchesUsingDictionary            | .NET 9.0  | .NET 9.0  | 10    |         28.80 ns |       0.196 ns |       0.183 ns |   1.00 |    0.01 |       - |         - |          NA |
| FindMatchesUsingFirstOrDeault         | .NET 9.0  | .NET 9.0  | 10    |        147.99 ns |       2.458 ns |       2.299 ns |   5.14 |    0.08 |  0.0525 |     880 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | .NET 9.0  | .NET 9.0  | 10    |        103.27 ns |       1.304 ns |       1.156 ns |   3.59 |    0.04 |  0.0381 |     640 B |          NA |
|                                       |           |           |       |                  |                |                |        |         |         |           |             |
| **FindMatchesUsingDictionary**            | **.NET 10.0** | **.NET 10.0** | **100**   |        **295.34 ns** |       **2.586 ns** |       **2.419 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | .NET 10.0 | .NET 10.0 | 100   |      3,564.29 ns |      32.914 ns |      30.788 ns |  12.07 |    0.14 |  0.5226 |    8800 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | .NET 10.0 | .NET 10.0 | 100   |      2,747.70 ns |      29.806 ns |      24.889 ns |   9.30 |    0.11 |  0.3815 |    6400 B |          NA |
|                                       |           |           |       |                  |                |                |        |         |         |           |             |
| FindMatchesUsingDictionary            | .NET 9.0  | .NET 9.0  | 100   |        294.97 ns |       2.179 ns |       2.038 ns |   1.00 |    0.01 |       - |         - |          NA |
| FindMatchesUsingFirstOrDeault         | .NET 9.0  | .NET 9.0  | 100   |      3,589.97 ns |      31.740 ns |      29.690 ns |  12.17 |    0.13 |  0.5226 |    8800 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | .NET 9.0  | .NET 9.0  | 100   |      3,062.11 ns |      58.885 ns |      60.471 ns |  10.38 |    0.21 |  0.3815 |    6400 B |          NA |
|                                       |           |           |       |                  |                |                |        |         |         |           |             |
| **FindMatchesUsingDictionary**            | **.NET 10.0** | **.NET 10.0** | **10000** |     **31,752.27 ns** |     **336.214 ns** |     **314.495 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | .NET 10.0 | .NET 10.0 | 10000 | 24,331,707.14 ns | 112,507.499 ns |  99,734.968 ns | 766.37 |    7.91 | 31.2500 |  880000 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | .NET 10.0 | .NET 10.0 | 10000 | 21,294,543.96 ns | 197,759.719 ns | 184,984.564 ns | 670.71 |    8.53 | 31.2500 |  640000 B |          NA |
|                                       |           |           |       |                  |                |                |        |         |         |           |             |
| FindMatchesUsingDictionary            | .NET 9.0  | .NET 9.0  | 10000 |     31,809.55 ns |     405.577 ns |     359.533 ns |   1.00 |    0.02 |       - |         - |          NA |
| FindMatchesUsingFirstOrDeault         | .NET 9.0  | .NET 9.0  | 10000 | 24,891,301.34 ns | 193,723.252 ns | 171,730.617 ns | 782.60 |    9.99 | 31.2500 |  880000 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | .NET 9.0  | .NET 9.0  | 10000 | 21,590,988.54 ns | 199,036.051 ns | 186,178.446 ns | 678.84 |    9.31 | 31.2500 |  640000 B |          NA |
