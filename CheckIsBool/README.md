# Validating if a retrieved value represent a boolean value of 'true'.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27818.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| CheckWithTryParse           | 1000  | 63.53 μs | 1.234 μs | 1.421 μs |  1.01 |    0.06 | 9.0332 |  38.28 KB |        1.00 |
| CheckWithStringCompare      | 1000  | 60.75 μs | 1.214 μs | 2.789 μs |  1.00 |    0.00 | 9.0332 |  38.28 KB |        1.00 |
| CheckWithStringCompareAaron | 1000  | 79.32 μs | 1.525 μs | 1.757 μs |  1.27 |    0.08 | 9.0332 |  38.28 KB |        1.00 |
