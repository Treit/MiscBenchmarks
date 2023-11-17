# Getting the string representation of enum values.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25997.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|                     Method | Count |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |     Gen0 |  Allocated | Alloc Ratio |
|--------------------------- |------ |---------:|---------:|---------:|---------:|------:|--------:|---------:|-----------:|------------:|
|               EnumToString | 10000 | 938.4 μs | 18.67 μs | 46.50 μs | 927.4 μs |  1.00 |    0.00 | 277.3438 | 1172.03 KB |        1.00 |
| CustomGetStringUsingSwitch | 10000 | 207.8 μs |  4.64 μs | 13.52 μs | 203.2 μs |  0.22 |    0.02 |  55.4199 |  234.41 KB |        0.20 |
