## Counting digits




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                               Method |  Count |           Mean |       Error |      StdDev |         Median | Ratio | RatioSD |     Gen0 | Allocated | Alloc Ratio |
|----------------------------------------------------- |------- |---------------:|------------:|------------:|---------------:|------:|--------:|---------:|----------:|------------:|
|                                 **CountDigitsUsingMath** |    **100** |       **710.9 ns** |     **0.68 ns** |     **0.57 ns** |       **710.8 ns** |  **1.00** |    **0.00** |        **-** |         **-** |          **NA** |
|                   CountDigitsUsingMathIncludingFloor |    100 |       733.3 ns |     0.52 ns |     0.44 ns |       733.3 ns |  1.03 |    0.00 |        - |         - |          NA |
|                               CountDigitsUsingString |    100 |     1,088.3 ns |    21.72 ns |    52.05 ns |     1,068.2 ns |  1.55 |    0.07 |   0.2632 |    4424 B |          NA |
|                             CountDigitsUsingMaxMahem |    100 |       801.7 ns |     2.13 ns |     1.89 ns |       801.8 ns |  1.13 |    0.00 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup |    100 |       243.0 ns |     4.84 ns |     9.43 ns |       243.8 ns |  0.35 |    0.01 |        - |         - |          NA |
|                          CountDigitsUsingLookupTable |    100 |       169.9 ns |     0.42 ns |     0.39 ns |       169.9 ns |  0.24 |    0.00 |        - |         - |          NA |
|                  CountDigitsUsingIfGreaterThanChecks |    100 |       167.2 ns |     0.15 ns |     0.13 ns |       167.2 ns |  0.24 |    0.00 |        - |         - |          NA |
|                                                      |        |                |             |             |                |       |         |          |           |             |
|                                 **CountDigitsUsingMath** |   **1000** |     **7,065.0 ns** |     **6.93 ns** |     **5.78 ns** |     **7,063.4 ns** |  **1.00** |    **0.00** |        **-** |         **-** |          **NA** |
|                   CountDigitsUsingMathIncludingFloor |   1000 |     7,331.2 ns |    23.06 ns |    21.57 ns |     7,331.7 ns |  1.04 |    0.00 |        - |         - |          NA |
|                               CountDigitsUsingString |   1000 |    12,290.2 ns |   343.16 ns | 1,011.81 ns |    12,049.1 ns |  1.68 |    0.16 |   2.6398 |   44376 B |          NA |
|                             CountDigitsUsingMaxMahem |   1000 |    10,055.5 ns |   126.06 ns |   105.27 ns |    10,008.4 ns |  1.42 |    0.02 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup |   1000 |     2,200.3 ns |     9.61 ns |     8.52 ns |     2,196.6 ns |  0.31 |    0.00 |        - |         - |          NA |
|                          CountDigitsUsingLookupTable |   1000 |     1,620.4 ns |     3.87 ns |     3.62 ns |     1,620.4 ns |  0.23 |    0.00 |        - |         - |          NA |
|                  CountDigitsUsingIfGreaterThanChecks |   1000 |     1,607.6 ns |     2.96 ns |     2.47 ns |     1,607.4 ns |  0.23 |    0.00 |        - |         - |          NA |
|                                                      |        |                |             |             |                |       |         |          |           |             |
|                                 **CountDigitsUsingMath** | **100000** |   **710,614.3 ns** | **1,217.44 ns** | **1,079.23 ns** |   **710,052.4 ns** |  **1.00** |    **0.00** |        **-** |         **-** |          **NA** |
|                   CountDigitsUsingMathIncludingFloor | 100000 |   731,008.3 ns |   625.93 ns |   522.68 ns |   731,052.1 ns |  1.03 |    0.00 |        - |         - |          NA |
|                               CountDigitsUsingString | 100000 | 1,504,347.3 ns | 7,765.64 ns | 6,884.04 ns | 1,505,279.4 ns |  2.12 |    0.01 | 263.6719 | 4426136 B |          NA |
|                             CountDigitsUsingMaxMahem | 100000 | 1,418,195.1 ns |   954.58 ns |   797.12 ns | 1,418,211.3 ns |  2.00 |    0.00 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 100000 |   220,264.3 ns |   270.36 ns |   225.76 ns |   220,221.5 ns |  0.31 |    0.00 |        - |         - |          NA |
|                          CountDigitsUsingLookupTable | 100000 |   160,029.0 ns |   185.99 ns |   145.21 ns |   160,082.5 ns |  0.23 |    0.00 |        - |         - |          NA |
|                  CountDigitsUsingIfGreaterThanChecks | 100000 |   160,346.1 ns |   461.87 ns |   432.03 ns |   160,368.6 ns |  0.23 |    0.00 |        - |         - |          NA |
