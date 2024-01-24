# Repeating strings


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                       Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen0 |   Gen1 | Allocated | Alloc Ratio |
|----------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
|   **DupeUsingStringBuilderLoop** |     **3** |  **29.31 ns** |  **0.643 ns** |  **0.601 ns** |  **29.45 ns** |  **1.00** |    **0.00** | **0.0081** |      **-** |     **136 B** |        **1.00** |
|        DupeUsingStringCreate |     3 |  18.74 ns |  0.221 ns |  0.196 ns |  18.77 ns |  0.64 |    0.02 | 0.0062 |      - |     104 B |        0.76 |
| DupeUsingStackOverflowAnswer |     3 |  55.78 ns |  0.994 ns |  0.930 ns |  55.80 ns |  1.90 |    0.05 | 0.0153 |      - |     256 B |        1.88 |
|    DupeUsingEnumerableRepeat |     3 |  35.36 ns |  0.179 ns |  0.167 ns |  35.37 ns |  1.21 |    0.03 | 0.0048 |      - |      80 B |        0.59 |
|                              |       |           |           |           |           |       |         |        |        |           |             |
|   **DupeUsingStringBuilderLoop** |    **50** | **239.78 ns** |  **2.471 ns** |  **2.311 ns** | **240.59 ns** |  **1.00** |    **0.00** | **0.0420** |      **-** |     **704 B** |        **1.00** |
|        DupeUsingStringCreate |    50 | 158.01 ns |  3.207 ns |  8.505 ns | 153.36 ns |  0.68 |    0.05 | 0.0234 |      - |     392 B |        0.56 |
| DupeUsingStackOverflowAnswer |    50 | 479.63 ns |  3.056 ns |  2.858 ns | 478.97 ns |  2.00 |    0.03 | 0.0887 |      - |    1496 B |        2.12 |
|    DupeUsingEnumerableRepeat |    50 | 239.86 ns |  1.356 ns |  1.268 ns | 239.54 ns |  1.00 |    0.01 | 0.0219 |      - |     368 B |        0.52 |
|                              |       |           |           |           |           |       |         |        |        |           |             |
|   **DupeUsingStringBuilderLoop** |   **100** | **510.73 ns** |  **4.415 ns** |  **4.130 ns** | **509.95 ns** |  **1.00** |    **0.00** | **0.0772** |      **-** |    **1296 B** |        **1.00** |
|        DupeUsingStringCreate |   100 | 295.44 ns |  2.575 ns |  2.283 ns | 294.96 ns |  0.58 |    0.01 | 0.0410 |      - |     688 B |        0.53 |
| DupeUsingStackOverflowAnswer |   100 | 911.28 ns | 13.074 ns | 12.230 ns | 908.29 ns |  1.78 |    0.03 | 0.1535 | 0.0010 |    2576 B |        1.99 |
|    DupeUsingEnumerableRepeat |   100 | 494.52 ns |  1.070 ns |  0.948 ns | 494.56 ns |  0.97 |    0.01 | 0.0391 |      - |     664 B |        0.51 |
