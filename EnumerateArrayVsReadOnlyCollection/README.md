# Enumerating array vs. ReadOnlyCollection wrapper around the array.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27852.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
| EnumerateArray              | 100   | 216.3 ns | 2.39 ns | 1.99 ns |  1.16 |    0.02 | 0.0074 |      32 B |        1.00 |
| EnumerateArrayAsEnumerable  | 100   | 219.4 ns | 4.38 ns | 6.41 ns |  1.19 |    0.04 | 0.0074 |      32 B |        1.00 |
| EnumerateReadOnlyCollection | 100   | 187.2 ns | 3.45 ns | 3.23 ns |  1.00 |    0.00 | 0.0074 |      32 B |        1.00 |
