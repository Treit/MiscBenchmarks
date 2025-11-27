# Creating an array using ToArray vs. Collection Expression.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Job       | Runtime   | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------- |---------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| ToArray              | .NET 10.0 | .NET 10.0 | 19.27 ns | 0.302 ns | 0.267 ns |  1.00 |    0.02 | 0.0029 |      48 B |        1.00 |
| CollectionExpression | .NET 10.0 | .NET 10.0 | 19.55 ns | 0.276 ns | 0.230 ns |  1.01 |    0.02 | 0.0029 |      48 B |        1.00 |
|                      |           |           |          |          |          |       |         |        |           |             |
| ToArray              | .NET 9.0  | .NET 9.0  | 19.44 ns | 0.263 ns | 0.234 ns |  1.00 |    0.02 | 0.0029 |      48 B |        1.00 |
| CollectionExpression | .NET 9.0  | .NET 9.0  | 19.42 ns | 0.209 ns | 0.196 ns |  1.00 |    0.02 | 0.0029 |      48 B |        1.00 |
