# Calling static methods on static and non-static classes.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25319.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                           Method |  Count |         Mean |      Error |      StdDev |       Median |     Gen0 | Allocated |
|--------------------------------- |------- |-------------:|-----------:|------------:|-------------:|---------:|----------:|
|    **CallStaticMethodOnStaticClass** |    **100** |     **1.837 μs** |  **0.1437 μs** |   **0.4237 μs** |     **1.692 μs** |   **0.3948** |   **1.66 KB** |
| CallStaticMethodOnNonStaticClass |    100 |     1.808 μs |  0.1251 μs |   0.3688 μs |     1.777 μs |   0.3929 |   1.66 KB |
|    **CallStaticMethodOnStaticClass** | **100000** | **1,586.865 μs** | **80.3471 μs** | **234.3763 μs** | **1,556.438 μs** | **369.1406** | **1562.6 KB** |
| CallStaticMethodOnNonStaticClass | 100000 | 1,596.980 μs | 76.9582 μs | 225.7050 μs | 1,603.443 μs | 369.1406 | 1562.6 KB |
