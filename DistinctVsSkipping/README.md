# Consider each unique value in a set that has 'runs' of values.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Count   | Mean             | Error            | StdDev         | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|-------------------------------- |-------- |-----------------:|-----------------:|---------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **IterateListAfterCallingDistinct** | **10**      |        **597.87 ns** |         **5.545 ns** |       **4.915 ns** |  **1.00** |    **0.01** |   **0.0391** |        **-** |        **-** |      **664 B** |        **1.00** |
| IterateListSkippingDuplicates   | 10      |         68.00 ns |         1.066 ns |       0.945 ns |  0.11 |    0.00 |        - |        - |        - |          - |        0.00 |
|                                 |         |                  |                  |                |       |         |          |          |          |            |             |
| **IterateListAfterCallingDistinct** | **1000000** | **72,711,847.96 ns** | **1,048,060.547 ns** | **929,078.377 ns** |  **1.00** |    **0.02** | **285.7143** | **285.7143** | **285.7143** | **43111209 B** |        **1.00** |
| IterateListSkippingDuplicates   | 1000000 | 15,479,604.79 ns |    17,931.991 ns |  16,773.595 ns |  0.21 |    0.00 |        - |        - |        - |          - |        0.00 |
