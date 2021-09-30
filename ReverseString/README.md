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
|   **ReverseStringUsingLinqAndNew** |    **10** |     **5,801.4 ns** |     **4,049.7 ns** |     **221.98 ns** |  **1.00** |    **0.00** |    **1.3504** |     **-** |     **-** |     **5.7 KB** |
|  ReverseStringUsingLinqAndJoin |    10 |     9,671.8 ns |     5,272.0 ns |     288.97 ns |  1.67 |    0.11 |    3.2501 |     - |     - |   13.75 KB |
| ReverseStringUsingExplicitCopy |    10 |       633.0 ns |       199.4 ns |      10.93 ns |  0.11 |    0.00 |    0.4444 |     - |     - |    1.88 KB |
|                                |       |                |                |               |       |         |           |       |       |            |
|   **ReverseStringUsingLinqAndNew** |   **100** |    **56,744.6 ns** |    **17,812.6 ns** |     **976.37 ns** |  **1.00** |    **0.00** |   **13.4888** |     **-** |     **-** |   **57.03 KB** |
|  ReverseStringUsingLinqAndJoin |   100 |    95,876.4 ns |    66,968.2 ns |   3,670.75 ns |  1.69 |    0.08 |   32.5928 |     - |     - |   137.5 KB |
| ReverseStringUsingExplicitCopy |   100 |     8,054.8 ns |     2,811.2 ns |     154.09 ns |  0.14 |    0.00 |    4.4403 |     - |     - |   18.75 KB |
|                                |       |                |                |               |       |         |           |       |       |            |
|   **ReverseStringUsingLinqAndNew** | **10000** | **5,652,785.4 ns** | **3,798,479.0 ns** | **208,207.45 ns** |  **1.00** |    **0.00** | **1351.5625** |     **-** |     **-** | **5703.13 KB** |
|  ReverseStringUsingLinqAndJoin | 10000 | 9,730,880.7 ns | 6,324,979.1 ns | 346,693.45 ns |  1.72 |    0.12 | 3250.0000 |     - |     - |   13750 KB |
| ReverseStringUsingExplicitCopy | 10000 |   790,501.5 ns |   123,776.5 ns |   6,784.61 ns |  0.14 |    0.00 |  444.3359 |     - |     - |    1875 KB |
