# Getting enum values






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
| EnumGetValuesTypeof  | .NET 10.0 | .NET 10.0 | 86.56 ns | 0.778 ns | 0.727 ns |  3.61 |    0.05 | 0.0038 |      64 B |        1.00 |
| EnumGetValuesGeneric | .NET 10.0 | .NET 10.0 | 24.00 ns | 0.294 ns | 0.275 ns |  1.00 |    0.02 | 0.0038 |      64 B |        1.00 |
|                      |           |           |          |          |          |       |         |        |           |             |
| EnumGetValuesTypeof  | .NET 9.0  | .NET 9.0  | 85.38 ns | 1.284 ns | 1.201 ns |  3.61 |    0.06 | 0.0038 |      64 B |        1.00 |
| EnumGetValuesGeneric | .NET 9.0  | .NET 9.0  | 23.62 ns | 0.197 ns | 0.185 ns |  1.00 |    0.01 | 0.0038 |      64 B |        1.00 |
