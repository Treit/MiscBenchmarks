# Indexing strings





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Job       | Runtime   | Count | Mean         | Error        | StdDev       | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------ |---------- |---------- |------ |-------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **FindIndexesInString**                       | **.NET 10.0** | **.NET 10.0** | **10**    |     **28.23 ns** |     **0.398 ns** |     **0.373 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| FindIndexesInIntArray                     | .NET 10.0 | .NET 10.0 | 10    |     28.74 ns |     0.250 ns |     0.222 ns |  1.02 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | .NET 10.0 | .NET 10.0 | 10    |     32.30 ns |     0.366 ns |     0.342 ns |  1.14 |    0.02 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | .NET 10.0 | .NET 10.0 | 10    |     37.98 ns |     0.499 ns |     0.443 ns |  1.35 |    0.02 |         - |          NA |
| FindIndexesBytePointers                   | .NET 10.0 | .NET 10.0 | 10    |     25.50 ns |     0.158 ns |     0.140 ns |  0.90 |    0.01 |         - |          NA |
|                                           |           |           |       |              |              |              |       |         |           |             |
| FindIndexesInString                       | .NET 9.0  | .NET 9.0  | 10    |     28.80 ns |     0.319 ns |     0.298 ns |  1.00 |    0.01 |         - |          NA |
| FindIndexesInIntArray                     | .NET 9.0  | .NET 9.0  | 10    |     30.32 ns |     0.280 ns |     0.262 ns |  1.05 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | .NET 9.0  | .NET 9.0  | 10    |     33.50 ns |     0.415 ns |     0.389 ns |  1.16 |    0.02 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | .NET 9.0  | .NET 9.0  | 10    |     38.05 ns |     0.570 ns |     0.533 ns |  1.32 |    0.02 |         - |          NA |
| FindIndexesBytePointers                   | .NET 9.0  | .NET 9.0  | 10    |     30.34 ns |     0.294 ns |     0.260 ns |  1.05 |    0.01 |         - |          NA |
|                                           |           |           |       |              |              |              |       |         |           |             |
| **FindIndexesInString**                       | **.NET 10.0** | **.NET 10.0** | **100**   |    **324.70 ns** |     **1.711 ns** |     **1.600 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FindIndexesInIntArray                     | .NET 10.0 | .NET 10.0 | 100   |    337.92 ns |     1.706 ns |     1.512 ns |  1.04 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | .NET 10.0 | .NET 10.0 | 100   |    306.50 ns |     2.730 ns |     2.420 ns |  0.94 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | .NET 10.0 | .NET 10.0 | 100   |    386.55 ns |     2.743 ns |     2.141 ns |  1.19 |    0.01 |         - |          NA |
| FindIndexesBytePointers                   | .NET 10.0 | .NET 10.0 | 100   |    319.19 ns |     2.845 ns |     2.661 ns |  0.98 |    0.01 |         - |          NA |
|                                           |           |           |       |              |              |              |       |         |           |             |
| FindIndexesInString                       | .NET 9.0  | .NET 9.0  | 100   |    317.24 ns |     2.520 ns |     2.357 ns |  1.00 |    0.01 |         - |          NA |
| FindIndexesInIntArray                     | .NET 9.0  | .NET 9.0  | 100   |    306.16 ns |     3.399 ns |     3.179 ns |  0.97 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | .NET 9.0  | .NET 9.0  | 100   |    293.63 ns |     3.094 ns |     2.894 ns |  0.93 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | .NET 9.0  | .NET 9.0  | 100   |    376.01 ns |     2.669 ns |     2.084 ns |  1.19 |    0.01 |         - |          NA |
| FindIndexesBytePointers                   | .NET 9.0  | .NET 9.0  | 100   |    324.05 ns |     5.844 ns |     5.467 ns |  1.02 |    0.02 |         - |          NA |
|                                           |           |           |       |              |              |              |       |         |           |             |
| **FindIndexesInString**                       | **.NET 10.0** | **.NET 10.0** | **10000** | **63,143.62 ns** |   **658.082 ns** |   **615.570 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FindIndexesInIntArray                     | .NET 10.0 | .NET 10.0 | 10000 | 67,467.02 ns |   622.053 ns |   581.869 ns |  1.07 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | .NET 10.0 | .NET 10.0 | 10000 | 64,884.91 ns |   574.745 ns |   537.617 ns |  1.03 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | .NET 10.0 | .NET 10.0 | 10000 | 64,799.48 ns | 1,244.328 ns | 1,163.945 ns |  1.03 |    0.02 |         - |          NA |
| FindIndexesBytePointers                   | .NET 10.0 | .NET 10.0 | 10000 |           NA |           NA |           NA |     ? |       ? |        NA |           ? |
|                                           |           |           |       |              |              |              |       |         |           |             |
| FindIndexesInString                       | .NET 9.0  | .NET 9.0  | 10000 | 62,177.27 ns |   851.755 ns |   796.733 ns |  1.00 |    0.02 |         - |          NA |
| FindIndexesInIntArray                     | .NET 9.0  | .NET 9.0  | 10000 | 66,903.30 ns | 1,138.291 ns | 1,064.758 ns |  1.08 |    0.02 |         - |          NA |
| FindIndexesInCharArray                    | .NET 9.0  | .NET 9.0  | 10000 | 66,277.63 ns |   723.044 ns |   676.336 ns |  1.07 |    0.02 |       2 B |          NA |
| FindIndexesPointerArithmeticIntoCharArray | .NET 9.0  | .NET 9.0  | 10000 | 64,298.87 ns |   629.151 ns |   588.508 ns |  1.03 |    0.02 |       2 B |          NA |
| FindIndexesBytePointers                   | .NET 9.0  | .NET 9.0  | 10000 |           NA |           NA |           NA |     ? |       ? |        NA |           ? |

Benchmarks with issues:
  Benchmark.FindIndexesBytePointers: .NET 10.0(Runtime=.NET 10.0) [Count=10000]
  Benchmark.FindIndexesBytePointers: .NET 9.0(Runtime=.NET 9.0) [Count=10000]
