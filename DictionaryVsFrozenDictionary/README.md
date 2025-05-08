# Regular dictionary vs FrozeDictionary.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27852.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                            | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingDictionaryInt          | 1000  |  5.274 ns | 0.5414 ns | 1.5963 ns |  4.590 ns |  1.00 |    0.00 |         - |          NA |
| LookupUsingFrozenDictionaryInt    | 1000  |  3.552 ns | 0.2110 ns | 0.6189 ns |  3.426 ns |  0.73 |    0.24 |         - |          NA |
| LookupUsingDictionaryString       | 1000  | 11.374 ns | 0.7518 ns | 2.1569 ns | 10.552 ns |  2.31 |    0.73 |         - |          NA |
| LookupUsingFrozenDictionaryString | 1000  |  8.608 ns | 0.5953 ns | 1.7365 ns |  8.297 ns |  1.77 |    0.61 |         - |          NA |
