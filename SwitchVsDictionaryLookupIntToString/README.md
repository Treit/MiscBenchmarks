# Lookup string by integer key using both dictionary and switch expressions



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Mean     | Error    | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |---------:|---------:|--------:|------:|-------:|----------:|------------:|
| LookupIntKeyUsingDictionary100Items       | 954.5 ns |  8.48 ns | 7.93 ns |  1.04 | 0.0172 |     304 B |        1.00 |
| LookupIntKeyUsingDictionary5Items         | 917.9 ns |  5.22 ns | 4.36 ns |  1.00 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression5Items   | 641.7 ns |  5.31 ns | 4.96 ns |  0.70 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression100Items | 693.1 ns |  5.67 ns | 5.30 ns |  0.76 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement5Items    | 639.6 ns |  5.54 ns | 4.91 ns |  0.70 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement100Items  | 703.4 ns | 10.58 ns | 9.90 ns |  0.77 | 0.0181 |     304 B |        1.00 |
