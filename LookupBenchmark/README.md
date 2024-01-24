# Finding an item


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                 Method | Iterations |           Mean |        Error |       StdDev | Allocated |
|----------------------- |----------- |---------------:|-------------:|-------------:|----------:|
|     **LookupUsingHashSet** |       **1000** |     **4,520.1 ns** |      **6.46 ns** |      **5.04 ns** |         **-** |
|        LookupUsingList |       1000 |     4,342.1 ns |      3.74 ns |      3.13 ns |         - |
| LookupUsingConditional |       1000 |       779.2 ns |      0.98 ns |      0.82 ns |         - |
|      LookupUsingSwitch |       1000 |       469.7 ns |      0.27 ns |      0.25 ns |         - |
|       LookupUsingRange |       1000 |       624.7 ns |      0.32 ns |      0.27 ns |         - |
|     **LookupUsingHashSet** |     **100000** |   **453,870.0 ns** |  **4,233.29 ns** |  **3,959.82 ns** |         **-** |
|        LookupUsingList |     100000 |   433,523.3 ns |    601.65 ns |    502.40 ns |         - |
| LookupUsingConditional |     100000 |    77,427.2 ns |     82.87 ns |     69.20 ns |         - |
|      LookupUsingSwitch |     100000 |    61,973.5 ns |     80.79 ns |     71.62 ns |         - |
|       LookupUsingRange |     100000 |    61,915.4 ns |     34.41 ns |     26.86 ns |         - |
|     **LookupUsingHashSet** |    **1000000** | **4,558,966.1 ns** | **54,089.15 ns** | **50,595.03 ns** |         **-** |
|        LookupUsingList |    1000000 | 4,334,477.3 ns |  2,074.45 ns |  1,619.59 ns |         - |
| LookupUsingConditional |    1000000 |   775,619.2 ns |  3,283.46 ns |  2,910.70 ns |         - |
|      LookupUsingSwitch |    1000000 |   620,285.1 ns |  1,511.92 ns |  1,262.52 ns |         - |
|       LookupUsingRange |    1000000 |   618,944.3 ns |    254.32 ns |    198.55 ns |         - |
