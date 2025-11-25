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
| ReturnEnumerableEmpty      | 31.33 μs | 0.201 μs | 0.188 μs |  1.00 |         - |          NA |
| ReturnArrayEmpty           | 31.40 μs | 0.257 μs | 0.240 μs |  1.00 |         - |          NA |
| ReturnNewArray             | 31.39 μs | 0.367 μs | 0.343 μs |  1.00 |         - |          NA |
| ReturnNull                 | 31.33 μs | 0.278 μs | 0.260 μs |  1.00 |         - |          NA |
| ReturnCollectionExpression | 31.39 μs | 0.338 μs | 0.316 μs |  1.00 |         - |          NA |
