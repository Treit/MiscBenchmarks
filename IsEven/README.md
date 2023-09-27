# Is it even?

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25961.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|                               Method |  Count |       Mean |    Error |   StdDev | Ratio | RatioSD |     Gen0 | Allocated | Alloc Ratio |
|------------------------------------- |------- |-----------:|---------:|---------:|------:|--------:|---------:|----------:|------------:|
|                       IsEvenUsingMod | 100000 |   402.6 μs |  2.30 μs |  1.92 μs |  1.00 |    0.00 |        - |         - |          NA |
|      IsEvenUsingINumberIsEvenInteger | 100000 |   403.0 μs |  5.00 μs |  4.43 μs |  1.00 |    0.01 |        - |         - |          NA |
|                      IsEvenlyxerexyl | 100000 | 1,696.0 μs | 33.50 μs | 39.88 μs |  4.24 |    0.13 | 263.6719 | 1142625 B |          NA |
|                       IsEvenMrCarrot | 100000 |   595.9 μs | 10.02 μs |  8.37 μs |  1.48 |    0.03 |        - |         - |          NA |
|                          IsEvenAaron | 100000 |   380.3 μs |  2.67 μs |  2.08 μs |  0.94 |    0.01 |        - |         - |          NA |
|        IsEvenAaronUnsafeBitConverter | 100000 |   659.9 μs | 12.58 μs | 24.25 μs |  1.65 |    0.06 |        - |         - |          NA |
| IsEvenCrabFuelCursedRecursiveVersion | 100000 | 1,621.5 μs | 15.16 μs | 13.44 μs |  4.03 |    0.04 |        - |       1 B |          NA |
