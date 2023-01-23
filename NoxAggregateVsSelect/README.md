# Aggregate vs Select.ToList.
By Nox#0256 on the C# Community Discord, at the request of Orannis#3333.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25276.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|       Method | Count |         Mean |       Error |       StdDev |    Gen0 |   Gen1 | Allocated |
|------------- |------ |-------------:|------------:|-------------:|--------:|-------:|----------:|
|    **Aggregate** |   **100** |   **1,836.9 ns** |    **58.09 ns** |    **168.53 ns** |  **0.2823** |      **-** |    **1224 B** |
| SelectToList |   100 |     429.3 ns |    16.00 ns |     45.39 ns |  0.1221 |      - |     528 B |
|    **Aggregate** | **10000** | **140,860.4 ns** | **4,564.39 ns** | **13,169.30 ns** | **30.2734** | **0.2441** |  **131440 B** |
| SelectToList | 10000 |  36,799.0 ns | 1,276.64 ns |  3,703.78 ns |  9.2163 | 2.2583 |   40128 B |
