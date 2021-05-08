# Using a Struct vs a Class when populating a queue

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21370
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.202
  [Host]   : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  ShortRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|           Method |   Count |             Mean |            Error |         StdDev | Ratio | RatioSD |       Gen 0 |       Gen 1 |     Gen 2 |     Allocated |
|----------------- |-------- |-----------------:|-----------------:|---------------:|------:|--------:|------------:|------------:|----------:|--------------:|
| QueueUsingStruct |      10 |         4.091 us |         1.626 us |      0.0891 us |  0.94 |    0.04 |      9.8038 |           - |         - |      41.33 KB |
|  QueueUsingClass |      10 |         4.352 us |         4.619 us |      0.2532 us |  1.00 |    0.00 |      9.9182 |      0.0153 |         - |       41.8 KB |
|                  |         |                  |                  |                |       |         |             |             |           |               |
| QueueUsingStruct |     100 |        50.845 us |        40.589 us |      2.2248 us |  1.06 |    0.07 |     78.9795 |     39.3677 |         - |     413.28 KB |
|  QueueUsingClass |     100 |        48.177 us |        28.124 us |      1.5416 us |  1.00 |    0.00 |     87.7686 |     17.5171 |         - |     417.97 KB |
|                  |         |                  |                  |                |       |         |             |             |           |               |
| QueueUsingStruct |    1000 |       618.564 us |       892.082 us |     48.8980 us |  0.91 |    0.09 |    772.4609 |    239.2578 |         - |    4132.81 KB |
|  QueueUsingClass |    1000 |       681.782 us |     1,013.075 us |     55.5300 us |  1.00 |    0.00 |    774.4141 |    282.2266 |         - |    4179.69 KB |
|                  |         |                  |                  |                |       |         |             |             |           |               |
| QueueUsingStruct |   10000 |    30,662.529 us |    40,920.872 us |  2,243.0111 us |  1.04 |    0.10 |   7437.5000 |   3062.5000 | 1000.0000 |   41328.91 KB |
|  QueueUsingClass |   10000 |    29,543.202 us |    11,025.742 us |    604.3581 us |  1.00 |    0.00 |   7468.7500 |   3000.0000 |  968.7500 |    41797.6 KB |
|                  |         |                  |                  |                |       |         |             |             |           |               |
| QueueUsingStruct |  100000 |   464,132.233 us |   739,423.318 us | 40,530.2872 us |  1.03 |    0.20 |  71000.0000 |  26000.0000 | 4000.0000 |  413285.98 KB |
|  QueueUsingClass |  100000 |   459,286.000 us | 1,127,303.549 us | 61,791.3114 us |  1.00 |    0.00 |  72000.0000 |  27000.0000 | 4000.0000 |  417974.88 KB |
|                  |         |                  |                  |                |       |         |             |             |           |               |
| QueueUsingStruct | 1000000 | 4,089,415.767 us | 1,368,039.403 us | 74,986.8559 us |  0.91 |    0.02 | 682000.0000 | 244000.0000 | 8000.0000 | 4132836.88 KB |
|  QueueUsingClass | 1000000 | 4,491,414.633 us |   667,370.620 us | 36,580.8356 us |  1.00 |    0.00 | 690000.0000 | 244000.0000 | 8000.0000 | 4179703.82 KB |