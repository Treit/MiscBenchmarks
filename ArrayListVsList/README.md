# ArrayList vs List


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method |  Count |        Mean |      Error |     StdDev |  Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|------------------------- |------- |------------:|-----------:|-----------:|-------:|--------:|---------:|---------:|---------:|----------:|------------:|
|     CreateArrayListOfInt | 100000 | 5,996.43 μs | 119.211 μs | 266.633 μs |  95.13 |    4.02 | 359.3750 | 351.5625 | 210.9375 | 4497597 B |          NA |
|          CreateListOfInt | 100000 |   279.88 μs |   5.503 μs |   6.960 μs |   4.47 |    0.12 |  56.1523 |  48.3398 |  48.3398 | 1049268 B |          NA |
|  CreateArrayListOfObject | 100000 | 7,419.57 μs | 147.026 μs | 191.175 μs | 118.82 |    3.57 | 406.2500 | 398.4375 | 210.9375 | 5288061 B |          NA |
|       CreateListOfObject | 100000 | 7,528.05 μs | 149.499 μs | 199.577 μs | 121.37 |    2.81 | 406.2500 | 398.4375 | 210.9375 | 5288062 B |          NA |
|    IterateArrayListOfInt | 100000 |   284.05 μs |   0.548 μs |   0.458 μs |   4.57 |    0.01 |        - |        - |        - |      48 B |          NA |
|         IterateListOfInt | 100000 |    62.20 μs |   0.148 μs |   0.131 μs |   1.00 |    0.00 |        - |        - |        - |         - |          NA |
| IterateArrayListOfObject | 100000 |   261.55 μs |   0.744 μs |   0.660 μs |   4.21 |    0.02 |        - |        - |        - |      48 B |          NA |
|      IterateListOfObject | 100000 |   104.49 μs |   0.335 μs |   0.297 μs |   1.68 |    0.01 |        - |        - |        - |         - |          NA |
