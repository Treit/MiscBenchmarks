# Getting the string representation of enum values.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                       | Count | Mean       | Error     | StdDev     | Ratio  | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------------- |------ |-----------:|----------:|-----------:|-------:|--------:|--------:|----------:|------------:|
| EnumToString                 | 10000 | 281.236 μs | 5.5822 μs | 10.6206 μs | 121.93 |    3.85 | 95.2148 | 1200053 B |          NA |
| Nameof                       | 10000 |   2.324 μs | 0.0130 μs |  0.0122 μs |   1.00 |    0.00 |       - |         - |          NA |
| CustomGetStringUsingSwitch   | 10000 |  53.386 μs | 0.9859 μs |  1.6741 μs |  23.38 |    0.81 | 19.1040 |  240011 B |          NA |
| EnumVariableToString         | 10000 | 293.633 μs | 5.2462 μs | 11.6252 μs | 130.17 |    3.41 | 95.2148 | 1200053 B |          NA |
| EnumVariableDictionaryLookup | 10000 | 120.352 μs | 2.4044 μs |  4.2111 μs |  51.38 |    1.50 |       - |         - |          NA |
| EnumVariableArrayLookup      | 10000 |  11.312 μs | 0.2261 μs |  0.5877 μs |   4.69 |    0.19 |       - |         - |          NA |
