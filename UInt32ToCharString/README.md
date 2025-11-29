## Converting a byte array encoded as a uint back to a string






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------- |---------- |---------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| UIntToStringUsingLINQ             | .NET 10.0 | .NET 10.0 | 23.16 ns | 0.190 ns | 0.177 ns |  2.31 |    0.02 | 0.0086 |     144 B |        4.50 |
| UIntToStringUsingBinaryPrimitives | .NET 10.0 | .NET 10.0 | 10.05 ns | 0.059 ns | 0.049 ns |  1.00 |    0.01 | 0.0019 |      32 B |        1.00 |
|                                   |           |           |          |          |          |       |         |        |           |             |
| UIntToStringUsingLINQ             | .NET 9.0  | .NET 9.0  | 23.40 ns | 0.159 ns | 0.133 ns |  2.33 |    0.02 | 0.0086 |     144 B |        4.50 |
| UIntToStringUsingBinaryPrimitives | .NET 9.0  | .NET 9.0  | 10.05 ns | 0.049 ns | 0.046 ns |  1.00 |    0.01 | 0.0019 |      32 B |        1.00 |
