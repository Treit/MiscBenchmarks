# Test dictionary lookups using string interpolation vs. ToString()



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27823.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-LHNWPU : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                   | Count | Mean     | Error   | StdDev   | Median   | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------- |------ |---------:|--------:|---------:|---------:|------:|--------:|--------:|----------:|------------:|
| LookupUsingToString      | 5000  | 165.7 μs | 3.29 μs |  6.26 μs | 165.9 μs |  1.00 |    0.00 | 34.6680 | 146.88 KB |        1.00 |
| LookupUsingInterpolation | 5000  | 365.1 μs | 7.29 μs | 17.74 μs | 358.6 μs |  2.20 |    0.13 | 36.6211 | 156.17 KB |        1.06 |
