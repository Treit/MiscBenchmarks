# Populating a dictionary from an existing dictionary using some specific logic.

The scenario here is from production real-world code, where we are updating a dictionary with values from another dictionary. The majority of the keys are not present in the second dictionary, so we need to set those to zero in the target dictionary.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Count | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|-------------------------------------------- |------ |---------:|---------:|---------:|---------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| PopulateOriginalWithThreeChecksAndTryAdd    | 5000  | 540.8 μs | 10.71 μs | 21.14 μs | 545.9 μs |  1.19 |    0.05 | 90.8203 | 90.8203 | 90.8203 | 721.66 KB |        1.64 |
| PopulateWithThreeChecksAndAdd               | 5000  | 538.5 μs | 10.68 μs | 26.61 μs | 546.8 μs |  1.19 |    0.06 | 90.8203 | 90.8203 | 90.8203 | 721.73 KB |        1.64 |
| PopulateWithThreeChecksAndIndexerAssignment | 5000  | 539.9 μs |  6.52 μs |  6.10 μs | 539.7 μs |  1.19 |    0.01 | 90.8203 | 90.8203 | 90.8203 | 721.66 KB |        1.64 |
| PopulateWithInitializeToZeroAndThenUpdate   | 5000  | 454.3 μs |  2.95 μs |  2.47 μs | 454.0 μs |  1.00 |    0.01 | 43.4570 | 43.4570 | 43.4570 | 440.66 KB |        1.00 |
