# Simple dictionary lookup benchmark.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27852.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                | Count | Mean      | Error     | StdDev   | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------- |------ |----------:|----------:|---------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingDictionaryInt              | 1000  |  6.124 ns | 0.4361 ns | 1.251 ns |  5.993 ns |  1.00 |    0.00 |         - |          NA |
| LookupUsingFrozenDictionaryInt        | 1000  |  4.600 ns | 0.4972 ns | 1.466 ns |  3.839 ns |  0.78 |    0.30 |         - |          NA |
| LookupUsingConcurrentDictionaryInt    | 1000  |  6.125 ns | 0.5403 ns | 1.533 ns |  5.659 ns |  1.04 |    0.34 |         - |          NA |
| LookupUsingLockedDictionaryInt        | 1000  | 20.807 ns | 0.6921 ns | 1.883 ns | 20.319 ns |  3.47 |    0.72 |         - |          NA |
| LookupUsingReaderWriterLockInt        | 1000  | 31.468 ns | 1.6656 ns | 4.832 ns | 29.427 ns |  5.36 |    1.35 |         - |          NA |
| LookupUsingReaderWriterLockSlimInt    | 1000  | 38.458 ns | 1.6243 ns | 4.789 ns | 36.571 ns |  6.52 |    1.42 |         - |          NA |
| LookupUsingDictionaryString           | 1000  | 13.115 ns | 1.1731 ns | 3.441 ns | 11.494 ns |  2.23 |    0.75 |         - |          NA |
| LookupUsingFrozenDictionaryString     | 1000  |  8.694 ns | 0.7157 ns | 2.110 ns |  8.312 ns |  1.47 |    0.42 |         - |          NA |
| LookupUsingConcurrentDictionaryString | 1000  | 15.192 ns | 1.3671 ns | 4.031 ns | 13.377 ns |  2.57 |    0.87 |         - |          NA |
| LookupUsingLockedDictionaryString     | 1000  | 30.382 ns | 1.9214 ns | 5.665 ns | 28.199 ns |  5.16 |    1.42 |         - |          NA |
| LookupUsingReaderWriterLockString     | 1000  | 38.048 ns | 2.2605 ns | 6.226 ns | 35.449 ns |  6.39 |    1.60 |         - |          NA |
| LookupUsingReaderWriterLockSlimString | 1000  | 50.968 ns | 2.4191 ns | 7.133 ns | 49.550 ns |  8.71 |    2.21 |         - |          NA |
