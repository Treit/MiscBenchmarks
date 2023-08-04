# Array vs. List

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25921.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  Job-FLXYNJ : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|        Method |   Count |         Mean |       Error |      StdDev |       Median |
|-------------- |-------- |-------------:|------------:|------------:|-------------:|
|  **PopulateList** |   **10000** |    **13.850 μs** |   **0.1022 μs** |   **0.0798 μs** |    **13.850 μs** |
| PopulateArray |   10000 |     4.738 μs |   0.0606 μs |   0.0506 μs |     4.700 μs |
|       SumList |   10000 |     6.607 μs |   0.1277 μs |   0.3181 μs |     6.500 μs |
|      SumArray |   10000 |     5.977 μs |   0.0868 μs |   0.0725 μs |     6.000 μs |
|  **PopulateList** | **1000000** | **2,277.373 μs** | **308.3542 μs** | **909.1893 μs** | **2,234.200 μs** |
| PopulateArray | 1000000 | 1,409.357 μs | 315.8792 μs | 931.3770 μs | 1,332.150 μs |
|       SumList | 1000000 |   699.182 μs |  13.7265 μs |  19.6862 μs |   704.250 μs |
|      SumArray | 1000000 |   648.838 μs |  12.9665 μs |  26.7780 μs |   649.700 μs |
