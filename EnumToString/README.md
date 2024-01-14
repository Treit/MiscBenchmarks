# Getting the string representation of enum values.



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                     Method | Count |      Mean |    Error |   StdDev | Ratio |    Gen0 |  Allocated | Alloc Ratio |
|--------------------------- |------ |----------:|---------:|---------:|------:|--------:|-----------:|------------:|
|               EnumToString | 10000 | 432.16 μs | 5.238 μs | 4.899 μs |  1.00 | 71.2891 | 1171.91 KB |        1.00 |
| CustomGetStringUsingSwitch | 10000 |  90.96 μs | 0.846 μs | 0.792 μs |  0.21 | 14.2822 |  234.38 KB |        0.20 |
