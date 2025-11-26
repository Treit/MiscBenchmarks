# TeBeCoStorageDictionary


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | EntityCount | Mean           | Error        | StdDev       | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------- |------------ |---------------:|-------------:|-------------:|------:|--------:|--------:|----------:|------------:|
| **NewImplementationTypeOf**  | **1**           |    **10,513.2 ns** |    **183.89 ns** |    **153.56 ns** |  **1.00** |    **0.02** |  **0.1526** |    **2888 B** |        **1.00** |
| OldImplementationTypeOf  | 1           |       209.3 ns |      3.11 ns |      2.91 ns |  0.02 |    0.00 |  0.0367 |     616 B |        0.21 |
| NewImplementationGetType | 1           |    10,844.1 ns |    215.22 ns |    190.79 ns |  1.03 |    0.02 |  0.1526 |    2888 B |        1.00 |
| OldImplementationGetType | 1           |       211.9 ns |      1.57 ns |      1.31 ns |  0.02 |    0.00 |  0.0367 |     616 B |        0.21 |
|                          |             |                |              |              |       |         |         |           |             |
| **NewImplementationTypeOf**  | **512**         | **5,376,261.9 ns** | **84,521.73 ns** | **70,579.47 ns** |  **1.00** |    **0.02** | **78.1250** | **1478843 B** |        **1.00** |
| OldImplementationTypeOf  | 512         |    99,550.1 ns |    868.76 ns |    812.64 ns |  0.02 |    0.00 | 18.7988 |  315399 B |        0.21 |
| NewImplementationGetType | 512         | 5,523,677.9 ns | 90,858.13 ns | 75,870.65 ns |  1.03 |    0.02 | 78.1250 | 1478843 B |        1.00 |
| OldImplementationGetType | 512         |   105,176.0 ns |  1,031.93 ns |    914.78 ns |  0.02 |    0.00 | 18.7988 |  315399 B |        0.21 |
