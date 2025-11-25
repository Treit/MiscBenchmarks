# Populating a dictionary from an existing dictionary using some specific logic.

The scenario here is from production real-world code, where we are updating a dictionary with values from another dictionary. The majority of the keys are not present in the second dictionary, so we need to set those to zero in the target dictionary.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|-------------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| PopulateOriginalWithThreeChecksAndTryAdd    | 5000  | 540.0 μs | 10.53 μs | 15.76 μs |  1.20 |    0.05 | 90.8203 | 90.8203 | 90.8203 | 721.66 KB |        1.64 |
| PopulateWithThreeChecksAndAdd               | 5000  | 541.6 μs | 10.61 μs | 20.69 μs |  1.21 |    0.06 | 90.8203 | 90.8203 | 90.8203 | 721.66 KB |        1.64 |
| PopulateWithThreeChecksAndIndexerAssignment | 5000  | 545.7 μs | 10.80 μs | 19.48 μs |  1.21 |    0.06 | 90.8203 | 90.8203 | 90.8203 | 721.66 KB |        1.64 |
| PopulateWithInitializeToZeroAndThenUpdate   | 5000  | 449.6 μs |  8.78 μs | 13.40 μs |  1.00 |    0.04 | 43.4570 | 43.4570 | 43.4570 | 440.66 KB |        1.00 |
