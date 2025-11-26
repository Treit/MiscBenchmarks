# Concat two lists using spread operator vs. LINQ Concat





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                     | Count | Mean       | Error     | StdDev     | Median     | Allocated |
|--------------------------- |------ |-----------:|----------:|-----------:|-----------:|----------:|
| **AddThenEnumerateWithSpread** | **100**   |   **4.144 μs** | **0.3913 μs** |  **1.1477 μs** |   **4.200 μs** |     **856 B** |
| AddThenEnumerateWithConcat | 100   |  13.447 μs | 0.2681 μs |  0.4174 μs |  13.450 μs |     136 B |
| **AddThenEnumerateWithSpread** | **10000** |  **50.391 μs** | **5.0049 μs** | **14.2793 μs** |  **55.350 μs** |   **80056 B** |
| AddThenEnumerateWithConcat | 10000 | 133.803 μs | 2.5631 μs |  2.8489 μs | 133.150 μs |     136 B |
