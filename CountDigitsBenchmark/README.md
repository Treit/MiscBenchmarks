## Counting digits



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26010.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|                                               Method |  Count |           Mean |        Error |       StdDev |         Median | Ratio | RatioSD |      Gen0 | Allocated | Alloc Ratio |
|----------------------------------------------------- |------- |---------------:|-------------:|-------------:|---------------:|------:|--------:|----------:|----------:|------------:|
|                                 **CountDigitsUsingMath** |    **100** |       **766.8 ns** |     **15.38 ns** |     **21.56 ns** |       **759.6 ns** |  **1.00** |    **0.00** |         **-** |         **-** |          **NA** |
|                   CountDigitsUsingMathIncludingFloor |    100 |       938.5 ns |      8.84 ns |      7.84 ns |       936.8 ns |  1.23 |    0.04 |         - |         - |          NA |
|                               CountDigitsUsingString |    100 |     2,275.8 ns |     17.27 ns |     15.31 ns |     2,269.0 ns |  2.97 |    0.10 |    1.0223 |    4424 B |          NA |
|                             CountDigitsUsingMaxMahem |    100 |     2,286.6 ns |     44.05 ns |     64.56 ns |     2,281.6 ns |  2.98 |    0.10 |         - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup |    100 |       311.0 ns |      5.65 ns |      7.14 ns |       306.9 ns |  0.41 |    0.02 |         - |         - |          NA |
|                          CountDigitsUsingLookupTable |    100 |       322.5 ns |      6.49 ns |     15.91 ns |       316.5 ns |  0.43 |    0.03 |         - |         - |          NA |
|                  CountDigitsUsingIfGreaterThanChecks |    100 |       320.6 ns |      6.09 ns |      5.40 ns |       320.7 ns |  0.42 |    0.01 |         - |         - |          NA |
|                                                      |        |                |              |              |                |       |         |           |           |             |
|                                 **CountDigitsUsingMath** |   **1000** |     **8,448.0 ns** |    **165.52 ns** |    **247.74 ns** |     **8,449.6 ns** |  **1.00** |    **0.00** |         **-** |         **-** |          **NA** |
|                   CountDigitsUsingMathIncludingFloor |   1000 |     9,722.9 ns |     68.19 ns |     60.45 ns |     9,713.2 ns |  1.13 |    0.03 |         - |         - |          NA |
|                               CountDigitsUsingString |   1000 |    24,227.1 ns |    475.85 ns |    939.29 ns |    24,377.2 ns |  2.89 |    0.11 |   10.2844 |   44376 B |          NA |
|                             CountDigitsUsingMaxMahem |   1000 |    24,004.4 ns |    449.13 ns |    441.11 ns |    23,911.4 ns |  2.80 |    0.09 |         - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup |   1000 |     3,472.2 ns |     68.10 ns |    182.95 ns |     3,412.1 ns |  0.42 |    0.04 |         - |         - |          NA |
|                          CountDigitsUsingLookupTable |   1000 |     3,076.0 ns |     43.86 ns |     48.75 ns |     3,064.5 ns |  0.36 |    0.01 |         - |         - |          NA |
|                  CountDigitsUsingIfGreaterThanChecks |   1000 |     3,064.4 ns |     38.61 ns |     32.25 ns |     3,061.8 ns |  0.36 |    0.01 |         - |         - |          NA |
|                                                      |        |                |              |              |                |       |         |           |           |             |
|                                 **CountDigitsUsingMath** | **100000** |   **785,436.0 ns** | **15,562.66 ns** | **13,795.89 ns** |   **782,320.8 ns** |  **1.00** |    **0.00** |         **-** |         **-** |          **NA** |
|                   CountDigitsUsingMathIncludingFloor | 100000 | 1,057,284.7 ns | 18,081.76 ns | 25,932.32 ns | 1,049,087.4 ns |  1.36 |    0.04 |         - |       1 B |          NA |
|                               CountDigitsUsingString | 100000 | 2,482,897.1 ns | 40,874.24 ns | 36,233.95 ns | 2,475,389.5 ns |  3.16 |    0.09 | 1023.4375 | 4426138 B |          NA |
|                             CountDigitsUsingMaxMahem | 100000 | 2,270,483.8 ns | 29,374.47 ns | 26,039.70 ns | 2,264,916.4 ns |  2.89 |    0.07 |         - |       2 B |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 100000 |   299,440.4 ns |  3,467.07 ns |  2,895.16 ns |   298,485.2 ns |  0.38 |    0.01 |         - |         - |          NA |
|                          CountDigitsUsingLookupTable | 100000 |   302,381.6 ns |  3,297.19 ns |  2,922.87 ns |   302,320.2 ns |  0.39 |    0.01 |         - |         - |          NA |
|                  CountDigitsUsingIfGreaterThanChecks | 100000 |   301,767.1 ns |  2,714.72 ns |  2,119.48 ns |   302,226.2 ns |  0.39 |    0.01 |         - |         - |          NA |
