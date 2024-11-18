## Counting digits





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27754.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                               | Count  | Mean           | Error        | StdDev       | Median         | Ratio | RatioSD | Gen0      | Allocated | Alloc Ratio |
|----------------------------------------------------- |------- |---------------:|-------------:|-------------:|---------------:|------:|--------:|----------:|----------:|------------:|
| **CountDigitsUsingMath**                                 | **100**    |       **756.4 ns** |     **13.43 ns** |     **24.89 ns** |       **750.4 ns** |  **1.00** |    **0.00** |         **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 100    |       835.5 ns |     16.74 ns |     44.09 ns |       820.7 ns |  1.12 |    0.08 |         - |         - |          NA |
| CountDigitsUsingString                               | 100    |     1,384.9 ns |     25.83 ns |     26.53 ns |     1,383.5 ns |  1.82 |    0.07 |    1.0242 |    4424 B |          NA |
| CountDigitsUsingMaxMahem                             | 100    |     1,496.8 ns |     29.47 ns |     47.59 ns |     1,493.5 ns |  1.97 |    0.09 |         - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 100    |       291.2 ns |      5.43 ns |     13.02 ns |       287.5 ns |  0.39 |    0.02 |         - |         - |          NA |
| CountDigitsUsingLookupTable                          | 100    |       231.0 ns |      4.56 ns |      7.23 ns |       229.3 ns |  0.30 |    0.01 |         - |         - |          NA |
|                                                      |        |                |              |              |                |       |         |           |           |             |
| **CountDigitsUsingMath**                                 | **1000**   |     **7,492.2 ns** |    **140.39 ns** |    **150.21 ns** |     **7,492.1 ns** |  **1.00** |    **0.00** |         **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 1000   |     7,914.3 ns |    136.87 ns |    114.30 ns |     7,888.2 ns |  1.06 |    0.02 |         - |         - |          NA |
| CountDigitsUsingString                               | 1000   |    16,447.3 ns |    323.65 ns |    372.71 ns |    16,393.2 ns |  2.19 |    0.04 |   10.2844 |   44376 B |          NA |
| CountDigitsUsingMaxMahem                             | 1000   |    18,200.0 ns |    267.95 ns |    223.75 ns |    18,107.6 ns |  2.45 |    0.06 |         - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 1000   |     3,097.4 ns |     52.49 ns |     64.46 ns |     3,085.1 ns |  0.41 |    0.01 |         - |         - |          NA |
| CountDigitsUsingLookupTable                          | 1000   |     2,215.4 ns |     31.89 ns |     29.83 ns |     2,213.0 ns |  0.30 |    0.01 |         - |         - |          NA |
|                                                      |        |                |              |              |                |       |         |           |           |             |
| **CountDigitsUsingMath**                                 | **100000** |   **754,788.8 ns** |  **7,910.73 ns** |  **6,605.82 ns** |   **756,478.5 ns** |  **1.00** |    **0.00** |         **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | 100000 |   849,384.8 ns | 16,770.26 ns | 47,300.82 ns |   833,649.3 ns |  1.10 |    0.03 |         - |         - |          NA |
| CountDigitsUsingString                               | 100000 | 1,724,193.3 ns | 30,366.59 ns | 61,342.01 ns | 1,699,534.8 ns |  2.32 |    0.11 | 1025.3906 | 4426137 B |          NA |
| CountDigitsUsingMaxMahem                             | 100000 | 2,081,876.2 ns | 39,804.46 ns | 70,752.39 ns | 2,056,581.2 ns |  2.75 |    0.08 |         - |       2 B |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | 100000 |   299,448.6 ns |  3,944.51 ns |  3,496.71 ns |   299,454.4 ns |  0.40 |    0.01 |         - |         - |          NA |
| CountDigitsUsingLookupTable                          | 100000 |   219,429.4 ns |  3,992.52 ns |  6,215.88 ns |   216,851.1 ns |  0.29 |    0.01 |         - |         - |          NA |
