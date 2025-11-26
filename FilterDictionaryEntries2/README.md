# Filtering dictionary entries. The "create a HashSet from the dictionary keys" idea was from Ai :|




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Count | Mean             | Error           | StdDev          | Ratio    | RatioSD | Gen0       | Gen1      | Gen2    | Allocated   | Alloc Ratio |
|-------------------------------- |------ |-----------------:|----------------:|----------------:|---------:|--------:|-----------:|----------:|--------:|------------:|------------:|
| **FilterUsingContainsKey**          | **100**   |         **969.3 ns** |        **11.51 ns** |        **10.77 ns** |     **1.00** |    **0.02** |     **0.0572** |         **-** |       **-** |       **960 B** |        **1.00** |
| FilterUsingSelectToListContains | 100   |      30,094.6 ns |       275.60 ns |       257.80 ns |    31.05 |    0.42 |     3.1128 |         - |       - |     52160 B |       54.33 |
| FilterUsingHashSet              | 100   |       1,849.9 ns |        13.86 ns |        12.97 ns |     1.91 |    0.02 |     0.1698 |         - |       - |      2856 B |        2.98 |
|                                 |       |                  |                 |                 |          |         |            |           |         |             |             |
| **FilterUsingContainsKey**          | **10000** |      **82,364.1 ns** |       **897.75 ns** |       **839.75 ns** |     **1.00** |    **0.01** |     **4.7607** |         **-** |       **-** |     **80160 B** |        **1.00** |
| FilterUsingSelectToListContains | 10000 | 195,761,616.7 ns | 3,238,617.17 ns | 3,729,596.36 ns | 2,377.01 |   50.05 | 23666.6667 | 2333.3333 |       - | 401200160 B |    5,004.99 |
| FilterUsingHashSet              | 10000 |     274,388.7 ns |     5,479.70 ns |     9,304.95 ns |     3.33 |    0.12 |    38.0859 |   38.0859 | 38.0859 |    242018 B |        3.02 |
