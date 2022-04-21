# Counting strings containing certain text.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22598
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.202
  [Host]     : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT


```
|                               Method | Count |         Mean |        Error |       StdDev |       Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |------ |-------------:|-------------:|-------------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|                  CountUsingTwoChecks |    10 |     217.2 ns |      5.25 ns |     15.14 ns |     213.5 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|          CountUsingOrdinalIgnoreCase |    10 |     579.8 ns |     11.52 ns |     17.93 ns |     580.6 ns |  2.60 |    0.19 |     - |     - |     - |         - |
|                          CountKuinox |    10 |     831.3 ns |     22.25 ns |     63.83 ns |     819.4 ns |  3.84 |    0.37 |     - |     - |     - |         - |
|             CountKuinoxSecondVersion |    10 |   1,010.4 ns |     20.14 ns |     58.12 ns |   1,008.0 ns |  4.67 |    0.41 |     - |     - |     - |         - |
| CountUsingInvariantCultureIgnoreCase |    10 |   9,366.2 ns |    185.66 ns |    465.78 ns |   9,301.8 ns | 42.87 |    3.54 |     - |     - |     - |         - |
|   CountUsingCurrentCultureIgnoreCase |    10 |   9,888.9 ns |    284.21 ns |    824.54 ns |   9,615.5 ns | 45.73 |    4.58 |     - |     - |     - |         - |
|                                      |       |              |              |              |              |       |         |       |       |       |           |
|                  CountUsingTwoChecks |  1000 |  25,326.4 ns |    504.82 ns |  1,228.81 ns |  25,180.8 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|          CountUsingOrdinalIgnoreCase |  1000 |  67,576.7 ns |  1,827.48 ns |  5,359.69 ns |  66,016.5 ns |  2.66 |    0.23 |     - |     - |     - |         - |
|                          CountKuinox |  1000 |  84,624.5 ns |  2,438.28 ns |  7,112.58 ns |  82,890.0 ns |  3.33 |    0.28 |     - |     - |     - |         - |
|             CountKuinoxSecondVersion |  1000 | 102,448.4 ns |  2,031.74 ns |  2,978.10 ns | 102,533.3 ns |  4.08 |    0.25 |     - |     - |     - |         - |
|   CountUsingCurrentCultureIgnoreCase |  1000 | 915,027.5 ns | 23,496.53 ns | 67,792.87 ns | 906,063.2 ns | 36.11 |    3.10 |     - |     - |     - |         - |
| CountUsingInvariantCultureIgnoreCase |  1000 | 918,598.4 ns | 27,307.83 ns | 77,910.77 ns | 904,839.4 ns | 36.50 |    3.51 |     - |     - |     - |         - |
