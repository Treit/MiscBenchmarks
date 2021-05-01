# Regex parsing vs string.Split

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21370
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=5.0.202
  [Host]   : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  ShortRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                      Method |   Count |                Mean |               Error |           StdDev |    Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |   Allocated |
|---------------------------- |-------- |--------------------:|--------------------:|-----------------:|---------:|--------:|-----------:|----------:|------:|------------:|
|         FindTokenUsingSplit |      10 |          2,136.5 ns |           556.24 ns |         30.49 ns |     1.00 |    0.00 |     0.4997 |         - |     - |      4200 B |
|         FindTokenUsingRegex |      10 |         60,622.0 ns |        13,658.34 ns |        748.66 ns |    28.38 |    0.59 |     0.8545 |         - |     - |      7232 B |
| FindTokenUsingCompiledRegex |      10 |      3,645,540.8 ns |       207,712.90 ns |     11,385.45 ns | 1,706.54 |   22.38 |          - |         - |     - |     23889 B |
|          FindTokenUsingSpan |      10 |            253.9 ns |            83.03 ns |          4.55 ns |     0.12 |    0.00 |          - |         - |     - |           - |
|                             |         |                     |                     |                  |          |         |            |           |       |             |
|         FindTokenUsingSplit |     100 |         21,089.0 ns |         4,055.07 ns |        222.27 ns |     1.00 |    0.00 |     5.4932 |         - |     - |     45960 B |
|         FindTokenUsingRegex |     100 |        608,894.0 ns |        46,578.96 ns |      2,553.15 ns |    28.88 |    0.42 |     2.9297 |         - |     - |     32433 B |
| FindTokenUsingCompiledRegex |     100 |      3,963,468.0 ns |     1,740,793.18 ns |     95,418.75 ns |   187.94 |    3.78 |     3.9063 |         - |     - |     49121 B |
|          FindTokenUsingSpan |     100 |          2,640.7 ns |           130.89 ns |          7.17 ns |     0.13 |    0.00 |          - |         - |     - |           - |
|                             |         |                     |                     |                  |          |         |            |           |       |             |
|         FindTokenUsingSplit |    1000 |        212,979.7 ns |        63,438.36 ns |      3,477.27 ns |     1.00 |    0.00 |    55.4199 |         - |     - |    463560 B |
|         FindTokenUsingRegex |    1000 |      7,440,851.3 ns |     2,543,997.79 ns |    139,445.10 ns |    34.95 |    1.17 |    31.2500 |         - |     - |    284440 B |
| FindTokenUsingCompiledRegex |    1000 |      5,561,014.1 ns |       416,469.03 ns |     22,828.07 ns |    26.11 |    0.40 |    31.2500 |   15.6250 |     - |    301136 B |
|          FindTokenUsingSpan |    1000 |         35,626.9 ns |        11,393.58 ns |        624.52 ns |     0.17 |    0.01 |          - |         - |     - |           - |
|                             |         |                     |                     |                  |          |         |            |           |       |             |
|         FindTokenUsingSplit |  100000 |     22,916,339.1 ns |     5,032,672.72 ns |    275,857.77 ns |     1.00 |    0.00 |  5531.2500 |         - |     - |  46400000 B |
|         FindTokenUsingRegex |  100000 |  1,144,839,700.0 ns |   361,866,184.96 ns | 19,835,106.66 ns |    49.97 |    1.40 |  3000.0000 |         - |     - |  28009080 B |
| FindTokenUsingCompiledRegex |  100000 |    297,398,066.7 ns |     7,091,392.16 ns |    388,703.13 ns |    12.98 |    0.16 |  3000.0000 |         - |     - |  28026584 B |
|          FindTokenUsingSpan |  100000 |      4,926,028.0 ns |     1,489,889.61 ns |     81,665.88 ns |     0.22 |    0.01 |          - |         - |     - |           - |
|                             |         |                     |                     |                  |          |         |            |           |       |             |
|         FindTokenUsingSplit | 1000000 |    271,497,716.7 ns |   127,153,540.28 ns |  6,969,714.60 ns |     1.00 |    0.00 | 64500.0000 |         - |     - | 543200000 B |
|         FindTokenUsingRegex | 1000000 | 13,760,973,033.3 ns | 1,731,268,294.37 ns | 94,896,657.12 ns |    50.71 |    1.61 | 34000.0000 | 1000.0000 |     - | 287211592 B |
| FindTokenUsingCompiledRegex | 1000000 |  3,329,884,833.3 ns | 1,044,754,410.65 ns | 57,266,514.61 ns |    12.27 |    0.16 | 34000.0000 |         - |     - | 287228232 B |
|          FindTokenUsingSpan | 1000000 |     61,882,604.2 ns |    34,437,680.33 ns |  1,887,645.46 ns |     0.23 |    0.01 |          - |         - |     - |       158 B |