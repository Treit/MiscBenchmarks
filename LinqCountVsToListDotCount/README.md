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
| **LinqCount**      | **10**      |         **7.079 ns** |       **0.0624 ns** |       **0.0584 ns** |  **1.00** |    **0.01** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| ToListDotCount | 10      |       105.816 ns |       1.0211 ns |       0.9552 ns | 14.95 |    0.18 |  0.0124 |       - |       - |     208 B |          NA |
|                |         |                  |                 |                 |       |         |         |         |         |           |             |
| **LinqCount**      | **1000000** | **3,184,994.076 ns** |  **63,038.6458 ns** |  **81,968.0527 ns** |  **1.00** |    **0.04** |       **-** |       **-** |       **-** |         **-** |          **NA** |
| ToListDotCount | 1000000 | 9,737,772.424 ns | 194,405.5226 ns | 379,173.0703 ns |  3.06 |    0.14 | 78.1250 | 78.1250 | 78.1250 | 7992594 B |          NA |
