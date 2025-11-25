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
| ElseIf   | 100000 | 126.5 μs | 1.86 μs | 1.74 μs |  1.00 |    0.02 |
| TwoIfs   | 100000 | 150.6 μs | 2.96 μs | 3.74 μs |  1.19 |    0.03 |
| Continue | 100000 | 110.6 μs | 0.61 μs | 0.57 μs |  0.87 |    0.01 |
| Switch   | 100000 | 110.3 μs | 0.39 μs | 0.37 μs |  0.87 |    0.01 |
