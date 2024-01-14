# Turning a single item into an IEnumerable.



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                 Method |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|--------------------------------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
|       SingleItemIntEnumerableDotRepeat |  9.073 ns | 0.0715 ns | 0.0669 ns |  1.00 |    0.00 | 0.0019 |      32 B |        1.00 |
|        SingleItemIntEnumerableNewArray | 13.816 ns | 0.1450 ns | 0.1285 ns |  1.52 |    0.02 | 0.0038 |      64 B |        2.00 |
|    SingleItemIntEnumerableWrapperClass |  4.090 ns | 0.0380 ns | 0.0337 ns |  0.45 |    0.01 | 0.0014 |      24 B |        0.75 |
|    SingleItemStringEnumerableDotRepeat |  9.660 ns | 0.0770 ns | 0.0720 ns |  1.06 |    0.01 | 0.0024 |      40 B |        1.25 |
|     SingleItemStringEnumerableNewArray | 14.302 ns | 0.1243 ns | 0.1162 ns |  1.58 |    0.01 | 0.0038 |      64 B |        2.00 |
| SingleItemStringEnumerableWrapperClass |  4.756 ns | 0.0552 ns | 0.0517 ns |  0.52 |    0.01 | 0.0019 |      32 B |        1.00 |
