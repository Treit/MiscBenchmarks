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
| **AddThenEnumerateWithSpread** | **100**   |   **3.791 μs** | **0.2803 μs** |  **0.8266 μs** |   **4.100 μs** |     **856 B** |
| AddThenEnumerateWithConcat | 100   |  12.970 μs | 0.2578 μs |  0.3614 μs |  12.900 μs |     136 B |
| **AddThenEnumerateWithSpread** | **10000** |  **57.640 μs** | **8.1048 μs** | **23.7700 μs** |  **71.350 μs** |   **80056 B** |
| AddThenEnumerateWithConcat | 10000 | 132.425 μs | 2.5253 μs |  2.4802 μs | 131.050 μs |     136 B |
