## Looking up integer values in a bit array vs. a HashSet







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Mean       | Error   | StdDev  | Ratio | RatioSD |
|-------------------- |-----------:|--------:|--------:|------:|--------:|
| LookupUsingHashSet  | 1,304.6 ns | 9.08 ns | 8.49 ns |  2.17 |    0.02 |
| LookupUsingBitArray |   601.0 ns | 6.22 ns | 5.82 ns |  1.00 |    0.01 |
