# Making HashSets


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|           Method |     Mean |     Error |    StdDev | Ratio |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|----------------- |---------:|----------:|----------:|------:|---------:|---------:|---------:|----------:|------------:|
|      ToCharArray | 3.662 ms | 0.0277 ms | 0.0259 ms |  1.00 | 523.4375 | 523.4375 | 523.4375 |    2.8 MB |        1.00 |
| ValueSpanToArray | 2.900 ms | 0.0158 ms | 0.0148 ms |  0.79 | 375.0000 | 375.0000 | 375.0000 |   1.87 MB |        0.67 |
