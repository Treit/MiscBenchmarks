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
| CheckWithTryParse                       | 1000  | 41.01 μs | 0.573 μs | 0.536 μs |  1.17 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompare                  | 1000  | 35.06 μs | 0.577 μs | 0.540 μs |  1.00 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronSearchValues | 1000  | 45.98 μs | 0.666 μs | 0.623 μs |  1.31 |    0.03 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronFrozenSet    | 1000  | 40.79 μs | 0.366 μs | 0.342 μs |  1.16 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
