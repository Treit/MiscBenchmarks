# Task.FromResult

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|              Method |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|      TaskFromResult | 10.00 ns | 0.335 ns | 0.962 ns |  1.00 |    0.00 | 0.0167 |     - |     - |      72 B |
| AwaitTaskFromResult | 32.58 ns | 0.734 ns | 1.815 ns |  3.27 |    0.37 | 0.0334 |     - |     - |     144 B |
