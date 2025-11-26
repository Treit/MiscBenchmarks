# HashSet<T> vs. C5 HashSet<T>





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Count   | Mean           | Error         | StdDev        | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated   | Alloc Ratio |
|--------------------- |-------- |---------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|------------:|------------:|
| **DedupeUsingHashSet**   | **100**     |       **658.6 ns** |       **5.59 ns** |       **4.67 ns** |  **1.00** |    **0.01** |   **0.1259** |        **-** |        **-** |     **2.07 KB** |        **1.00** |
| DedupeUsingC5HashSet | 100     |     1,711.6 ns |      20.30 ns |      18.99 ns |  2.60 |    0.03 |   0.2117 |   0.0019 |        - |     3.46 KB |        1.67 |
|                      |         |                |               |               |       |         |          |          |          |             |             |
| **DedupeUsingHashSet**   | **1000000** | **4,112,324.0 ns** |  **61,980.85 ns** |  **57,976.92 ns** |  **1.00** |    **0.02** | **500.0000** | **500.0000** | **500.0000** | **18169.38 KB** |        **1.00** |
| DedupeUsingC5HashSet | 1000000 | 6,432,067.6 ns | 115,771.86 ns | 108,293.07 ns |  1.56 |    0.03 | 281.2500 | 281.2500 | 281.2500 |  8196.29 KB |        0.45 |
