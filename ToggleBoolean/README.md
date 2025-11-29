# Toggling a boolean value




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count   | Mean       | Error   | StdDev  | Ratio | RatioSD |
|---------------------------- |---------- |---------- |-------- |-----------:|--------:|--------:|------:|--------:|
| ToggleUsingNegation         | .NET 10.0 | .NET 10.0 | 1000000 |   624.5 μs | 3.67 μs | 3.26 μs |  1.00 |    0.01 |
| ToggleUsingXor              | .NET 10.0 | .NET 10.0 | 1000000 |   752.4 μs | 1.01 μs | 0.95 μs |  1.20 |    0.01 |
| ToggleUsingTernary          | .NET 10.0 | .NET 10.0 | 1000000 |   622.1 μs | 0.62 μs | 0.48 μs |  1.00 |    0.01 |
| ToggleUsingSwitchExpression | .NET 10.0 | .NET 10.0 | 1000000 | 4,145.8 μs | 3.91 μs | 3.47 μs |  6.64 |    0.03 |
|                             |           |           |         |            |         |         |       |         |
| ToggleUsingNegation         | .NET 9.0  | .NET 9.0  | 1000000 |   622.0 μs | 1.04 μs | 0.87 μs |  1.00 |    0.00 |
| ToggleUsingXor              | .NET 9.0  | .NET 9.0  | 1000000 |   752.4 μs | 1.47 μs | 1.30 μs |  1.21 |    0.00 |
| ToggleUsingTernary          | .NET 9.0  | .NET 9.0  | 1000000 |   623.2 μs | 1.70 μs | 1.42 μs |  1.00 |    0.00 |
| ToggleUsingSwitchExpression | .NET 9.0  | .NET 9.0  | 1000000 | 4,127.7 μs | 3.63 μs | 3.03 μs |  6.64 |    0.01 |
