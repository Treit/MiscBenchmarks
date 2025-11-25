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
| **Sealed**                 | **10**    |     **3.541 μs** |  **0.0391 μs** |  **0.0365 μs** |
| NonSealed              | 10    |     3.488 μs |  0.0267 μs |  0.0237 μs |
| NonSealedVirtualMethod | 10    |     3.459 μs |  0.0268 μs |  0.0224 μs |
| OneChild               | 10    |     3.523 μs |  0.0273 μs |  0.0242 μs |
| **Sealed**                 | **1000**  | **2,597.363 μs** | **18.7112 μs** | **17.5025 μs** |
| NonSealed              | 1000  | 2,591.695 μs | 17.9038 μs | 15.8713 μs |
| NonSealedVirtualMethod | 1000  | 2,577.160 μs | 10.3804 μs |  8.6681 μs |
| OneChild               | 1000  | 2,617.956 μs | 41.8920 μs | 39.1858 μs |
