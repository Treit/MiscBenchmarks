## Looking up enum values in a bit array vs. a HashSet








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Job       | Runtime   | Mean        | Error     | StdDev    | Ratio | RatioSD |
|-------------------------------------- |---------- |---------- |------------:|----------:|----------:|------:|--------:|
| LookupUsingHashSet                    | .NET 10.0 | .NET 10.0 |  4,782.1 ns |  52.53 ns |  49.14 ns |  1.00 |    0.01 |
| LookupUsingBitArrayWithUnsafeAs       | .NET 10.0 | .NET 10.0 |  1,892.0 ns |  11.29 ns |  10.56 ns |  0.40 |    0.00 |
| LookupUsingBitArrayWithCast           | .NET 10.0 | .NET 10.0 |    630.4 ns |   3.98 ns |   3.53 ns |  0.13 |    0.00 |
| LookupUsingBitArrayWithConvertToInt32 | .NET 10.0 | .NET 10.0 | 15,416.4 ns | 284.70 ns | 380.06 ns |  3.22 |    0.08 |
|                                       |           |           |             |           |           |       |         |
| LookupUsingHashSet                    | .NET 9.0  | .NET 9.0  |  4,756.6 ns |  39.46 ns |  30.81 ns |  1.00 |    0.01 |
| LookupUsingBitArrayWithUnsafeAs       | .NET 9.0  | .NET 9.0  |  1,033.9 ns |  10.60 ns |   9.91 ns |  0.22 |    0.00 |
| LookupUsingBitArrayWithCast           | .NET 9.0  | .NET 9.0  |    959.0 ns |   6.49 ns |   6.07 ns |  0.20 |    0.00 |
| LookupUsingBitArrayWithConvertToInt32 | .NET 9.0  | .NET 9.0  | 32,145.7 ns | 622.52 ns | 716.90 ns |  6.76 |    0.15 |
