# Regular dictionary vs FrozeDictionary.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26020.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
|                      Method | Count |     Mean |     Error |   StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |------ |---------:|----------:|---------:|---------:|------:|--------:|----------:|------------:|
|       LookupUsingDictionary |  1000 | 7.114 ns | 0.3978 ns | 1.167 ns | 6.918 ns |  1.00 |    0.00 |         - |          NA |
| LookupUsingFrozenDictionary |  1000 | 5.227 ns | 0.4741 ns | 1.391 ns | 4.804 ns |  0.76 |    0.24 |         - |          NA |
