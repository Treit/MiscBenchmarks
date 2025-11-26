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
| CreateC5ArrayListOfInt     | 100000 |   427.49 μs |   4.017 μs |   3.757 μs |   6.81 |    0.08 |  98.6328 |  90.8203 |  90.8203 | 1049640 B |          NA |
| CreateListOfInt            | 100000 |   289.42 μs |   5.602 μs |   6.880 μs |   4.61 |    0.11 |  71.7773 |  63.9648 |  63.9648 | 1049419 B |          NA |
| CreateC5ArrayListOfObject  | 100000 | 7,049.24 μs | 137.928 μs | 147.581 μs | 112.35 |    2.43 | 468.7500 | 460.9375 | 273.4375 | 5288099 B |          NA |
| CreateListOfObject         | 100000 | 6,756.85 μs | 135.072 μs | 221.928 μs | 107.69 |    3.57 | 468.7500 | 460.9375 | 273.4375 | 5288137 B |          NA |
| IterateC5ArrayListOfInt    | 100000 |   146.66 μs |   1.304 μs |   1.220 μs |   2.34 |    0.03 |        - |        - |        - |      48 B |          NA |
| IterateListOfInt           | 100000 |    62.75 μs |   0.499 μs |   0.466 μs |   1.00 |    0.01 |        - |        - |        - |         - |          NA |
| IterateC5ArrayListOfObject | 100000 |   232.67 μs |   1.068 μs |   0.892 μs |   3.71 |    0.03 |        - |        - |        - |      56 B |          NA |
| IterateListOfObject        | 100000 |    97.28 μs |   0.518 μs |   0.485 μs |   1.55 |    0.01 |        - |        - |        - |         - |          NA |
