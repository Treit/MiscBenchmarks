# Regex parsing vs string.Split

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21370
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=5.0.202
  [Host]   : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  ShortRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                      Method |   Count |              Mean |             Error |         StdDev |  Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |    Allocated |
|---------------------------- |-------- |------------------:|------------------:|---------------:|-------:|--------:|-----------:|----------:|------:|-------------:|
|         FindTokenUsingSplit |      10 |          3.647 us |         0.2531 us |      0.0139 us |   1.00 |    0.00 |     0.5341 |         - |     - |      4.38 KB |
|         FindTokenUsingRegex |      10 |         59.812 us |         4.9330 us |      0.2704 us |  16.40 |    0.07 |     0.8545 |         - |     - |      7.34 KB |
| FindTokenUsingCompiledRegex |      10 |      3,638.054 us |       113.4121 us |      6.2165 us | 997.54 |    4.96 |          - |         - |     - |      23.6 KB |
|                             |         |                   |                   |                |        |         |            |           |       |              |
|         FindTokenUsingSplit |     100 |         23.089 us |        21.4267 us |      1.1745 us |   1.00 |    0.00 |     5.5237 |         - |     - |     45.18 KB |
|         FindTokenUsingRegex |     100 |        575.585 us |        22.2949 us |      1.2221 us |  24.97 |    1.30 |     3.9063 |         - |     - |     31.97 KB |
| FindTokenUsingCompiledRegex |     100 |      3,795.274 us |        65.2887 us |      3.5787 us | 164.66 |    8.51 |     3.9063 |         - |     - |      48.3 KB |
|                             |         |                   |                   |                |        |         |            |           |       |              |
|         FindTokenUsingSplit |    1000 |        212.412 us |        56.6023 us |      3.1026 us |   1.00 |    0.00 |    55.4199 |         - |     - |       453 KB |
|         FindTokenUsingRegex |    1000 |      7,212.646 us |     1,969.8768 us |    107.9756 us |  33.96 |    0.58 |    31.2500 |         - |     - |    278.08 KB |
| FindTokenUsingCompiledRegex |    1000 |      5,577.158 us |       388.9371 us |     21.3190 us |  26.26 |    0.43 |    31.2500 |   15.6250 |     - |    294.38 KB |
|                             |         |                   |                   |                |        |         |            |           |       |              |
|         FindTokenUsingSplit |  100000 |     24,906.697 us |     2,399.3381 us |    131.5158 us |   1.00 |    0.00 |  5531.2500 |         - |     - |   45312.8 KB |
|         FindTokenUsingRegex |  100000 |  1,546,085.000 us | 1,048,292.7714 us | 57,460.4641 us |  62.07 |    2.03 |  3000.0000 |         - |     - |  27352.92 KB |
| FindTokenUsingCompiledRegex |  100000 |    294,409.033 us |    70,214.1380 us |  3,848.6738 us |  11.82 |    0.21 |  3000.0000 |         - |     - |  27365.65 KB |
|                             |         |                   |                   |                |        |         |            |           |       |              |
|         FindTokenUsingSplit | 1000000 |    281,597.417 us |    35,884.1878 us |  1,966.9334 us |   1.00 |    0.00 | 64500.0000 |         - |     - | 530469.06 KB |
|         FindTokenUsingRegex | 1000000 | 13,354,609.800 us | 1,455,336.9306 us | 79,771.9280 us |  47.43 |    0.59 | 34000.0000 | 1000.0000 |     - | 280480.38 KB |
| FindTokenUsingCompiledRegex | 1000000 |  3,317,923.433 us |   157,475.2441 us |  8,631.7495 us |  11.78 |    0.11 | 34000.0000 |         - |     - | 280496.63 KB |