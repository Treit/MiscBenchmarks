# Move a random item to the front of the list, leaving the rest in existing order

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27713.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                         | Count | Mean        | Error       | StdDev      | Ratio  | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------------------------- |------ |------------:|------------:|------------:|-------:|--------:|-------:|-------:|----------:|------------:|
| MoveUsingRandomIndex                           | 1000  |    824.2 ns |    14.61 ns |    12.95 ns |   1.00 |    0.00 | 0.0687 |      - |     304 B |        1.00 |
| MoveUsingLinqOrderByRandomWithUnecessaryToList | 1000  | 85,572.9 ns | 1,486.50 ns | 1,241.29 ns | 103.84 |    1.88 | 5.6152 | 0.2441 |   24696 B |       81.24 |
