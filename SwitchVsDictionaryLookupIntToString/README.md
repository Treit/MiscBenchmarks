# Lookup string by integer key using both dictionary and switch expressions


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27871.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                    | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| LookupIntKeyUsingDictionary100Items       | 1.827 μs | 0.0645 μs | 0.1871 μs | 1.764 μs |  1.20 |    0.14 | 0.0687 |     304 B |        1.00 |
| LookupIntKeyUsingDictionary5Items         | 1.601 μs | 0.0303 μs | 0.0633 μs | 1.590 μs |  1.00 |    0.00 | 0.0687 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression5Items   | 1.196 μs | 0.0284 μs | 0.0801 μs | 1.175 μs |  0.74 |    0.06 | 0.0687 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchExpression100Items | 1.181 μs | 0.0232 μs | 0.0480 μs | 1.175 μs |  0.74 |    0.04 | 0.0687 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement5Items    | 1.148 μs | 0.0216 μs | 0.0343 μs | 1.144 μs |  0.72 |    0.03 | 0.0687 |     304 B |        1.00 |
| LookupIntKeyUsingSwitchStatement100Items  | 1.147 μs | 0.0177 μs | 0.0148 μs | 1.148 μs |  0.72 |    0.02 | 0.0687 |     304 B |        1.00 |
