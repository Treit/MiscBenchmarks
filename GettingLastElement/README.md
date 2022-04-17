# Getting last element

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22598
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 5.0.15 (CoreCLR 5.0.1522.11506, CoreFX 5.0.1522.11506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.15 (CoreCLR 5.0.1522.11506, CoreFX 5.0.1522.11506), X64 RyuJIT


```
|                    Method |   Count |       Mean |     Error |    StdDev |     Median |  Ratio | RatioSD |
|-------------------------- |-------- |-----------:|----------:|----------:|-----------:|-------:|--------:|
|  **LastElementViaArrayIndex** |    **1000** |  **0.3303 ns** | **0.0398 ns** | **0.0785 ns** |  **0.3310 ns** |   **1.00** |    **0.00** |
|   LastElementWithLinqLast |    1000 | 26.2722 ns | 0.5463 ns | 0.8822 ns | 26.2893 ns |  87.27 |   24.39 |
| LastElementWithRangeIndex |    1000 |  0.0250 ns | 0.0234 ns | 0.0320 ns |  0.0090 ns |   0.08 |    0.11 |
|                           |         |            |           |           |            |        |         |
|  **LastElementViaArrayIndex** |  **100000** |  **0.2883 ns** | **0.0420 ns** | **0.0838 ns** |  **0.2974 ns** |   **1.00** |    **0.00** |
|   LastElementWithLinqLast |  100000 | 27.3530 ns | 0.5336 ns | 1.0408 ns | 27.2214 ns | 105.72 |   39.88 |
| LastElementWithRangeIndex |  100000 |  0.3723 ns | 0.0419 ns | 0.0766 ns |  0.3526 ns |   1.42 |    0.60 |
|                           |         |            |           |           |            |        |         |
|  **LastElementViaArrayIndex** | **1000000** |  **0.2346 ns** | **0.0422 ns** | **0.0926 ns** |  **0.2261 ns** |   **1.00** |    **0.00** |
|   LastElementWithLinqLast | 1000000 | 28.2195 ns | 0.5952 ns | 1.5988 ns | 27.7092 ns | 150.69 |   96.23 |
| LastElementWithRangeIndex | 1000000 |  0.3293 ns | 0.0419 ns | 0.0894 ns |  0.3200 ns |   1.72 |    1.04 |
