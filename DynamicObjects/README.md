# Dynamic vs regular C# types

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|                 Method | Size |      Mean |     Error |    StdDev |    Median |      Gen0 |      Gen1 |      Gen2 | Allocated |
|----------------------- |----- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
|        InitJaggedArray | 1024 |  1.017 ms | 0.0201 ms | 0.0346 ms |  1.001 ms |  187.5000 |  142.5781 |         - |   1.03 MB |
| InitDynamicJaggedArray | 1024 | 97.397 ms | 1.7376 ms | 1.4510 ms | 97.744 ms | 6333.3333 | 3833.3333 | 1000.0000 |  32.03 MB |


