# Getting the string representation of enum values.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Job       | Runtime   | Count | Mean       | Error     | StdDev    | Ratio  | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------------- |---------- |---------- |------ |-----------:|----------:|----------:|-------:|--------:|--------:|----------:|------------:|
| EnumToString                 | .NET 10.0 | .NET 10.0 | 10000 | 416.581 μs | 7.5965 μs | 7.1057 μs | 131.64 |    2.44 | 71.2891 | 1200040 B |          NA |
| Nameof                       | .NET 10.0 | .NET 10.0 | 10000 |   3.165 μs | 0.0293 μs | 0.0274 μs |   1.00 |    0.01 |       - |         - |          NA |
| CustomGetStringUsingSwitch   | .NET 10.0 | .NET 10.0 | 10000 |  86.084 μs | 1.1895 μs | 0.9933 μs |  27.20 |    0.38 | 14.2822 |  240008 B |          NA |
| EnumVariableToString         | .NET 10.0 | .NET 10.0 | 10000 | 452.793 μs | 4.5648 μs | 4.2699 μs | 143.08 |    1.77 | 71.2891 | 1200040 B |          NA |
| EnumVariableDictionaryLookup | .NET 10.0 | .NET 10.0 | 10000 | 134.388 μs | 1.7760 μs | 1.5744 μs |  42.47 |    0.60 |       - |         - |          NA |
| EnumVariableArrayLookup      | .NET 10.0 | .NET 10.0 | 10000 |  18.540 μs | 0.1787 μs | 0.1493 μs |   5.86 |    0.07 |       - |         - |          NA |
|                              |           |           |       |            |           |           |        |         |         |           |             |
| EnumToString                 | .NET 9.0  | .NET 9.0  | 10000 | 410.131 μs | 5.8960 μs | 5.2267 μs | 130.12 |    1.84 | 71.2891 | 1200040 B |          NA |
| Nameof                       | .NET 9.0  | .NET 9.0  | 10000 |   3.152 μs | 0.0240 μs | 0.0224 μs |   1.00 |    0.01 |       - |         - |          NA |
| CustomGetStringUsingSwitch   | .NET 9.0  | .NET 9.0  | 10000 |  88.430 μs | 1.1012 μs | 0.9762 μs |  28.06 |    0.36 | 14.2822 |  240008 B |          NA |
| EnumVariableToString         | .NET 9.0  | .NET 9.0  | 10000 | 454.697 μs | 2.9918 μs | 2.3358 μs | 144.26 |    1.23 | 71.2891 | 1200040 B |          NA |
| EnumVariableDictionaryLookup | .NET 9.0  | .NET 9.0  | 10000 | 135.139 μs | 2.0249 μs | 1.7950 μs |  42.87 |    0.63 |       - |         - |          NA |
| EnumVariableArrayLookup      | .NET 9.0  | .NET 9.0  | 10000 |  18.550 μs | 0.1202 μs | 0.1124 μs |   5.89 |    0.05 |       - |         - |          NA |
