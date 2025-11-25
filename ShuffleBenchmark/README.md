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
| FisherYates                        | 100000 |  1.149 ms | 0.0060 ms | 0.0056 ms |  1.00 |    0.01 |         - |         - |         - |          - |          NA |
| FisherYatesAscending               | 100000 |  1.140 ms | 0.0080 ms | 0.0075 ms |  0.99 |    0.01 |         - |         - |         - |          - |          NA |
| FisherYatesXorSwap                 | 100000 |  1.201 ms | 0.0061 ms | 0.0057 ms |  1.04 |    0.01 |         - |         - |         - |          - |          NA |
| FisherYatesUsingStrongCryptoRandom | 100000 |  8.107 ms | 0.0612 ms | 0.0572 ms |  7.05 |    0.06 |         - |         - |         - |          - |          NA |
| FisherYatesDynamic                 | 100000 |  7.554 ms | 0.0526 ms | 0.0492 ms |  6.57 |    0.05 | 1140.6250 |         - |         - | 19199952 B |          NA |
| Sattolo                            | 100000 |  1.131 ms | 0.0078 ms | 0.0073 ms |  0.98 |    0.01 |         - |         - |         - |          - |          NA |
| LinqWithRandom                     | 100000 | 10.626 ms | 0.0666 ms | 0.0623 ms |  9.24 |    0.07 |  484.3750 |  484.3750 |  484.3750 |  1600659 B |          NA |
| LinqWithGuid                       | 100000 | 20.978 ms | 0.0923 ms | 0.0863 ms | 18.25 |    0.11 |  531.2500 |  531.2500 |  531.2500 |  2803856 B |          NA |
| PLinqWithRandom                    | 100000 |  5.330 ms | 0.0848 ms | 0.0794 ms |  4.64 |    0.07 | 1257.8125 | 1210.9375 | 1000.0000 |  7907487 B |          NA |
| PLinqWithGuid                      | 100000 |  6.399 ms | 0.0634 ms | 0.0562 ms |  5.57 |    0.05 | 1789.0625 | 1757.8125 | 1500.0000 | 14475486 B |          NA |
