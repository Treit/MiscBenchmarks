# Illustrating the overhead of boxing





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count  | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------- |---------- |---------- |------- |-------------:|-----------:|-----------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **BuildIntListWithoutBoxing** | **.NET 10.0** | **.NET 10.0** | **1000**   |     **1.082 μs** |  **0.0131 μs** |  **0.0116 μs** |  **1.00** |    **0.01** |   **0.2422** |        **-** |        **-** |    **3.96 KB** |        **1.00** |
| BuildIntListWitBoxing     | .NET 10.0 | .NET 10.0 | 1000   |     5.581 μs |  0.0545 μs |  0.0455 μs |  5.16 |    0.07 |   1.9150 |   0.2060 |        - |    31.3 KB |        7.90 |
|                           |           |           |        |              |            |            |       |         |          |          |          |            |             |
| BuildIntListWithoutBoxing | .NET 9.0  | .NET 9.0  | 1000   |     1.090 μs |  0.0158 μs |  0.0140 μs |  1.00 |    0.02 |   0.2422 |        - |        - |    3.96 KB |        1.00 |
| BuildIntListWitBoxing     | .NET 9.0  | .NET 9.0  | 1000   |     5.717 μs |  0.1097 μs |  0.1347 μs |  5.25 |    0.14 |   1.9150 |   0.2060 |        - |    31.3 KB |        7.90 |
|                           |           |           |        |              |            |            |       |         |          |          |          |            |             |
| **BuildIntListWithoutBoxing** | **.NET 10.0** | **.NET 10.0** | **100000** |   **279.601 μs** |  **2.0391 μs** |  **1.9074 μs** |  **1.00** |    **0.01** | **124.5117** | **124.5117** | **124.5117** |  **390.72 KB** |        **1.00** |
| BuildIntListWitBoxing     | .NET 10.0 | .NET 10.0 | 100000 | 1,335.517 μs | 26.5761 μs | 57.7742 μs |  4.78 |    0.21 | 248.0469 | 248.0469 | 248.0469 | 3125.14 KB |        8.00 |
|                           |           |           |        |              |            |            |       |         |          |          |          |            |             |
| BuildIntListWithoutBoxing | .NET 9.0  | .NET 9.0  | 100000 |   279.127 μs |  3.5446 μs |  3.3156 μs |  1.00 |    0.02 | 124.5117 | 124.5117 | 124.5117 |  390.72 KB |        1.00 |
| BuildIntListWitBoxing     | .NET 9.0  | .NET 9.0  | 100000 | 1,296.020 μs | 25.8506 μs | 59.9127 μs |  4.64 |    0.22 | 248.0469 | 248.0469 | 248.0469 | 3125.14 KB |        8.00 |
