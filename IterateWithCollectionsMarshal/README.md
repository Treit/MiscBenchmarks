# Iterating a List with and without CollectionsMarshal.AsSpan





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26080.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                      | Count  | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD |
|-------------------------------------------- |------- |---------:|---------:|---------:|---------:|------:|--------:|
| IterateUsingForEach                         | 100000 | 64.12 μs | 1.266 μs | 2.884 μs | 63.09 μs |  1.92 |    0.07 |
| IterateUsingForEachCollectionsMarshalAsSpan | 100000 | 35.29 μs | 0.237 μs | 0.210 μs | 35.23 μs |  1.00 |    0.00 |
