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
| **BuiltInHashCodeCombine** | **10**    |    **54.412 ns** |  **0.1800 ns** |  **0.1683 ns** |
| CustomHashCodeCombine  | 10    |     6.018 ns |  0.0717 ns |  0.0671 ns |
| **BuiltInHashCodeCombine** | **1000**  | **7,754.992 ns** | **49.4154 ns** | **46.2232 ns** |
| CustomHashCodeCombine  | 1000  |   929.748 ns |  1.8207 ns |  1.7031 ns |
