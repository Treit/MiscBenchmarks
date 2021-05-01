# Regex parsing vs string.Split

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21370
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=5.0.202
  [Host]   : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  ShortRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                      Method |   Count |              Mean |            Error |         StdDev |      Gen 0 |     Gen 1 | Gen 2 |    Allocated |
|---------------------------- |-------- |------------------:|-----------------:|---------------:|-----------:|----------:|------:|-------------:|
|         FindTokenUsingSplit |      10 |          3.801 us |         2.098 us |      0.1150 us |     0.5341 |         - |     - |      4.38 KB |
|         FindTokenUsingRegex |      10 |         60.038 us |         6.180 us |      0.3387 us |     0.8545 |         - |     - |      7.34 KB |
| FindTokenUsingCompiledRegex |      10 |      3,871.644 us |     6,168.054 us |    338.0918 us |          - |         - |     - |      23.6 KB |
|         FindTokenUsingSplit |     100 |         22.509 us |         4.389 us |      0.2406 us |     5.5237 |         - |     - |     45.18 KB |
|         FindTokenUsingRegex |     100 |        574.419 us |        29.929 us |      1.6405 us |     3.9063 |         - |     - |     31.97 KB |
| FindTokenUsingCompiledRegex |     100 |      3,756.789 us |        53.988 us |      2.9593 us |     3.9063 |         - |     - |      48.3 KB |
|         FindTokenUsingSplit |    1000 |        213.411 us |         2.405 us |      0.1318 us |    55.4199 |         - |     - |       453 KB |
|         FindTokenUsingRegex |    1000 |      7,146.676 us |     1,369.275 us |     75.0546 us |    31.2500 |         - |     - |    278.08 KB |
| FindTokenUsingCompiledRegex |    1000 |      5,527.701 us |       175.939 us |      9.6438 us |    31.2500 |   15.6250 |     - |    294.38 KB |
|         FindTokenUsingSplit |  100000 |     23,300.616 us |     5,908.041 us |    323.8397 us |  5531.2500 |         - |     - |   45312.8 KB |
|         FindTokenUsingRegex |  100000 |  1,369,778.867 us |    64,893.799 us |  3,557.0481 us |  3000.0000 |         - |     - |  27352.92 KB |
| FindTokenUsingCompiledRegex |  100000 |    290,998.767 us |    60,515.877 us |  3,317.0794 us |  3000.0000 |         - |     - |  27365.65 KB |
|         FindTokenUsingSplit | 1000000 |    280,467.033 us |   104,741.041 us |  5,741.2099 us | 64500.0000 |         - |     - | 530469.06 KB |
|         FindTokenUsingRegex | 1000000 | 13,011,741.067 us | 1,753,476.595 us | 96,113.9690 us | 34000.0000 | 1000.0000 |     - | 280480.38 KB |
| FindTokenUsingCompiledRegex | 1000000 |  3,352,983.533 us |   418,318.150 us | 22,929.4294 us | 34000.0000 |         - |     - | 280496.63 KB |