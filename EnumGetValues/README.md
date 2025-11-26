# Getting enum values





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| EnumGetValuesTypeof  | 83.15 ns | 0.930 ns | 0.870 ns |  3.58 |    0.04 | 0.0038 |      64 B |        1.00 |
| EnumGetValuesGeneric | 23.23 ns | 0.132 ns | 0.117 ns |  1.00 |    0.01 | 0.0038 |      64 B |        1.00 |
