# Passing classes vs. structs.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| Pass16ByteStructByRef  | 10000 |  9.599 μs | 0.0636 μs | 0.0595 μs |  0.29 |    0.01 |         - |          NA |
| Pass16ByteStruct       | 10000 |  9.603 μs | 0.0558 μs | 0.0522 μs |  0.29 |    0.01 |         - |          NA |
| Pass32ByteStruct       | 10000 | 20.048 μs | 0.1464 μs | 0.1369 μs |  0.60 |    0.02 |         - |          NA |
| Pass32ByteClass        | 10000 | 20.068 μs | 0.1054 μs | 0.0986 μs |  0.60 |    0.02 |         - |          NA |
| Pass32ByteStructByRef  | 10000 | 20.091 μs | 0.1282 μs | 0.1199 μs |  0.60 |    0.02 |         - |          NA |
| Pass16ByteClass        | 10000 | 20.245 μs | 0.1314 μs | 0.1230 μs |  0.60 |    0.02 |         - |          NA |
| Pass128ByteStruct      | 10000 | 20.262 μs | 0.5047 μs | 1.4882 μs |  0.60 |    0.05 |         - |          NA |
| Pass128ByteStructByRef | 10000 | 21.732 μs | 0.4270 μs | 0.6648 μs |  0.65 |    0.03 |         - |          NA |
| Pass128ByteClass       | 10000 | 33.673 μs | 0.6536 μs | 0.9783 μs |  1.00 |    0.04 |         - |          NA |
