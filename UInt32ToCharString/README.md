## Converting a byte array encoded as a uint back to a string



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                            Method |     Mean |    Error |   StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|---------------------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
|             UIntToStringUsingLINQ | 40.82 ns | 0.853 ns | 1.250 ns |  3.14 |    0.12 | 0.0086 |     144 B |        4.50 |
| UIntToStringUsingBinaryPrimitives | 13.06 ns | 0.117 ns | 0.109 ns |  1.00 |    0.00 | 0.0019 |      32 B |        1.00 |
