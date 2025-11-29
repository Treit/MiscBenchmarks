# Validating if a retrieved value represent a boolean value of 'true'.









```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                  | Job       | Runtime   | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------- |---------- |---------- |------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| CheckWithTryParse                       | .NET 10.0 | .NET 10.0 | 1000  | 42.84 μs | 0.695 μs | 0.616 μs |  1.20 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompare                  | .NET 10.0 | .NET 10.0 | 1000  | 35.72 μs | 0.590 μs | 0.523 μs |  1.00 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronSearchValues | .NET 10.0 | .NET 10.0 | 1000  | 46.75 μs | 0.439 μs | 0.411 μs |  1.31 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronFrozenSet    | .NET 10.0 | .NET 10.0 | 1000  | 40.04 μs | 0.536 μs | 0.501 μs |  1.12 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
|                                         |           |           |       |          |          |          |       |         |        |           |             |
| CheckWithTryParse                       | .NET 9.0  | .NET 9.0  | 1000  | 42.12 μs | 0.578 μs | 0.540 μs |  1.17 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompare                  | .NET 9.0  | .NET 9.0  | 1000  | 36.07 μs | 0.548 μs | 0.486 μs |  1.00 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronSearchValues | .NET 9.0  | .NET 9.0  | 1000  | 48.82 μs | 0.550 μs | 0.514 μs |  1.35 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronFrozenSet    | .NET 9.0  | .NET 9.0  | 1000  | 40.10 μs | 0.654 μs | 0.580 μs |  1.11 |    0.02 | 2.3193 |  38.28 KB |        1.00 |
