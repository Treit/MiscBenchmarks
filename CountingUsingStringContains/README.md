# Counting strings containing certain text.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Count | Mean         | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| CountUsingOrdinalIgnoreCase          | 10    |     46.21 ns |   0.247 ns |   0.206 ns |  0.39 |    0.00 |         - |          NA |
| CountUsingTwoChecks                  | 10    |    118.43 ns |   1.382 ns |   1.292 ns |  1.00 |    0.01 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase | 10    |    287.13 ns |   2.515 ns |   2.352 ns |  2.42 |    0.03 |         - |          NA |
| CountUsingCurrentCultureIgnoreCase   | 10    |    312.91 ns |   1.649 ns |   1.543 ns |  2.64 |    0.03 |         - |          NA |
| CountKuinox                          | 10    |    340.38 ns |   1.993 ns |   1.864 ns |  2.87 |    0.03 |         - |          NA |
| CountKuinoxSecondVersion             | 10    |    515.25 ns |   3.931 ns |   3.678 ns |  4.35 |    0.05 |         - |          NA |
|                                      |       |              |            |            |       |         |           |             |
| CountUsingOrdinalIgnoreCase          | 1000  |  4,690.91 ns |  32.948 ns |  30.820 ns |  0.39 |    0.00 |         - |          NA |
| CountUsingTwoChecks                  | 1000  | 12,181.73 ns |  59.675 ns |  55.820 ns |  1.00 |    0.01 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase | 1000  | 32,880.67 ns | 252.747 ns | 236.419 ns |  2.70 |    0.02 |         - |          NA |
| CountKuinox                          | 1000  | 35,661.85 ns | 259.510 ns | 242.745 ns |  2.93 |    0.02 |         - |          NA |
| CountUsingCurrentCultureIgnoreCase   | 1000  | 35,743.10 ns | 307.333 ns | 287.480 ns |  2.93 |    0.03 |         - |          NA |
| CountKuinoxSecondVersion             | 1000  | 50,864.97 ns | 152.956 ns | 143.075 ns |  4.18 |    0.02 |         - |          NA |
