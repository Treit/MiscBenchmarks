# Toggling a boolean value


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count   | Mean       | Error    | StdDev   | Ratio | RatioSD |
|---------------------------- |-------- |-----------:|---------:|---------:|------:|--------:|
| ToggleUsingNegation         | 1000000 |   628.7 μs |  3.55 μs |  3.32 μs |  1.00 |    0.01 |
| ToggleUsingXor              | 1000000 |   743.6 μs |  3.09 μs |  2.74 μs |  1.18 |    0.01 |
| ToggleUsingTernary          | 1000000 |   626.7 μs |  3.85 μs |  3.41 μs |  1.00 |    0.01 |
| ToggleUsingSwitchExpression | 1000000 | 4,252.9 μs | 27.93 μs | 26.12 μs |  6.76 |    0.05 |
