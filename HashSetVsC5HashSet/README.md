# HashSet<T> vs. C5 HashSet<T>




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Count   | Mean           | Error        | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated   | Alloc Ratio |
|--------------------- |-------- |---------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|------------:|------------:|
| **DedupeUsingHashSet**   | **100**     |       **625.4 ns** |      **7.78 ns** |      **7.28 ns** |  **1.00** |    **0.02** |   **0.1249** |        **-** |        **-** |     **2.05 KB** |        **1.00** |
| DedupeUsingC5HashSet | 100     |     1,729.9 ns |      9.33 ns |      7.79 ns |  2.77 |    0.03 |   0.2193 |   0.0019 |        - |      3.6 KB |        1.75 |
|                      |         |                |              |              |       |         |          |          |          |             |             |
| **DedupeUsingHashSet**   | **1000000** | **4,087,217.4 ns** | **63,280.15 ns** | **56,096.20 ns** |  **1.00** |    **0.02** | **500.0000** | **500.0000** | **500.0000** | **18169.38 KB** |        **1.00** |
| DedupeUsingC5HashSet | 1000000 | 6,641,378.9 ns | 70,143.77 ns | 65,612.52 ns |  1.63 |    0.03 | 289.0625 | 289.0625 | 289.0625 |  8196.25 KB |        0.45 |
