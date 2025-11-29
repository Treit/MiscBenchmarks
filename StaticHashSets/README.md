# Accessing HashSets using an assigned property vs. an expression body definition




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|------------------------ |---------- |---------- |------ |----------:|---------:|---------:|------:|--------:|---------:|----------:|------------:|
| HashSetAssignedProperty | .NET 10.0 | .NET 10.0 | 10000 |  20.98 μs | 0.028 μs | 0.023 μs |  1.00 |    0.00 |        - |         - |          NA |
| HashSetArrowProperty    | .NET 10.0 | .NET 10.0 | 10000 | 724.38 μs | 4.519 μs | 4.006 μs | 34.52 |    0.19 | 200.1953 | 3360000 B |          NA |
|                         |           |           |       |           |          |          |       |         |          |           |             |
| HashSetAssignedProperty | .NET 9.0  | .NET 9.0  | 10000 |  21.01 μs | 0.038 μs | 0.032 μs |  1.00 |    0.00 |        - |         - |          NA |
| HashSetArrowProperty    | .NET 9.0  | .NET 9.0  | 10000 | 728.34 μs | 6.523 μs | 6.102 μs | 34.67 |    0.29 | 200.1953 | 3360000 B |          NA |
