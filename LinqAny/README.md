# Calling Any() multiple times vs just once with a more complex predicate





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Count  | Mean           | Error         | StdDev        | Median         | Ratio     | RatioSD  | Allocated | Alloc Ratio |
|------------------------------ |---------- |---------- |------- |---------------:|--------------:|--------------:|---------------:|----------:|---------:|----------:|------------:|
| **SingleAnyWithMatch**            | **.NET 10.0** | **.NET 10.0** | **10**     |       **7.212 ns** |     **0.1097 ns** |     **0.1026 ns** |       **7.215 ns** |      **1.00** |     **0.02** |         **-** |          **NA** |
| SingleAnyWithNoMatch          | .NET 10.0 | .NET 10.0 | 10     |       7.244 ns |     0.1135 ns |     0.1062 ns |       7.251 ns |      1.00 |     0.02 |         - |          NA |
| MultipleCallsToAnyWithMatch   | .NET 10.0 | .NET 10.0 | 10     |      31.155 ns |     0.4570 ns |     0.4051 ns |      31.059 ns |      4.32 |     0.08 |         - |          NA |
| MultipleCallsToAnyWithNoMatch | .NET 10.0 | .NET 10.0 | 10     |      31.954 ns |     0.2696 ns |     0.2522 ns |      32.009 ns |      4.43 |     0.07 |         - |          NA |
|                               |           |           |        |                |               |               |                |           |          |           |             |
| SingleAnyWithMatch            | .NET 9.0  | .NET 9.0  | 10     |       7.177 ns |     0.0834 ns |     0.0780 ns |       7.198 ns |      1.00 |     0.01 |         - |          NA |
| SingleAnyWithNoMatch          | .NET 9.0  | .NET 9.0  | 10     |       7.247 ns |     0.0596 ns |     0.0558 ns |       7.261 ns |      1.01 |     0.01 |         - |          NA |
| MultipleCallsToAnyWithMatch   | .NET 9.0  | .NET 9.0  | 10     |      32.114 ns |     0.2686 ns |     0.2382 ns |      32.231 ns |      4.48 |     0.06 |         - |          NA |
| MultipleCallsToAnyWithNoMatch | .NET 9.0  | .NET 9.0  | 10     |      31.707 ns |     0.3388 ns |     0.3169 ns |      31.808 ns |      4.42 |     0.06 |         - |          NA |
|                               |           |           |        |                |               |               |                |           |          |           |             |
| **SingleAnyWithMatch**            | **.NET 10.0** | **.NET 10.0** | **100000** |       **8.329 ns** |     **0.1927 ns** |     **0.4466 ns** |       **8.088 ns** |      **1.00** |     **0.07** |         **-** |          **NA** |
| SingleAnyWithNoMatch          | .NET 10.0 | .NET 10.0 | 100000 |  63,989.576 ns | 1,725.2188 ns | 5,086.8470 ns |  66,645.624 ns |  7,703.43 |   722.36 |         - |          NA |
| MultipleCallsToAnyWithMatch   | .NET 10.0 | .NET 10.0 | 100000 |  68,896.829 ns |   990.0256 ns |   826.7162 ns |  69,104.944 ns |  8,294.20 |   427.47 |         - |          NA |
| MultipleCallsToAnyWithNoMatch | .NET 10.0 | .NET 10.0 | 100000 | 382,094.544 ns | 6,668.0621 ns | 6,237.3094 ns | 386,285.059 ns | 45,998.73 | 2,421.81 |         - |          NA |
|                               |           |           |        |                |               |               |                |           |          |           |             |
| SingleAnyWithMatch            | .NET 9.0  | .NET 9.0  | 100000 |       8.026 ns |     0.0478 ns |     0.0423 ns |       8.034 ns |      1.00 |     0.01 |         - |          NA |
| SingleAnyWithNoMatch          | .NET 9.0  | .NET 9.0  | 100000 |  64,043.372 ns | 1,750.1018 ns | 5,160.2150 ns |  67,636.588 ns |  7,979.87 |   641.27 |         - |          NA |
| MultipleCallsToAnyWithMatch   | .NET 9.0  | .NET 9.0  | 100000 |  54,016.355 ns |   817.0675 ns |   637.9125 ns |  53,968.372 ns |  6,730.49 |    83.72 |         - |          NA |
| MultipleCallsToAnyWithNoMatch | .NET 9.0  | .NET 9.0  | 100000 | 383,620.658 ns | 5,189.1691 ns | 4,853.9520 ns | 385,857.812 ns | 47,799.51 |   634.55 |         - |          NA |
