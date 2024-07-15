# Serializing and deserializng JSON list using AsyncEnumerable vs. Normal


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26254.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                     | Count  | Mean        | Error       | StdDev      | Median      | Gen0      | Gen1      | Gen2     | Allocated   |
|--------------------------- |------- |------------:|------------:|------------:|------------:|----------:|----------:|---------:|------------:|
| **DeserializeAsyncEnumerable** | **100**    |    **340.4 μs** |     **8.79 μs** |    **25.76 μs** |    **334.9 μs** |    **4.8828** |         **-** |        **-** |    **23.18 KB** |
| DeserializeNormal          | 100    |    197.7 μs |     6.98 μs |    20.48 μs |    189.5 μs |    5.1270 |         - |        - |    21.81 KB |
| **DeserializeAsyncEnumerable** | **10000**  |  **7,644.4 μs** |   **352.10 μs** | **1,038.17 μs** |  **7,408.3 μs** |  **445.3125** |   **23.4375** |        **-** |  **1889.83 KB** |
| DeserializeNormal          | 10000  |  8,883.5 μs |   488.64 μs | 1,433.10 μs |  8,346.7 μs |  328.1250 |  156.2500 |  62.5000 |  2132.34 KB |
| **DeserializeAsyncEnumerable** | **100000** | **54,891.2 μs** |   **419.81 μs** |   **838.41 μs** | **54,751.8 μs** | **4400.0000** |  **200.0000** |        **-** | **18806.27 KB** |
| DeserializeNormal          | 100000 | 89,101.0 μs | 1,763.24 μs | 4,121.52 μs | 87,964.5 μs | 3333.3333 | 1333.3333 | 333.3333 | 20799.84 KB |
