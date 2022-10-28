# Using enums with different underlying types

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25231
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|          Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|---------------- |------ |---------:|--------:|--------:|------:|--------:|--------:|--------:|--------:|----------:|
| EnumsUsingInt32 | 10000 | 162.2 μs | 3.23 μs | 6.96 μs |  1.00 |    0.00 | 30.2734 |  4.8828 |       - | 128.62 KB |
| EnumsUsingInt64 | 10000 | 227.2 μs | 4.48 μs | 8.30 μs |  1.41 |    0.08 | 41.5039 | 41.5039 | 41.5039 | 256.62 KB |
|  EnumsUsingByte | 10000 | 144.2 μs | 2.85 μs | 4.36 μs |  0.89 |    0.05 |  7.5684 |  0.4883 |       - |  32.63 KB |
