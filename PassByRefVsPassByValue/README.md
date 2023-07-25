# Passing classes vs. structs.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2


```
|              Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------- |------ |----------:|---------:|---------:|------:|--------:|----------:|------------:|
|      PassTinyStruct | 10000 |  11.04 μs | 0.146 μs | 0.122 μs |  0.27 |    0.01 |         - |          NA |
| PassTinyStructByRef | 10000 |  11.16 μs | 0.142 μs | 0.133 μs |  0.28 |    0.01 |         - |          NA |
|       PassTinyClass | 10000 |  26.58 μs | 0.531 μs | 1.481 μs |  0.64 |    0.04 |         - |          NA |
|           PassClass | 10000 |  41.38 μs | 0.821 μs | 1.920 μs |  1.00 |    0.00 |         - |          NA |
|     PassStructByRef | 10000 |  55.11 μs | 1.078 μs | 1.439 μs |  1.35 |    0.07 |         - |          NA |
|          PassStruct | 10000 | 110.61 μs | 0.624 μs | 0.553 μs |  2.73 |    0.14 |         - |          NA |
