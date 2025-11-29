# Shuffle Benchmarks






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count  | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated  | Alloc Ratio |
|----------------------------------- |---------- |---------- |------- |----------:|----------:|----------:|------:|--------:|----------:|----------:|----------:|-----------:|------------:|
| FisherYates                        | .NET 10.0 | .NET 10.0 | 100000 |  1.147 ms | 0.0056 ms | 0.0049 ms |  1.00 |    0.01 |         - |         - |         - |          - |          NA |
| FisherYatesAscending               | .NET 10.0 | .NET 10.0 | 100000 |  1.138 ms | 0.0038 ms | 0.0033 ms |  0.99 |    0.00 |         - |         - |         - |          - |          NA |
| FisherYatesXorSwap                 | .NET 10.0 | .NET 10.0 | 100000 |  1.195 ms | 0.0019 ms | 0.0016 ms |  1.04 |    0.00 |         - |         - |         - |          - |          NA |
| FisherYatesUsingStrongCryptoRandom | .NET 10.0 | .NET 10.0 | 100000 |  8.353 ms | 0.0312 ms | 0.0277 ms |  7.29 |    0.04 |         - |         - |         - |          - |          NA |
| FisherYatesDynamic                 | .NET 10.0 | .NET 10.0 | 100000 |  6.181 ms | 0.0488 ms | 0.0456 ms |  5.39 |    0.04 | 1140.6250 |         - |         - | 19199952 B |          NA |
| Sattolo                            | .NET 10.0 | .NET 10.0 | 100000 |  1.127 ms | 0.0016 ms | 0.0014 ms |  0.98 |    0.00 |         - |         - |         - |          - |          NA |
| LinqWithRandom                     | .NET 10.0 | .NET 10.0 | 100000 | 10.296 ms | 0.0203 ms | 0.0189 ms |  8.98 |    0.04 |  484.3750 |  484.3750 |  484.3750 |  1600659 B |          NA |
| LinqWithGuid                       | .NET 10.0 | .NET 10.0 | 100000 | 22.033 ms | 0.0684 ms | 0.0640 ms | 19.22 |    0.10 |  531.2500 |  531.2500 |  531.2500 |  2802845 B |          NA |
| PLinqWithRandom                    | .NET 10.0 | .NET 10.0 | 100000 |  5.277 ms | 0.0876 ms | 0.0819 ms |  4.60 |    0.07 | 1257.8125 | 1210.9375 | 1000.0000 |  7905527 B |          NA |
| PLinqWithGuid                      | .NET 10.0 | .NET 10.0 | 100000 |  6.358 ms | 0.1197 ms | 0.1176 ms |  5.55 |    0.10 | 1828.1250 | 1796.8750 | 1539.0625 | 14472989 B |          NA |
|                                    |           |           |        |           |           |           |       |         |           |           |           |            |             |
| FisherYates                        | .NET 9.0  | .NET 9.0  | 100000 |  1.143 ms | 0.0022 ms | 0.0020 ms |  1.00 |    0.00 |         - |         - |         - |          - |          NA |
| FisherYatesAscending               | .NET 9.0  | .NET 9.0  | 100000 |  1.134 ms | 0.0020 ms | 0.0019 ms |  0.99 |    0.00 |         - |         - |         - |          - |          NA |
| FisherYatesXorSwap                 | .NET 9.0  | .NET 9.0  | 100000 |  1.199 ms | 0.0017 ms | 0.0015 ms |  1.05 |    0.00 |         - |         - |         - |          - |          NA |
| FisherYatesUsingStrongCryptoRandom | .NET 9.0  | .NET 9.0  | 100000 |  8.361 ms | 0.0153 ms | 0.0136 ms |  7.31 |    0.02 |         - |         - |         - |          - |          NA |
| FisherYatesDynamic                 | .NET 9.0  | .NET 9.0  | 100000 |  6.119 ms | 0.0488 ms | 0.0432 ms |  5.35 |    0.04 | 1140.6250 |         - |         - | 19199952 B |          NA |
| Sattolo                            | .NET 9.0  | .NET 9.0  | 100000 |  1.158 ms | 0.0019 ms | 0.0017 ms |  1.01 |    0.00 |         - |         - |         - |          - |          NA |
| LinqWithRandom                     | .NET 9.0  | .NET 9.0  | 100000 | 10.501 ms | 0.0246 ms | 0.0205 ms |  9.19 |    0.02 |  484.3750 |  484.3750 |  484.3750 |  1600659 B |          NA |
| LinqWithGuid                       | .NET 9.0  | .NET 9.0  | 100000 | 21.119 ms | 0.1101 ms | 0.1030 ms | 18.47 |    0.09 |  531.2500 |  531.2500 |  531.2500 |  2803610 B |          NA |
| PLinqWithRandom                    | .NET 9.0  | .NET 9.0  | 100000 |  5.211 ms | 0.0524 ms | 0.0465 ms |  4.56 |    0.04 | 1257.8125 | 1218.7500 | 1000.0000 |  7905494 B |          NA |
| PLinqWithGuid                      | .NET 9.0  | .NET 9.0  | 100000 |  6.273 ms | 0.0506 ms | 0.0395 ms |  5.49 |    0.03 | 1773.4375 | 1742.1875 | 1484.3750 | 14475021 B |          NA |
