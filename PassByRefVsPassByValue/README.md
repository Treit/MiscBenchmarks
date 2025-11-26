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
| Pass16ByteStruct       | 10000 |  9.689 μs | 0.0710 μs | 0.0665 μs |  0.35 |    0.00 |         - |          NA |
| Pass16ByteStructByRef  | 10000 |  9.705 μs | 0.0623 μs | 0.0582 μs |  0.35 |    0.00 |         - |          NA |
| Pass128ByteStructByRef | 10000 | 17.570 μs | 0.0883 μs | 0.1570 μs |  0.64 |    0.01 |         - |          NA |
| Pass128ByteStruct      | 10000 | 17.653 μs | 0.2409 μs | 0.5389 μs |  0.64 |    0.02 |         - |          NA |
| Pass16ByteClass        | 10000 | 19.928 μs | 0.1697 μs | 0.1587 μs |  0.72 |    0.01 |         - |          NA |
| Pass32ByteStruct       | 10000 | 19.980 μs | 0.1062 μs | 0.0993 μs |  0.72 |    0.00 |         - |          NA |
| Pass32ByteStructByRef  | 10000 | 20.048 μs | 0.1444 μs | 0.1351 μs |  0.73 |    0.01 |         - |          NA |
| Pass32ByteClass        | 10000 | 20.143 μs | 0.1139 μs | 0.1066 μs |  0.73 |    0.00 |         - |          NA |
| Pass128ByteClass       | 10000 | 27.612 μs | 0.0980 μs | 0.0916 μs |  1.00 |    0.00 |         - |          NA |
