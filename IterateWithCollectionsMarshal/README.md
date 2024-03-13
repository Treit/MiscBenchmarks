# Iterating a List with and without CollectionsMarshal.AsSpan




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26080.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                  | Count  | Mean     | Error    | StdDev   | Ratio | RatioSD |
|---------------------------------------- |------- |---------:|---------:|---------:|------:|--------:|
| SumUsingForEach                         | 100000 | 61.46 μs | 0.798 μs | 0.746 μs |  1.76 |    0.03 |
| SumUsingForEachCollectionsMarshalAsSpan | 100000 | 34.92 μs | 0.570 μs | 0.505 μs |  1.00 |    0.00 |
