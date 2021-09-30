## Reversing a string

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22468
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT
  ShortRun : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                         Method | Count |            Mean |            Error |          StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 |  Allocated |
|------------------------------- |------ |----------------:|-----------------:|----------------:|------:|--------:|----------:|------:|------:|-----------:|
|   **ReverseStringUsingLinqAndNew** |    **10** |      **6,386.9 ns** |      **5,027.21 ns** |       **275.56 ns** |  **1.00** |    **0.00** |    **1.3504** |     **-** |     **-** |     **5840 B** |
|  ReverseStringUsingLinqAndJoin |    10 |      9,639.0 ns |      7,160.15 ns |       392.47 ns |  1.51 |    0.05 |    3.2501 |     - |     - |    14080 B |
| ReverseStringUsingExplicitCopy |    10 |        783.8 ns |         32.42 ns |         1.78 ns |  0.12 |    0.00 |    0.4444 |     - |     - |     1920 B |
| ReverseStringUsingStringCreate |    10 |        493.2 ns |        223.38 ns |        12.24 ns |  0.08 |    0.00 |    0.2222 |     - |     - |      960 B |
| ReverseStringUsingArrayReverse |    10 |        482.8 ns |        255.46 ns |        14.00 ns |  0.08 |    0.00 |    0.4444 |     - |     - |     1920 B |
|                                |       |                 |                  |                 |       |         |           |       |       |            |
|   **ReverseStringUsingLinqAndNew** |   **100** |     **54,901.2 ns** |      **8,562.16 ns** |       **469.32 ns** |  **1.00** |    **0.00** |   **13.4888** |     **-** |     **-** |    **58400 B** |
|  ReverseStringUsingLinqAndJoin |   100 |     96,000.3 ns |      7,946.88 ns |       435.60 ns |  1.75 |    0.02 |   32.5928 |     - |     - |   140800 B |
| ReverseStringUsingExplicitCopy |   100 |      8,776.3 ns |     11,006.46 ns |       603.30 ns |  0.16 |    0.01 |    4.4403 |     - |     - |    19200 B |
| ReverseStringUsingStringCreate |   100 |      4,709.5 ns |        544.62 ns |        29.85 ns |  0.09 |    0.00 |    2.2202 |     - |     - |     9600 B |
| ReverseStringUsingArrayReverse |   100 |      4,521.4 ns |      1,572.83 ns |        86.21 ns |  0.08 |    0.00 |    4.4479 |     - |     - |    19200 B |
|                                |       |                 |                  |                 |       |         |           |       |       |            |
|   **ReverseStringUsingLinqAndNew** | **10000** |  **6,090,167.7 ns** |  **8,079,670.92 ns** |   **442,874.03 ns** |  **1.00** |    **0.00** | **1351.5625** |     **-** |     **-** |  **5840000 B** |
|  ReverseStringUsingLinqAndJoin | 10000 | 10,567,770.6 ns | 18,510,653.58 ns | 1,014,631.38 ns |  1.73 |    0.09 | 3250.0000 |     - |     - | 14080000 B |
| ReverseStringUsingExplicitCopy | 10000 |    811,130.3 ns |    348,900.63 ns |    19,124.42 ns |  0.13 |    0.01 |  444.3359 |     - |     - |  1920000 B |
| ReverseStringUsingStringCreate | 10000 |    482,611.6 ns |    286,277.55 ns |    15,691.84 ns |  0.08 |    0.00 |  221.6797 |     - |     - |   960000 B |
| ReverseStringUsingArrayReverse | 10000 |    478,132.6 ns |    127,185.94 ns |     6,971.49 ns |  0.08 |    0.01 |  444.8242 |     - |     - |  1920000 B |
