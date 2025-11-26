# Lookup string by integer key using both dictionary and switch expressions




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Mean     | Error   | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |---------:|--------:|--------:|------:|-------:|----------:|------------:|
| LookupIntKeyUsingDictionary100Items       | 946.4 ns | 2.05 ns | 1.71 ns |  1.00 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingDictionary5Items         | 943.1 ns | 1.56 ns | 1.38 ns |  1.00 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression5Items   | 642.0 ns | 6.39 ns | 5.98 ns |  0.68 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression100Items | 699.1 ns | 5.59 ns | 4.96 ns |  0.74 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement5Items    | 656.2 ns | 4.92 ns | 4.11 ns |  0.70 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement100Items  | 686.4 ns | 5.85 ns | 5.47 ns |  0.73 | 0.0181 |     304 B |        1.00 |
