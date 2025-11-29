# RandomElementsBenchmark
Picking n elements at random from a list without duplicates.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Job       | Runtime   | SourceCount | SelectCount | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------- |---------- |---------- |------------ |------------ |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| CryptographicRngWithHashSet          | .NET 10.0 | .NET 10.0 | 500         | 3           |   211.39 ns |  1.364 ns |  1.276 ns |  6.21 |    0.07 | 0.0105 |     176 B |        1.10 |
| SharedRandomWithHashSet              | .NET 10.0 | .NET 10.0 | 500         | 3           |    63.66 ns |  0.593 ns |  0.555 ns |  1.87 |    0.02 | 0.0105 |     176 B |        1.10 |
| SharedRandomWithBoolArray            | .NET 10.0 | .NET 10.0 | 500         | 3           |    43.17 ns |  0.475 ns |  0.421 ns |  1.27 |    0.02 | 0.0358 |     600 B |        3.75 |
| SharedRandomWithStackAllocBoolArray  | .NET 10.0 | .NET 10.0 | 500         | 3           |    66.25 ns |  0.495 ns |  0.463 ns |  1.94 |    0.02 | 0.0043 |      72 B |        0.45 |
| SharedRandomWithWithStackAllocBitSet | .NET 10.0 | .NET 10.0 | 500         | 3           |    48.21 ns |  0.176 ns |  0.137 ns |  1.42 |    0.01 | 0.0043 |      72 B |        0.45 |
| SharedRandomWithBitArray             | .NET 10.0 | .NET 10.0 | 500         | 3           |    34.07 ns |  0.363 ns |  0.340 ns |  1.00 |    0.01 | 0.0095 |     160 B |        1.00 |
| FisherYatesShuffleSuggestedByCopilot | .NET 10.0 | .NET 10.0 | 500         | 3           | 1,415.92 ns |  4.436 ns |  3.933 ns | 41.57 |    0.42 | 0.0095 |     160 B |        1.00 |
| ReservoirSampling                    | .NET 10.0 | .NET 10.0 | 500         | 3           | 1,532.35 ns | 10.692 ns | 10.001 ns | 44.99 |    0.52 | 0.0019 |      40 B |        0.25 |
|                                      |           |           |             |             |             |           |           |       |         |        |           |             |
| CryptographicRngWithHashSet          | .NET 9.0  | .NET 9.0  | 500         | 3           |   209.00 ns |  1.024 ns |  0.907 ns |  6.02 |    0.04 | 0.0105 |     176 B |        1.10 |
| SharedRandomWithHashSet              | .NET 9.0  | .NET 9.0  | 500         | 3           |    64.07 ns |  0.301 ns |  0.235 ns |  1.85 |    0.01 | 0.0105 |     176 B |        1.10 |
| SharedRandomWithBoolArray            | .NET 9.0  | .NET 9.0  | 500         | 3           |    43.52 ns |  0.504 ns |  0.471 ns |  1.25 |    0.01 | 0.0358 |     600 B |        3.75 |
| SharedRandomWithStackAllocBoolArray  | .NET 9.0  | .NET 9.0  | 500         | 3           |    66.73 ns |  0.563 ns |  0.499 ns |  1.92 |    0.02 | 0.0043 |      72 B |        0.45 |
| SharedRandomWithWithStackAllocBitSet | .NET 9.0  | .NET 9.0  | 500         | 3           |    49.98 ns |  0.628 ns |  0.588 ns |  1.44 |    0.02 | 0.0043 |      72 B |        0.45 |
| SharedRandomWithBitArray             | .NET 9.0  | .NET 9.0  | 500         | 3           |    34.71 ns |  0.190 ns |  0.148 ns |  1.00 |    0.01 | 0.0095 |     160 B |        1.00 |
| FisherYatesShuffleSuggestedByCopilot | .NET 9.0  | .NET 9.0  | 500         | 3           | 1,410.10 ns |  5.733 ns |  5.362 ns | 40.63 |    0.22 | 0.0095 |     160 B |        1.00 |
| ReservoirSampling                    | .NET 9.0  | .NET 9.0  | 500         | 3           | 1,524.82 ns |  2.263 ns |  1.890 ns | 43.93 |    0.19 | 0.0019 |      40 B |        0.25 |
