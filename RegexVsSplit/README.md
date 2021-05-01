# Regex parsing vs string.Split

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21370
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=5.0.202
  [Host]   : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  ShortRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                      Method |   Count |                Mean |               Error |           StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |   Allocated |
|---------------------------- |-------- |--------------------:|--------------------:|-----------------:|------:|--------:|-----------:|----------:|------:|------------:|
|         FindTokenUsingSplit |      10 |          2,140.8 ns |           542.90 ns |         29.76 ns |  1.00 |    0.00 |     0.4997 |         - |     - |      4200 B |
|         FindTokenUsingRegex |      10 |         56,463.6 ns |         3,335.08 ns |        182.81 ns | 26.38 |    0.36 |     0.3052 |         - |     - |      2792 B |
| FindTokenUsingCompiledRegex |      10 |         14,178.4 ns |           672.71 ns |         36.87 ns |  6.62 |    0.10 |     0.3204 |         - |     - |      2792 B |
|          FindTokenUsingSpan |      10 |            267.9 ns |            71.94 ns |          3.94 ns |  0.13 |    0.00 |          - |         - |     - |           - |
|                             |         |                     |                     |                  |       |         |            |           |       |             |
|         FindTokenUsingSplit |     100 |         24,933.0 ns |        55,186.06 ns |      3,024.93 ns |  1.00 |    0.00 |     5.4932 |         - |     - |     45960 B |
|         FindTokenUsingRegex |     100 |        595,514.4 ns |        20,810.12 ns |      1,140.67 ns | 24.10 |    2.69 |     2.9297 |         - |     - |     27993 B |
| FindTokenUsingCompiledRegex |     100 |        147,878.4 ns |         6,899.26 ns |        378.17 ns |  5.99 |    0.68 |     3.1738 |         - |     - |     27993 B |
|          FindTokenUsingSpan |     100 |          2,995.8 ns |           906.71 ns |         49.70 ns |  0.12 |    0.01 |          - |         - |     - |           - |
|                             |         |                     |                     |                  |       |         |            |           |       |             |
|         FindTokenUsingSplit |    1000 |        246,817.3 ns |       132,280.18 ns |      7,250.72 ns |  1.00 |    0.00 |    55.4199 |         - |     - |    463560 B |
|         FindTokenUsingRegex |    1000 |      7,389,017.7 ns |     1,712,812.59 ns |     93,885.04 ns | 29.96 |    1.15 |    31.2500 |         - |     - |    280002 B |
| FindTokenUsingCompiledRegex |    1000 |      1,865,642.7 ns |        75,139.90 ns |      4,118.67 ns |  7.56 |    0.24 |    33.2031 |         - |     - |    280000 B |
|          FindTokenUsingSpan |    1000 |         37,520.2 ns |        11,596.27 ns |        635.63 ns |  0.15 |    0.00 |          - |         - |     - |           - |
|                             |         |                     |                     |                  |       |         |            |           |       |             |
|         FindTokenUsingSplit |  100000 |     23,361,687.5 ns |     4,704,550.57 ns |    257,872.29 ns |  1.00 |    0.00 |  5531.2500 |         - |     - |  46400000 B |
|         FindTokenUsingRegex |  100000 |  1,198,710,366.7 ns | 1,153,391,968.21 ns | 63,221,305.72 ns | 51.32 |    3.01 |  3000.0000 |         - |     - |  28006992 B |
| FindTokenUsingCompiledRegex |  100000 |    287,225,200.0 ns |    19,602,254.56 ns |  1,074,465.72 ns | 12.30 |    0.13 |  3000.0000 |         - |     - |  28001072 B |
|          FindTokenUsingSpan |  100000 |      5,008,397.7 ns |     1,457,117.16 ns |     79,869.51 ns |  0.21 |    0.00 |          - |         - |     - |           - |
|                             |         |                     |                     |                  |       |         |            |           |       |             |
|         FindTokenUsingSplit | 1000000 |    265,410,216.7 ns |    79,162,101.87 ns |  4,339,141.92 ns |  1.00 |    0.00 | 64500.0000 |         - |     - | 543200000 B |
|         FindTokenUsingRegex | 1000000 | 13,881,539,100.0 ns | 1,080,914,880.01 ns | 59,248,591.96 ns | 52.31 |    0.74 | 34000.0000 | 1000.0000 |     - | 287207352 B |
| FindTokenUsingCompiledRegex | 1000000 |  3,311,206,100.0 ns |   198,025,830.37 ns | 10,854,463.97 ns | 12.48 |    0.16 | 34000.0000 |         - |     - | 287207352 B |
|          FindTokenUsingSpan | 1000000 |     70,325,087.5 ns |    37,090,106.11 ns |  2,033,033.87 ns |  0.26 |    0.01 |          - |         - |     - |       158 B |