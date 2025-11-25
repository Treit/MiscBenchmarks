# Using Equals instead of ReferenceEquals




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Equals          | 14.82 ns | 0.293 ns | 0.274 ns |  1.00 |    0.03 | 0.0019 |      32 B |        1.00 |
| ReferenceEquals | 13.20 ns | 0.152 ns | 0.142 ns |  0.89 |    0.02 | 0.0019 |      32 B |        1.00 |
