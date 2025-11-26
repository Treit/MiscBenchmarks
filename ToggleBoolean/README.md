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
| ToggleUsingNegation         | 1000000 |   629.9 μs |  4.44 μs |  4.16 μs |  1.00 |    0.01 |
| ToggleUsingXor              | 1000000 |   745.3 μs |  3.28 μs |  3.07 μs |  1.18 |    0.01 |
| ToggleUsingTernary          | 1000000 |   630.1 μs |  3.68 μs |  3.44 μs |  1.00 |    0.01 |
| ToggleUsingSwitchExpression | 1000000 | 4,268.2 μs | 31.02 μs | 29.01 μs |  6.78 |    0.06 |
