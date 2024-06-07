# Getting the string representations of many items by calling ToString() vs. caching the string value.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26231.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                             | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| HashWithStringBuilder                              | 500   |  8.314 μs | 0.2117 μs | 0.6039 μs |  1.00 |    0.00 | 2.1362 |   9.03 KB |        1.00 |
| HashWithStringDotJoin                              | 500   |  9.804 μs | 0.2404 μs | 0.6819 μs |  1.19 |    0.13 | 1.0529 |   4.47 KB |        0.49 |
| HashWithMemoryMarshalCastAndStream                 | 500   | 13.055 μs | 0.2482 μs | 0.2955 μs |  1.49 |    0.10 | 1.2512 |   5.31 KB |        0.59 |
| HashWithMemoryMarshalCastAndStreamPrecomputeLength | 500   | 14.202 μs | 0.4067 μs | 1.1733 μs |  1.72 |    0.17 | 0.7324 |   3.15 KB |        0.35 |
