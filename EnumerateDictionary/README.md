# Enumerating dictionary keys.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27823.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-VGCJHG : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                               | Count | Mean       | Error    | StdDev    | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------- |------ |-----------:|---------:|----------:|-----------:|------:|--------:|----------:|------------:|
| EnumerateDictionaryKeys              | 1000  | 1,356.9 ns | 36.47 ns | 107.52 ns | 1,321.0 ns |  2.14 |    0.17 |         - |          NA |
| EnumerateDictionaryKeyValuePairs     | 1000  | 1,536.6 ns | 50.94 ns | 150.19 ns | 1,482.8 ns |  2.36 |    0.18 |         - |          NA |
| EnumerateDictionaryKeysCachedInArray | 1000  |   635.8 ns | 12.73 ns |  33.98 ns |   626.5 ns |  1.00 |    0.00 |         - |          NA |
