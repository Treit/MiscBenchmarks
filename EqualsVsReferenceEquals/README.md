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
| Equals          | 16.60 ns | 0.267 ns | 0.250 ns |  1.00 |    0.02 | 0.0019 |      32 B |        1.00 |
| ReferenceEquals | 13.59 ns | 0.143 ns | 0.127 ns |  0.82 |    0.01 | 0.0019 |      32 B |        1.00 |
