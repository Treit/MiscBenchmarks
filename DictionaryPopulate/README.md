# Populating a dictionary from an existing dictionary using some specific logic.

The scenario here is from production real-world code, where we are updating a dictionary with values from another dictionary. The majority of the keys are not present in the second dictionary, so we need to set those to zero in the target dictionary.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Job       | Runtime   | Count | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|-------------------------------------------- |---------- |---------- |------ |---------:|--------:|--------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| PopulateOriginalWithThreeChecksAndTryAdd    | .NET 10.0 | .NET 10.0 | 5000  | 479.2 μs | 2.50 μs | 2.22 μs |  1.14 |    0.01 | 90.8203 | 90.8203 | 90.8203 | 721.66 KB |        1.64 |
| PopulateWithThreeChecksAndAdd               | .NET 10.0 | .NET 10.0 | 5000  | 476.9 μs | 5.04 μs | 4.72 μs |  1.14 |    0.01 | 90.8203 | 90.8203 | 90.8203 | 721.73 KB |        1.64 |
| PopulateWithThreeChecksAndIndexerAssignment | .NET 10.0 | .NET 10.0 | 5000  | 479.4 μs | 4.61 μs | 4.31 μs |  1.14 |    0.01 | 90.8203 | 90.8203 | 90.8203 | 721.73 KB |        1.64 |
| PopulateWithInitializeToZeroAndThenUpdate   | .NET 10.0 | .NET 10.0 | 5000  | 419.9 μs | 2.24 μs | 2.10 μs |  1.00 |    0.01 | 43.4570 | 43.4570 | 43.4570 | 440.66 KB |        1.00 |
|                                             |           |           |       |          |         |         |       |         |         |         |         |           |             |
| PopulateOriginalWithThreeChecksAndTryAdd    | .NET 9.0  | .NET 9.0  | 5000  | 477.2 μs | 4.07 μs | 3.81 μs |  1.12 |    0.01 | 90.8203 | 90.8203 | 90.8203 | 721.66 KB |        1.64 |
| PopulateWithThreeChecksAndAdd               | .NET 9.0  | .NET 9.0  | 5000  | 476.1 μs | 5.43 μs | 5.08 μs |  1.12 |    0.02 | 90.8203 | 90.8203 | 90.8203 | 721.73 KB |        1.64 |
| PopulateWithThreeChecksAndIndexerAssignment | .NET 9.0  | .NET 9.0  | 5000  | 478.1 μs | 6.45 μs | 6.04 μs |  1.13 |    0.02 | 90.8203 | 90.8203 | 90.8203 | 721.75 KB |        1.64 |
| PopulateWithInitializeToZeroAndThenUpdate   | .NET 9.0  | .NET 9.0  | 5000  | 424.9 μs | 4.12 μs | 3.85 μs |  1.00 |    0.01 | 43.4570 | 43.4570 | 43.4570 | 440.66 KB |        1.00 |
