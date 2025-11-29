# Check if there is anything worth processing with Any before enumerating vs...well...just enumerating.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                | Job       | Runtime   | Count  | Mean          | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------- |---------- |---------- |------- |--------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **JustEnumerate**         | **.NET 10.0** | **.NET 10.0** | **10**     |      **5.634 ns** |     **0.1881 ns** |     **0.5548 ns** |  **1.01** |    **0.14** |         **-** |          **NA** |
| AnyCheckThenEnumerate | .NET 10.0 | .NET 10.0 | 10     |     12.433 ns |     0.2798 ns |     0.3222 ns |  2.23 |    0.22 |         - |          NA |
|                       |           |           |        |               |               |               |       |         |           |             |
| JustEnumerate         | .NET 9.0  | .NET 9.0  | 10     |      5.503 ns |     0.1782 ns |     0.5254 ns |  1.01 |    0.14 |         - |          NA |
| AnyCheckThenEnumerate | .NET 9.0  | .NET 9.0  | 10     |     12.713 ns |     0.3871 ns |     1.1412 ns |  2.33 |    0.30 |         - |          NA |
|                       |           |           |        |               |               |               |       |         |           |             |
| **JustEnumerate**         | **.NET 10.0** | **.NET 10.0** | **100000** | **32,128.865 ns** |   **422.2518 ns** |   **394.9746 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| AnyCheckThenEnumerate | .NET 10.0 | .NET 10.0 | 100000 | 64,788.867 ns | 1,282.2578 ns | 1,372.0015 ns |  2.02 |    0.05 |         - |          NA |
|                       |           |           |        |               |               |               |       |         |           |             |
| JustEnumerate         | .NET 9.0  | .NET 9.0  | 100000 | 32,168.702 ns |   631.5935 ns |   590.7929 ns |  1.00 |    0.02 |         - |          NA |
| AnyCheckThenEnumerate | .NET 9.0  | .NET 9.0  | 100000 | 64,474.207 ns |   818.7995 ns |   765.9055 ns |  2.00 |    0.04 |         - |          NA |
