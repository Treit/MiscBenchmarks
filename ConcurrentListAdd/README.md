# Adding to ConcurrentBag vs. List`<T>` with a lock.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                            | Count   | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|---------------------------------- |-------- |-------------:|-------------:|-------------:|-------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **ConcurrentAddToNormalListWithLock** | **100**     |     **30.21 μs** |     **0.770 μs** |     **2.081 μs** |     **29.50 μs** |  **1.00** |    **0.10** |         **-** |         **-** |         **-** |     **3.72 KB** |        **1.00** |
| ConcurrentAddToConcurrentBag      | 100     |     44.00 μs |     1.722 μs |     4.770 μs |     44.65 μs |  1.46 |    0.18 |         - |         - |         - |     4.06 KB |        1.09 |
|                                   |         |              |              |              |              |       |         |           |           |           |             |             |
| **ConcurrentAddToNormalListWithLock** | **1000000** | **75,816.97 μs** | **1,480.827 μs** | **2,554.354 μs** | **75,649.70 μs** |  **1.00** |    **0.05** | **1000.0000** | **1000.0000** | **1000.0000** |  **8198.14 KB** |        **1.00** |
| ConcurrentAddToConcurrentBag      | 1000000 |  7,951.65 μs |   178.595 μs |   512.422 μs |  8,005.55 μs |  0.10 |    0.01 | 1000.0000 | 1000.0000 | 1000.0000 | 16972.93 KB |        2.07 |
