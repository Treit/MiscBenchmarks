# Passing classes vs. structs.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                 Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
|  Pass16ByteStructByRef | 10000 |  9.329 μs | 0.0361 μs | 0.0337 μs |  9.312 μs |  0.28 |    0.03 |         - |          NA |
|       Pass16ByteStruct | 10000 |  9.335 μs | 0.0508 μs | 0.0450 μs |  9.315 μs |  0.29 |    0.03 |         - |          NA |
|       Pass32ByteStruct | 10000 | 16.595 μs | 0.0939 μs | 0.0879 μs | 16.621 μs |  0.51 |    0.06 |         - |          NA |
|        Pass16ByteClass | 10000 | 16.649 μs | 0.1719 μs | 0.1524 μs | 16.680 μs |  0.51 |    0.06 |         - |          NA |
|        Pass32ByteClass | 10000 | 16.652 μs | 0.1328 μs | 0.1177 μs | 16.693 μs |  0.51 |    0.06 |         - |          NA |
|  Pass32ByteStructByRef | 10000 | 17.142 μs | 0.1293 μs | 0.1210 μs | 17.160 μs |  0.52 |    0.06 |         - |          NA |
|      Pass128ByteStruct | 10000 | 22.092 μs | 0.8345 μs | 2.4605 μs | 23.448 μs |  0.68 |    0.12 |         - |          NA |
| Pass128ByteStructByRef | 10000 | 22.713 μs | 0.6798 μs | 2.0045 μs | 23.489 μs |  0.70 |    0.11 |         - |          NA |
|       Pass128ByteClass | 10000 | 32.799 μs | 1.2329 μs | 3.6352 μs | 34.754 μs |  1.00 |    0.00 |         - |          NA |
