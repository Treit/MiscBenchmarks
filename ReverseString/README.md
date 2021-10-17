## Reversing a string

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22478
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-rc.1.21463.6
  [Host]   : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT
  ShortRun : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                             Method | Count |            Mean |           Error |        StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 |  Allocated |
|----------------------------------- |------ |----------------:|----------------:|--------------:|------:|--------:|----------:|------:|------:|-----------:|
|       **ReverseStringUsingLinqAndNew** |    **10** |      **5,629.2 ns** |      **2,354.7 ns** |     **129.07 ns** |  **1.00** |    **0.00** |    **1.3504** |     **-** |     **-** |     **5840 B** |
|      ReverseStringUsingLinqAndJoin |    10 |     10,174.8 ns |      6,955.8 ns |     381.27 ns |  1.81 |    0.11 |    3.2501 |     - |     - |    14080 B |
|     ReverseStringUsingExplicitCopy |    10 |        796.5 ns |        813.2 ns |      44.58 ns |  0.14 |    0.01 |    0.4444 |     - |     - |     1920 B |
|     ReverseStringUsingStringCreate |    10 |        446.9 ns |        179.6 ns |       9.84 ns |  0.08 |    0.00 |    0.2222 |     - |     - |      960 B |
|     ReverseStringUsingArrayReverse |    10 |        473.8 ns |        332.8 ns |      18.24 ns |  0.08 |    0.00 |    0.4444 |     - |     - |     1920 B |
| ReverseStringUsingStringCreateKozi |    10 |        413.0 ns |        400.9 ns |      21.98 ns |  0.07 |    0.00 |    0.2222 |     - |     - |      960 B |
|         RevereStringEnumerableKesa |    10 |      5,654.0 ns |      3,529.0 ns |     193.44 ns |  1.01 |    0.06 |    1.2741 |     - |     - |     5520 B |
|                                    |       |                 |                 |               |       |         |           |       |       |            |
|       **ReverseStringUsingLinqAndNew** |   **100** |     **59,634.5 ns** |     **37,803.8 ns** |   **2,072.15 ns** |  **1.00** |    **0.00** |   **13.4888** |     **-** |     **-** |    **58400 B** |
|      ReverseStringUsingLinqAndJoin |   100 |     99,450.1 ns |     59,255.2 ns |   3,247.98 ns |  1.67 |    0.10 |   32.5928 |     - |     - |   140800 B |
|     ReverseStringUsingExplicitCopy |   100 |      7,829.5 ns |      1,574.0 ns |      86.28 ns |  0.13 |    0.01 |    4.4403 |     - |     - |    19200 B |
|     ReverseStringUsingStringCreate |   100 |      4,974.5 ns |      2,016.7 ns |     110.54 ns |  0.08 |    0.00 |    2.2202 |     - |     - |     9600 B |
|     ReverseStringUsingArrayReverse |   100 |      4,511.2 ns |      1,803.7 ns |      98.87 ns |  0.08 |    0.00 |    4.4479 |     - |     - |    19200 B |
| ReverseStringUsingStringCreateKozi |   100 |      3,695.7 ns |      2,512.8 ns |     137.74 ns |  0.06 |    0.00 |    2.2240 |     - |     - |     9600 B |
|         RevereStringEnumerableKesa |   100 |     58,342.8 ns |     71,413.6 ns |   3,914.42 ns |  0.98 |    0.09 |   12.7563 |     - |     - |    55200 B |
|                                    |       |                 |                 |               |       |         |           |       |       |            |
|       **ReverseStringUsingLinqAndNew** | **10000** |  **5,463,144.9 ns** |  **1,521,092.1 ns** |  **83,376.19 ns** |  **1.00** |    **0.00** | **1351.5625** |     **-** |     **-** |  **5840000 B** |
|      ReverseStringUsingLinqAndJoin | 10000 | 10,129,041.9 ns | 10,008,567.7 ns | 548,603.37 ns |  1.85 |    0.07 | 3250.0000 |     - |     - | 14080000 B |
|     ReverseStringUsingExplicitCopy | 10000 |    778,019.5 ns |     32,219.2 ns |   1,766.04 ns |  0.14 |    0.00 |  444.3359 |     - |     - |  1920000 B |
|     ReverseStringUsingStringCreate | 10000 |    478,656.3 ns |    290,261.2 ns |  15,910.20 ns |  0.09 |    0.00 |  222.1680 |     - |     - |   960000 B |
|     ReverseStringUsingArrayReverse | 10000 |    458,900.9 ns |     87,866.8 ns |   4,816.27 ns |  0.08 |    0.00 |  444.8242 |     - |     - |  1920000 B |
| ReverseStringUsingStringCreateKozi | 10000 |    366,558.5 ns |    188,889.5 ns |  10,353.67 ns |  0.07 |    0.00 |  222.1680 |     - |     - |   960000 B |
|         RevereStringEnumerableKesa | 10000 |  5,590,750.9 ns |  3,059,727.3 ns | 167,713.98 ns |  1.02 |    0.04 | 1273.4375 |     - |     - |  5520000 B |
