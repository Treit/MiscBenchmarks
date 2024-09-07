# Shuffle Benchmarks



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27699.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count  | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated  | Alloc Ratio   |
|----------------------------------- |------- |----------:|----------:|----------:|------:|--------:|----------:|----------:|----------:|-----------:|--------------:|
| FisherYates                        | 100000 |  1.206 ms | 0.0154 ms | 0.0144 ms |  1.00 |    0.00 |         - |         - |         - |        1 B |          1.00 |
| FisherYatesAscending               | 100000 |  1.235 ms | 0.0241 ms | 0.0338 ms |  1.04 |    0.04 |         - |         - |         - |        1 B |          1.00 |
| FisherYatesXorSwap                 | 100000 |  1.350 ms | 0.0234 ms | 0.0312 ms |  1.11 |    0.04 |         - |         - |         - |        1 B |          1.00 |
| FisherYatesUsingStrongCryptoRandom | 100000 | 13.852 ms | 0.2763 ms | 0.6349 ms | 11.62 |    0.40 |         - |         - |         - |        6 B |          6.00 |
| FisherYatesDynamic                 | 100000 |  9.035 ms | 0.4962 ms | 1.4395 ms |  7.39 |    0.80 | 4445.3125 |         - |         - | 19199955 B | 19,199,955.00 |
| Sattolo                            | 100000 |  1.324 ms | 0.0228 ms | 0.0280 ms |  1.10 |    0.02 |         - |         - |         - |        1 B |          1.00 |
| LinqWithRandom                     | 100000 | 13.853 ms | 0.2057 ms | 0.1924 ms | 11.49 |    0.19 |  484.3750 |  484.3750 |  484.3750 |  1600633 B |  1,600,633.00 |
| LinqWithGuid                       | 100000 | 25.237 ms | 0.5039 ms | 0.5601 ms | 21.03 |    0.60 |  531.2500 |  531.2500 |  531.2500 |  2803778 B |  2,803,778.00 |
| PLinqWithRandom                    | 100000 |  8.695 ms | 0.1725 ms | 0.3786 ms |  7.46 |    0.16 | 1484.3750 | 1437.5000 | 1000.0000 |  6728410 B |  6,728,410.00 |
| PLinqWithGuid                      | 100000 | 13.238 ms | 0.2721 ms | 0.8023 ms | 11.28 |    0.57 | 1859.3750 | 1812.5000 | 1375.0000 | 12182072 B | 12,182,072.00 |
