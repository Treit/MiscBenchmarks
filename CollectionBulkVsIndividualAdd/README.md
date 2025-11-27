# Collection Bulk vs Individual Add Benchmark

Looping through and calling Add vs. using other techniques.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Job       | Runtime   | Count | Mean          | Error        | StdDev       | Median        | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |------ |--------------:|-------------:|-------------:|--------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **ListIndividualAdd**                | **.NET 10.0** | **.NET 10.0** | **10**    |      **23.42 ns** |     **0.379 ns** |     **0.355 ns** |      **23.37 ns** |  **1.00** |    **0.02** |  **0.0057** |       **-** |       **-** |      **96 B** |        **1.00** |
| ListAddRange                     | .NET 10.0 | .NET 10.0 | 10    |      11.96 ns |     0.120 ns |     0.112 ns |      11.92 ns |  0.51 |    0.01 |  0.0057 |       - |       - |      96 B |        1.00 |
| ListConstructorWithCollection    | .NET 10.0 | .NET 10.0 | 10    |      10.94 ns |     0.126 ns |     0.118 ns |      10.92 ns |  0.47 |    0.01 |  0.0057 |       - |       - |      96 B |        1.00 |
| HashSetIndividualAdd             | .NET 10.0 | .NET 10.0 | 10    |      92.29 ns |     1.191 ns |     1.056 ns |      92.31 ns |  3.94 |    0.07 |  0.0176 |       - |       - |     296 B |        3.08 |
| HashSetUnionWith                 | .NET 10.0 | .NET 10.0 | 10    |      89.13 ns |     1.313 ns |     1.164 ns |      89.02 ns |  3.81 |    0.07 |  0.0176 |       - |       - |     296 B |        3.08 |
| HashSetConstructorWithCollection | .NET 10.0 | .NET 10.0 | 10    |      95.38 ns |     0.632 ns |     0.494 ns |      95.50 ns |  4.07 |    0.06 |  0.0176 |       - |       - |     296 B |        3.08 |
|                                  |           |           |       |               |              |              |               |       |         |         |         |         |           |             |
| ListIndividualAdd                | .NET 9.0  | .NET 9.0  | 10    |      23.25 ns |     0.323 ns |     0.270 ns |      23.20 ns |  1.00 |    0.02 |  0.0057 |       - |       - |      96 B |        1.00 |
| ListAddRange                     | .NET 9.0  | .NET 9.0  | 10    |      11.90 ns |     0.292 ns |     0.300 ns |      11.88 ns |  0.51 |    0.01 |  0.0057 |       - |       - |      96 B |        1.00 |
| ListConstructorWithCollection    | .NET 9.0  | .NET 9.0  | 10    |      11.03 ns |     0.115 ns |     0.102 ns |      11.04 ns |  0.47 |    0.01 |  0.0057 |       - |       - |      96 B |        1.00 |
| HashSetIndividualAdd             | .NET 9.0  | .NET 9.0  | 10    |      90.53 ns |     0.938 ns |     0.832 ns |      90.62 ns |  3.89 |    0.06 |  0.0176 |       - |       - |     296 B |        3.08 |
| HashSetUnionWith                 | .NET 9.0  | .NET 9.0  | 10    |      95.09 ns |     1.556 ns |     1.455 ns |      95.42 ns |  4.09 |    0.08 |  0.0176 |       - |       - |     296 B |        3.08 |
| HashSetConstructorWithCollection | .NET 9.0  | .NET 9.0  | 10    |      98.68 ns |     1.243 ns |     1.163 ns |      98.60 ns |  4.25 |    0.07 |  0.0176 |       - |       - |     296 B |        3.08 |
|                                  |           |           |       |               |              |              |               |       |         |         |         |         |           |             |
| **ListIndividualAdd**                | **.NET 10.0** | **.NET 10.0** | **10000** |  **15,970.20 ns** |   **276.531 ns** |   **258.667 ns** |  **16,049.11 ns** |  **1.00** |    **0.02** |  **2.3804** |  **0.2747** |       **-** |   **40056 B** |        **1.00** |
| ListAddRange                     | .NET 10.0 | .NET 10.0 | 10000 |   2,113.71 ns |    40.436 ns |    35.845 ns |   2,114.52 ns |  0.13 |    0.00 |  2.3918 |  0.2975 |       - |   40056 B |        1.00 |
| ListConstructorWithCollection    | .NET 10.0 | .NET 10.0 | 10000 |   1,923.11 ns |    38.416 ns |    81.033 ns |   1,884.20 ns |  0.12 |    0.01 |  2.3918 |  0.2975 |       - |   40056 B |        1.00 |
| HashSetIndividualAdd             | .NET 10.0 | .NET 10.0 | 10000 |  99,094.33 ns |   911.034 ns |   852.182 ns |  99,323.89 ns |  6.21 |    0.11 | 38.4521 | 38.4521 | 38.4521 |  161781 B |        4.04 |
| HashSetUnionWith                 | .NET 10.0 | .NET 10.0 | 10000 | 107,920.22 ns |   848.238 ns |   751.941 ns | 108,178.05 ns |  6.76 |    0.12 | 38.4521 | 38.4521 | 38.4521 |  161781 B |        4.04 |
| HashSetConstructorWithCollection | .NET 10.0 | .NET 10.0 | 10000 | 108,530.68 ns |   492.736 ns |   436.798 ns | 108,475.66 ns |  6.80 |    0.11 | 38.4521 | 38.4521 | 38.4521 |  161781 B |        4.04 |
|                                  |           |           |       |               |              |              |               |       |         |         |         |         |           |             |
| ListIndividualAdd                | .NET 9.0  | .NET 9.0  | 10000 |  15,828.67 ns |   168.852 ns |   149.683 ns |  15,819.15 ns |  1.00 |    0.01 |  2.3804 |  0.2747 |       - |   40056 B |        1.00 |
| ListAddRange                     | .NET 9.0  | .NET 9.0  | 10000 |   1,957.43 ns |    28.202 ns |    25.001 ns |   1,961.51 ns |  0.12 |    0.00 |  2.3918 |  0.2975 |       - |   40056 B |        1.00 |
| ListConstructorWithCollection    | .NET 9.0  | .NET 9.0  | 10000 |   2,089.47 ns |    23.226 ns |    20.590 ns |   2,087.23 ns |  0.13 |    0.00 |  2.3918 |  0.2975 |       - |   40056 B |        1.00 |
| HashSetIndividualAdd             | .NET 9.0  | .NET 9.0  | 10000 |  99,221.27 ns |   295.628 ns |   262.067 ns |  99,282.18 ns |  6.27 |    0.06 | 38.4521 | 38.4521 | 38.4521 |  161781 B |        4.04 |
| HashSetUnionWith                 | .NET 9.0  | .NET 9.0  | 10000 | 109,615.42 ns | 1,952.923 ns | 1,826.766 ns | 108,830.71 ns |  6.93 |    0.13 | 38.4521 | 38.4521 | 38.4521 |  161781 B |        4.04 |
| HashSetConstructorWithCollection | .NET 9.0  | .NET 9.0  | 10000 | 108,369.44 ns |   481.530 ns |   450.423 ns | 108,340.45 ns |  6.85 |    0.07 | 38.4521 | 38.4521 | 38.4521 |  161781 B |        4.04 |
