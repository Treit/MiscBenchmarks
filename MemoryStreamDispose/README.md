# MemoryStream with and without 'using'



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                     Method |     Mean |     Error |    StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|--------------------------- |---------:|----------:|----------:|------:|-------:|----------:|------------:|
|          WriteMemoryStream | 1.973 μs | 0.0084 μs | 0.0074 μs |  1.00 | 0.1755 |   2.91 KB |        1.00 |
| WriteMemoryStreamWithUsing | 1.943 μs | 0.0084 μs | 0.0070 μs |  0.99 | 0.1755 |   2.91 KB |        1.00 |
