# Calling methods on sealed vs non-sealed classes.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count | Mean         | Error      | StdDev     |
|----------------------- |------ |-------------:|-----------:|-----------:|
| **Sealed**                 | **10**    |     **3.577 μs** |  **0.0163 μs** |  **0.0153 μs** |
| NonSealed              | 10    |     3.588 μs |  0.0280 μs |  0.0261 μs |
| NonSealedVirtualMethod | 10    |     3.538 μs |  0.0362 μs |  0.0339 μs |
| OneChild               | 10    |     3.594 μs |  0.0142 μs |  0.0119 μs |
| **Sealed**                 | **1000**  | **2,596.663 μs** | **13.8214 μs** | **11.5415 μs** |
| NonSealed              | 1000  | 2,628.276 μs | 12.7877 μs | 11.3359 μs |
| NonSealedVirtualMethod | 1000  | 2,627.663 μs | 28.0711 μs | 26.2577 μs |
| OneChild               | 1000  | 2,586.350 μs | 21.7567 μs | 20.3512 μs |
