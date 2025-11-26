# Enumerating using IEnumerable vs List




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count  | Mean       | Error      | StdDev     | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|----------------------------------- |------- |-----------:|-----------:|-----------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **EnumerateUsingEnumerableAndForEach** | **1000**   |   **1.302 μs** |  **0.0109 μs** |  **0.0097 μs** |  **1.00** |    **0.01** |   **0.0019** |        **-** |        **-** |      **40 B** |        **1.00** |
| EnumerateUsingToListAndForEach     | 1000   |   3.028 μs |  0.0319 μs |  0.0299 μs |  2.33 |    0.03 |   0.5035 |        - |        - |    8424 B |      210.60 |
|                                    |        |            |            |            |       |         |          |          |          |           |             |
| **EnumerateUsingEnumerableAndForEach** | **100000** | **124.614 μs** |  **1.0011 μs** |  **0.9364 μs** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
| EnumerateUsingToListAndForEach     | 100000 | 688.334 μs | 13.6225 μs | 33.1592 μs |  5.52 |    0.27 | 285.1563 | 285.1563 | 285.1563 | 1049072 B |   26,226.80 |
