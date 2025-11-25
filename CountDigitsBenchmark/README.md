## Counting digits






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                               | Count  | Mean           | Error        | StdDev       | Median         | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|----------------------------------------------------- |------- |---------------:|-------------:|-------------:|---------------:|------:|--------:|---------:|----------:|------------:|
| **CountDigitsUsingMath**                                 | **100**    |       **742.3 ns** |      **3.94 ns** |      **3.50 ns** |       **743.6 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 100    |       762.5 ns |      4.37 ns |      3.87 ns |       762.0 ns |  1.03 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | 100    |     1,041.3 ns |     19.42 ns |     19.95 ns |     1,039.6 ns |  1.40 |    0.03 |   0.2632 |    4424 B |          NA |
| CountDigitsUsingMaxMahem                             | 100    |       659.5 ns |      5.09 ns |      4.25 ns |       659.2 ns |  0.89 |    0.01 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 100    |       246.5 ns |      4.96 ns |     10.25 ns |       248.9 ns |  0.33 |    0.01 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | 100    |       172.7 ns |      0.87 ns |      0.81 ns |       173.0 ns |  0.23 |    0.00 |        - |         - |          NA |
|                                                      |        |                |              |              |                |       |         |          |           |             |
| **CountDigitsUsingMath**                                 | **1000**   |     **7,308.6 ns** |     **28.45 ns** |     **25.22 ns** |     **7,303.3 ns** |  **1.00** |    **0.00** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 1000   |     7,509.8 ns |     67.00 ns |     62.67 ns |     7,476.4 ns |  1.03 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | 1000   |    10,250.8 ns |    104.18 ns |     97.45 ns |    10,203.9 ns |  1.40 |    0.01 |   2.6398 |   44376 B |          NA |
| CountDigitsUsingMaxMahem                             | 1000   |     9,350.0 ns |    402.60 ns |  1,187.08 ns |     8,897.2 ns |  1.28 |    0.16 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 1000   |     2,261.2 ns |     45.02 ns |     96.91 ns |     2,211.0 ns |  0.31 |    0.01 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | 1000   |     1,637.0 ns |      6.14 ns |      5.44 ns |     1,637.5 ns |  0.22 |    0.00 |        - |         - |          NA |
|                                                      |        |                |              |              |                |       |         |          |           |             |
| **CountDigitsUsingMath**                                 | **100000** |   **729,195.3 ns** |  **3,384.98 ns** |  **2,826.61 ns** |   **730,473.3 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 100000 |   754,852.4 ns |  2,865.85 ns |  2,540.50 ns |   755,869.3 ns |  1.04 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | 100000 | 1,466,187.4 ns | 15,750.16 ns | 12,296.69 ns | 1,467,310.7 ns |  2.01 |    0.02 | 263.6719 | 4426136 B |          NA |
| CountDigitsUsingMaxMahem                             | 100000 | 1,305,367.7 ns |  7,639.20 ns |  7,145.72 ns | 1,304,421.3 ns |  1.79 |    0.01 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 100000 |   250,349.2 ns |  2,050.55 ns |  1,918.08 ns |   251,456.6 ns |  0.34 |    0.00 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | 100000 |   163,490.7 ns |    948.77 ns |    841.06 ns |   163,584.5 ns |  0.22 |    0.00 |        - |         - |          NA |
