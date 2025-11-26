# Getting the string representation of enum values.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Count | Mean       | Error     | StdDev    | Ratio  | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------------- |------ |-----------:|----------:|----------:|-------:|--------:|--------:|----------:|------------:|
| EnumToString                 | 10000 | 401.014 μs | 2.7169 μs | 2.5414 μs | 127.99 |    0.92 | 71.2891 | 1200040 B |          NA |
| Nameof                       | 10000 |   3.133 μs | 0.0147 μs | 0.0123 μs |   1.00 |    0.01 |       - |         - |          NA |
| CustomGetStringUsingSwitch   | 10000 |  84.306 μs | 0.6942 μs | 0.6494 μs |  26.91 |    0.23 | 14.2822 |  240008 B |          NA |
| EnumVariableToString         | 10000 | 445.528 μs | 3.5234 μs | 2.7508 μs | 142.20 |    1.00 | 71.2891 | 1200040 B |          NA |
| EnumVariableDictionaryLookup | 10000 | 133.455 μs | 0.8224 μs | 0.7693 μs |  42.59 |    0.29 |       - |         - |          NA |
| EnumVariableArrayLookup      | 10000 |  18.348 μs | 0.1495 μs | 0.1399 μs |   5.86 |    0.05 |       - |         - |          NA |
