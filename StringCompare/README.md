# Searching for substrings using Contains

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                     Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |
|--------------------------- |------ |----------:|---------:|---------:|------:|--------:|
|                    Ordinal |  1000 |  21.11 μs | 0.417 μs | 0.556 μs |  1.00 |    0.00 |
|          OrdinalIgnoreCase |  1000 | 348.11 μs | 6.838 μs | 5.710 μs | 16.56 |    0.33 |
|             CurrentCulture |  1000 | 268.12 μs | 2.382 μs | 2.111 μs | 12.75 |    0.36 |
|   CurrentCultureIgnoreCase |  1000 | 325.52 μs | 4.218 μs | 3.522 μs | 15.49 |    0.50 |
|           InvariantCulture |  1000 | 270.37 μs | 5.364 μs | 8.509 μs | 12.90 |    0.57 |
| InvariantCultureIgnoreCase |  1000 | 346.59 μs | 6.723 μs | 9.202 μs | 16.44 |    0.52 |
