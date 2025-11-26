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
| UsingSwitchAndTypeOf       | 10000 |  9.667 μs | 0.0592 μs | 0.0554 μs |  1.00 |    0.01 |         - |          NA |
| UsingTypeOfExtensionMethod | 10000 |  6.245 μs | 0.0250 μs | 0.0234 μs |  0.65 |    0.00 |         - |          NA |
| UsingGetType               | 10000 | 19.105 μs | 0.1409 μs | 0.1318 μs |  1.98 |    0.02 |         - |          NA |
