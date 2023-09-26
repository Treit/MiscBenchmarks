# Shuffle Benchmarks

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25961.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                             Method |  Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |      Gen0 |      Gen1 |      Gen2 |  Allocated |  Alloc Ratio |
|----------------------------------- |------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|----------:|----------:|-----------:|-------------:|
|                        FisherYates | 100000 |  2.223 ms | 0.0912 ms | 0.2689 ms |  2.195 ms |  1.00 |    0.00 |         - |         - |         - |        2 B |         1.00 |
|               FisherYatesAscending | 100000 |  1.902 ms | 0.0973 ms | 0.2868 ms |  1.884 ms |  0.87 |    0.16 |         - |         - |         - |        1 B |         0.50 |
|                 FisherYatesXorSwap | 100000 |  2.646 ms | 0.0525 ms | 0.0736 ms |  2.632 ms |  1.19 |    0.13 |         - |         - |         - |        2 B |         1.00 |
| FisherYatesUsingStrongCryptoRandom | 100000 | 19.671 ms | 0.9210 ms | 2.7156 ms | 19.452 ms |  9.02 |    1.86 |         - |         - |         - |       17 B |         8.50 |
|                            Sattolo | 100000 |  1.742 ms | 0.0732 ms | 0.2124 ms |  1.676 ms |  0.80 |    0.14 |         - |         - |         - |        1 B |         0.50 |
|                     LinqWithRandom | 100000 | 25.033 ms | 1.3412 ms | 3.9545 ms | 23.504 ms | 11.35 |    1.88 |  468.7500 |  468.7500 |  468.7500 |  1600638 B |   800,319.00 |
|                       LinqWithGuid | 100000 | 44.869 ms | 2.0541 ms | 6.0564 ms | 45.058 ms | 20.50 |    3.73 |  538.4615 |  538.4615 |  538.4615 |  2802473 B | 1,401,236.50 |
|                    PLinqWithRandom | 100000 | 13.682 ms | 0.2580 ms | 0.5876 ms | 13.565 ms |  6.63 |    0.81 | 1484.3750 | 1437.5000 | 1000.0000 |  6727086 B | 3,363,543.00 |
|                      PLinqWithGuid | 100000 | 17.391 ms | 0.3401 ms | 0.6219 ms | 17.335 ms |  8.28 |    1.06 | 2031.2500 | 1968.7500 | 1562.5000 | 12177022 B | 6,088,511.00 |
