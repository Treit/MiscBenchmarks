# Searching for several items in a list of strings.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0    | Gen1    | Allocated | Alloc Ratio |
|-------------------- |------ |-----------:|----------:|----------:|------:|--------:|--------:|--------:|----------:|------------:|
| **SliceWithSpan**       | **10**    |   **1.216 μs** | **0.0143 μs** | **0.0120 μs** |  **1.00** |    **0.01** |  **0.4025** |  **0.0057** |    **6.6 KB** |        **1.00** |
| SliceWithEnumerable | 10    |   1.262 μs | 0.0178 μs | 0.0166 μs |  1.04 |    0.02 |  0.4215 |  0.0076 |    6.9 KB |        1.04 |
|                     |       |            |           |           |       |         |         |         |           |             |
| **SliceWithSpan**       | **1000**  | **116.724 μs** | **0.9891 μs** | **0.8260 μs** |  **1.00** |    **0.01** | **32.5928** | **21.3623** | **532.84 KB** |        **1.00** |
| SliceWithEnumerable | 1000  | 117.438 μs | 1.5053 μs | 1.4081 μs |  1.01 |    0.01 | 31.8604 | 22.5830 | 522.55 KB |        0.98 |
