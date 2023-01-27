# MemoryStream with and without 'using'


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25284.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
|                     Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|--------------------------- |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
|          WriteMemoryStream | 5.083 μs | 0.1149 μs | 0.3332 μs | 5.066 μs |  1.00 |    0.00 | 0.6866 |   2.91 KB |        1.00 |
| WriteMemoryStreamWithUsing | 6.014 μs | 0.2150 μs | 0.6170 μs | 5.808 μs |  1.19 |    0.15 | 0.6866 |   2.91 KB |        1.00 |
