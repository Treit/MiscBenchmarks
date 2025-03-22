# Validating if a retrieved value represent a boolean value of 'true'.






```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27818.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                  | Count | Mean     | Error    | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------- |------ |---------:|---------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| CheckWithTryParse                       | 1000  | 82.46 μs | 6.332 μs | 18.670 μs | 73.70 μs |  1.58 |    0.36 | 9.0332 |  38.28 KB |        1.00 |
| CheckWithStringCompare                  | 1000  | 60.31 μs | 1.140 μs |  1.967 μs | 59.40 μs |  1.00 |    0.00 | 9.0332 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronSearchValues | 1000  | 78.05 μs | 1.513 μs |  1.859 μs | 77.55 μs |  1.28 |    0.06 | 9.0332 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaronFrozenSet    | 1000  | 63.11 μs | 1.077 μs |  2.643 μs | 62.50 μs |  1.06 |    0.05 | 9.0332 |  38.28 KB |        1.00 |
