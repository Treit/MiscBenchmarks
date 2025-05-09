# Enumerating array vs. ReadOnlyCollection wrapper around the array.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27852.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]   : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  .NET 7.0 : .NET 7.0.20 (7.0.2024.26716), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  .NET 9.0 : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Job      | Runtime  | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |--------- |--------- |------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| EnumerateArray              | .NET 7.0 | .NET 7.0 | 100   | 532.7 ns | 10.38 ns | 11.54 ns |  2.71 |    0.11 | 0.0067 |      32 B |        1.00 |
| EnumerateArrayAsEnumerable  | .NET 7.0 | .NET 7.0 | 100   | 523.6 ns |  9.07 ns |  7.08 ns |  2.63 |    0.07 | 0.0067 |      32 B |        1.00 |
| EnumerateReadOnlyCollection | .NET 7.0 | .NET 7.0 | 100   | 540.6 ns | 10.75 ns | 24.69 ns |  2.75 |    0.14 | 0.0067 |      32 B |        1.00 |
| EnumerateArray              | .NET 8.0 | .NET 8.0 | 100   | 215.0 ns |  2.65 ns |  2.35 ns |  1.08 |    0.03 | 0.0074 |      32 B |        1.00 |
| EnumerateArrayAsEnumerable  | .NET 8.0 | .NET 8.0 | 100   | 215.5 ns |  4.34 ns |  3.84 ns |  1.09 |    0.03 | 0.0074 |      32 B |        1.00 |
| EnumerateReadOnlyCollection | .NET 8.0 | .NET 8.0 | 100   | 188.0 ns |  3.64 ns |  4.19 ns |  0.96 |    0.03 | 0.0074 |      32 B |        1.00 |
| EnumerateArray              | .NET 9.0 | .NET 9.0 | 100   | 176.0 ns |  3.18 ns |  3.40 ns |  0.89 |    0.03 | 0.0074 |      32 B |        1.00 |
| EnumerateArrayAsEnumerable  | .NET 9.0 | .NET 9.0 | 100   | 180.2 ns |  3.53 ns |  4.83 ns |  0.92 |    0.03 | 0.0074 |      32 B |        1.00 |
| EnumerateReadOnlyCollection | .NET 9.0 | .NET 9.0 | 100   | 196.4 ns |  3.97 ns |  5.56 ns |  1.00 |    0.00 | 0.0074 |      32 B |        1.00 |
