# Getting the type





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Job       | Runtime   | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------- |---------- |---------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| UsingSwitchAndTypeOf       | .NET 10.0 | .NET 10.0 | 10000 |  9.646 μs | 0.0753 μs | 0.0668 μs |  1.00 |    0.01 |         - |          NA |
| UsingTypeOfExtensionMethod | .NET 10.0 | .NET 10.0 | 10000 |  6.256 μs | 0.0316 μs | 0.0264 μs |  0.65 |    0.01 |         - |          NA |
| UsingGetType               | .NET 10.0 | .NET 10.0 | 10000 | 18.971 μs | 0.1746 μs | 0.1634 μs |  1.97 |    0.02 |         - |          NA |
|                            |           |           |       |           |           |           |       |         |           |             |
| UsingSwitchAndTypeOf       | .NET 9.0  | .NET 9.0  | 10000 |  9.553 μs | 0.0902 μs | 0.0800 μs |  1.00 |    0.01 |         - |          NA |
| UsingTypeOfExtensionMethod | .NET 9.0  | .NET 9.0  | 10000 |  6.253 μs | 0.0285 μs | 0.0252 μs |  0.65 |    0.01 |         - |          NA |
| UsingGetType               | .NET 9.0  | .NET 9.0  | 10000 | 18.953 μs | 0.1370 μs | 0.1281 μs |  1.98 |    0.02 |         - |          NA |
