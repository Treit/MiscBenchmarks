# Getting the type

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25217
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT


```
|                     Method | Count |     Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |------ |---------:|---------:|---------:|------:|------:|------:|----------:|
|       UsingSwitchAndTypeOf | 10000 | 49.63 μs | 0.899 μs | 0.797 μs |     - |     - |     - |         - |
| UsingTypeOfExtensionMethod | 10000 | 32.61 μs | 0.647 μs | 1.878 μs |     - |     - |     - |         - |
|               UsingGetType | 10000 | 26.64 μs | 0.515 μs | 1.452 μs |     - |     - |     - |         - |
