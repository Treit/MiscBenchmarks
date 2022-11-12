# Returning an empty sequence

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25241
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|             Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| EnumerableDotEmpty |  8.572 ns | 0.5361 ns | 1.5724 ns |  7.979 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      NewEmptyArray | 26.170 ns | 0.6021 ns | 1.0059 ns | 25.807 ns |  3.06 |    0.56 | 0.0055 |     - |     - |      24 B |
|       NewEmptyList | 18.738 ns | 0.3849 ns | 0.3781 ns | 18.700 ns |  2.40 |    0.22 | 0.0074 |     - |     - |      32 B |
