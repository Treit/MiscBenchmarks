# Adding to ConcurrentBag vs. List`<T>` with a lock.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26252.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-TYHWBM : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method                            | Count   | Mean        | Error       | StdDev      | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|---------------------------------- |-------- |------------:|------------:|------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **ConcurrentAddToNormalListWithLock** | **100**     |    **119.9 μs** |     **7.58 μs** |    **22.22 μs** |  **1.00** |    **0.00** |         **-** |         **-** |         **-** |     **3.25 KB** |        **1.00** |
| ConcurrentAddToConcurrentBag      | 100     |    109.4 μs |     5.32 μs |    15.35 μs |  0.94 |    0.22 |         - |         - |         - |      4.2 KB |        1.29 |
|                                   |         |             |             |             |       |         |           |           |           |             |             |
| **ConcurrentAddToNormalListWithLock** | **1000000** | **72,480.7 μs** | **1,162.25 μs** | **1,469.87 μs** |  **1.00** |    **0.00** | **1000.0000** | **1000.0000** | **1000.0000** |  **8197.06 KB** |        **1.00** |
| ConcurrentAddToConcurrentBag      | 1000000 | 17,503.3 μs |   735.61 μs | 2,168.97 μs |  0.26 |    0.02 |         - |         - |         - | 15208.43 KB |        1.86 |
