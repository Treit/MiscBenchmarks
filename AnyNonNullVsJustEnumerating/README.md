# Check if there is anything worth processing with Any before enumerating vs...well...just enumerating.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                | Count  | Mean          | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------- |------- |--------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **JustEnumerate**         | **10**     |      **5.584 ns** |     **0.3374 ns** |     **0.9948 ns** |  **1.03** |    **0.26** |         **-** |          **NA** |
| AnyCheckThenEnumerate | 10     |     12.740 ns |     0.3878 ns |     1.1435 ns |  2.36 |    0.47 |         - |          NA |
|                       |        |               |               |               |       |         |           |             |
| **JustEnumerate**         | **100000** | **32,226.422 ns** |   **640.5201 ns** |   **938.8662 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
| AnyCheckThenEnumerate | 100000 | 64,831.953 ns | 1,245.4710 ns | 1,482.6447 ns |  2.01 |    0.07 |         - |          NA |
