# Iterating a List with and without CollectionsMarshal.AsSpan






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Count  | Mean     | Error    | StdDev   | Ratio | RatioSD |
|-------------------------------------------- |------- |---------:|---------:|---------:|------:|--------:|
| IterateUsingForEach                         | 100000 | 62.70 μs | 0.599 μs | 0.560 μs |  1.95 |    0.03 |
| IterateUsingForEachCollectionsMarshalAsSpan | 100000 | 32.08 μs | 0.398 μs | 0.353 μs |  1.00 |    0.02 |
