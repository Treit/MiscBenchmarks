# Test getting random weighted values


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27828.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-SUHVST : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                             | Count | Mean        | Error       | StdDev      | Median      | Ratio  | RatioSD | Gen0      | Gen1      | Gen2     | Allocated   | Alloc Ratio |
|----------------------------------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|----------:|----------:|---------:|------------:|------------:|
| GetRandomWeightedKnobsOriginal     | 5000  | 57,344.8 μs | 1,365.88 μs | 4,027.32 μs | 56,191.5 μs | 575.40 |   48.76 | 2000.0000 | 1142.8571 | 428.5714 | 13155.47 KB |       78.46 |
| GetRandomWeightedKnobsBinarySearch | 5000  |    141.5 μs |     4.36 μs |    12.84 μs |    139.9 μs |   1.29 |    0.06 |   39.3066 |    7.8125 |        - |   167.74 KB |        1.00 |
| GetRandomWeightedKnobsFenwickTree  | 5000  |    105.8 μs |     2.09 μs |     2.49 μs |    106.1 μs |   1.00 |    0.00 |   39.5508 |    7.8125 |        - |   167.68 KB |        1.00 |
