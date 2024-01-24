# Returning an empty sequence



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|             Method |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| EnumerableDotEmpty |  5.301 ns | 0.0270 ns | 0.0240 ns |  1.00 |    0.00 |      - |         - |          NA |
|      ArrayDotEmpty | 16.846 ns | 0.0343 ns | 0.0287 ns |  3.18 |    0.01 |      - |         - |          NA |
|      NewEmptyArray | 18.721 ns | 0.0483 ns | 0.0403 ns |  3.53 |    0.02 | 0.0014 |      24 B |          NA |
|       NewEmptyList | 12.560 ns | 0.1293 ns | 0.1079 ns |  2.37 |    0.02 | 0.0019 |      32 B |          NA |
