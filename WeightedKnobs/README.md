# Test getting random weighted values






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                             | Job       | Runtime   | Count | Mean         | Error      | StdDev     | Ratio  | RatioSD | Gen0      | Gen1      | Gen2     | Allocated   | Alloc Ratio |
|----------------------------------- |---------- |---------- |------ |-------------:|-----------:|-----------:|-------:|--------:|----------:|----------:|---------:|------------:|------------:|
| GetRandomWeightedKnobsOriginal     | .NET 10.0 | .NET 10.0 | 5000  | 38,142.98 μs | 319.612 μs | 298.965 μs | 596.23 |    6.39 | 1000.0000 |  928.5714 | 500.0000 | 13074.48 KB |      166.95 |
| GetRandomWeightedKnobsBinarySearch | .NET 10.0 | .NET 10.0 | 5000  |    134.62 μs |   1.110 μs |   1.038 μs |   2.10 |    0.02 |    4.6387 |    0.4883 |        - |    78.38 KB |        1.00 |
| GetRandomWeightedKnobsFenwickTree  | .NET 10.0 | .NET 10.0 | 5000  |     63.98 μs |   0.537 μs |   0.503 μs |   1.00 |    0.01 |    4.7607 |    0.4883 |        - |    78.31 KB |        1.00 |
|                                    |           |           |       |              |            |            |        |         |           |           |          |             |             |
| GetRandomWeightedKnobsOriginal     | .NET 9.0  | .NET 9.0  | 5000  | 38,114.22 μs | 394.781 μs | 369.279 μs | 564.18 |   15.52 | 1076.9231 | 1000.0000 | 538.4615 | 13065.55 KB |      166.84 |
| GetRandomWeightedKnobsBinarySearch | .NET 9.0  | .NET 9.0  | 5000  |    134.18 μs |   1.467 μs |   1.372 μs |   1.99 |    0.05 |    4.6387 |    0.4883 |        - |    78.38 KB |        1.00 |
| GetRandomWeightedKnobsFenwickTree  | .NET 9.0  | .NET 9.0  | 5000  |     67.61 μs |   1.344 μs |   1.970 μs |   1.00 |    0.04 |    4.7607 |    0.4883 |        - |    78.31 KB |        1.00 |
