# List<T> vs. [C5](https://github.com/sestoft/C5) ArrayList<T>



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                     Method |  Count |        Mean |      Error |     StdDev |  Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|--------------------------- |------- |------------:|-----------:|-----------:|-------:|--------:|---------:|---------:|---------:|----------:|------------:|
|     CreateC5ArrayListOfInt | 100000 |   674.27 μs |   6.865 μs |   6.422 μs |  10.85 |    0.11 | 115.2344 | 107.4219 | 107.4219 | 1049714 B |          NA |
|            CreateListOfInt | 100000 |   314.06 μs |   6.070 μs |   6.233 μs |   5.05 |    0.10 |  64.4531 |  56.6406 |  56.6406 | 1049370 B |          NA |
|  CreateC5ArrayListOfObject | 100000 | 7,469.18 μs |  48.062 μs |  42.606 μs | 120.23 |    0.70 | 468.7500 | 460.9375 | 273.4375 | 5288134 B |          NA |
|         CreateListOfObject | 100000 | 7,403.89 μs | 121.213 μs | 113.383 μs | 119.35 |    1.85 | 468.7500 | 460.9375 | 273.4375 | 5288056 B |          NA |
|    IterateC5ArrayListOfInt | 100000 |   144.83 μs |   0.078 μs |   0.069 μs |   2.33 |    0.00 |        - |        - |        - |      48 B |          NA |
|           IterateListOfInt | 100000 |    62.14 μs |   0.093 μs |   0.078 μs |   1.00 |    0.00 |        - |        - |        - |         - |          NA |
| IterateC5ArrayListOfObject | 100000 |   242.06 μs |   4.815 μs |   9.726 μs |   3.90 |    0.17 |        - |        - |        - |      56 B |          NA |
|        IterateListOfObject | 100000 |   104.46 μs |   0.220 μs |   0.195 μs |   1.68 |    0.00 |        - |        - |        - |         - |          NA |
