# Finding matches using Dictionary vs Linear Search using LINQ.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Count | Mean             | Error          | StdDev         | Ratio  | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------------- |------ |-----------------:|---------------:|---------------:|-------:|--------:|--------:|----------:|------------:|
| **FindMatchesUsingDictionary**            | **10**    |         **28.92 ns** |       **0.256 ns** |       **0.239 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | 10    |        150.07 ns |       2.384 ns |       2.230 ns |   5.19 |    0.09 |  0.0525 |     880 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | 10    |        103.81 ns |       1.151 ns |       1.076 ns |   3.59 |    0.05 |  0.0381 |     640 B |          NA |
|                                       |       |                  |                |                |        |         |         |           |             |
| **FindMatchesUsingDictionary**            | **100**   |        **294.55 ns** |       **1.944 ns** |       **1.818 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | 100   |      3,534.57 ns |      24.017 ns |      20.056 ns |  12.00 |    0.10 |  0.5226 |    8800 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | 100   |      2,717.21 ns |      24.931 ns |      23.320 ns |   9.23 |    0.09 |  0.3815 |    6400 B |          NA |
|                                       |       |                  |                |                |        |         |         |           |             |
| **FindMatchesUsingDictionary**            | **10000** |     **32,121.29 ns** |     **275.129 ns** |     **257.355 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | 10000 | 25,391,346.88 ns | 129,229.514 ns | 114,558.598 ns | 790.53 |    7.04 | 31.2500 |  880000 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | 10000 | 20,718,823.32 ns | 110,860.555 ns |  92,573.584 ns | 645.06 |    5.73 | 31.2500 |  640000 B |          NA |
