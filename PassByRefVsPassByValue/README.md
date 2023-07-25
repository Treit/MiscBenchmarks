# Passing classes vs. structs.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2


```
|          Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------- |------ |----------:|---------:|---------:|------:|--------:|----------:|------------:|
|       PassClass | 10000 |  35.76 μs | 0.714 μs | 2.048 μs |  1.00 |    0.00 |         - |          NA |
| PassStructByRef | 10000 |  55.89 μs | 1.073 μs | 1.468 μs |  1.57 |    0.09 |         - |          NA |
|      PassStruct | 10000 | 111.35 μs | 2.177 μs | 2.980 μs |  3.14 |    0.23 |         - |          NA |
