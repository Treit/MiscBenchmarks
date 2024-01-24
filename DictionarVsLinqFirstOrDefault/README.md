# Finding matches using Dictionary vs Linear Search using LINQ.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                Method | Count |              Mean |            Error |           StdDev |    Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|-------------------------------------- |------ |------------------:|-----------------:|-----------------:|---------:|--------:|-------:|----------:|------------:|
|            **FindMatchesUsingDictionary** |    **10** |          **53.06 ns** |         **0.103 ns** |         **0.080 ns** |     **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
|         FindMatchesUsingFirstOrDeault |    10 |         431.31 ns |         7.452 ns |         6.971 ns |     8.13 |    0.15 | 0.0763 |    1280 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda |    10 |         389.14 ns |         4.829 ns |         4.281 ns |     7.33 |    0.08 | 0.0620 |    1040 B |          NA |
|                                       |       |                   |                  |                  |          |         |        |           |             |
|            **FindMatchesUsingDictionary** |   **100** |         **583.44 ns** |         **1.007 ns** |         **0.786 ns** |     **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
|         FindMatchesUsingFirstOrDeault |   100 |      18,582.46 ns |       365.491 ns |       341.881 ns |    31.72 |    0.57 | 0.7629 |   12800 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda |   100 |      18,724.08 ns |       207.229 ns |       193.842 ns |    32.10 |    0.32 | 0.6104 |   10400 B |          NA |
|                                       |       |                   |                  |                  |          |         |        |           |             |
|            **FindMatchesUsingDictionary** | **10000** |      **53,904.20 ns** |       **439.253 ns** |       **410.877 ns** |     **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
|         FindMatchesUsingFirstOrDeault | 10000 | 154,123,071.74 ns | 3,024,789.074 ns | 3,825,389.681 ns | 2,884.48 |   84.79 |      - | 1280016 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | 10000 | 158,874,769.64 ns | 1,677,588.566 ns | 1,487,138.568 ns | 2,948.50 |   34.73 |      - | 1040100 B |          NA |
