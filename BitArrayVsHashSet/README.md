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
| LookupUsingHashSet  | 1,298.1 ns | 7.64 ns | 6.77 ns |  2.11 |    0.02 |
| LookupUsingBitArray |   614.6 ns | 6.86 ns | 6.42 ns |  1.00 |    0.01 |
