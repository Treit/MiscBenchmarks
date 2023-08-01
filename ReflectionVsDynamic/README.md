```

BenchmarkDotNet v0.13.6, Arch Linux
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.100-preview.6.23330.14
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|                Method |      Mean |     Error |    StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|---------------------- |----------:|----------:|----------:|------:|-------:|----------:|------------:|
|            Reflection | 72.917 ns | 1.0150 ns | 0.9494 ns |  1.00 | 0.0013 |     112 B |        1.00 |
|      ReflectionCached | 53.873 ns | 0.6870 ns | 0.6426 ns |  0.74 | 0.0013 |     112 B |        1.00 |
| ReflectionCachedFully | 36.013 ns | 0.2546 ns | 0.1988 ns |  0.49 | 0.0002 |      24 B |        0.21 |
|       WithSpanInvoker | 11.212 ns | 0.0323 ns | 0.0287 ns |  0.15 |      - |         - |        0.00 |
|         GeneratedFunc |  1.236 ns | 0.0023 ns | 0.0021 ns |  0.02 |      - |         - |        0.00 |
|               Dynamic |  8.838 ns | 0.1546 ns | 0.1446 ns |  0.12 | 0.0003 |      24 B |        0.21 |
