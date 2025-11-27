# Consider each unique value in a set that has 'runs' of values.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Count   | Mean             | Error            | StdDev         | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------------- |---------- |---------- |-------- |-----------------:|-----------------:|---------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **IterateListAfterCallingDistinct** | **.NET 10.0** | **.NET 10.0** | **10**      |        **615.40 ns** |         **5.070 ns** |       **4.494 ns** |  **1.00** |    **0.01** |   **0.0391** |        **-** |        **-** |      **664 B** |        **1.00** |
| IterateListSkippingDuplicates   | .NET 10.0 | .NET 10.0 | 10      |         67.77 ns |         0.692 ns |       0.614 ns |  0.11 |    0.00 |        - |        - |        - |          - |        0.00 |
|                                 |           |           |         |                  |                  |                |       |         |          |          |          |            |             |
| IterateListAfterCallingDistinct | .NET 9.0  | .NET 9.0  | 10      |        643.47 ns |         6.283 ns |       5.569 ns |  1.00 |    0.01 |   0.0391 |        - |        - |      664 B |        1.00 |
| IterateListSkippingDuplicates   | .NET 9.0  | .NET 9.0  | 10      |         67.88 ns |         1.037 ns |       0.970 ns |  0.11 |    0.00 |        - |        - |        - |          - |        0.00 |
|                                 |           |           |         |                  |                  |                |       |         |          |          |          |            |             |
| **IterateListAfterCallingDistinct** | **.NET 10.0** | **.NET 10.0** | **1000000** | **71,508,170.33 ns** | **1,039,330.330 ns** | **867,887.897 ns** |  **1.00** |    **0.02** | **285.7143** | **285.7143** | **285.7143** | **43111209 B** |        **1.00** |
| IterateListSkippingDuplicates   | .NET 10.0 | .NET 10.0 | 1000000 | 15,474,352.50 ns |    14,055.863 ns |  13,147.863 ns |  0.22 |    0.00 |        - |        - |        - |          - |        0.00 |
|                                 |           |           |         |                  |                  |                |       |         |          |          |          |            |             |
| IterateListAfterCallingDistinct | .NET 9.0  | .NET 9.0  | 1000000 | 71,350,596.43 ns |   613,016.682 ns | 543,423.322 ns |  1.00 |    0.01 | 250.0000 | 250.0000 | 250.0000 | 43111198 B |        1.00 |
| IterateListSkippingDuplicates   | .NET 9.0  | .NET 9.0  | 1000000 | 15,270,801.90 ns |    52,369.804 ns |  46,424.467 ns |  0.21 |    0.00 |        - |        - |        - |          - |        0.00 |
