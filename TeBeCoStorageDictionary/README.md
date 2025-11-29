# TeBeCoStorageDictionary



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | EntityCount | Mean           | Error        | StdDev       | Ratio | Gen0    | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |------------ |---------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **NewImplementationTypeOf**  | **.NET 10.0** | **.NET 10.0** | **1**           |    **10,596.3 ns** |    **119.26 ns** |     **99.58 ns** |  **1.00** |  **0.1526** |    **2888 B** |        **1.00** |
| OldImplementationTypeOf  | .NET 10.0 | .NET 10.0 | 1           |       193.1 ns |      1.40 ns |      1.17 ns |  0.02 |  0.0367 |     616 B |        0.21 |
| NewImplementationGetType | .NET 10.0 | .NET 10.0 | 1           |    10,794.4 ns |     48.80 ns |     38.10 ns |  1.02 |  0.1526 |    2888 B |        1.00 |
| OldImplementationGetType | .NET 10.0 | .NET 10.0 | 1           |       201.6 ns |      1.00 ns |      0.94 ns |  0.02 |  0.0367 |     616 B |        0.21 |
|                          |           |           |             |                |              |              |       |         |           |             |
| NewImplementationTypeOf  | .NET 9.0  | .NET 9.0  | 1           |    10,845.8 ns |    104.93 ns |     87.62 ns |  1.00 |  0.1526 |    2888 B |        1.00 |
| OldImplementationTypeOf  | .NET 9.0  | .NET 9.0  | 1           |       192.0 ns |      0.89 ns |      0.79 ns |  0.02 |  0.0367 |     616 B |        0.21 |
| NewImplementationGetType | .NET 9.0  | .NET 9.0  | 1           |    10,610.6 ns |     80.87 ns |     67.53 ns |  0.98 |  0.1526 |    2888 B |        1.00 |
| OldImplementationGetType | .NET 9.0  | .NET 9.0  | 1           |       196.1 ns |      1.09 ns |      1.02 ns |  0.02 |  0.0367 |     616 B |        0.21 |
|                          |           |           |             |                |              |              |       |         |           |             |
| **NewImplementationTypeOf**  | **.NET 10.0** | **.NET 10.0** | **512**         | **5,466,415.5 ns** | **28,534.71 ns** | **23,827.77 ns** |  **1.00** | **78.1250** | **1478843 B** |        **1.00** |
| OldImplementationTypeOf  | .NET 10.0 | .NET 10.0 | 512         |    99,762.1 ns |  1,698.50 ns |  1,505.68 ns |  0.02 | 18.7988 |  315399 B |        0.21 |
| NewImplementationGetType | .NET 10.0 | .NET 10.0 | 512         | 5,565,813.3 ns | 84,896.92 ns | 70,892.77 ns |  1.02 | 78.1250 | 1478843 B |        1.00 |
| OldImplementationGetType | .NET 10.0 | .NET 10.0 | 512         |   102,977.1 ns |    671.68 ns |    524.41 ns |  0.02 | 18.7988 |  315399 B |        0.21 |
|                          |           |           |             |                |              |              |       |         |           |             |
| NewImplementationTypeOf  | .NET 9.0  | .NET 9.0  | 512         | 5,527,022.5 ns | 28,065.55 ns | 21,911.73 ns |  1.00 | 78.1250 | 1478843 B |        1.00 |
| OldImplementationTypeOf  | .NET 9.0  | .NET 9.0  | 512         |   112,039.5 ns |    955.67 ns |    847.18 ns |  0.02 | 18.7988 |  315399 B |        0.21 |
| NewImplementationGetType | .NET 9.0  | .NET 9.0  | 512         | 5,369,362.1 ns | 37,994.49 ns | 29,663.60 ns |  0.97 | 78.1250 | 1478843 B |        1.00 |
| OldImplementationGetType | .NET 9.0  | .NET 9.0  | 512         |   100,593.9 ns |    720.22 ns |    638.46 ns |  0.02 | 18.7988 |  315399 B |        0.21 |
