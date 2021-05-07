# Using a Struct vs a Class when populating a queue

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21370
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.202
  [Host]   : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  ShortRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|           Method |   Count |            Mean |           Error |         StdDev |  Ratio | RatioSD |       Gen 0 |       Gen 1 |     Gen 2 |     Allocated |
|----------------- |-------- |----------------:|----------------:|---------------:|-------:|--------:|------------:|------------:|----------:|--------------:|
| QueueUsingStruct |      10 |     7,828.42 us |    22,811.02 us |   1,250.349 us | 223.58 |   28.23 |      9.2773 |      2.9297 |         - |      41.33 KB |
|  QueueUsingClass |      10 |        34.98 us |        55.05 us |       3.017 us |   1.00 |    0.00 |      6.8359 |      2.3804 |         - |       41.8 KB |
|                  |         |                 |                 |                |        |         |             |             |           |               |
| QueueUsingStruct |     100 |    20,349.76 us |    63,638.04 us |   3,488.215 us |  60.38 |    4.21 |     66.4063 |     23.4375 |         - |     413.28 KB |
|  QueueUsingClass |     100 |       335.92 us |       756.14 us |      41.447 us |   1.00 |    0.00 |     68.3594 |     23.9258 |         - |     417.97 KB |
|                  |         |                 |                 |                |        |         |             |             |           |               |
| QueueUsingStruct |    1000 |    28,208.38 us |    63,379.86 us |   3,474.064 us |   8.55 |    1.24 |    671.8750 |    250.0000 |         - |    4132.81 KB |
|  QueueUsingClass |    1000 |     3,304.56 us |     1,453.16 us |      79.653 us |   1.00 |    0.00 |    679.6875 |    234.3750 |         - |    4179.69 KB |
|                  |         |                 |                 |                |        |         |             |             |           |               |
| QueueUsingStruct |   10000 |    83,607.58 us |   160,579.62 us |   8,801.911 us |   2.05 |    0.26 |   6777.7778 |   2333.3333 |         - |   41328.13 KB |
|  QueueUsingClass |   10000 |    40,790.12 us |    23,414.89 us |   1,283.449 us |   1.00 |    0.00 |   6812.5000 |   2375.0000 |         - |   41796.88 KB |
|                  |         |                 |                 |                |        |         |             |             |           |               |
| QueueUsingStruct |  100000 |   351,869.70 us |   199,366.30 us |  10,927.940 us |   1.08 |    0.04 |  67000.0000 |  23000.0000 |         - |  413281.39 KB |
|  QueueUsingClass |  100000 |   324,632.73 us |   149,477.14 us |   8,193.346 us |   1.00 |    0.00 |  68000.0000 |  23000.0000 |         - |  417968.89 KB |
|                  |         |                 |                 |                |        |         |             |             |           |               |
| QueueUsingStruct | 1000000 | 4,816,914.37 us | 7,353,630.27 us | 403,077.289 us |   1.15 |    0.07 | 675000.0000 | 239000.0000 | 1000.0000 | 4132816.25 KB |
|  QueueUsingClass | 1000000 | 4,183,020.57 us | 1,520,368.34 us |  83,336.519 us |   1.00 |    0.00 | 682000.0000 | 239000.0000 |         - | 4179687.64 KB |
