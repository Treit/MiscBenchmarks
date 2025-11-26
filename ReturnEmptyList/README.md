# Indicating an empty sequence.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                     | Mean     | Error    | StdDev   | Ratio | Allocated | Alloc Ratio |
|--------------------------- |---------:|---------:|---------:|------:|----------:|------------:|
| ReturnEnumerableEmpty      | 31.31 μs | 0.336 μs | 0.315 μs |  1.00 |         - |          NA |
| ReturnArrayEmpty           | 31.29 μs | 0.324 μs | 0.303 μs |  1.00 |         - |          NA |
| ReturnNewArray             | 31.34 μs | 0.256 μs | 0.239 μs |  1.00 |         - |          NA |
| ReturnNull                 | 31.30 μs | 0.326 μs | 0.305 μs |  1.00 |         - |          NA |
| ReturnCollectionExpression | 31.27 μs | 0.283 μs | 0.265 μs |  1.00 |         - |          NA |
