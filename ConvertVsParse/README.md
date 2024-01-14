## Convert.ToInt32 vs. int.Parse


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method |  Count |            Mean |         Error |        StdDev | Ratio | Allocated | Alloc Ratio |
|------------------------- |------- |----------------:|--------------:|--------------:|------:|----------:|------------:|
|  **StringToIntUsingConvert** |     **10** |        **68.60 ns** |      **0.056 ns** |      **0.050 ns** |  **1.00** |         **-** |          **NA** |
|    StringToIntUsingParse |     10 |        68.72 ns |      0.188 ns |      0.167 ns |  1.00 |         - |          NA |
| StringToIntUsingTryParse |     10 |        71.75 ns |      0.095 ns |      0.080 ns |  1.05 |         - |          NA |
|                          |        |                 |               |               |       |           |             |
|  **StringToIntUsingConvert** |    **100** |       **771.85 ns** |      **0.472 ns** |      **0.418 ns** |  **1.00** |         **-** |          **NA** |
|    StringToIntUsingParse |    100 |       771.38 ns |      0.623 ns |      0.520 ns |  1.00 |         - |          NA |
| StringToIntUsingTryParse |    100 |       833.77 ns |      0.721 ns |      0.639 ns |  1.08 |         - |          NA |
|                          |        |                 |               |               |       |           |             |
|  **StringToIntUsingConvert** |  **10000** |    **98,347.48 ns** |     **61.347 ns** |     **47.896 ns** |  **1.00** |         **-** |          **NA** |
|    StringToIntUsingParse |  10000 |    98,518.46 ns |    163.828 ns |    153.245 ns |  1.00 |         - |          NA |
| StringToIntUsingTryParse |  10000 |   101,729.10 ns |     87.811 ns |     82.138 ns |  1.03 |         - |          NA |
|                          |        |                 |               |               |       |           |             |
|  **StringToIntUsingConvert** | **100000** | **1,027,367.35 ns** |  **2,771.108 ns** |  **2,456.515 ns** |  **1.00** |         **-** |          **NA** |
|    StringToIntUsingParse | 100000 | 1,116,122.22 ns | 11,083.548 ns |  9,825.277 ns |  1.09 |         - |          NA |
| StringToIntUsingTryParse | 100000 | 1,145,973.44 ns | 12,802.534 ns | 11,975.498 ns |  1.11 |         - |          NA |
