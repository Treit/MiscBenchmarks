# Creating an array using ToArray vs. Collection Expression.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| ToArray              | 19.26 ns | 0.179 ns | 0.159 ns |  1.00 |    0.01 | 0.0029 |      48 B |        1.00 |
| CollectionExpression | 19.32 ns | 0.321 ns | 0.300 ns |  1.00 |    0.02 | 0.0029 |      48 B |        1.00 |
