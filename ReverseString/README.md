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
|                         Method | Count |           Mean |          Error |        StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 |  Allocated |
|------------------------------- |------ |---------------:|---------------:|--------------:|------:|--------:|----------:|------:|------:|-----------:|
|   **ReverseStringUsingLinqAndNew** |    **10** |     **5,615.6 ns** |     **2,277.7 ns** |     **124.85 ns** |  **1.00** |    **0.00** |    **1.3504** |     **-** |     **-** |     **5840 B** |
|  ReverseStringUsingLinqAndJoin |    10 |     9,829.6 ns |     2,737.0 ns |     150.03 ns |  1.75 |    0.06 |    3.2501 |     - |     - |    14080 B |
| ReverseStringUsingExplicitCopy |    10 |       665.1 ns |       349.1 ns |      19.14 ns |  0.12 |    0.00 |    0.4444 |     - |     - |     1920 B |
| ReverseStringUsingStringCreate |    10 |       501.2 ns |       453.8 ns |      24.87 ns |  0.09 |    0.00 |    0.2222 |     - |     - |      960 B |
|                                |       |                |                |               |       |         |           |       |       |            |
|   **ReverseStringUsingLinqAndNew** |   **100** |    **55,041.3 ns** |    **34,840.6 ns** |   **1,909.73 ns** |  **1.00** |    **0.00** |   **13.4888** |     **-** |     **-** |    **58400 B** |
|  ReverseStringUsingLinqAndJoin |   100 |    95,007.2 ns |    42,035.2 ns |   2,304.09 ns |  1.73 |    0.10 |   32.5928 |     - |     - |   140800 B |
| ReverseStringUsingExplicitCopy |   100 |     6,206.6 ns |     3,793.9 ns |     207.96 ns |  0.11 |    0.01 |    4.4479 |     - |     - |    19200 B |
| ReverseStringUsingStringCreate |   100 |     4,346.6 ns |     1,542.6 ns |      84.55 ns |  0.08 |    0.00 |    2.2202 |     - |     - |     9600 B |
|                                |       |                |                |               |       |         |           |       |       |            |
|   **ReverseStringUsingLinqAndNew** | **10000** | **6,121,107.3 ns** | **4,488,889.8 ns** | **246,051.20 ns** |  **1.00** |    **0.00** | **1351.5625** |     **-** |     **-** |  **5840000 B** |
|  ReverseStringUsingLinqAndJoin | 10000 | 9,509,628.6 ns | 4,662,364.6 ns | 255,559.94 ns |  1.55 |    0.03 | 3250.0000 |     - |     - | 14080000 B |
| ReverseStringUsingExplicitCopy | 10000 |   801,176.3 ns |   139,701.9 ns |   7,657.53 ns |  0.13 |    0.01 |  444.3359 |     - |     - |  1920000 B |
| ReverseStringUsingStringCreate | 10000 |   513,277.7 ns |   434,428.4 ns |  23,812.49 ns |  0.08 |    0.01 |  221.6797 |     - |     - |   960000 B |
