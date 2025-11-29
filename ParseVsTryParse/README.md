## Parse vs TryParse for weeding out bad input.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count  | Mean           | Error         | StdDev        | Ratio  | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|-------------------------- |---------- |---------- |------- |---------------:|--------------:|--------------:|-------:|--------:|----------:|-----------:|------------:|
| **FindValidIntsWithParse**    | **.NET 10.0** | **.NET 10.0** | **100**    |     **167.358 μs** |     **1.0481 μs** |     **0.9291 μs** | **162.32** |    **1.27** |    **1.9531** |    **35216 B** |          **NA** |
| FindValidIntsWithTryParse | .NET 10.0 | .NET 10.0 | 100    |       1.031 μs |     0.0065 μs |     0.0061 μs |   1.00 |    0.01 |         - |          - |          NA |
|                           |           |           |        |                |               |               |        |         |           |            |             |
| FindValidIntsWithParse    | .NET 9.0  | .NET 9.0  | 100    |     165.669 μs |     0.5484 μs |     0.4861 μs | 158.04 |    2.10 |    1.9531 |    35216 B |          NA |
| FindValidIntsWithTryParse | .NET 9.0  | .NET 9.0  | 100    |       1.048 μs |     0.0149 μs |     0.0140 μs |   1.00 |    0.02 |         - |          - |          NA |
|                           |           |           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **.NET 10.0** | **.NET 10.0** | **1000**   |   **1,663.948 μs** |     **7.9731 μs** |     **7.4580 μs** | **127.78** |    **0.79** |   **21.4844** |   **362992 B** |          **NA** |
| FindValidIntsWithTryParse | .NET 10.0 | .NET 10.0 | 1000   |      13.022 μs |     0.0634 μs |     0.0593 μs |   1.00 |    0.01 |         - |          - |          NA |
|                           |           |           |        |                |               |               |        |         |           |            |             |
| FindValidIntsWithParse    | .NET 9.0  | .NET 9.0  | 1000   |   1,629.599 μs |     5.9773 μs |     4.9913 μs | 122.81 |    0.56 |   19.5313 |   347680 B |          NA |
| FindValidIntsWithTryParse | .NET 9.0  | .NET 9.0  | 1000   |      13.269 μs |     0.0503 μs |     0.0471 μs |   1.00 |    0.00 |         - |          - |          NA |
|                           |           |           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **.NET 10.0** | **.NET 10.0** | **10000**  |  **16,693.177 μs** |    **56.6909 μs** |    **50.2550 μs** | **119.78** |    **0.39** |  **187.5000** |  **3607968 B** |          **NA** |
| FindValidIntsWithTryParse | .NET 10.0 | .NET 10.0 | 10000  |     139.366 μs |     0.2556 μs |     0.1996 μs |   1.00 |    0.00 |         - |          - |          NA |
|                           |           |           |        |                |               |               |        |         |           |            |             |
| FindValidIntsWithParse    | .NET 9.0  | .NET 9.0  | 10000  |  16,630.596 μs |    40.2700 μs |    33.6272 μs | 115.59 |    0.31 |  187.5000 |  3619728 B |          NA |
| FindValidIntsWithTryParse | .NET 9.0  | .NET 9.0  | 10000  |     143.874 μs |     0.3183 μs |     0.2822 μs |   1.00 |    0.00 |         - |          - |          NA |
|                           |           |           |        |                |               |               |        |         |           |            |             |
| **FindValidIntsWithParse**    | **.NET 10.0** | **.NET 10.0** | **100000** | **170,237.267 μs** | **1,390.3356 μs** | **1,300.5208 μs** | **111.04** |    **0.92** | **2000.0000** | **35950840 B** |          **NA** |
| FindValidIntsWithTryParse | .NET 10.0 | .NET 10.0 | 100000 |   1,533.132 μs |     6.7472 μs |     5.9813 μs |   1.00 |    0.01 |         - |          - |          NA |
|                           |           |           |        |                |               |               |        |         |           |            |             |
| FindValidIntsWithParse    | .NET 9.0  | .NET 9.0  | 100000 | 168,212.826 μs |   312.1226 μs |   276.6886 μs | 108.46 |    0.28 | 2000.0000 | 35864704 B |          NA |
| FindValidIntsWithTryParse | .NET 9.0  | .NET 9.0  | 100000 |   1,550.867 μs |     3.7598 μs |     3.3330 μs |   1.00 |    0.00 |         - |          - |          NA |
