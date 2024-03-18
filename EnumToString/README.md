# Getting the string representation of enum values.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                     | Count | Mean       | Error     | StdDev     | Median     | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|--------------------------- |------ |-----------:|----------:|-----------:|-----------:|------:|--------:|--------:|----------:|------------:|
| EnumToString               | 10000 | 399.591 μs | 8.9481 μs | 26.2431 μs | 407.078 μs | 1.000 |    0.00 | 95.2148 | 1200053 B |        1.00 |
| Nameof                     | 10000 |   3.437 μs | 0.0669 μs |  0.1678 μs |   3.478 μs | 0.009 |    0.00 |       - |         - |        0.00 |
| CustomGetStringUsingSwitch | 10000 |  74.637 μs | 4.8791 μs | 14.3862 μs |  78.609 μs | 0.188 |    0.04 | 19.1040 |  240011 B |        0.20 |
