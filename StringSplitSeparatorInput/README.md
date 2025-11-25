# string.Split with different types of separator input




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------- |------ |---------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| SplitWithSingleChar      | 100   | 1.721 μs | 0.0238 μs | 0.0223 μs |  1.00 |    0.02 | 0.2251 | 0.0019 |    3.7 KB |        1.00 |
| SplitWithSingleString    | 100   | 2.482 μs | 0.0326 μs | 0.0305 μs |  1.44 |    0.02 | 0.2251 |      - |    3.7 KB |        1.00 |
| SplitWithNewCharArray    | 100   | 1.709 μs | 0.0125 μs | 0.0117 μs |  0.99 |    0.01 | 0.2270 | 0.0019 |   3.73 KB |        1.01 |
| SplitWithStaticCharArray | 100   | 1.652 μs | 0.0129 μs | 0.0120 μs |  0.96 |    0.01 | 0.2251 | 0.0019 |    3.7 KB |        1.00 |
