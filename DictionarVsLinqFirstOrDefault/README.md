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
| **FindMatchesUsingDictionary**            | **10**    |         **28.90 ns** |       **0.195 ns** |       **0.183 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | 10    |        146.49 ns |       2.025 ns |       1.894 ns |   5.07 |    0.07 |  0.0525 |     880 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | 10    |        103.95 ns |       0.900 ns |       0.842 ns |   3.60 |    0.04 |  0.0381 |     640 B |          NA |
|                                       |       |                  |                |                |        |         |         |           |             |
| **FindMatchesUsingDictionary**            | **100**   |        **294.84 ns** |       **1.702 ns** |       **1.421 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | 100   |      3,562.38 ns |      21.217 ns |      19.846 ns |  12.08 |    0.09 |  0.5226 |    8800 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | 100   |      2,738.51 ns |      25.981 ns |      24.303 ns |   9.29 |    0.09 |  0.3815 |    6400 B |          NA |
|                                       |       |                  |                |                |        |         |         |           |             |
| **FindMatchesUsingDictionary**            | **10000** |     **33,682.58 ns** |     **263.895 ns** |     **233.936 ns** |   **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| FindMatchesUsingFirstOrDeault         | 10000 | 25,128,121.88 ns | 207,295.840 ns | 183,762.362 ns | 746.06 |    7.29 | 31.2500 |  880000 B |          NA |
| FindMatchesUsingFirstOrDeaultNoLambda | 10000 | 21,034,011.25 ns | 158,361.623 ns | 148,131.561 ns | 624.51 |    5.99 | 31.2500 |  640000 B |          NA |
