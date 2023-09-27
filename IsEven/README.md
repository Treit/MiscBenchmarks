# Is it even?

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25961.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|                           Method |  Count |       Mean |    Error |   StdDev | Ratio | RatioSD |      Gen0 | Allocated | Alloc Ratio |
|--------------------------------- |------- |-----------:|---------:|---------:|------:|--------:|----------:|----------:|------------:|
|                   IsEvenUsingMod | 100000 |   406.0 μs |  7.72 μs |  9.76 μs |  1.00 |    0.00 |         - |         - |          NA |
| IsEvenUsingINumberIsEvenInteger | 100000 |   410.4 μs |  7.90 μs |  9.41 μs |  1.01 |    0.04 |         - |         - |          NA |
|                  IsEvenlyxerexyl | 100000 | 3,164.1 μs | 60.03 μs | 61.65 μs |  7.82 |    0.24 | 1023.4375 | 4427778 B |          NA |
|                   IsEvenMrCarrot | 100000 |   597.0 μs |  3.90 μs |  3.46 μs |  1.48 |    0.03 |         - |         - |          NA |
|                      IsEvenAaron | 100000 |   389.7 μs |  5.01 μs |  4.18 μs |  0.97 |    0.02 |         - |         - |          NA |
|    IsEvenAaronUnsafeBitConverter | 100000 |   686.4 μs | 13.71 μs | 17.83 μs |  1.69 |    0.06 |         - |         - |          NA |
