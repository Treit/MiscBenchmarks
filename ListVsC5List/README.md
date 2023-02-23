# List<T> vs. [C5](https://github.com/sestoft/C5) ArrayList<T>


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25290.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                     Method |  Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|--------------------------- |------- |------------:|----------:|----------:|------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
|     CreateC5ArrayListOfInt | 100000 |  1,243.1 μs |  24.46 μs |  50.51 μs |  1,227.0 μs |  7.38 |    0.51 | 152.3438 | 123.0469 | 123.0469 | 1049624 B |          NA |
|            CreateListOfInt | 100000 |    749.2 μs |  14.97 μs |  15.37 μs |    750.1 μs |  4.59 |    0.21 |  64.4531 |  36.1328 |  34.1797 | 1049097 B |          NA |
|  CreateC5ArrayListOfObject | 100000 | 12,602.9 μs | 253.58 μs | 743.71 μs | 12,685.0 μs | 76.57 |    6.73 | 781.2500 | 500.0000 | 281.2500 | 5297478 B |          NA |
|         CreateListOfObject | 100000 | 12,169.4 μs | 242.51 μs | 608.42 μs | 12,055.1 μs | 73.57 |    5.89 | 796.8750 | 531.2500 | 281.2500 | 5297312 B |          NA |
|    IterateC5ArrayListOfInt | 100000 |    616.1 μs |  14.03 μs |  40.48 μs |    608.3 μs |  3.75 |    0.33 |        - |        - |        - |      49 B |          NA |
|           IterateListOfInt | 100000 |    164.6 μs |   3.26 μs |   9.09 μs |    164.1 μs |  1.00 |    0.00 |        - |        - |        - |         - |          NA |
| IterateC5ArrayListOfObject | 100000 |    719.7 μs |  16.92 μs |  48.82 μs |    701.6 μs |  4.38 |    0.30 |        - |        - |        - |      57 B |          NA |
|        IterateListOfObject | 100000 |    162.3 μs |   3.24 μs |   7.82 μs |    160.9 μs |  0.97 |    0.07 |        - |        - |        - |         - |          NA |
