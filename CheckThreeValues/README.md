# Check if a property is one of three string values
Found the array version in some actual production code.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method            | Job       | Runtime   | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------ |---------- |---------- |------ |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| CheckWithArray    | .NET 10.0 | .NET 10.0 | 1000  | 21.670 μs | 0.2310 μs | 0.2161 μs |  7.76 |    0.09 | 5.2490 |   88000 B |          NA |
| CheckWithSimpleIf | .NET 10.0 | .NET 10.0 | 1000  |  2.792 μs | 0.0168 μs | 0.0158 μs |  1.00 |    0.01 |      - |         - |          NA |
|                   |           |           |       |           |           |           |       |         |        |           |             |
| CheckWithArray    | .NET 9.0  | .NET 9.0  | 1000  | 21.133 μs | 0.2702 μs | 0.2527 μs |  7.58 |    0.10 | 5.2490 |   88000 B |          NA |
| CheckWithSimpleIf | .NET 9.0  | .NET 9.0  | 1000  |  2.789 μs | 0.0196 μs | 0.0174 μs |  1.00 |    0.01 |      - |         - |          NA |
