# Goose wants to see what Yield does.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26244.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.5.24307.3
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method      | Count | Mean        | Error      | StdDev       | Median      | Ratio  | RatioSD | Allocated | Alloc Ratio |
|------------ |------ |------------:|-----------:|-------------:|------------:|-------:|--------:|----------:|------------:|
| NoYield     | 10000 |    16.03 μs |   0.424 μs |     1.230 μs |    15.59 μs |   1.00 |    0.00 |         - |          NA |
| TaskYield   | 10000 | 2,917.35 μs |  76.563 μs |   225.749 μs | 2,943.83 μs | 182.79 |   20.44 |     171 B |          NA |
| ThreadYield | 10000 | 9,740.89 μs | 939.217 μs | 2,555.209 μs | 8,814.54 μs | 610.10 |  178.46 |      50 B |          NA |
