# Passing classes vs. structs.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2


```
|                 Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |------ |----------:|---------:|---------:|------:|--------:|----------:|------------:|
|       Pass16ByteStruct | 10000 |  10.99 μs | 0.092 μs | 0.081 μs |  0.23 |    0.01 |         - |          NA |
|  Pass16ByteStructByRef | 10000 |  11.16 μs | 0.223 μs | 0.238 μs |  0.23 |    0.01 |         - |          NA |
|       Pass32ByteStruct | 10000 |  16.72 μs | 0.330 μs | 0.651 μs |  0.35 |    0.02 |         - |          NA |
|        Pass16ByteClass | 10000 |  16.82 μs | 0.334 μs | 0.856 μs |  0.36 |    0.02 |         - |          NA |
|  Pass32ByteStructByRef | 10000 |  17.51 μs | 0.338 μs | 0.698 μs |  0.36 |    0.02 |         - |          NA |
|        Pass32ByteClass | 10000 |  19.00 μs | 0.414 μs | 1.167 μs |  0.40 |    0.03 |         - |          NA |
|       Pass128ByteClass | 10000 |  48.19 μs | 0.960 μs | 1.682 μs |  1.00 |    0.00 |         - |          NA |
| Pass128ByteStructByRef | 10000 |  55.21 μs | 1.098 μs | 1.128 μs |  1.15 |    0.04 |         - |          NA |
|      Pass128ByteStruct | 10000 | 106.48 μs | 1.720 μs | 1.608 μs |  2.22 |    0.08 |         - |          NA |
