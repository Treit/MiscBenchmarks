# Finding an item



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Iterations | Mean           | Error        | StdDev       | Allocated |
|----------------------- |----------- |---------------:|-------------:|-------------:|----------:|
| **LookupUsingHashSet**     | **1000**       |     **2,361.1 ns** |     **21.00 ns** |     **19.64 ns** |         **-** |
| LookupUsingList        | 1000       |     2,503.4 ns |     15.24 ns |     14.25 ns |         - |
| LookupUsingConditional | 1000       |       785.5 ns |      3.42 ns |      3.20 ns |         - |
| LookupUsingSwitch      | 1000       |       476.8 ns |      4.70 ns |      4.40 ns |         - |
| LookupUsingRange       | 1000       |       323.4 ns |      4.59 ns |      4.07 ns |         - |
| **LookupUsingHashSet**     | **100000**     |   **232,431.9 ns** |    **753.41 ns** |    **588.21 ns** |         **-** |
| LookupUsingList        | 100000     |   249,997.6 ns |  2,498.58 ns |  2,337.18 ns |         - |
| LookupUsingConditional | 100000     |    78,021.8 ns |    457.10 ns |    427.57 ns |         - |
| LookupUsingSwitch      | 100000     |    46,943.5 ns |    189.17 ns |    167.70 ns |         - |
| LookupUsingRange       | 100000     |    31,341.4 ns |    322.45 ns |    301.62 ns |         - |
| **LookupUsingHashSet**     | **1000000**    | **2,374,108.6 ns** | **14,473.86 ns** | **13,538.86 ns** |         **-** |
| LookupUsingList        | 1000000    | 2,493,411.2 ns | 12,950.92 ns | 12,114.30 ns |         - |
| LookupUsingConditional | 1000000    |   779,071.9 ns |  2,764.95 ns |  2,451.06 ns |         - |
| LookupUsingSwitch      | 1000000    |   469,280.3 ns |  1,734.69 ns |  1,622.63 ns |         - |
| LookupUsingRange       | 1000000    |   313,226.9 ns |    941.78 ns |    735.28 ns |         - |
