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
| **DoTrimWithOneCallUsingParamsArray**       | **100**    |     **5.380 μs** |  **0.0629 μs** |  **0.0588 μs** |  **1.10** |    **0.01** |    **0.4196** |     **6.95 KB** |        **2.28** |
| DoTrimWithOneCallUsingNewCharArray      | 100    |     5.245 μs |  0.0401 μs |  0.0355 μs |  1.07 |    0.01 |    0.4196 |     6.95 KB |        2.28 |
| DoTrimWithOneCallUsingStaticCharArray   | 100    |     4.880 μs |  0.0390 μs |  0.0365 μs |  1.00 |    0.01 |    0.1831 |     3.05 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | 100    |     5.615 μs |  0.0648 μs |  0.0574 μs |  1.15 |    0.01 |    1.2360 |    20.23 KB |        6.64 |
|                                         |        |              |            |            |       |         |           |             |             |
| **DoTrimWithOneCallUsingParamsArray**       | **100000** | **5,978.496 μs** | **56.1451 μs** | **52.5182 μs** |  **1.26** |    **0.02** |  **429.6875** |  **7031.17 KB** |        **2.25** |
| DoTrimWithOneCallUsingNewCharArray      | 100000 | 5,972.903 μs | 38.6137 μs | 34.2300 μs |  1.26 |    0.01 |  429.6875 |  7031.17 KB |        2.25 |
| DoTrimWithOneCallUsingStaticCharArray   | 100000 | 4,748.725 μs | 50.1991 μs | 41.9185 μs |  1.00 |    0.01 |  187.5000 |  3124.92 KB |        1.00 |
| DoTrimWithThreeTrimCallsAndNewCharArray | 100000 | 5,935.517 μs | 64.8150 μs | 57.4568 μs |  1.25 |    0.02 | 1328.1250 | 21796.02 KB |        6.97 |
