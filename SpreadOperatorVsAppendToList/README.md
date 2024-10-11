# Return a copy of a list with a new item added to the end

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27723.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                 | Count | Mean        | Error     | StdDev     | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------- |------ |------------:|----------:|-----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **AddWithSpreadOperator**  | **5**     |    **23.82 ns** |  **0.708 ns** |   **2.032 ns** |  **1.00** |    **0.00** | **0.0185** |      **-** |      **80 B** |        **1.00** |
| AddWithAppendAndToList | 5     |    59.21 ns |  1.243 ns |   2.177 ns |  2.52 |    0.23 | 0.0315 |      - |     136 B |        1.70 |
|                        |       |             |           |            |       |         |        |        |           |             |
| **AddWithSpreadOperator**  | **50**    |    **34.52 ns** |  **0.763 ns** |   **1.356 ns** |  **1.00** |    **0.00** | **0.0612** |      **-** |     **264 B** |        **1.00** |
| AddWithAppendAndToList | 50    |    72.90 ns |  1.320 ns |   1.762 ns |  2.13 |    0.09 | 0.0741 |      - |     320 B |        1.21 |
|                        |       |             |           |            |       |         |        |        |           |             |
| **AddWithSpreadOperator**  | **10000** | **4,162.71 ns** | **78.484 ns** |  **73.414 ns** |  **1.00** |    **0.00** | **9.2545** | **1.0223** |   **40064 B** |        **1.00** |
| AddWithAppendAndToList | 10000 | 4,258.67 ns | 84.208 ns | 175.773 ns |  1.01 |    0.03 | 9.2545 | 1.0223 |   40120 B |        1.00 |
