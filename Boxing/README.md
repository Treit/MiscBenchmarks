# Illustrating the overhead of boxing




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count  | Mean         | Error      | StdDev      | Median       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------- |------- |-------------:|-----------:|------------:|-------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **BuildIntListWithoutBoxing** | **1000**   |     **1.076 μs** |  **0.0132 μs** |   **0.0124 μs** |     **1.076 μs** |  **1.00** |    **0.02** |   **0.2422** |        **-** |        **-** |    **3.96 KB** |        **1.00** |
| BuildIntListWitBoxing     | 1000   |     5.614 μs |  0.0568 μs |   0.0531 μs |     5.610 μs |  5.22 |    0.08 |   1.9150 |   0.2060 |        - |    31.3 KB |        7.90 |
|                           |        |              |            |             |              |       |         |          |          |          |            |             |
| **BuildIntListWithoutBoxing** | **100000** |   **349.185 μs** |  **4.8237 μs** |   **4.5120 μs** |   **348.968 μs** |  **1.00** |    **0.02** | **124.5117** | **124.5117** | **124.5117** |  **390.72 KB** |        **1.00** |
| BuildIntListWitBoxing     | 100000 | 1,452.586 μs | 35.2223 μs | 103.8539 μs | 1,412.230 μs |  4.16 |    0.30 | 248.0469 | 248.0469 | 248.0469 | 3125.14 KB |        8.00 |
