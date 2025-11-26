# Trimming whitespace and slashes



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                  | Count  | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0      | Allocated   | Alloc Ratio |
|---------------------------------------- |------- |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|------------:|
| **DoTrimWithOneCallUsingParamsArray**       | **100**    |     **5.543 μs** |  **0.0582 μs** |  **0.0545 μs** |  **1.10** |    **0.01** |    **0.4196** |     **6.95 KB** |        **2.28** |
| DoTrimWithOneCallUsingNewCharArray      | 100    |     5.348 μs |  0.0544 μs |  0.0509 μs |  1.06 |    0.01 |    0.4196 |     6.95 KB |        2.28 |
| DoTrimWithOneCallUsingStaticCharArray   | 100    |     5.042 μs |  0.0540 μs |  0.0505 μs |  1.00 |    0.01 |    0.1831 |     3.05 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | 100    |     6.091 μs |  0.0822 μs |  0.0769 μs |  1.21 |    0.02 |    1.2360 |    20.23 KB |        6.64 |
|                                         |        |              |            |            |       |         |           |             |             |
| **DoTrimWithOneCallUsingParamsArray**       | **100000** | **5,390.154 μs** | **49.1841 μs** | **43.6004 μs** |  **1.11** |    **0.01** |  **429.6875** |  **7031.17 KB** |        **2.25** |
| DoTrimWithOneCallUsingNewCharArray      | 100000 | 5,823.887 μs | 58.3676 μs | 54.5971 μs |  1.20 |    0.01 |  429.6875 |  7031.17 KB |        2.25 |
| DoTrimWithOneCallUsingStaticCharArray   | 100000 | 4,871.821 μs | 37.0831 μs | 34.6875 μs |  1.00 |    0.01 |  187.5000 |  3124.92 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | 100000 | 6,022.350 μs | 79.4640 μs | 74.3306 μs |  1.24 |    0.02 | 1328.1250 | 21796.02 KB |        6.97 |
