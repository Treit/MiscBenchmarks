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
| **FilterUsingContainsKey**          | **100**   |         **970.3 ns** |        **13.09 ns** |        **12.24 ns** |     **1.00** |    **0.02** |     **0.0572** |         **-** |       **-** |       **960 B** |        **1.00** |
| FilterUsingSelectToListContains | 100   |      30,292.3 ns |       198.00 ns |       185.21 ns |    31.22 |    0.42 |     3.1128 |         - |       - |     52160 B |       54.33 |
| FilterUsingHashSet              | 100   |       1,829.9 ns |        13.34 ns |        11.83 ns |     1.89 |    0.03 |     0.1698 |         - |       - |      2856 B |        2.98 |
|                                 |       |                  |                 |                 |          |         |            |           |         |             |             |
| **FilterUsingContainsKey**          | **10000** |      **82,156.8 ns** |       **939.38 ns** |       **878.70 ns** |     **1.00** |    **0.01** |     **4.7607** |         **-** |       **-** |     **80160 B** |        **1.00** |
| FilterUsingSelectToListContains | 10000 | 193,484,586.7 ns | 2,647,813.16 ns | 2,476,766.08 ns | 2,355.32 |   37.98 | 23666.6667 | 2333.3333 |       - | 401200160 B |    5,004.99 |
| FilterUsingHashSet              | 10000 |     276,322.3 ns |     3,544.98 ns |     3,315.97 ns |     3.36 |    0.05 |    38.0859 |   38.0859 | 38.0859 |    242018 B |        3.02 |
