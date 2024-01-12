# Returning an empty sequence


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26026.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|             Method |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| EnumerableDotEmpty |  5.723 ns | 0.1251 ns | 0.1109 ns |  1.00 |    0.00 |      - |         - |          NA |
|      ArrayDotEmpty | 21.463 ns | 0.1869 ns | 0.1459 ns |  3.77 |    0.05 |      - |         - |          NA |
|      NewEmptyArray | 24.193 ns | 0.5053 ns | 0.8983 ns |  4.29 |    0.20 | 0.0055 |      24 B |          NA |
|       NewEmptyList | 18.030 ns | 0.4189 ns | 0.4302 ns |  3.14 |    0.08 | 0.0074 |      32 B |          NA |
