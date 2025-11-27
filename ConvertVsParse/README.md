## Convert.ToInt32 vs. int.Parse





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Count  | Mean            | Error         | StdDev        | Ratio | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |------- |----------------:|--------------:|--------------:|------:|----------:|------------:|
| **StringToIntUsingConvert**  | **.NET 10.0** | **.NET 10.0** | **10**     |        **68.98 ns** |      **0.558 ns** |      **0.522 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | .NET 10.0 | .NET 10.0 | 10     |        69.46 ns |      0.608 ns |      0.568 ns |  1.01 |         - |          NA |
| StringToIntUsingTryParse | .NET 10.0 | .NET 10.0 | 10     |        69.53 ns |      0.524 ns |      0.490 ns |  1.01 |         - |          NA |
|                          |           |           |        |                 |               |               |       |           |             |
| StringToIntUsingConvert  | .NET 9.0  | .NET 9.0  | 10     |        69.10 ns |      0.570 ns |      0.534 ns |  1.00 |         - |          NA |
| StringToIntUsingParse    | .NET 9.0  | .NET 9.0  | 10     |        68.68 ns |      0.581 ns |      0.543 ns |  0.99 |         - |          NA |
| StringToIntUsingTryParse | .NET 9.0  | .NET 9.0  | 10     |        69.20 ns |      0.652 ns |      0.610 ns |  1.00 |         - |          NA |
|                          |           |           |        |                 |               |               |       |           |             |
| **StringToIntUsingConvert**  | **.NET 10.0** | **.NET 10.0** | **100**    |       **756.43 ns** |      **5.532 ns** |      **5.175 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | .NET 10.0 | .NET 10.0 | 100    |       756.72 ns |      3.278 ns |      2.906 ns |  1.00 |         - |          NA |
| StringToIntUsingTryParse | .NET 10.0 | .NET 10.0 | 100    |       786.51 ns |      3.574 ns |      3.343 ns |  1.04 |         - |          NA |
|                          |           |           |        |                 |               |               |       |           |             |
| StringToIntUsingConvert  | .NET 9.0  | .NET 9.0  | 100    |       782.82 ns |      3.757 ns |      3.137 ns |  1.00 |         - |          NA |
| StringToIntUsingParse    | .NET 9.0  | .NET 9.0  | 100    |       756.10 ns |      4.888 ns |      4.333 ns |  0.97 |         - |          NA |
| StringToIntUsingTryParse | .NET 9.0  | .NET 9.0  | 100    |       786.72 ns |      2.342 ns |      2.076 ns |  1.00 |         - |          NA |
|                          |           |           |        |                 |               |               |       |           |             |
| **StringToIntUsingConvert**  | **.NET 10.0** | **.NET 10.0** | **10000**  |    **93,392.10 ns** |    **595.318 ns** |    **556.861 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | .NET 10.0 | .NET 10.0 | 10000  |    93,927.13 ns |    607.755 ns |    568.495 ns |  1.01 |         - |          NA |
| StringToIntUsingTryParse | .NET 10.0 | .NET 10.0 | 10000  |    94,018.68 ns |    637.347 ns |    564.992 ns |  1.01 |         - |          NA |
|                          |           |           |        |                 |               |               |       |           |             |
| StringToIntUsingConvert  | .NET 9.0  | .NET 9.0  | 10000  |    93,525.78 ns |    423.091 ns |    375.060 ns |  1.00 |         - |          NA |
| StringToIntUsingParse    | .NET 9.0  | .NET 9.0  | 10000  |    93,768.64 ns |    563.804 ns |    527.383 ns |  1.00 |         - |          NA |
| StringToIntUsingTryParse | .NET 9.0  | .NET 9.0  | 10000  |    94,184.82 ns |    595.944 ns |    528.289 ns |  1.01 |         - |          NA |
|                          |           |           |        |                 |               |               |       |           |             |
| **StringToIntUsingConvert**  | **.NET 10.0** | **.NET 10.0** | **100000** | **1,001,266.50 ns** |  **8,955.791 ns** |  **8,377.252 ns** |  **1.00** |         **-** |          **NA** |
| StringToIntUsingParse    | .NET 10.0 | .NET 10.0 | 100000 | 1,034,795.69 ns | 10,916.751 ns | 10,211.536 ns |  1.03 |         - |          NA |
| StringToIntUsingTryParse | .NET 10.0 | .NET 10.0 | 100000 | 1,034,450.36 ns |  9,090.436 ns |  8,503.200 ns |  1.03 |         - |          NA |
|                          |           |           |        |                 |               |               |       |           |             |
| StringToIntUsingConvert  | .NET 9.0  | .NET 9.0  | 100000 | 1,004,490.96 ns |  9,236.666 ns |  8,639.983 ns |  1.00 |         - |          NA |
| StringToIntUsingParse    | .NET 9.0  | .NET 9.0  | 100000 | 1,036,914.93 ns | 12,784.091 ns | 11,958.247 ns |  1.03 |         - |          NA |
| StringToIntUsingTryParse | .NET 9.0  | .NET 9.0  | 100000 | 1,034,649.73 ns |  8,955.624 ns |  8,377.096 ns |  1.03 |         - |          NA |
