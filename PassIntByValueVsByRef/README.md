# PassIntByValueVsByRef

Compares passing an integer to a method by value, by ref, and as a readonly ref using `in`.

The called methods are marked `NoInlining` to prevent the JIT from eliding the calling convention differences entirely.

## Results


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6491/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.103
  [Host]    : .NET 10.0.3 (10.0.326.7603), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.3 (10.0.326.7603), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.3 (10.0.326.7603), X64 RyuJIT AVX2


```
| Method      | Job       | Runtime   | Count  | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------ |---------- |---------- |------- |-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **PassByValue** | **.NET 10.0** | **.NET 10.0** | **1000**   |   **1.621 μs** | **0.0292 μs** | **0.0274 μs** |  **1.00** |    **0.02** |         **-** |          **NA** |
| PassByRef   | .NET 10.0 | .NET 10.0 | 1000   |   1.590 μs | 0.0131 μs | 0.0102 μs |  0.98 |    0.02 |         - |          NA |
| PassByIn    | .NET 10.0 | .NET 10.0 | 1000   |   1.595 μs | 0.0162 μs | 0.0151 μs |  0.98 |    0.02 |         - |          NA |
|             |           |           |        |            |           |           |       |         |           |             |
| PassByValue | .NET 9.0  | .NET 9.0  | 1000   |   1.615 μs | 0.0208 μs | 0.0194 μs |  1.00 |    0.02 |         - |          NA |
| PassByRef   | .NET 9.0  | .NET 9.0  | 1000   |   1.647 μs | 0.0326 μs | 0.0376 μs |  1.02 |    0.03 |         - |          NA |
| PassByIn    | .NET 9.0  | .NET 9.0  | 1000   |   1.622 μs | 0.0188 μs | 0.0147 μs |  1.00 |    0.01 |         - |          NA |
|             |           |           |        |            |           |           |       |         |           |             |
| **PassByValue** | **.NET 10.0** | **.NET 10.0** | **100000** | **165.875 μs** | **3.2126 μs** | **4.8084 μs** |  **1.00** |    **0.04** |         **-** |          **NA** |
| PassByRef   | .NET 10.0 | .NET 10.0 | 100000 | 164.619 μs | 3.2529 μs | 3.4806 μs |  0.99 |    0.04 |         - |          NA |
| PassByIn    | .NET 10.0 | .NET 10.0 | 100000 | 161.649 μs | 3.0011 μs | 2.8072 μs |  0.98 |    0.03 |         - |          NA |
|             |           |           |        |            |           |           |       |         |           |             |
| PassByValue | .NET 9.0  | .NET 9.0  | 100000 | 160.234 μs | 2.4541 μs | 2.2956 μs |  1.00 |    0.02 |         - |          NA |
| PassByRef   | .NET 9.0  | .NET 9.0  | 100000 | 161.854 μs | 3.1755 μs | 4.0160 μs |  1.01 |    0.03 |         - |          NA |
| PassByIn    | .NET 9.0  | .NET 9.0  | 100000 | 160.905 μs | 2.9432 μs | 2.6091 μs |  1.00 |    0.02 |         - |          NA |
