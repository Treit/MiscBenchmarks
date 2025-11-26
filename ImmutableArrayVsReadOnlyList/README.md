# Returning a collection of things that should not be mutated as an IReadOnlyList<T> vs. an ImmutableArray<T>.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Iterations | Mean              | Error           | StdDev          | Ratio  | RatioSD | Gen0       | Allocated   | Alloc Ratio |
|-------------------- |----------- |------------------:|----------------:|----------------:|-------:|--------:|-----------:|------------:|------------:|
| **GetAsImmutableArray** | **10**         |      **1,672.572 ns** |      **10.6326 ns** |       **9.4255 ns** | **358.40** |    **2.80** |     **2.4052** |     **40240 B** |          **NA** |
| GetAsReadOnlyList   | 10         |          4.667 ns |       0.0286 ns |       0.0268 ns |   1.00 |    0.01 |          - |           - |          NA |
|                     |            |                   |                 |                 |        |         |            |             |             |
| **GetAsImmutableArray** | **100000**     | **16,699,146.759 ns** | **328,826.0357 ns** | **460,968.2159 ns** | **408.38** |   **12.28** | **24031.2500** | **402400000 B** |          **NA** |
| GetAsReadOnlyList   | 100000     |     40,897.797 ns |     591.3614 ns |     553.1598 ns |   1.00 |    0.02 |          - |           - |          NA |
