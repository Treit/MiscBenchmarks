# Shuffle Benchmarks





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count  | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated  | Alloc Ratio |
|----------------------------------- |------- |----------:|----------:|----------:|------:|--------:|----------:|----------:|----------:|-----------:|------------:|
| FisherYates                        | 100000 |  1.151 ms | 0.0067 ms | 0.0063 ms |  1.00 |    0.01 |         - |         - |         - |          - |          NA |
| FisherYatesAscending               | 100000 |  1.144 ms | 0.0075 ms | 0.0070 ms |  0.99 |    0.01 |         - |         - |         - |          - |          NA |
| FisherYatesXorSwap                 | 100000 |  1.207 ms | 0.0060 ms | 0.0056 ms |  1.05 |    0.01 |         - |         - |         - |          - |          NA |
| FisherYatesUsingStrongCryptoRandom | 100000 |  8.146 ms | 0.0624 ms | 0.0584 ms |  7.08 |    0.06 |         - |         - |         - |          - |          NA |
| FisherYatesDynamic                 | 100000 |  6.220 ms | 0.0917 ms | 0.0858 ms |  5.40 |    0.08 | 1140.6250 |         - |         - | 19199952 B |          NA |
| Sattolo                            | 100000 |  1.137 ms | 0.0075 ms | 0.0070 ms |  0.99 |    0.01 |         - |         - |         - |          - |          NA |
| LinqWithRandom                     | 100000 | 10.501 ms | 0.0622 ms | 0.0551 ms |  9.12 |    0.07 |  484.3750 |  484.3750 |  484.3750 |  1600659 B |          NA |
| LinqWithGuid                       | 100000 | 21.204 ms | 0.1271 ms | 0.1189 ms | 18.42 |    0.14 |  531.2500 |  531.2500 |  531.2500 |  2803939 B |          NA |
| PLinqWithRandom                    | 100000 |  5.359 ms | 0.0771 ms | 0.0722 ms |  4.66 |    0.07 | 1257.8125 | 1218.7500 | 1000.0000 |  7905530 B |          NA |
| PLinqWithGuid                      | 100000 |  6.442 ms | 0.0878 ms | 0.0686 ms |  5.60 |    0.06 | 1789.0625 | 1757.8125 | 1500.0000 | 14474699 B |          NA |
