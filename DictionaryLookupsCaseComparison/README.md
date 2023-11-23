# Dictionary lookups using different case comparison options.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26002.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|                                         Method | Iterations |            Mean |         Error |        StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |----------- |----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
|                    **DictonaryLookupUsingOrdinal** |         **10** |        **22.91 μs** |      **0.404 μs** |      **0.358 μs** |  **1.00** |    **0.00** |         **-** |          **NA** |
|          DictonaryLookupUsingOrdinalIgnoreCase |         10 |        25.44 μs |      0.500 μs |      0.536 μs |  1.10 |    0.03 |         - |          NA |
|           DictonaryLookupUsingInvariantCulture |         10 |       356.44 μs |      6.939 μs |      6.151 μs | 15.56 |    0.21 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase |         10 |       347.69 μs |      6.402 μs |      5.676 μs | 15.18 |    0.32 |         - |          NA |
|                                                |            |                 |               |               |       |         |           |             |
|                    **DictonaryLookupUsingOrdinal** |     **100000** |   **227,803.19 μs** |  **2,614.821 μs** |  **2,317.971 μs** |  **1.00** |    **0.00** |     **168 B** |        **1.00** |
|          DictonaryLookupUsingOrdinalIgnoreCase |     100000 |   247,688.04 μs |  2,335.940 μs |  1,823.748 μs |  1.09 |    0.01 |     252 B |        1.50 |
|           DictonaryLookupUsingInvariantCulture |     100000 | 3,602,149.51 μs | 68,069.636 μs | 81,032.060 μs | 15.81 |    0.34 |     504 B |        3.00 |
| DictonaryLookupUsingInvariantCultureIgnoreCase |     100000 | 3,422,537.58 μs | 68,427.698 μs | 93,664.605 μs | 14.86 |    0.40 |     504 B |        3.00 |
