# Using Equals instead of ReferenceEquals






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Job       | Runtime   | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------- |---------- |---------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Equals          | .NET 10.0 | .NET 10.0 | 15.65 ns | 0.337 ns | 0.375 ns |  1.00 |    0.03 | 0.0019 |      32 B |        1.00 |
| ReferenceEquals | .NET 10.0 | .NET 10.0 | 14.24 ns | 0.304 ns | 0.338 ns |  0.91 |    0.03 | 0.0019 |      32 B |        1.00 |
|                 |           |           |          |          |          |       |         |        |           |             |
| Equals          | .NET 9.0  | .NET 9.0  | 15.56 ns | 0.320 ns | 0.300 ns |  1.00 |    0.03 | 0.0019 |      32 B |        1.00 |
| ReferenceEquals | .NET 9.0  | .NET 9.0  | 13.74 ns | 0.301 ns | 0.281 ns |  0.88 |    0.02 | 0.0019 |      32 B |        1.00 |
