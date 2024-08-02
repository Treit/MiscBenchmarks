# Getting count of set intersection.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count | Mean         | Error       | StdDev       | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|----------------------------------- |------ |-------------:|------------:|-------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **CountUsingLinqIntersect**            | **10**    |     **578.3 ns** |    **11.57 ns** |     **25.63 ns** |  **1.00** |    **0.00** |  **0.1183** |       **-** |       **-** |     **512 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | 10    |     863.3 ns |    25.27 ns |     70.45 ns |  1.49 |    0.16 |  0.2260 |       - |       - |     976 B |        1.91 |
|                                    |       |              |             |              |       |         |         |         |         |           |             |
| **CountUsingLinqIntersect**            | **10000** | **344,300.6 ns** | **6,310.90 ns** | **12,748.34 ns** |  **1.00** |    **0.00** | **49.8047** | **49.8047** | **49.8047** |  **202641 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | 10000 | 391,292.0 ns | 7,769.15 ns | 18,160.13 ns |  1.14 |    0.07 | 99.6094 | 99.6094 | 99.6094 |  405474 B |        2.00 |
