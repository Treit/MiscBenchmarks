# Task.FromResult and Task.CompletedTask

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT


```
|              Method |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|      TaskFromResult |  9.7919 ns | 0.3819 ns | 1.1139 ns |  9.4179 ns |  1.00 |    0.00 | 0.0167 |     - |     - |      72 B |
| AwaitTaskFromResult | 35.0993 ns | 1.2316 ns | 3.6120 ns | 34.3739 ns |  3.62 |    0.55 | 0.0334 |     - |     - |     144 B |
| ReturnCompletedTask |  0.1739 ns | 0.0724 ns | 0.2088 ns |  0.0784 ns |  0.02 |    0.02 |      - |     - |     - |         - |
|  AwaitCompletedTask | 15.7939 ns | 0.6623 ns | 1.9527 ns | 15.1570 ns |  1.63 |    0.29 |      - |     - |     - |         - |
