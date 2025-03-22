# Set vs. FrozenSet

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27818.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method               | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingSet       | 1000  | 10.078 ns | 0.2213 ns | 0.2460 ns |  1.00 |    0.00 |         - |          NA |
| LookupUsingFrozenSet | 1000  |  6.950 ns | 0.1291 ns | 0.1008 ns |  0.69 |    0.02 |         - |          NA |
