# Consider each unique value in a set that has 'runs' of values.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Count   | Mean             | Error          | StdDev         | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **IterateListAfterCallingDistinct** | **10**      |        **608.16 ns** |       **5.217 ns** |       **4.625 ns** |  **1.00** |    **0.01** |   **0.0391** |        **-** |        **-** |      **664 B** |        **1.00** |
| IterateListSkippingDuplicates   | 10      |         67.34 ns |       0.769 ns |       0.682 ns |  0.11 |    0.00 |        - |        - |        - |          - |        0.00 |
|                                 |         |                  |                |                |       |         |          |          |          |            |             |
| **IterateListAfterCallingDistinct** | **1000000** | **72,837,871.43 ns** | **961,816.230 ns** | **803,160.113 ns** |  **1.00** |    **0.02** | **285.7143** | **285.7143** | **285.7143** | **43111209 B** |        **1.00** |
| IterateListSkippingDuplicates   | 1000000 | 15,239,042.67 ns |  35,760.894 ns |  29,861.966 ns |  0.21 |    0.00 |        - |        - |        - |          - |        0.00 |
