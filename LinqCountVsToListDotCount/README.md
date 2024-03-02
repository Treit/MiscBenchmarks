# LINQ Count() vs. ToList().Count




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-HNUTJF : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method         | Count   | Mean            | Error           | StdDev          | Median          | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated  | Alloc Ratio |
|--------------- |-------- |----------------:|----------------:|----------------:|----------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **LinqCount**      | **10**      |        **107.8 ns** |         **3.46 ns** |        **10.19 ns** |        **103.9 ns** |  **1.00** |    **0.00** |   **0.0092** |        **-** |        **-** |       **40 B** |        **1.00** |
| ToListDotCount | 10      |        157.7 ns |         2.82 ns |         2.64 ns |        157.3 ns |  1.44 |    0.18 |   0.0927 |        - |        - |      400 B |       10.00 |
|                |         |                 |                 |                 |                 |       |         |          |          |          |            |             |
| **LinqCount**      | **1000000** | **10,535,873.2 ns** |   **275,029.28 ns** |   **810,930.05 ns** | **10,250,359.4 ns** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |       **52 B** |        **1.00** |
| ToListDotCount | 1000000 | 20,764,652.7 ns | 1,244,180.11 ns | 3,668,493.12 ns | 21,562,979.7 ns |  1.98 |    0.39 | 250.0000 | 250.0000 | 250.0000 | 16777840 B |  322,650.77 |
