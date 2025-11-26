# Test dictionary lookups using string interpolation vs. ToString()





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                   | Count | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
| LookupUsingToString      | 5000  | 101.9 μs | 1.28 μs | 1.19 μs |  1.00 |    0.02 | 8.9111 | 146.88 KB |        1.00 |
| LookupUsingInterpolation | 5000  | 175.9 μs | 1.42 μs | 1.32 μs |  1.73 |    0.02 | 9.5215 | 156.17 KB |        1.06 |
