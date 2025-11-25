# Validating if a retrieved value represent a boolean value of 'true'.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                  | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| CheckWithTryParse                       | 1000  | 41.36 μs | 0.421 μs | 0.374 μs |  1.22 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompare                  | 1000  | 33.86 μs | 0.450 μs | 0.421 μs |  1.00 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronSearchValues | 1000  | 46.17 μs | 0.416 μs | 0.369 μs |  1.36 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronFrozenSet    | 1000  | 39.91 μs | 0.566 μs | 0.529 μs |  1.18 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
