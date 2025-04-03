# Test getting random weighted values



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27828.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-VYNGRO : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                             | Count | Mean         | Error        | StdDev     | Median       | Ratio  | RatioSD | Gen0      | Gen1      | Gen2     | Allocated   | Alloc Ratio |
|----------------------------------- |------ |-------------:|-------------:|-----------:|-------------:|-------:|--------:|----------:|----------:|---------:|------------:|------------:|
| GetRandomWeightedKnobsOriginal     | 5000  | 52,763.36 μs | 1,049.045 μs | 981.277 μs | 52,429.08 μs | 579.90 |   24.33 | 2100.0000 | 1300.0000 | 500.0000 | 13154.75 KB |       78.46 |
| GetRandomWeightedKnobsBinarySearch | 5000  |    143.04 μs |     8.894 μs |  26.224 μs |    133.06 μs |   1.51 |    0.24 |   39.3066 |    7.8125 |        - |   167.74 KB |        1.00 |
| GetRandomWeightedKnobsFenwickTree  | 5000  |     94.68 μs |     2.340 μs |   6.899 μs |     92.47 μs |   1.00 |    0.00 |   39.5508 |         - |        - |   167.67 KB |        1.00 |
