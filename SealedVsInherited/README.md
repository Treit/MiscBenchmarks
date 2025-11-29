# Calling methods on sealed vs non-sealed classes.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count | Mean         | Error      | StdDev     |
|----------------------- |---------- |---------- |------ |-------------:|-----------:|-----------:|
| **Sealed**                 | **.NET 10.0** | **.NET 10.0** | **10**    |     **3.499 μs** |  **0.0223 μs** |  **0.0208 μs** |
| NonSealed              | .NET 10.0 | .NET 10.0 | 10    |     3.443 μs |  0.0176 μs |  0.0165 μs |
| NonSealedVirtualMethod | .NET 10.0 | .NET 10.0 | 10    |     3.502 μs |  0.0186 μs |  0.0165 μs |
| OneChild               | .NET 10.0 | .NET 10.0 | 10    |     3.512 μs |  0.0165 μs |  0.0155 μs |
| Sealed                 | .NET 9.0  | .NET 9.0  | 10    |     3.494 μs |  0.0185 μs |  0.0173 μs |
| NonSealed              | .NET 9.0  | .NET 9.0  | 10    |     3.487 μs |  0.0135 μs |  0.0120 μs |
| NonSealedVirtualMethod | .NET 9.0  | .NET 9.0  | 10    |     3.496 μs |  0.0204 μs |  0.0191 μs |
| OneChild               | .NET 9.0  | .NET 9.0  | 10    |     3.509 μs |  0.0129 μs |  0.0108 μs |
| **Sealed**                 | **.NET 10.0** | **.NET 10.0** | **1000**  | **2,587.306 μs** |  **9.2731 μs** |  **8.2203 μs** |
| NonSealed              | .NET 10.0 | .NET 10.0 | 1000  | 2,589.957 μs | 10.1039 μs |  8.9569 μs |
| NonSealedVirtualMethod | .NET 10.0 | .NET 10.0 | 1000  | 2,591.000 μs | 11.7838 μs | 10.4461 μs |
| OneChild               | .NET 10.0 | .NET 10.0 | 1000  | 2,586.788 μs | 15.3510 μs | 13.6083 μs |
| Sealed                 | .NET 9.0  | .NET 9.0  | 1000  | 2,556.590 μs |  9.8940 μs |  8.7708 μs |
| NonSealed              | .NET 9.0  | .NET 9.0  | 1000  | 2,589.450 μs | 14.5192 μs | 13.5812 μs |
| NonSealedVirtualMethod | .NET 9.0  | .NET 9.0  | 1000  | 2,596.325 μs | 14.0213 μs | 12.4295 μs |
| OneChild               | .NET 9.0  | .NET 9.0  | 1000  | 2,575.642 μs |  3.4997 μs |  2.7323 μs |
