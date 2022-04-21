# Counting strings containing certain text.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22598
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.202
  [Host]     : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT


```
|                               Method |   Count |             Mean |            Error |           StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |-------- |-----------------:|-----------------:|-----------------:|------:|--------:|------:|------:|------:|----------:|
|                  CountUsingTwoChecks |      10 |         237.1 ns |          4.80 ns |          9.80 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|          CountUsingOrdinalIgnoreCase |      10 |         675.8 ns |         19.55 ns |         57.33 ns |  2.92 |    0.23 |     - |     - |     - |         - |
|   CountUsingCurrentCultureIgnoreCase |      10 |       9,359.1 ns |        182.97 ns |        352.52 ns | 39.54 |    2.03 |     - |     - |     - |         - |
| CountUsingInvariantCultureIgnoreCase |      10 |       9,910.9 ns |        320.12 ns |        933.81 ns | 43.20 |    4.14 |     - |     - |     - |         - |
|                                      |         |                  |                  |                  |       |         |       |       |       |           |
|                  CountUsingTwoChecks |    1000 |      23,638.8 ns |        393.17 ns |        551.17 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|          CountUsingOrdinalIgnoreCase |    1000 |      63,763.1 ns |      1,196.11 ns |      1,897.16 ns |  2.70 |    0.11 |     - |     - |     - |         - |
|   CountUsingCurrentCultureIgnoreCase |    1000 |     823,316.8 ns |     16,374.89 ns |     22,414.13 ns | 34.84 |    1.17 |     - |     - |     - |         - |
| CountUsingInvariantCultureIgnoreCase |    1000 |     830,446.7 ns |     16,477.25 ns |     34,756.11 ns | 35.37 |    2.02 |     - |     - |     - |         - |
|                                      |         |                  |                  |                  |       |         |       |       |       |           |
|                  CountUsingTwoChecks | 1000000 |  27,738,550.8 ns |    551,520.89 ns |  1,373,478.41 ns |  1.00 |    0.00 |     - |     - |     - |      15 B |
|          CountUsingOrdinalIgnoreCase | 1000000 |  75,148,827.2 ns |  1,502,831.83 ns |  2,785,595.16 ns |  2.75 |    0.17 |     - |     - |     - |      27 B |
| CountUsingInvariantCultureIgnoreCase | 1000000 | 911,853,817.1 ns | 17,630,471.37 ns | 46,753,508.99 ns | 33.05 |    2.56 |     - |     - |     - |     480 B |
|   CountUsingCurrentCultureIgnoreCase | 1000000 | 938,433,766.1 ns | 18,661,386.88 ns | 42,501,421.28 ns | 33.96 |    2.24 |     - |     - |     - |     480 B |
