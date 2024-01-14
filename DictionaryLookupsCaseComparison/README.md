# Dictionary lookups using different case comparison options.



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                         Method | Iterations |            Mean |         Error |        StdDev |          Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |----------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|----------:|------------:|
|                    **DictonaryLookupUsingOrdinal** |         **10** |        **23.39 μs** |      **0.015 μs** |      **0.012 μs** |        **23.39 μs** |  **1.00** |    **0.00** |         **-** |          **NA** |
|          DictonaryLookupUsingOrdinalIgnoreCase |         10 |        27.64 μs |      0.020 μs |      0.018 μs |        27.64 μs |  1.18 |    0.00 |         - |          NA |
|           DictonaryLookupUsingInvariantCulture |         10 |       490.02 μs |      8.721 μs |      8.158 μs |       491.58 μs | 20.95 |    0.37 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase |         10 |       476.17 μs |      8.683 μs |      8.122 μs |       478.52 μs | 20.36 |    0.34 |         - |          NA |
|                                                |            |                 |               |               |                 |       |         |           |             |
|                    **DictonaryLookupUsingOrdinal** |     **100000** |   **231,241.29 μs** |    **476.048 μs** |    **422.004 μs** |   **231,304.00 μs** |  **1.00** |    **0.00** |         **-** |          **NA** |
|          DictonaryLookupUsingOrdinalIgnoreCase |     100000 |   271,880.61 μs |  5,240.565 μs |  4,902.028 μs |   275,878.15 μs |  1.17 |    0.02 |         - |          NA |
|           DictonaryLookupUsingInvariantCulture |     100000 | 4,719,349.08 μs | 37,347.952 μs | 31,187.231 μs | 4,718,710.00 μs | 20.41 |    0.15 |         - |          NA |
| DictonaryLookupUsingInvariantCultureIgnoreCase |     100000 | 4,356,685.95 μs | 30,296.049 μs | 28,338.943 μs | 4,356,661.40 μs | 18.84 |    0.14 |         - |          NA |
