# Shuffle Benchmarks


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                             Method |  Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |      Gen0 |      Gen1 |      Gen2 |  Allocated | Alloc Ratio |
|----------------------------------- |------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|----------:|----------:|-----------:|------------:|
|                        FisherYates | 100000 |  1.078 ms | 0.0008 ms | 0.0008 ms |  1.077 ms |  1.00 |    0.00 |         - |         - |         - |          - |          NA |
|               FisherYatesAscending | 100000 |  1.160 ms | 0.0036 ms | 0.0032 ms |  1.158 ms |  1.08 |    0.00 |         - |         - |         - |          - |          NA |
|                 FisherYatesXorSwap | 100000 |  1.219 ms | 0.0012 ms | 0.0011 ms |  1.220 ms |  1.13 |    0.00 |         - |         - |         - |          - |          NA |
| FisherYatesUsingStrongCryptoRandom | 100000 |  8.170 ms | 0.0093 ms | 0.0072 ms |  8.171 ms |  7.58 |    0.01 |         - |         - |         - |          - |          NA |
|                            Sattolo | 100000 |  1.117 ms | 0.0009 ms | 0.0008 ms |  1.117 ms |  1.04 |    0.00 |         - |         - |         - |          - |          NA |
|                     LinqWithRandom | 100000 | 11.326 ms | 0.0632 ms | 0.0560 ms | 11.341 ms | 10.51 |    0.06 |  484.3750 |  484.3750 |  484.3750 |  1600633 B |          NA |
|                       LinqWithGuid | 100000 | 21.394 ms | 0.0627 ms | 0.0556 ms | 21.382 ms | 19.85 |    0.06 |  531.2500 |  531.2500 |  531.2500 |  2804089 B |          NA |
|                    PLinqWithRandom | 100000 |  5.307 ms | 0.1059 ms | 0.2066 ms |  5.183 ms |  4.91 |    0.20 | 1257.8125 | 1242.1875 | 1000.0000 |  7905352 B |          NA |
|                      PLinqWithGuid | 100000 |  7.287 ms | 0.0822 ms | 0.0769 ms |  7.293 ms |  6.76 |    0.07 | 1710.9375 | 1710.9375 | 1421.8750 | 14472163 B |          NA |
