# Toggling a boolean value

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26236.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count   | Mean       | Error    | StdDev    | Ratio | RatioSD |
|---------------------------- |-------- |-----------:|---------:|----------:|------:|--------:|
| ToggleUsingNegation         | 1000000 |   552.1 μs |  4.48 μs |   3.50 μs |  1.00 |    0.00 |
| ToggleUsingXor              | 1000000 |   553.5 μs |  9.48 μs |   8.40 μs |  1.00 |    0.02 |
| ToggleUsingTernary          | 1000000 |   550.6 μs |  6.48 μs |   6.06 μs |  1.00 |    0.01 |
| ToggleUsingSwitchExpression | 1000000 | 4,200.5 μs | 82.81 μs | 163.46 μs |  7.61 |    0.33 |
