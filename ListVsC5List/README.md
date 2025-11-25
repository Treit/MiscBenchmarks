# List<T> vs. [C5](https://github.com/sestoft/C5) ArrayList<T>




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Count  | Mean        | Error      | StdDev     | Ratio  | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------- |------- |------------:|-----------:|-----------:|-------:|--------:|---------:|---------:|---------:|----------:|------------:|
| CreateC5ArrayListOfInt     | 100000 |   424.69 μs |   3.285 μs |   2.912 μs |   6.79 |    0.06 |  98.1445 |  90.8203 |  90.3320 | 1049622 B |          NA |
| CreateListOfInt            | 100000 |   289.16 μs |   5.733 μs |   6.825 μs |   4.62 |    0.11 |  71.2891 |  63.4766 |  63.4766 | 1049403 B |          NA |
| CreateC5ArrayListOfObject  | 100000 | 7,032.09 μs | 135.534 μs | 185.520 μs | 112.41 |    2.99 | 468.7500 | 460.9375 | 273.4375 | 5288162 B |          NA |
| CreateListOfObject         | 100000 | 6,738.18 μs | 131.155 μs | 165.869 μs | 107.71 |    2.68 | 460.9375 | 453.1250 | 265.6250 | 5288096 B |          NA |
| IterateC5ArrayListOfInt    | 100000 |   147.16 μs |   0.864 μs |   0.808 μs |   2.35 |    0.02 |        - |        - |        - |      48 B |          NA |
| IterateListOfInt           | 100000 |    62.56 μs |   0.413 μs |   0.386 μs |   1.00 |    0.01 |        - |        - |        - |         - |          NA |
| IterateC5ArrayListOfObject | 100000 |   226.14 μs |   0.888 μs |   0.693 μs |   3.62 |    0.02 |        - |        - |        - |      56 B |          NA |
| IterateListOfObject        | 100000 |    97.01 μs |   0.406 μs |   0.380 μs |   1.55 |    0.01 |        - |        - |        - |         - |          NA |
