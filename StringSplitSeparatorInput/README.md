# string.Split with different types of separator input






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |------ |---------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| SplitWithSingleChar      | .NET 10.0 | .NET 10.0 | 100   | 1.684 μs | 0.0171 μs | 0.0160 μs |  1.00 |    0.01 | 0.2251 | 0.0019 |    3.7 KB |        1.00 |
| SplitWithSingleString    | .NET 10.0 | .NET 10.0 | 100   | 2.511 μs | 0.0175 μs | 0.0155 μs |  1.49 |    0.02 | 0.2251 |      - |    3.7 KB |        1.00 |
| SplitWithNewCharArray    | .NET 10.0 | .NET 10.0 | 100   | 1.691 μs | 0.0224 μs | 0.0209 μs |  1.00 |    0.02 | 0.2270 | 0.0019 |   3.73 KB |        1.01 |
| SplitWithStaticCharArray | .NET 10.0 | .NET 10.0 | 100   | 1.701 μs | 0.0272 μs | 0.0254 μs |  1.01 |    0.02 | 0.2251 | 0.0019 |    3.7 KB |        1.00 |
|                          |           |           |       |          |           |           |       |         |        |        |           |             |
| SplitWithSingleChar      | .NET 9.0  | .NET 9.0  | 100   | 1.704 μs | 0.0328 μs | 0.0307 μs |  1.00 |    0.02 | 0.2251 | 0.0019 |    3.7 KB |        1.00 |
| SplitWithSingleString    | .NET 9.0  | .NET 9.0  | 100   | 2.493 μs | 0.0329 μs | 0.0307 μs |  1.46 |    0.03 | 0.2251 |      - |    3.7 KB |        1.00 |
| SplitWithNewCharArray    | .NET 9.0  | .NET 9.0  | 100   | 1.731 μs | 0.0198 μs | 0.0176 μs |  1.02 |    0.02 | 0.2270 | 0.0019 |   3.73 KB |        1.01 |
| SplitWithStaticCharArray | .NET 9.0  | .NET 9.0  | 100   | 1.688 μs | 0.0197 μs | 0.0184 μs |  0.99 |    0.02 | 0.2251 | 0.0019 |    3.7 KB |        1.00 |
