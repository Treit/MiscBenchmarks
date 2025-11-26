# Adding to ConcurrentBag vs. List`<T>` with a lock.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                            | Count   | Mean         | Error        | StdDev       | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|---------------------------------- |-------- |-------------:|-------------:|-------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **ConcurrentAddToNormalListWithLock** | **100**     |     **32.78 μs** |     **1.158 μs** |     **3.265 μs** |  **1.01** |    **0.14** |         **-** |         **-** |         **-** |     **3.56 KB** |        **1.00** |
| ConcurrentAddToConcurrentBag      | 100     |     40.66 μs |     1.447 μs |     4.105 μs |  1.25 |    0.17 |         - |         - |         - |     4.06 KB |        1.14 |
|                                   |         |              |              |              |       |         |           |           |           |             |             |
| **ConcurrentAddToNormalListWithLock** | **1000000** | **85,542.09 μs** | **1,685.795 μs** | **2,769.810 μs** |  **1.00** |    **0.04** | **1000.0000** | **1000.0000** | **1000.0000** |  **8198.14 KB** |        **1.00** |
| ConcurrentAddToConcurrentBag      | 1000000 |  8,143.89 μs |   162.835 μs |   445.759 μs |  0.10 |    0.01 | 1000.0000 | 1000.0000 | 1000.0000 | 15948.42 KB |        1.95 |
