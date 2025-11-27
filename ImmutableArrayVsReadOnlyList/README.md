# Returning a collection of things that should not be mutated as an IReadOnlyList<T> vs. an ImmutableArray<T>.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | Iterations | Mean              | Error           | StdDev          | Ratio  | RatioSD | Gen0       | Allocated   | Alloc Ratio |
|-------------------- |---------- |---------- |----------- |------------------:|----------------:|----------------:|-------:|--------:|-----------:|------------:|------------:|
| **GetAsImmutableArray** | **.NET 10.0** | **.NET 10.0** | **10**         |      **1,700.982 ns** |      **30.0455 ns** |      **40.1098 ns** | **367.53** |    **8.81** |     **2.4052** |     **40240 B** |          **NA** |
| GetAsReadOnlyList   | .NET 10.0 | .NET 10.0 | 10         |          4.628 ns |       0.0317 ns |       0.0297 ns |   1.00 |    0.01 |          - |           - |          NA |
|                     |           |           |            |                   |                 |                 |        |         |            |             |             |
| GetAsImmutableArray | .NET 9.0  | .NET 9.0  | 10         |      1,677.360 ns |      32.8971 ns |      48.2201 ns | 359.03 |   10.33 |     2.4052 |     40240 B |          NA |
| GetAsReadOnlyList   | .NET 9.0  | .NET 9.0  | 10         |          4.672 ns |       0.0275 ns |       0.0257 ns |   1.00 |    0.01 |          - |           - |          NA |
|                     |           |           |            |                   |                 |                 |        |         |            |             |             |
| **GetAsImmutableArray** | **.NET 10.0** | **.NET 10.0** | **100000**     | **15,690,699.929 ns** | **291,600.5226 ns** | **547,696.5070 ns** | **385.62** |   **13.79** | **24046.8750** | **402400000 B** |          **NA** |
| GetAsReadOnlyList   | .NET 10.0 | .NET 10.0 | 100000     |     40,693.441 ns |     415.9908 ns |     389.1181 ns |   1.00 |    0.01 |          - |           - |          NA |
|                     |           |           |            |                   |                 |                 |        |         |            |             |             |
| GetAsImmutableArray | .NET 9.0  | .NET 9.0  | 100000     | 16,860,600.729 ns | 326,762.5622 ns | 489,082.8575 ns | 412.89 |   12.30 | 24031.2500 | 402400001 B |          NA |
| GetAsReadOnlyList   | .NET 9.0  | .NET 9.0  | 100000     |     40,838.153 ns |     404.7503 ns |     358.8006 ns |   1.00 |    0.01 |          - |           - |          NA |
