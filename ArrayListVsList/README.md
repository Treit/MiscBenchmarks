# ArrayList vs List




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Count  | Mean        | Error      | StdDev     | Ratio  | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|------------------------- |------- |------------:|-----------:|-----------:|-------:|--------:|---------:|---------:|---------:|----------:|------------:|
| CreateArrayListOfInt     | 100000 | 5,372.37 μs |  54.162 μs |  42.286 μs |  85.78 |    0.88 | 359.3750 | 351.5625 | 210.9375 | 4497596 B |          NA |
| CreateListOfInt          | 100000 |   262.91 μs |   3.761 μs |   2.937 μs |   4.20 |    0.05 |  58.1055 |  50.2930 |  50.2930 | 1049252 B |          NA |
| CreateArrayListOfObject  | 100000 | 6,647.19 μs | 129.784 μs | 154.498 μs | 106.14 |    2.52 | 406.2500 | 398.4375 | 210.9375 | 5287998 B |          NA |
| CreateListOfObject       | 100000 | 6,657.80 μs | 131.487 μs | 129.138 μs | 106.31 |    2.13 | 406.2500 | 398.4375 | 210.9375 | 5288006 B |          NA |
| IterateArrayListOfInt    | 100000 |   254.16 μs |   1.893 μs |   1.678 μs |   4.06 |    0.04 |        - |        - |        - |      48 B |          NA |
| IterateListOfInt         | 100000 |    62.63 μs |   0.477 μs |   0.446 μs |   1.00 |    0.01 |        - |        - |        - |         - |          NA |
| IterateArrayListOfObject | 100000 |   279.28 μs |   4.826 μs |   4.514 μs |   4.46 |    0.08 |        - |        - |        - |      48 B |          NA |
| IterateListOfObject      | 100000 |    97.20 μs |   0.718 μs |   0.672 μs |   1.55 |    0.01 |        - |        - |        - |         - |          NA |
