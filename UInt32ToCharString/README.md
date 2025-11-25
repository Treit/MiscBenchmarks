## Converting a byte array encoded as a uint back to a string




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| UIntToStringUsingLINQ             | 23.72 ns | 0.244 ns | 0.204 ns |  2.36 |    0.03 | 0.0086 |     144 B |        4.50 |
| UIntToStringUsingBinaryPrimitives | 10.05 ns | 0.089 ns | 0.083 ns |  1.00 |    0.01 | 0.0019 |      32 B |        1.00 |
