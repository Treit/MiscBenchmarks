# Trimming whitespace and slashes




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                  | Job       | Runtime   | Count  | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0      | Allocated   | Alloc Ratio |
|---------------------------------------- |---------- |---------- |------- |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|------------:|
| **DoTrimWithOneCallUsingParamsArray**       | **.NET 10.0** | **.NET 10.0** | **100**    |     **5.477 μs** |  **0.0360 μs** |  **0.0337 μs** |  **1.18** |    **0.01** |    **0.4196** |     **6.95 KB** |        **2.28** |
| DoTrimWithOneCallUsingNewCharArray      | .NET 10.0 | .NET 10.0 | 100    |     5.473 μs |  0.0292 μs |  0.0258 μs |  1.18 |    0.01 |    0.4196 |     6.95 KB |        2.28 |
| DoTrimWithOneCallUsingStaticCharArray   | .NET 10.0 | .NET 10.0 | 100    |     4.649 μs |  0.0197 μs |  0.0175 μs |  1.00 |    0.01 |    0.1831 |     3.05 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | .NET 10.0 | .NET 10.0 | 100    |     5.757 μs |  0.1118 μs |  0.1046 μs |  1.24 |    0.02 |    1.2360 |    20.23 KB |        6.64 |
|                                         |           |           |        |              |            |            |       |         |           |             |             |
| DoTrimWithOneCallUsingParamsArray       | .NET 9.0  | .NET 9.0  | 100    |     5.236 μs |  0.0435 μs |  0.0407 μs |  1.04 |    0.01 |    0.4196 |     6.95 KB |        2.28 |
| DoTrimWithOneCallUsingNewCharArray      | .NET 9.0  | .NET 9.0  | 100    |     5.458 μs |  0.0488 μs |  0.0456 μs |  1.08 |    0.01 |    0.4196 |     6.95 KB |        2.28 |
| DoTrimWithOneCallUsingStaticCharArray   | .NET 9.0  | .NET 9.0  | 100    |     5.054 μs |  0.0244 μs |  0.0229 μs |  1.00 |    0.01 |    0.1831 |     3.05 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | .NET 9.0  | .NET 9.0  | 100    |     5.905 μs |  0.0549 μs |  0.0513 μs |  1.17 |    0.01 |    1.2360 |    20.23 KB |        6.64 |
|                                         |           |           |        |              |            |            |       |         |           |             |             |
| **DoTrimWithOneCallUsingParamsArray**       | **.NET 10.0** | **.NET 10.0** | **100000** | **5,660.377 μs** | **29.0557 μs** | **24.2629 μs** |  **1.11** |    **0.01** |  **429.6875** |  **7031.17 KB** |        **2.25** |
| DoTrimWithOneCallUsingNewCharArray      | .NET 10.0 | .NET 10.0 | 100000 | 5,428.413 μs | 33.5487 μs | 29.7401 μs |  1.07 |    0.01 |  429.6875 |  7031.17 KB |        2.25 |
| DoTrimWithOneCallUsingStaticCharArray   | .NET 10.0 | .NET 10.0 | 100000 | 5,080.889 μs | 16.0176 μs | 12.5055 μs |  1.00 |    0.00 |  187.5000 |  3124.92 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | .NET 10.0 | .NET 10.0 | 100000 | 5,925.546 μs | 25.6628 μs | 21.4296 μs |  1.17 |    0.00 | 1328.1250 | 21796.02 KB |        6.97 |
|                                         |           |           |        |              |            |            |       |         |           |             |             |
| DoTrimWithOneCallUsingParamsArray       | .NET 9.0  | .NET 9.0  | 100000 | 5,239.256 μs | 56.0486 μs | 52.4279 μs |  1.07 |    0.01 |  429.6875 |  7031.17 KB |        2.25 |
| DoTrimWithOneCallUsingNewCharArray      | .NET 9.0  | .NET 9.0  | 100000 | 5,232.721 μs | 39.4081 μs | 36.8624 μs |  1.07 |    0.01 |  429.6875 |  7031.17 KB |        2.25 |
| DoTrimWithOneCallUsingStaticCharArray   | .NET 9.0  | .NET 9.0  | 100000 | 4,885.623 μs | 28.4634 μs | 26.6247 μs |  1.00 |    0.01 |  187.5000 |  3124.92 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | .NET 9.0  | .NET 9.0  | 100000 | 6,036.818 μs | 45.6143 μs | 42.6677 μs |  1.24 |    0.01 | 1328.1250 | 21796.02 KB |        6.97 |
