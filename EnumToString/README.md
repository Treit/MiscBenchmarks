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
| EnumToString                 | 10000 | 402.309 μs | 5.3836 μs | 5.0359 μs | 128.56 |    1.61 | 71.2891 | 1200040 B |          NA |
| Nameof                       | 10000 |   3.129 μs | 0.0115 μs | 0.0102 μs |   1.00 |    0.00 |       - |         - |          NA |
| CustomGetStringUsingSwitch   | 10000 |  85.646 μs | 0.4782 μs | 0.4239 μs |  27.37 |    0.16 | 14.2822 |  240010 B |          NA |
| EnumVariableToString         | 10000 | 452.103 μs | 6.9084 μs | 6.1241 μs | 144.47 |    1.94 | 71.2891 | 1200040 B |          NA |
| EnumVariableDictionaryLookup | 10000 | 133.108 μs | 0.8696 μs | 0.8135 μs |  42.54 |    0.29 |       - |         - |          NA |
| EnumVariableArrayLookup      | 10000 |  18.278 μs | 0.1064 μs | 0.0995 μs |   5.84 |    0.04 |       - |         - |          NA |
