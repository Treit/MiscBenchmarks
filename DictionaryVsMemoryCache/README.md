# Dictionary vs MemoryCache

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27779.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| LookupUsingDictionary           | 1000  |  10.48 ns | 0.140 ns | 0.131 ns |  1.00 |    0.00 |      - |         - |          NA |
| LookupUsingMemoryCache          | 1000  | 121.46 ns | 2.151 ns | 2.871 ns | 11.67 |    0.32 | 0.0074 |      32 B |          NA |
| LookupUsingConcurrentDictionary | 1000  |  12.37 ns | 0.239 ns | 0.223 ns |  1.18 |    0.03 |      - |         - |          NA |
