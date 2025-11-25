# Getting the type



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| UsingSwitchAndTypeOf       | 10000 |  9.569 μs | 0.0901 μs | 0.0843 μs |  1.00 |    0.01 |         - |          NA |
| UsingTypeOfExtensionMethod | 10000 |  6.236 μs | 0.0255 μs | 0.0213 μs |  0.65 |    0.01 |         - |          NA |
| UsingGetType               | 10000 | 18.898 μs | 0.1018 μs | 0.0952 μs |  1.98 |    0.02 |         - |          NA |
