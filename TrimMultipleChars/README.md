# Trimming whitespace and slashes

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4602/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                  | Count  | Mean         | Error      | StdDev     | Ratio | Gen0      | Allocated   | Alloc Ratio |
|---------------------------------------- |------- |-------------:|-----------:|-----------:|------:|----------:|------------:|------------:|
| **DoTrimWithOneCallUsingParamsArray**       | **100**    |     **6.403 μs** |  **0.0403 μs** |  **0.0357 μs** |  **1.15** |    **0.4196** |     **6.95 KB** |        **2.28** |
| DoTrimWithOneCallUsingNewCharArray      | 100    |     6.391 μs |  0.0439 μs |  0.0411 μs |  1.14 |    0.4196 |     6.95 KB |        2.28 |
| DoTrimWithOneCallUsingStaticCharArray   | 100    |     5.591 μs |  0.0434 μs |  0.0362 μs |  1.00 |    0.1831 |     3.05 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | 100    |     7.026 μs |  0.0457 μs |  0.0357 μs |  1.26 |    1.2360 |    20.23 KB |        6.64 |
|                                         |        |              |            |            |       |           |             |             |
| **DoTrimWithOneCallUsingParamsArray**       | **100000** | **6,808.939 μs** | **56.5135 μs** | **50.0977 μs** |  **1.22** |  **429.6875** |  **7031.17 KB** |        **2.25** |
| DoTrimWithOneCallUsingNewCharArray      | 100000 | 6,800.585 μs | 38.3647 μs | 34.0093 μs |  1.22 |  429.6875 |  7031.17 KB |        2.25 |
| DoTrimWithOneCallUsingStaticCharArray   | 100000 | 5,586.842 μs | 15.5770 μs | 13.8086 μs |  1.00 |  187.5000 |  3124.92 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | 100000 | 7,189.791 μs | 49.7554 μs | 46.5412 μs |  1.29 | 1328.1250 | 21796.02 KB |        6.97 |
