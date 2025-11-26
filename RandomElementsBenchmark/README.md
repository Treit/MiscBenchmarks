# RandomElementsBenchmark
Picking n elements at random from a list without duplicates.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | SourceCount | SelectCount | Mean        | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------- |------------ |------------ |------------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| CryptographicRngWithHashSet          | 500         | 3           |   206.73 ns | 0.960 ns | 0.898 ns |  5.83 |    0.07 | 0.0105 |     176 B |        1.10 |
| SharedRandomWithHashSet              | 500         | 3           |    65.34 ns | 0.627 ns | 0.556 ns |  1.84 |    0.03 | 0.0105 |     176 B |        1.10 |
| SharedRandomWithBoolArray            | 500         | 3           |    43.91 ns | 0.737 ns | 0.689 ns |  1.24 |    0.02 | 0.0358 |     600 B |        3.75 |
| SharedRandomWithStackAllocBoolArray  | 500         | 3           |    68.07 ns | 0.784 ns | 0.733 ns |  1.92 |    0.03 | 0.0043 |      72 B |        0.45 |
| SharedRandomWithWithStackAllocBitSet | 500         | 3           |    49.40 ns | 0.731 ns | 0.648 ns |  1.39 |    0.02 | 0.0043 |      72 B |        0.45 |
| SharedRandomWithBitArray             | 500         | 3           |    35.46 ns | 0.487 ns | 0.431 ns |  1.00 |    0.02 | 0.0095 |     160 B |        1.00 |
| FisherYatesShuffleSuggestedByCopilot | 500         | 3           | 1,405.65 ns | 7.434 ns | 6.590 ns | 39.65 |    0.50 | 0.0095 |     160 B |        1.00 |
| ReservoirSampling                    | 500         | 3           | 1,540.85 ns | 6.147 ns | 5.449 ns | 43.46 |    0.53 | 0.0019 |      40 B |        0.25 |
