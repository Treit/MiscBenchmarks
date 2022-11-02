# Shuffle Benchmarks

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25236
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|                             Method |  Count |      Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|----------------------------------- |------- |----------:|----------:|----------:|------:|--------:|----------:|----------:|----------:|-----------:|
|                        FisherYates | 100000 |  1.662 ms | 0.0325 ms | 0.0525 ms |  1.00 |    0.00 |         - |         - |         - |        2 B |
|               FisherYatesAscending | 100000 |  1.621 ms | 0.0524 ms | 0.1488 ms |  1.00 |    0.10 |         - |         - |         - |        1 B |
| FisherYatesUsingStrongCryptoRandom | 100000 | 17.217 ms | 0.3733 ms | 1.0890 ms | 10.28 |    0.81 |         - |         - |         - |       15 B |
|                            Sattolo | 100000 |  1.607 ms | 0.0321 ms | 0.0874 ms |  0.96 |    0.06 |         - |         - |         - |        1 B |
|                     LinqWithRandom | 100000 | 20.804 ms | 0.4131 ms | 1.1240 ms | 12.62 |    0.76 |  468.7500 |  468.7500 |  468.7500 |  1600636 B |
|                       LinqWithGuid | 100000 | 33.688 ms | 0.6735 ms | 1.7743 ms | 19.77 |    1.06 |  562.5000 |  562.5000 |  562.5000 |  2803098 B |
|                    PLinqWithRandom | 100000 | 12.437 ms | 0.2614 ms | 0.7707 ms |  7.57 |    0.60 | 1484.3750 | 1453.1250 | 1000.0000 |  6729934 B |
|                      PLinqWithGuid | 100000 | 15.486 ms | 0.3471 ms | 1.0235 ms |  9.17 |    0.58 | 2046.8750 | 1968.7500 | 1546.8750 | 12180196 B |
