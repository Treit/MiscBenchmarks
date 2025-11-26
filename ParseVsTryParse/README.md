## Parse vs TryParse for weeding out bad input.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count  | Mean           | Error         | StdDev        | Ratio  | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|-------------------------- |------- |---------------:|--------------:|--------------:|-------:|--------:|----------:|-----------:|------------:|
| **FindValidIntsWithParse**    | **100**    |     **193.513 μs** |     **2.1971 μs** |     **1.9477 μs** | **185.98** |    **2.74** |    **2.1973** |    **39184 B** |          **NA** |
| FindValidIntsWithTryParse | 100    |       1.041 μs |     0.0127 μs |     0.0119 μs |   1.00 |    0.02 |         - |          - |          NA |
|                           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **1000**   |   **1,690.858 μs** |     **6.3927 μs** |     **5.3382 μs** | **130.10** |    **0.63** |   **19.5313** |   **350576 B** |          **NA** |
| FindValidIntsWithTryParse | 1000   |      12.997 μs |     0.0573 μs |     0.0508 μs |   1.00 |    0.01 |         - |          - |          NA |
|                           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **10000**  |  **17,546.573 μs** |   **127.6158 μs** |   **119.3719 μs** | **121.84** |    **1.15** |  **187.5000** |  **3607968 B** |          **NA** |
| FindValidIntsWithTryParse | 10000  |     144.017 μs |     1.0684 μs |     0.9994 μs |   1.00 |    0.01 |         - |          - |          NA |
|                           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **100000** | **173,223.127 μs** | **1,484.9615 μs** | **1,389.0339 μs** | **112.92** |    **1.01** | **2000.0000** | **36022512 B** |          **NA** |
| FindValidIntsWithTryParse | 100000 |   1,534.030 μs |     7.5407 μs |     7.0535 μs |   1.00 |    0.01 |         - |          - |          NA |
