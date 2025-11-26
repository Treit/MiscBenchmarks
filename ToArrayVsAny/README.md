# Finding if a collection has elements matching a collection. Any() vs. Length > 0 and variants.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Count  | Mean           | Error         | StdDev        | Ratio      | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------- |------- |---------------:|--------------:|--------------:|-----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **ToArrayDotLengthGreaterThanZero** | **10**     |      **97.711 ns** |     **0.7802 ns** |     **0.7298 ns** |      **45.69** |     **0.70** |   **0.0086** |        **-** |        **-** |     **144 B** |          **NA** |
| LinqCountGreaterThanZero        | 10     |      33.978 ns |     0.7063 ns |     0.6607 ns |      15.89 |     0.37 |   0.0029 |        - |        - |      48 B |          NA |
| Any                             | 10     |       2.139 ns |     0.0336 ns |     0.0297 ns |       1.00 |     0.02 |        - |        - |        - |         - |          NA |
|                                 |        |                |               |               |            |          |          |          |          |           |             |
| **ToArrayDotLengthGreaterThanZero** | **100000** | **757,725.156 ns** | **9,174.8777 ns** | **8,582.1863 ns** | **335,822.46** | **5,600.35** | **131.8359** | **131.8359** | **131.8359** |  **721184 B** |          **NA** |
| LinqCountGreaterThanZero        | 100000 | 224,881.034 ns |   767.8150 ns |   718.2146 ns |  99,666.88 | 1,289.33 |        - |        - |        - |      48 B |          NA |
| Any                             | 100000 |       2.257 ns |     0.0331 ns |     0.0293 ns |       1.00 |     0.02 |        - |        - |        - |         - |          NA |
