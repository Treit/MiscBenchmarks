# List<T> vs. [C5](https://github.com/sestoft/C5) ArrayList<T>






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Job       | Runtime   | Count  | Mean        | Error      | StdDev     | Ratio  | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------- |---------- |---------- |------- |------------:|-----------:|-----------:|-------:|--------:|---------:|---------:|---------:|----------:|------------:|
| CreateC5ArrayListOfInt     | .NET 10.0 | .NET 10.0 | 100000 |   405.86 μs |   2.638 μs |   2.338 μs |   6.51 |    0.04 |  96.6797 |  89.3555 |  88.8672 | 1049624 B |          NA |
| CreateListOfInt            | .NET 10.0 | .NET 10.0 | 100000 |   258.19 μs |   3.840 μs |   3.592 μs |   4.14 |    0.06 |  70.3125 |  62.9883 |  62.5000 | 1049399 B |          NA |
| CreateC5ArrayListOfObject  | .NET 10.0 | .NET 10.0 | 100000 | 7,057.93 μs | 133.343 μs | 186.929 μs | 113.21 |    2.95 | 468.7500 | 460.9375 | 273.4375 | 5288205 B |          NA |
| CreateListOfObject         | .NET 10.0 | .NET 10.0 | 100000 | 6,679.83 μs | 132.656 μs | 162.914 μs | 107.15 |    2.56 | 460.9375 | 453.1250 | 265.6250 | 5288060 B |          NA |
| IterateC5ArrayListOfInt    | .NET 10.0 | .NET 10.0 | 100000 |   145.31 μs |   0.654 μs |   0.579 μs |   2.33 |    0.01 |        - |        - |        - |      48 B |          NA |
| IterateListOfInt           | .NET 10.0 | .NET 10.0 | 100000 |    62.34 μs |   0.123 μs |   0.103 μs |   1.00 |    0.00 |        - |        - |        - |         - |          NA |
| IterateC5ArrayListOfObject | .NET 10.0 | .NET 10.0 | 100000 |   225.57 μs |   0.945 μs |   0.838 μs |   3.62 |    0.01 |        - |        - |        - |      56 B |          NA |
| IterateListOfObject        | .NET 10.0 | .NET 10.0 | 100000 |    95.68 μs |   0.254 μs |   0.225 μs |   1.53 |    0.00 |        - |        - |        - |         - |          NA |
|                            |           |           |        |             |            |            |        |         |          |          |          |           |             |
| CreateC5ArrayListOfInt     | .NET 9.0  | .NET 9.0  | 100000 |   401.32 μs |   3.810 μs |   3.564 μs |   6.45 |    0.06 |  97.1680 |  89.8438 |  89.3555 | 1049591 B |          NA |
| CreateListOfInt            | .NET 9.0  | .NET 9.0  | 100000 |   257.26 μs |   4.779 μs |   4.470 μs |   4.13 |    0.07 |  69.3359 |  61.5234 |  61.5234 | 1049411 B |          NA |
| CreateC5ArrayListOfObject  | .NET 9.0  | .NET 9.0  | 100000 | 6,703.69 μs | 131.390 μs | 134.928 μs | 107.73 |    2.11 | 460.9375 | 453.1250 | 265.6250 | 5288203 B |          NA |
| CreateListOfObject         | .NET 9.0  | .NET 9.0  | 100000 | 6,672.38 μs | 132.124 μs | 176.382 μs | 107.22 |    2.78 | 460.9375 | 453.1250 | 265.6250 | 5288110 B |          NA |
| IterateC5ArrayListOfInt    | .NET 9.0  | .NET 9.0  | 100000 |   145.17 μs |   0.312 μs |   0.261 μs |   2.33 |    0.00 |        - |        - |        - |      48 B |          NA |
| IterateListOfInt           | .NET 9.0  | .NET 9.0  | 100000 |    62.23 μs |   0.064 μs |   0.050 μs |   1.00 |    0.00 |        - |        - |        - |         - |          NA |
| IterateC5ArrayListOfObject | .NET 9.0  | .NET 9.0  | 100000 |   225.15 μs |   0.579 μs |   0.484 μs |   3.62 |    0.01 |        - |        - |        - |      56 B |          NA |
| IterateListOfObject        | .NET 9.0  | .NET 9.0  | 100000 |    96.37 μs |   0.215 μs |   0.201 μs |   1.55 |    0.00 |        - |        - |        - |         - |          NA |
