# Checking if dictionaries are empty

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25900.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2


```
|                         Method | Count |     Mean |    Error |   StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |------ |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| CheckDictionaryEmptyUsingCount |  1000 | 10.51 μs | 0.210 μs | 0.327 μs |  1.00 |    0.00 |      40 B |        1.00 |
|   CheckDictionaryEmptyUsingAny |  1000 | 18.23 μs | 0.219 μs | 0.183 μs |  1.75 |    0.05 |      40 B |        1.00 |
