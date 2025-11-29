# ArrayList vs List





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Count  | Mean        | Error      | StdDev     | Ratio  | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|------------------------- |---------- |---------- |------- |------------:|-----------:|-----------:|-------:|--------:|---------:|---------:|---------:|----------:|------------:|
| CreateArrayListOfInt     | .NET 10.0 | .NET 10.0 | 100000 | 5,548.11 μs | 109.959 μs | 209.208 μs |  88.34 |    3.36 | 359.3750 | 351.5625 | 210.9375 | 4497596 B |          NA |
| CreateListOfInt          | .NET 10.0 | .NET 10.0 | 100000 |   253.57 μs |   3.352 μs |   3.136 μs |   4.04 |    0.06 |  56.1523 |  48.8281 |  48.3398 | 1049273 B |          NA |
| CreateArrayListOfObject  | .NET 10.0 | .NET 10.0 | 100000 | 6,365.22 μs |  96.779 μs |  90.527 μs | 101.36 |    1.59 | 406.2500 | 398.4375 | 210.9375 | 5288094 B |          NA |
| CreateListOfObject       | .NET 10.0 | .NET 10.0 | 100000 | 6,663.17 μs | 130.374 μs | 186.979 μs | 106.10 |    3.03 | 406.2500 | 398.4375 | 210.9375 | 5287998 B |          NA |
| IterateArrayListOfInt    | .NET 10.0 | .NET 10.0 | 100000 |   255.70 μs |   2.222 μs |   2.079 μs |   4.07 |    0.04 |        - |        - |        - |      48 B |          NA |
| IterateListOfInt         | .NET 10.0 | .NET 10.0 | 100000 |    62.80 μs |   0.523 μs |   0.489 μs |   1.00 |    0.01 |        - |        - |        - |         - |          NA |
| IterateArrayListOfObject | .NET 10.0 | .NET 10.0 | 100000 |   257.16 μs |   2.397 μs |   2.125 μs |   4.09 |    0.04 |        - |        - |        - |      48 B |          NA |
| IterateListOfObject      | .NET 10.0 | .NET 10.0 | 100000 |    96.95 μs |   0.736 μs |   0.689 μs |   1.54 |    0.02 |        - |        - |        - |         - |          NA |
|                          |           |           |        |             |            |            |        |         |          |          |          |           |             |
| CreateArrayListOfInt     | .NET 9.0  | .NET 9.0  | 100000 | 5,453.72 μs | 108.835 μs | 199.011 μs |  86.80 |    3.20 | 359.3750 | 351.5625 | 210.9375 | 4497597 B |          NA |
| CreateListOfInt          | .NET 9.0  | .NET 9.0  | 100000 |   252.68 μs |   4.454 μs |   4.166 μs |   4.02 |    0.07 |  56.1523 |  48.8281 |  48.3398 | 1049282 B |          NA |
| CreateArrayListOfObject  | .NET 9.0  | .NET 9.0  | 100000 | 6,535.23 μs | 129.297 μs | 158.788 μs | 104.01 |    2.60 | 406.2500 | 398.4375 | 210.9375 | 5287997 B |          NA |
| CreateListOfObject       | .NET 9.0  | .NET 9.0  | 100000 | 6,625.16 μs | 126.372 μs | 129.775 μs | 105.44 |    2.17 | 406.2500 | 398.4375 | 210.9375 | 5287998 B |          NA |
| IterateArrayListOfInt    | .NET 9.0  | .NET 9.0  | 100000 |   255.41 μs |   2.245 μs |   2.100 μs |   4.07 |    0.05 |        - |        - |        - |      48 B |          NA |
| IterateListOfInt         | .NET 9.0  | .NET 9.0  | 100000 |    62.83 μs |   0.571 μs |   0.506 μs |   1.00 |    0.01 |        - |        - |        - |         - |          NA |
| IterateArrayListOfObject | .NET 9.0  | .NET 9.0  | 100000 |   256.88 μs |   2.445 μs |   2.287 μs |   4.09 |    0.05 |        - |        - |        - |      48 B |          NA |
| IterateListOfObject      | .NET 9.0  | .NET 9.0  | 100000 |    97.25 μs |   0.350 μs |   0.292 μs |   1.55 |    0.01 |        - |        - |        - |         - |          NA |
