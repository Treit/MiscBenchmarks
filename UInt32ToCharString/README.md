## Converting a byte array encoded as a uint back to a string


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25982.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2


```
|                            Method |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|---------------------------------- |---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
|             UIntToStringUsingLINQ | 60.06 ns | 1.222 ns | 1.407 ns | 60.21 ns |  2.31 |    0.14 | 0.0334 |     144 B |        4.50 |
| UIntToStringUsingBinaryPrimitives | 25.52 ns | 0.556 ns | 1.549 ns | 24.64 ns |  1.00 |    0.00 | 0.0074 |      32 B |        1.00 |
