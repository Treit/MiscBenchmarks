# Adding to ConcurrentBag vs. List`<T>` with a lock.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                            | Job       | Runtime   | Count   | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|---------------------------------- |---------- |---------- |-------- |-------------:|-------------:|-------------:|-------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **ConcurrentAddToNormalListWithLock** | **.NET 10.0** | **.NET 10.0** | **100**     |     **38.10 μs** |     **3.039 μs** |     **8.269 μs** |     **37.25 μs** |  **1.04** |    **0.30** |         **-** |         **-** |         **-** |     **3.56 KB** |        **1.00** |
| ConcurrentAddToConcurrentBag      | .NET 10.0 | .NET 10.0 | 100     |     55.27 μs |     5.240 μs |    15.284 μs |     50.95 μs |  1.51 |    0.51 |         - |         - |         - |     4.13 KB |        1.16 |
|                                   |           |           |         |              |              |              |              |       |         |           |           |           |             |             |
| ConcurrentAddToNormalListWithLock | .NET 9.0  | .NET 9.0  | 100     |     37.66 μs |     2.190 μs |     6.068 μs |     37.00 μs |  1.02 |    0.23 |         - |         - |         - |     3.72 KB |        1.00 |
| ConcurrentAddToConcurrentBag      | .NET 9.0  | .NET 9.0  | 100     |     52.91 μs |     5.096 μs |    14.785 μs |     49.00 μs |  1.44 |    0.46 |         - |         - |         - |     4.13 KB |        1.11 |
|                                   |           |           |         |              |              |              |              |       |         |           |           |           |             |             |
| **ConcurrentAddToNormalListWithLock** | **.NET 10.0** | **.NET 10.0** | **1000000** | **77,653.00 μs** | **1,532.741 μs** | **3,521.728 μs** | **78,287.80 μs** |  **1.00** |    **0.06** | **1000.0000** | **1000.0000** | **1000.0000** |   **8198.7 KB** |        **1.00** |
| ConcurrentAddToConcurrentBag      | .NET 10.0 | .NET 10.0 | 1000000 |  7,623.23 μs |   150.593 μs |   229.971 μs |  7,630.55 μs |  0.10 |    0.01 | 1000.0000 | 1000.0000 | 1000.0000 | 15692.48 KB |        1.91 |
|                                   |           |           |         |              |              |              |              |       |         |           |           |           |             |             |
| ConcurrentAddToNormalListWithLock | .NET 9.0  | .NET 9.0  | 1000000 | 76,038.35 μs | 1,514.791 μs | 2,882.047 μs | 75,499.60 μs |  1.00 |    0.05 | 1000.0000 | 1000.0000 | 1000.0000 |  8198.05 KB |        1.00 |
| ConcurrentAddToConcurrentBag      | .NET 9.0  | .NET 9.0  | 1000000 |  7,574.95 μs |   149.499 μs |   261.835 μs |  7,506.40 μs |  0.10 |    0.01 | 1000.0000 | 1000.0000 | 1000.0000 | 16460.51 KB |        2.01 |
