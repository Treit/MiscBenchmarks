# Check if there is anything worth processing with Any before enumerating vs...well...just enumerating.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                | Count  | Mean          | Error         | StdDev       | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------- |------- |--------------:|--------------:|-------------:|------:|--------:|----------:|------------:|
| **JustEnumerate**         | **10**     |      **5.402 ns** |     **0.3473 ns** |     **1.024 ns** |  **1.03** |    **0.27** |         **-** |          **NA** |
| AnyCheckThenEnumerate | 10     |     12.901 ns |     0.4590 ns |     1.353 ns |  2.47 |    0.51 |         - |          NA |
|                       |        |               |               |              |       |         |           |             |
| **JustEnumerate**         | **100000** | **31,961.003 ns** |   **238.1714 ns** |   **222.786 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| AnyCheckThenEnumerate | 100000 | 64,456.793 ns | 1,263.6774 ns | 1,771.499 ns |  2.02 |    0.06 |         - |          NA |
