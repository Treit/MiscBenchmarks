# Task.FromResult

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|              Method |     Mean |    Error |   StdDev |    Median | Ratio | RatioSD |
|-------------------- |---------:|---------:|---------:|----------:|------:|--------:|
|      TaskFromResult | 10.09 ns | 0.423 ns | 1.199 ns |  9.846 ns |  1.00 |    0.00 |
| AwaitTaskFromResult | 30.43 ns | 0.835 ns | 2.422 ns | 29.616 ns |  3.06 |    0.42 |
