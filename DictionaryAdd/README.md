# Adding items to a dictionary


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27793.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Count | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| CopyDictWithForEachLoop         | 100   | 5.253 μs | 0.0930 μs | 0.1143 μs | 5.218 μs |  3.86 |    0.08 | 2.3727 |  10.01 KB |        3.28 |
| CopyDictPresetCapacity          | 100   | 3.084 μs | 0.0548 μs | 0.0485 μs | 3.077 μs |  2.25 |    0.04 | 0.7362 |   3.11 KB |        1.02 |
| CopyDictWithConstructor         | 100   | 1.371 μs | 0.0245 μs | 0.0217 μs | 1.373 μs |  1.00 |    0.00 | 0.7248 |   3.05 KB |        1.00 |
| CopyDictWithToDictionaryLambdas | 100   | 3.153 μs | 0.0516 μs | 0.0706 μs | 3.125 μs |  2.31 |    0.08 | 0.7362 |   3.11 KB |        1.02 |
| CopyDictWithToDictionary        | 100   | 1.414 μs | 0.0313 μs | 0.0872 μs | 1.388 μs |  1.03 |    0.07 | 0.7248 |   3.05 KB |        1.00 |
