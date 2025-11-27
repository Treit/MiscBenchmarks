# Two ifs vs. else-if in a loop, and variants.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method   | Job       | Runtime   | Count  | Mean     | Error   | StdDev  | Ratio | RatioSD |
|--------- |---------- |---------- |------- |---------:|--------:|--------:|------:|--------:|
| ElseIf   | .NET 10.0 | .NET 10.0 | 100000 | 126.6 μs | 1.96 μs | 1.83 μs |  1.00 |    0.02 |
| TwoIfs   | .NET 10.0 | .NET 10.0 | 100000 | 146.3 μs | 1.06 μs | 0.99 μs |  1.16 |    0.02 |
| Continue | .NET 10.0 | .NET 10.0 | 100000 | 126.4 μs | 1.58 μs | 1.48 μs |  1.00 |    0.02 |
| Switch   | .NET 10.0 | .NET 10.0 | 100000 | 127.2 μs | 2.50 μs | 2.56 μs |  1.00 |    0.02 |
|          |           |           |        |          |         |         |       |         |
| ElseIf   | .NET 9.0  | .NET 9.0  | 100000 | 126.5 μs | 1.88 μs | 1.76 μs |  1.00 |    0.02 |
| TwoIfs   | .NET 9.0  | .NET 9.0  | 100000 | 150.0 μs | 2.82 μs | 3.14 μs |  1.19 |    0.03 |
| Continue | .NET 9.0  | .NET 9.0  | 100000 | 126.4 μs | 1.34 μs | 1.25 μs |  1.00 |    0.02 |
| Switch   | .NET 9.0  | .NET 9.0  | 100000 | 126.0 μs | 1.02 μs | 0.95 μs |  1.00 |    0.02 |
