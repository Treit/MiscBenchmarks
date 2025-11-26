# Concat vs Append String Arrays Benchmark

Compares different approaches for creating string arrays that combine a range of generated strings with additional fixed strings.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **UsingConcat**         | **100**   |  **3.512 μs** | **0.0174 μs** | **0.0163 μs** |  **1.00** |    **0.01** | **0.2594** |      **-** |   **4.25 KB** |        **1.00** |
| UsingAppend         | 100   |  3.035 μs | 0.0502 μs | 0.0537 μs |  0.86 |    0.02 | 0.2594 | 0.0038 |   4.24 KB |        1.00 |
| UsingListAdd        | 100   |  2.178 μs | 0.0231 μs | 0.0181 μs |  0.62 |    0.01 | 0.2937 | 0.0038 |    4.8 KB |        1.13 |
| UsingListAddRange   | 100   |  2.913 μs | 0.0583 μs | 0.0836 μs |  0.83 |    0.02 | 0.2975 |      - |   4.89 KB |        1.15 |
| UsingArrayWithIndex | 100   |  2.120 μs | 0.0423 μs | 0.0550 μs |  0.60 |    0.02 | 0.2403 |      - |   3.95 KB |        0.93 |
| UsingArrayCopyTo    | 100   |  2.140 μs | 0.0268 μs | 0.0237 μs |  0.61 |    0.01 | 0.2899 | 0.0038 |   4.76 KB |        1.12 |
| UsingSpanAndCopyTo  | 100   |  2.158 μs | 0.0243 μs | 0.0216 μs |  0.61 |    0.01 | 0.2403 |      - |   3.95 KB |        0.93 |
|                     |       |           |           |           |       |         |        |        |           |             |
| **UsingConcat**         | **1000**  | **33.193 μs** | **0.4309 μs** | **0.3820 μs** |  **1.00** |    **0.02** | **2.8076** | **0.1221** |  **46.44 KB** |        **1.00** |
| UsingAppend         | 1000  | 28.538 μs | 0.1929 μs | 0.1710 μs |  0.86 |    0.01 | 2.8381 | 0.4272 |  46.43 KB |        1.00 |
| UsingListAdd        | 1000  | 21.341 μs | 0.2311 μs | 0.2048 μs |  0.64 |    0.01 | 3.2959 | 0.5188 |  54.02 KB |        1.16 |
| UsingListAddRange   | 1000  | 28.790 μs | 0.5443 μs | 0.6050 μs |  0.87 |    0.02 | 3.2959 | 0.4578 |  54.11 KB |        1.17 |
| UsingArrayWithIndex | 1000  | 21.261 μs | 0.3887 μs | 0.3992 μs |  0.64 |    0.01 | 2.8076 | 0.3967 |  46.14 KB |        0.99 |
| UsingArrayCopyTo    | 1000  | 23.086 μs | 0.1883 μs | 0.1761 μs |  0.70 |    0.01 | 3.2959 | 0.4883 |  53.98 KB |        1.16 |
| UsingSpanAndCopyTo  | 1000  | 21.617 μs | 0.1936 μs | 0.1511 μs |  0.65 |    0.01 | 2.8076 | 0.3967 |  46.14 KB |        0.99 |
