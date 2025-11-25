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
| **FindValidIntsWithParse**    | **100**    |     **180.657 μs** |     **1.8113 μs** |     **1.6057 μs** | **163.88** |    **2.61** |    **2.1973** |    **37200 B** |          **NA** |
| FindValidIntsWithTryParse | 100    |       1.103 μs |     0.0164 μs |     0.0154 μs |   1.00 |    0.02 |         - |          - |          NA |
|                           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **1000**   |   **1,687.658 μs** |    **12.1341 μs** |    **10.7565 μs** | **127.00** |    **1.04** |   **21.4844** |   **364384 B** |          **NA** |
| FindValidIntsWithTryParse | 1000   |      13.289 μs |     0.0785 μs |     0.0734 μs |   1.00 |    0.01 |         - |          - |          NA |
|                           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **10000**  |  **16,879.899 μs** |   **167.4572 μs** |   **148.4464 μs** | **115.90** |    **1.31** |  **187.5000** |  **3575152 B** |          **NA** |
| FindValidIntsWithTryParse | 10000  |     145.655 μs |     1.2580 μs |     1.1152 μs |   1.00 |    0.01 |         - |          - |          NA |
|                           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **100000** | **166,055.340 μs** | **1,568.2059 μs** | **1,466.9007 μs** | **105.17** |    **1.27** | **2000.0000** | **36110760 B** |          **NA** |
| FindValidIntsWithTryParse | 100000 |   1,579.038 μs |    15.8485 μs |    14.0493 μs |   1.00 |    0.01 |         - |          - |          NA |
