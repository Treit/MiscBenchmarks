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
| CreateArrayListOfInt     | 100000 | 5,432.35 μs | 104.866 μs | 107.689 μs |  86.65 |    1.74 | 359.3750 | 351.5625 | 210.9375 | 4497596 B |          NA |
| CreateListOfInt          | 100000 |   262.56 μs |   5.222 μs |   5.128 μs |   4.19 |    0.08 |  56.6406 |  48.8281 |  48.8281 | 1049262 B |          NA |
| CreateArrayListOfObject  | 100000 | 6,613.46 μs |  93.620 μs |  87.572 μs | 105.49 |    1.48 | 406.2500 | 398.4375 | 210.9375 | 5287998 B |          NA |
| CreateListOfObject       | 100000 | 6,672.49 μs | 127.647 μs | 174.725 μs | 106.43 |    2.80 | 406.2500 | 398.4375 | 210.9375 | 5287999 B |          NA |
| IterateArrayListOfInt    | 100000 |   256.24 μs |   1.822 μs |   1.704 μs |   4.09 |    0.03 |        - |        - |        - |      48 B |          NA |
| IterateListOfInt         | 100000 |    62.70 μs |   0.387 μs |   0.362 μs |   1.00 |    0.01 |        - |        - |        - |         - |          NA |
| IterateArrayListOfObject | 100000 |   255.68 μs |   1.980 μs |   1.756 μs |   4.08 |    0.04 |        - |        - |        - |      48 B |          NA |
| IterateListOfObject      | 100000 |    96.76 μs |   0.371 μs |   0.347 μs |   1.54 |    0.01 |        - |        - |        - |         - |          NA |
