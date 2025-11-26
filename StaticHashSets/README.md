# Accessing HashSets using an assigned property vs. an expression body definition



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|------------------------ |------ |----------:|---------:|---------:|------:|--------:|---------:|----------:|------------:|
| HashSetAssignedProperty | 10000 |  20.43 μs | 0.097 μs | 0.090 μs |  1.00 |    0.01 |        - |         - |          NA |
| HashSetArrowProperty    | 10000 | 741.00 μs | 8.475 μs | 7.513 μs | 36.27 |    0.39 | 200.1953 | 3360000 B |          NA |
