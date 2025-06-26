# RandomElementsBenchmark
Picking n elements at random from a list without duplicates.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27887.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                          | SourceCount | SelectCount | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------------ |------------ |------------ |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| KeyCollectionToArrayCryptographicRngWithHashSet | 500         | 3           | 998.20 ns | 19.921 ns | 34.363 ns | 16.80 |    1.02 | 0.5245 |    2264 B |       14.15 |
| CryptographicRngWithHashSet                     | 500         | 3           | 354.96 ns |  7.071 ns |  9.679 ns |  5.97 |    0.34 | 0.0553 |     240 B |        1.50 |
| SharedRandomWithHashSet                         | 500         | 3           | 113.27 ns |  2.420 ns |  7.020 ns |  1.91 |    0.15 | 0.0556 |     240 B |        1.50 |
| SharedRandomWithBoolArray                       | 500         | 3           |  87.90 ns |  2.377 ns |  6.820 ns |  1.48 |    0.14 | 0.1391 |     600 B |        3.75 |
| SharedRandomWithStackAllocBoolArray             | 500         | 3           |  67.16 ns |  1.411 ns |  2.238 ns |  1.13 |    0.07 | 0.0167 |      72 B |        0.45 |
| SharedRandomWithWithStackAllocBitSet            | 500         | 3           |  64.19 ns |  1.346 ns |  2.781 ns |  1.08 |    0.07 | 0.0167 |      72 B |        0.45 |
| SharedRandomWithBitArray                        | 500         | 3           |  59.58 ns |  1.265 ns |  3.079 ns |  1.00 |    0.07 | 0.0371 |     160 B |        1.00 |
