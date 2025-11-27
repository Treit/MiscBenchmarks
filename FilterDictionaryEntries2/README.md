# Filtering dictionary entries. The "create a HashSet from the dictionary keys" idea was from Ai :|





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Count | Mean             | Error           | StdDev          | Ratio    | RatioSD | Gen0       | Gen1      | Gen2    | Allocated   | Alloc Ratio |
|-------------------------------- |---------- |---------- |------ |-----------------:|----------------:|----------------:|---------:|--------:|-----------:|----------:|--------:|------------:|------------:|
| **FilterUsingContainsKey**          | **.NET 10.0** | **.NET 10.0** | **100**   |         **996.5 ns** |        **14.61 ns** |        **13.66 ns** |     **1.00** |    **0.02** |     **0.0572** |         **-** |       **-** |       **960 B** |        **1.00** |
| FilterUsingSelectToListContains | .NET 10.0 | .NET 10.0 | 100   |      37,351.0 ns |       738.77 ns |     1,192.97 ns |    37.49 |    1.28 |     3.1128 |         - |       - |     52160 B |       54.33 |
| FilterUsingHashSet              | .NET 10.0 | .NET 10.0 | 100   |       1,824.0 ns |        20.36 ns |        19.04 ns |     1.83 |    0.03 |     0.1698 |         - |       - |      2856 B |        2.98 |
|                                 |           |           |       |                  |                 |                 |          |         |            |           |         |             |             |
| FilterUsingContainsKey          | .NET 9.0  | .NET 9.0  | 100   |         980.1 ns |        14.30 ns |        13.37 ns |     1.00 |    0.02 |     0.0572 |         - |       - |       960 B |        1.00 |
| FilterUsingSelectToListContains | .NET 9.0  | .NET 9.0  | 100   |      36,897.7 ns |       730.00 ns |     1,136.52 ns |    37.65 |    1.25 |     3.1128 |         - |       - |     52160 B |       54.33 |
| FilterUsingHashSet              | .NET 9.0  | .NET 9.0  | 100   |       1,835.3 ns |        12.65 ns |        11.83 ns |     1.87 |    0.03 |     0.1698 |         - |       - |      2856 B |        2.98 |
|                                 |           |           |       |                  |                 |                 |          |         |            |           |         |             |             |
| **FilterUsingContainsKey**          | **.NET 10.0** | **.NET 10.0** | **10000** |      **82,469.2 ns** |     **1,020.47 ns** |       **954.55 ns** |     **1.00** |    **0.02** |     **4.7607** |         **-** |       **-** |     **80160 B** |        **1.00** |
| FilterUsingSelectToListContains | .NET 10.0 | .NET 10.0 | 10000 | 200,638,690.5 ns | 1,407,703.79 ns | 1,247,892.74 ns | 2,433.20 |   30.82 | 23666.6667 | 2333.3333 |       - | 401200160 B |    5,004.99 |
| FilterUsingHashSet              | .NET 10.0 | .NET 10.0 | 10000 |     248,915.9 ns |     3,903.11 ns |     3,650.97 ns |     3.02 |    0.05 |    38.0859 |   38.0859 | 38.0859 |    242018 B |        3.02 |
|                                 |           |           |       |                  |                 |                 |          |         |            |           |         |             |             |
| FilterUsingContainsKey          | .NET 9.0  | .NET 9.0  | 10000 |      82,806.3 ns |       582.02 ns |       544.42 ns |     1.00 |    0.01 |     4.7607 |         - |       - |     80160 B |        1.00 |
| FilterUsingSelectToListContains | .NET 9.0  | .NET 9.0  | 10000 | 193,579,462.2 ns | 2,373,247.84 ns | 2,219,937.50 ns | 2,337.83 |   29.91 | 23666.6667 | 2333.3333 |       - | 401200160 B |    5,004.99 |
| FilterUsingHashSet              | .NET 9.0  | .NET 9.0  | 10000 |     248,177.0 ns |     3,448.16 ns |     3,225.41 ns |     3.00 |    0.04 |    38.0859 |   38.0859 | 38.0859 |    242018 B |        3.02 |
