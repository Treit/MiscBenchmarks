# Enumerating using IEnumerable vs List



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count  | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|----------------------------------- |------- |-----------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **EnumerateUsingEnumerableAndForEach** | **1000**   |   **1.269 μs** | **0.0077 μs** | **0.0072 μs** |  **1.00** |    **0.01** |   **0.0019** |        **-** |        **-** |      **40 B** |        **1.00** |
| EnumerateUsingToListAndForEach     | 1000   |   3.030 μs | 0.0440 μs | 0.0390 μs |  2.39 |    0.03 |   0.5035 |        - |        - |    8424 B |      210.60 |
|                                    |        |            |           |           |       |         |          |          |          |           |             |
| **EnumerateUsingEnumerableAndForEach** | **100000** | **125.223 μs** | **0.7629 μs** | **0.7136 μs** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
| EnumerateUsingToListAndForEach     | 100000 | 707.614 μs | 5.6733 μs | 5.3068 μs |  5.65 |    0.05 | 285.1563 | 285.1563 | 285.1563 | 1049072 B |   26,226.80 |
