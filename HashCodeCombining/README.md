# Combining hashcodes



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count | Mean         | Error      | StdDev     |
|----------------------- |------ |-------------:|-----------:|-----------:|
| **BuiltInHashCodeCombine** | **10**    |    **54.335 ns** |  **0.1522 ns** |  **0.1349 ns** |
| CustomHashCodeCombine  | 10    |     5.988 ns |  0.0533 ns |  0.0498 ns |
| **BuiltInHashCodeCombine** | **1000**  | **7,755.047 ns** | **45.8580 ns** | **42.8956 ns** |
| CustomHashCodeCombine  | 1000  |   929.518 ns |  0.9717 ns |  0.9089 ns |
