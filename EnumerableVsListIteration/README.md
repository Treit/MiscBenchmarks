# Enumerating using IEnumerable vs List





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count  | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|----------------------------------- |---------- |---------- |------- |-----------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **EnumerateUsingEnumerableAndForEach** | **.NET 10.0** | **.NET 10.0** | **1000**   |   **1.264 μs** | **0.0104 μs** | **0.0093 μs** |  **1.00** |    **0.01** |   **0.0019** |        **-** |        **-** |      **40 B** |        **1.00** |
| EnumerateUsingToListAndForEach     | .NET 10.0 | .NET 10.0 | 1000   |   3.066 μs | 0.0332 μs | 0.0310 μs |  2.43 |    0.03 |   0.5035 |        - |        - |    8424 B |      210.60 |
|                                    |           |           |        |            |           |           |       |         |          |          |          |           |             |
| EnumerateUsingEnumerableAndForEach | .NET 9.0  | .NET 9.0  | 1000   |   1.262 μs | 0.0078 μs | 0.0069 μs |  1.00 |    0.01 |   0.0019 |        - |        - |      40 B |        1.00 |
| EnumerateUsingToListAndForEach     | .NET 9.0  | .NET 9.0  | 1000   |   3.074 μs | 0.0372 μs | 0.0330 μs |  2.44 |    0.03 |   0.5035 |        - |        - |    8424 B |      210.60 |
|                                    |           |           |        |            |           |           |       |         |          |          |          |           |             |
| **EnumerateUsingEnumerableAndForEach** | **.NET 10.0** | **.NET 10.0** | **100000** | **124.967 μs** | **1.0981 μs** | **1.0271 μs** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
| EnumerateUsingToListAndForEach     | .NET 10.0 | .NET 10.0 | 100000 | 583.650 μs | 4.6485 μs | 4.3482 μs |  4.67 |    0.05 | 285.1563 | 285.1563 | 285.1563 | 1049072 B |   26,226.80 |
|                                    |           |           |        |            |           |           |       |         |          |          |          |           |             |
| EnumerateUsingEnumerableAndForEach | .NET 9.0  | .NET 9.0  | 100000 | 126.223 μs | 1.5783 μs | 1.4763 μs |  1.00 |    0.02 |        - |        - |        - |      40 B |        1.00 |
| EnumerateUsingToListAndForEach     | .NET 9.0  | .NET 9.0  | 100000 | 589.435 μs | 6.3850 μs | 5.9725 μs |  4.67 |    0.07 | 285.1563 | 285.1563 | 285.1563 | 1049072 B |   26,226.80 |
