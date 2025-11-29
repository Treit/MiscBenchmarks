# Lookup string by integer key using both dictionary and switch expressions





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Job       | Runtime   | Mean     | Error    | StdDev   | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |---------- |---------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| LookupIntKeyUsingDictionary100Items       | .NET 10.0 | .NET 10.0 | 950.2 ns |  4.34 ns |  4.06 ns |  1.05 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingDictionary5Items         | .NET 10.0 | .NET 10.0 | 908.5 ns |  2.45 ns |  2.18 ns |  1.00 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression5Items   | .NET 10.0 | .NET 10.0 | 652.7 ns |  2.86 ns |  2.53 ns |  0.72 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression100Items | .NET 10.0 | .NET 10.0 | 681.5 ns |  2.89 ns |  2.56 ns |  0.75 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement5Items    | .NET 10.0 | .NET 10.0 | 638.0 ns |  2.80 ns |  3.92 ns |  0.70 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement100Items  | .NET 10.0 | .NET 10.0 | 686.9 ns |  2.80 ns |  2.62 ns |  0.76 | 0.0181 |     304 B |        1.00 |
|                                           |           |           |          |          |          |       |        |           |             |
| LookupIntKeyUsingDictionary100Items       | .NET 9.0  | .NET 9.0  | 939.4 ns |  3.38 ns |  3.00 ns |  1.03 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingDictionary5Items         | .NET 9.0  | .NET 9.0  | 915.6 ns |  5.09 ns |  4.76 ns |  1.00 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression5Items   | .NET 9.0  | .NET 9.0  | 646.7 ns |  8.51 ns |  7.96 ns |  0.71 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression100Items | .NET 9.0  | .NET 9.0  | 692.8 ns |  5.76 ns |  5.39 ns |  0.76 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement5Items    | .NET 9.0  | .NET 9.0  | 654.0 ns | 11.38 ns | 10.65 ns |  0.71 | 0.0181 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement100Items  | .NET 9.0  | .NET 9.0  | 721.0 ns | 11.97 ns | 11.20 ns |  0.79 | 0.0181 |     304 B |        1.00 |
