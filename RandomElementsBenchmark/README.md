# RandomElementsBenchmark
Picking n elements at random from a list without duplicates.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27891.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                               | SourceCount | SelectCount | Mean        | Error      | StdDev    | Median      | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------- |------------ |------------ |------------:|-----------:|----------:|------------:|------:|--------:|-------:|----------:|------------:|
| CryptographicRngWithHashSet          | 500         | 3           |   475.87 ns |  34.133 ns | 100.64 ns |   446.88 ns |  5.48 |    1.91 | 0.0553 |     240 B |        1.50 |
| SharedRandomWithHashSet              | 500         | 3           |   166.08 ns |  13.648 ns |  40.24 ns |   151.71 ns |  1.91 |    0.71 | 0.0556 |     240 B |        1.50 |
| SharedRandomWithBoolArray            | 500         | 3           |   131.84 ns |  10.389 ns |  30.63 ns |   130.27 ns |  1.52 |    0.55 | 0.1391 |     600 B |        3.75 |
| SharedRandomWithStackAllocBoolArray  | 500         | 3           |    93.27 ns |   9.149 ns |  26.98 ns |    82.29 ns |  1.07 |    0.43 | 0.0167 |      72 B |        0.45 |
| SharedRandomWithWithStackAllocBitSet | 500         | 3           |    93.17 ns |   9.222 ns |  27.19 ns |    78.90 ns |  1.07 |    0.44 | 0.0167 |      72 B |        0.45 |
| SharedRandomWithBitArray             | 500         | 3           |    94.00 ns |   9.292 ns |  27.40 ns |    90.34 ns |  1.08 |    0.44 | 0.0370 |     160 B |        1.00 |
| FisherYatesShuffleSuggestedByCopilot | 500         | 3           | 2,057.75 ns |  41.165 ns | 109.16 ns | 2,040.25 ns | 23.70 |    6.58 | 0.0343 |     160 B |        1.00 |
| ReservoirSampling                    | 500         | 3           | 3,619.32 ns | 116.353 ns | 324.34 ns | 3,539.21 ns | 41.69 |   11.98 | 0.0076 |      40 B |        0.25 |
