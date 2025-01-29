# Accessing HashSets using an assigned property vs. an expression body definition

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27783.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                  | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|------------------------ |------ |------------:|----------:|----------:|------:|--------:|---------:|----------:|------------:|
| HashSetAssignedProperty | 10000 |    53.01 μs |  1.002 μs |  0.888 μs |  1.00 |    0.00 |        - |         - |          NA |
| HashSetArrowProperty    | 10000 | 1,158.12 μs | 14.417 μs | 12.780 μs | 21.85 |    0.45 | 777.3438 | 3360001 B |          NA |
