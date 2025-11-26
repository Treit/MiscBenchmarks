# Creating an array using ToArray vs. Collection Expression.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Mean     | Error    | StdDev   | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| ToArray              | 19.15 ns | 0.201 ns | 0.178 ns |  1.00 | 0.0029 |      48 B |        1.00 |
| CollectionExpression | 19.26 ns | 0.219 ns | 0.204 ns |  1.01 | 0.0029 |      48 B |        1.00 |
