# Illustrating the overhead of boxing



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count  | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------- |------- |-------------:|-----------:|-----------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **BuildIntListWithoutBoxing** | **1000**   |     **1.081 μs** |  **0.0152 μs** |  **0.0142 μs** |  **1.00** |    **0.02** |   **0.2422** |        **-** |        **-** |    **3.96 KB** |        **1.00** |
| BuildIntListWitBoxing     | 1000   |     5.622 μs |  0.0537 μs |  0.0503 μs |  5.20 |    0.08 |   1.9150 |   0.2060 |        - |    31.3 KB |        7.90 |
|                           |        |              |            |            |       |         |          |          |          |            |             |
| **BuildIntListWithoutBoxing** | **100000** |   **347.699 μs** |  **3.3291 μs** |  **3.1140 μs** |  **1.00** |    **0.01** | **124.5117** | **124.5117** | **124.5117** |  **390.72 KB** |        **1.00** |
| BuildIntListWitBoxing     | 100000 | 1,487.266 μs | 29.5753 μs | 77.3935 μs |  4.28 |    0.22 | 248.0469 | 248.0469 | 248.0469 | 3125.14 KB |        8.00 |
