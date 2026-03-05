# CustomStringJoinVsBuiltIns

Compares a custom `Span<char>`/`stackalloc`-based string join implementation against `string.Concat`, `string.Join`, and string interpolation.

## Results

```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6649/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.103
  [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3


```
| Method                 | Count | Mean        | Error     | StdDev      | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |------ |------------:|----------:|------------:|------:|--------:|-------:|----------:|------------:|
| **CustomSpanJoin**         | **10**    |    **269.3 ns** |   **5.41 ns** |    **15.25 ns** |  **1.00** |    **0.08** | **0.0696** |   **1.14 KB** |        **1.00** |
| CustomSpanJoinConstant | 10    |    337.3 ns |   5.77 ns |     4.82 ns |  1.26 |    0.07 | 0.0696 |   1.14 KB |        1.00 |
| StringConcat           | 10    |    210.7 ns |   4.25 ns |     6.86 ns |  0.78 |    0.05 | 0.0842 |   1.38 KB |        1.21 |
| StringJoin             | 10    |    190.3 ns |   4.39 ns |    12.80 ns |  0.71 |    0.06 | 0.0696 |   1.14 KB |        1.00 |
| StringInterpolation    | 10    |    342.0 ns |   6.84 ns |    13.50 ns |  1.27 |    0.09 | 0.0696 |   1.14 KB |        1.00 |
| StringCreate           | 10    |    161.7 ns |   4.33 ns |    12.50 ns |  0.60 |    0.06 | 0.0696 |   1.14 KB |        1.00 |
|                        |       |             |           |             |       |         |        |           |             |
| **CustomSpanJoin**         | **1000**  | **27,811.3 ns** | **548.59 ns** |   **960.80 ns** |  **1.00** |    **0.05** | **7.9346** |  **129.9 KB** |        **1.00** |
| CustomSpanJoinConstant | 1000  | 37,104.9 ns | 734.95 ns | 1,732.35 ns |  1.34 |    0.08 | 7.9346 |  129.9 KB |        1.00 |
| StringConcat           | 1000  | 23,415.3 ns | 465.09 ns | 1,049.79 ns |  0.84 |    0.05 | 9.3689 | 153.34 KB |        1.18 |
| StringJoin             | 1000  | 20,841.5 ns | 415.70 ns | 1,087.82 ns |  0.75 |    0.05 | 7.9346 |  129.9 KB |        1.00 |
| StringInterpolation    | 1000  | 35,430.0 ns | 700.59 ns | 1,048.61 ns |  1.28 |    0.06 | 7.9346 |  129.9 KB |        1.00 |
| StringCreate           | 1000  | 19,752.8 ns | 393.08 ns |   656.74 ns |  0.71 |    0.03 | 7.9346 |  129.9 KB |        1.00 |
