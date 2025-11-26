# LINQ Count() vs. ToList().Count






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method         | Count   | Mean             | Error           | StdDev          | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|--------------- |-------- |-----------------:|----------------:|----------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **LinqCount**      | **10**      |         **7.106 ns** |       **0.0618 ns** |       **0.0578 ns** |  **1.00** |    **0.01** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| ToListDotCount | 10      |       107.120 ns |       1.3675 ns |       1.2791 ns | 15.08 |    0.21 |  0.0124 |       - |       - |     208 B |          NA |
|                |         |                  |                 |                 |       |         |         |         |         |           |             |
| **LinqCount**      | **1000000** | **3,198,552.500 ns** |  **24,015.2729 ns** |  **22,463.9011 ns** |  **1.00** |    **0.01** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| ToListDotCount | 1000000 | 9,771,285.156 ns | 190,292.7272 ns | 317,936.4240 ns |  3.06 |    0.10 | 78.1250 | 78.1250 | 78.1250 | 7992593 B |          NA |
