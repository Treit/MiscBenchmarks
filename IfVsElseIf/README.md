# Two ifs vs. else-if in a loop, and variants.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method   | Count  | Mean     | Error   | StdDev  | Ratio | RatioSD |
|--------- |------- |---------:|--------:|--------:|------:|--------:|
| ElseIf   | 100000 | 126.9 μs | 2.53 μs | 3.38 μs |  1.00 |    0.04 |
| TwoIfs   | 100000 | 150.6 μs | 2.86 μs | 3.18 μs |  1.19 |    0.04 |
| Continue | 100000 | 126.3 μs | 0.96 μs | 0.89 μs |  1.00 |    0.02 |
| Switch   | 100000 | 110.2 μs | 0.38 μs | 0.36 μs |  0.87 |    0.02 |
