# Dictionary vs arrays to produce two separate sets of strings
Using a Dictionary as a bag to hold sets of keys and values and then passing those to methods that require arrays, vs. just building two arrays. This was seen in some production code in a hot path and thus allocating a lot more memory than necessary.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------- |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
| BuildDictionaryAndThenUseToArray | 909.9 ns | 5.64 ns | 5.00 ns |  2.39 |    0.03 | 0.1545 |   2.54 KB |        1.91 |
| BuildTwoArraysDirectly           | 380.3 ns | 4.42 ns | 3.92 ns |  1.00 |    0.01 | 0.0811 |   1.33 KB |        1.00 |
