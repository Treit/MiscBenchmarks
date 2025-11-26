## Counting digits







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                               | Count  | Mean           | Error        | StdDev       | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|----------------------------------------------------- |------- |---------------:|-------------:|-------------:|------:|--------:|---------:|----------:|------------:|
| **CountDigitsUsingMath**                                 | **100**    |       **790.3 ns** |      **3.87 ns** |      **3.23 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 100    |       761.5 ns |      3.39 ns |      3.17 ns |  0.96 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | 100    |     1,162.4 ns |     14.25 ns |     13.33 ns |  1.47 |    0.02 |   0.2632 |    4424 B |          NA |
| CountDigitsUsingMaxMahem                             | 100    |       658.6 ns |     12.03 ns |     12.87 ns |  0.83 |    0.02 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 100    |       239.2 ns |      4.74 ns |      7.38 ns |  0.30 |    0.01 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | 100    |       173.2 ns |      1.00 ns |      0.93 ns |  0.22 |    0.00 |        - |         - |          NA |
|                                                      |        |                |              |              |       |         |          |           |             |
| **CountDigitsUsingMath**                                 | **1000**   |     **7,336.2 ns** |     **28.82 ns** |     **25.55 ns** |  **1.00** |    **0.00** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 1000   |     7,556.8 ns |     11.93 ns |     11.16 ns |  1.03 |    0.00 |        - |         - |          NA |
| CountDigitsUsingString                               | 1000   |    10,253.0 ns |     99.19 ns |     82.83 ns |  1.40 |    0.01 |   2.6398 |   44376 B |          NA |
| CountDigitsUsingMaxMahem                             | 1000   |     8,429.0 ns |    168.34 ns |    180.13 ns |  1.15 |    0.02 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 1000   |     2,214.3 ns |     18.96 ns |     15.83 ns |  0.30 |    0.00 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | 1000   |     1,644.1 ns |      7.37 ns |      6.54 ns |  0.22 |    0.00 |        - |         - |          NA |
|                                                      |        |                |              |              |       |         |          |           |             |
| **CountDigitsUsingMath**                                 | **100000** |   **732,178.2 ns** |  **3,396.91 ns** |  **3,011.27 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 100000 |   761,472.6 ns |  3,160.27 ns |  2,638.97 ns |  1.04 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | 100000 | 1,462,842.0 ns | 11,400.92 ns | 10,106.62 ns |  2.00 |    0.02 | 263.6719 | 4426136 B |          NA |
| CountDigitsUsingMaxMahem                             | 100000 | 1,305,013.1 ns |  9,748.14 ns |  9,118.42 ns |  1.78 |    0.01 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 100000 |   252,382.2 ns |  2,065.77 ns |  1,932.33 ns |  0.34 |    0.00 |        - |       6 B |          NA |
| CountDigitsUsingLookupTable                          | 100000 |   163,946.9 ns |    777.55 ns |    689.28 ns |  0.22 |    0.00 |        - |         - |          NA |
