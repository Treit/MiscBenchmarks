# RandomElementsBenchmark
Picking n elements at random from a list without duplicates.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27887.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                               | SourceCount | SelectCount | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------- |------------ |------------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| CryptographicRngWithHashSet          | 500         | 3           | 411.21 ns | 13.814 ns | 37.817 ns | 400.54 ns |  5.58 |    0.77 | 0.0553 |     240 B |        1.50 |
| SharedRandomWithHashSet              | 500         | 3           | 132.20 ns |  4.077 ns | 11.499 ns | 130.38 ns |  1.80 |    0.24 | 0.0556 |     240 B |        1.50 |
| SharedRandomWithBoolArray            | 500         | 3           | 119.95 ns |  5.325 ns | 15.277 ns | 114.61 ns |  1.63 |    0.27 | 0.1391 |     600 B |        3.75 |
| SharedRandomWithStackAllocBoolArray  | 500         | 3           |  82.06 ns |  2.988 ns |  8.179 ns |  80.99 ns |  1.11 |    0.16 | 0.0167 |      72 B |        0.45 |
| SharedRandomWithWithStackAllocBitSet | 500         | 3           |  77.42 ns |  2.624 ns |  7.488 ns |  75.91 ns |  1.05 |    0.15 | 0.0167 |      72 B |        0.45 |
| SharedRandomWithBitArray             | 500         | 3           |  74.48 ns |  2.806 ns |  8.097 ns |  73.60 ns |  1.01 |    0.15 | 0.0371 |     160 B |        1.00 |
