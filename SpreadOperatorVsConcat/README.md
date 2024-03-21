# Concat two lists using spread operator vs. LINQ Concat



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26058.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-LSLKOX : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method                     | Count | Mean       | Error     | StdDev     | Median     | Allocated |
|--------------------------- |------ |-----------:|----------:|-----------:|-----------:|----------:|
| **AddThenEnumerateWithSpread** | **100**   |   **7.880 μs** | **0.5133 μs** |  **1.4393 μs** |   **7.500 μs** |    **1256 B** |
| AddThenEnumerateWithConcat | 100   |  14.679 μs | 0.2734 μs |  0.2424 μs |  14.700 μs |     536 B |
| **AddThenEnumerateWithSpread** | **10000** | **103.839 μs** | **3.6361 μs** | **10.1360 μs** |  **98.500 μs** |   **80456 B** |
| AddThenEnumerateWithConcat | 10000 | 153.454 μs | 3.0564 μs |  7.9440 μs | 149.900 μs |     536 B |
