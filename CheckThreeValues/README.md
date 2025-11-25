# Check if a property is one of three string values
Found the array version in some actual production code.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method            | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------ |------ |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| CheckWithArray    | 1000  | 21.221 μs | 0.2651 μs | 0.2214 μs |  7.71 |    0.09 | 5.2490 |   88000 B |          NA |
| CheckWithSimpleIf | 1000  |  2.751 μs | 0.0155 μs | 0.0137 μs |  1.00 |    0.01 |      - |         - |          NA |
