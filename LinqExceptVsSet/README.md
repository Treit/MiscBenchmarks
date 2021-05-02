# Linq 'Except' vs HashSet for computing set difference.
Not exactly an apples-to-apples comparison since the HashSet version mutates the first set instead of creating a new one for the results.

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21370
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.202
  [Host]   : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  ShortRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                    Method |   Count |             Mean |            Error |           StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|-------------------------- |-------- |-----------------:|-----------------:|-----------------:|------:|--------:|---------:|---------:|---------:|-----------:|
|    SetDifferenceUsingLinq |      10 |       1,320.7 ns |       1,344.9 ns |         73.72 ns |  5.26 |    0.42 |   0.1774 |        - |        - |      768 B |
| SetDifferenceUsingHashSet |      10 |         251.7 ns |         209.3 ns |         11.47 ns |  1.00 |    0.00 |   0.0091 |        - |        - |       40 B |
|                           |         |                  |                  |                  |       |         |          |          |          |            |
|    SetDifferenceUsingLinq |     100 |      10,724.8 ns |       5,263.9 ns |        288.53 ns |  4.47 |    0.39 |   1.2360 |        - |        - |     5344 B |
| SetDifferenceUsingHashSet |     100 |       2,411.7 ns |       3,714.5 ns |        203.60 ns |  1.00 |    0.00 |   0.0076 |        - |        - |       40 B |
|                           |         |                  |                  |                  |       |         |          |          |          |            |
|    SetDifferenceUsingLinq |    1000 |     116,875.3 ns |      18,187.3 ns |        996.91 ns |  5.15 |    0.88 |   9.5215 |        - |        - |    41280 B |
| SetDifferenceUsingHashSet |    1000 |      23,163.3 ns |      75,672.3 ns |      4,147.85 ns |  1.00 |    0.00 |        - |        - |        - |       40 B |
|                           |         |                  |                  |                  |       |         |          |          |          |            |
|    SetDifferenceUsingLinq |  100000 |  18,765,656.2 ns |  27,273,605.6 ns |  1,494,958.35 ns |  6.00 |    0.56 | 406.2500 | 375.0000 | 375.0000 |  5243906 B |
| SetDifferenceUsingHashSet |  100000 |   3,131,171.8 ns |   2,762,805.2 ns |    151,438.68 ns |  1.00 |    0.00 |        - |        - |        - |       40 B |
|                           |         |                  |                  |                  |       |         |          |          |          |            |
|    SetDifferenceUsingLinq | 1000000 | 421,657,133.3 ns | 372,056,411.9 ns | 20,393,667.39 ns |  6.13 |    0.69 |        - |        - |        - | 41943680 B |
| SetDifferenceUsingHashSet | 1000000 |  69,200,800.0 ns |  98,575,578.4 ns |  5,403,260.08 ns |  1.00 |    0.00 |        - |        - |        - |      269 B |
