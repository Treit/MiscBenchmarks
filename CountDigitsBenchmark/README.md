## Counting digits


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25272.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|                              Method |  Count |           Mean |        Error |       StdDev |         Median | Ratio | RatioSD |      Gen0 | Allocated |  Alloc Ratio |
|------------------------------------ |------- |---------------:|-------------:|-------------:|---------------:|------:|--------:|----------:|----------:|-------------:|
|                **CountDigitsUsingMath** |    **100** |       **836.6 ns** |     **16.37 ns** |     **24.00 ns** |       **833.7 ns** |  **1.00** |    **0.00** |         **-** |         **-** |           **NA** |
|  CountDigitsUsingMathIncludingFloor |    100 |     1,014.5 ns |     17.93 ns |     16.77 ns |     1,006.9 ns |  1.21 |    0.04 |         - |         - |           NA |
|              CountDigitsUsingString |    100 |     2,472.7 ns |     46.48 ns |    110.47 ns |     2,428.7 ns |  3.02 |    0.18 |    1.0223 |    4424 B |           NA |
|            CountDigitsUsingMaxMahem |    100 |     2,407.4 ns |     43.30 ns |     36.16 ns |     2,409.4 ns |  2.86 |    0.10 |         - |         - |           NA |
|         CountDigitsUsingLookupTable |    100 |       342.2 ns |      6.82 ns |     11.94 ns |       338.9 ns |  0.41 |    0.02 |         - |         - |           NA |
| CountDigitsUsingIfGreaterThanChecks |    100 |       336.1 ns |      6.71 ns |      6.27 ns |       335.0 ns |  0.40 |    0.01 |         - |         - |           NA |
|                                     |        |                |              |              |                |       |         |           |           |              |
|                **CountDigitsUsingMath** |   **1000** |     **8,195.6 ns** |    **162.87 ns** |    **380.70 ns** |     **8,064.7 ns** |  **1.00** |    **0.00** |         **-** |         **-** |           **NA** |
|  CountDigitsUsingMathIncludingFloor |   1000 |    10,211.2 ns |    202.21 ns |    276.79 ns |    10,184.6 ns |  1.21 |    0.06 |         - |         - |           NA |
|              CountDigitsUsingString |   1000 |    25,567.8 ns |    508.15 ns |    862.87 ns |    25,312.9 ns |  3.07 |    0.19 |   10.2844 |   44376 B |           NA |
|            CountDigitsUsingMaxMahem |   1000 |    25,079.5 ns |    293.97 ns |    274.98 ns |    25,082.1 ns |  2.91 |    0.17 |         - |         - |           NA |
|         CountDigitsUsingLookupTable |   1000 |     3,330.6 ns |     63.69 ns |     97.26 ns |     3,319.0 ns |  0.40 |    0.02 |         - |         - |           NA |
| CountDigitsUsingIfGreaterThanChecks |   1000 |     3,503.7 ns |     68.39 ns |     63.97 ns |     3,483.2 ns |  0.41 |    0.02 |         - |         - |           NA |
|                                     |        |                |              |              |                |       |         |           |           |              |
|                **CountDigitsUsingMath** | **100000** |   **820,526.1 ns** | **15,854.41 ns** | **18,257.96 ns** |   **818,527.2 ns** |  **1.00** |    **0.00** |         **-** |       **1 B** |         **1.00** |
|  CountDigitsUsingMathIncludingFloor | 100000 | 1,023,698.9 ns | 17,186.10 ns | 16,075.89 ns | 1,027,942.3 ns |  1.25 |    0.03 |         - |       1 B |         1.00 |
|              CountDigitsUsingString | 100000 | 2,581,233.3 ns | 48,618.10 ns | 47,749.47 ns | 2,566,578.1 ns |  3.14 |    0.08 | 1023.4375 | 4426138 B | 4,426,138.00 |
|            CountDigitsUsingMaxMahem | 100000 | 2,709,596.6 ns | 53,009.03 ns | 94,223.50 ns | 2,687,013.9 ns |  3.33 |    0.18 |         - |       2 B |         2.00 |
|         CountDigitsUsingLookupTable | 100000 |   324,056.1 ns |  4,293.02 ns |  3,351.71 ns |   324,819.3 ns |  0.39 |    0.01 |         - |         - |         0.00 |
| CountDigitsUsingIfGreaterThanChecks | 100000 |   329,603.8 ns |  4,890.70 ns |  4,083.96 ns |   330,347.7 ns |  0.40 |    0.01 |         - |         - |         0.00 |
