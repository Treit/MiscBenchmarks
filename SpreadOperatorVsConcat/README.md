# Concat two lists using spread operator vs. LINQ Concat






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                     | Job       | Runtime   | Count | Mean       | Error     | StdDev     | Median     | Allocated |
|--------------------------- |---------- |---------- |------ |-----------:|----------:|-----------:|-----------:|----------:|
| **AddThenEnumerateWithSpread** | **.NET 10.0** | **.NET 10.0** | **100**   |   **3.761 μs** | **0.2465 μs** |  **0.7231 μs** |   **3.900 μs** |     **856 B** |
| AddThenEnumerateWithConcat | .NET 10.0 | .NET 10.0 | 100   |  15.178 μs | 0.5996 μs |  1.7395 μs |  15.800 μs |     136 B |
| AddThenEnumerateWithSpread | .NET 9.0  | .NET 9.0  | 100   |   4.020 μs | 0.2905 μs |  0.8566 μs |   4.200 μs |     856 B |
| AddThenEnumerateWithConcat | .NET 9.0  | .NET 9.0  | 100   |  15.558 μs | 0.6893 μs |  1.9998 μs |  16.100 μs |     136 B |
| **AddThenEnumerateWithSpread** | **.NET 10.0** | **.NET 10.0** | **10000** |  **47.493 μs** | **5.2108 μs** | **15.2823 μs** |  **53.300 μs** |   **80056 B** |
| AddThenEnumerateWithConcat | .NET 10.0 | .NET 10.0 | 10000 | 134.644 μs | 2.5833 μs |  2.5372 μs | 133.900 μs |     136 B |
| AddThenEnumerateWithSpread | .NET 9.0  | .NET 9.0  | 10000 |  46.659 μs | 4.2353 μs | 12.4879 μs |  53.500 μs |   80056 B |
| AddThenEnumerateWithConcat | .NET 9.0  | .NET 9.0  | 10000 | 133.575 μs | 2.2595 μs |  2.2192 μs | 133.600 μs |     136 B |
