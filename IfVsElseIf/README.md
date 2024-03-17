# Two ifs vs. else-if in a loop, and variants.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  Job-ANXOLS : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method   | Count  | Mean      | Error    | StdDev   | Ratio | RatioSD |
|--------- |------- |----------:|---------:|---------:|------:|--------:|
| ElseIf   | 100000 |  85.50 μs | 1.533 μs | 1.434 μs |  1.00 |    0.00 |
| TwoIfs   | 100000 | 123.23 μs | 2.456 μs | 2.412 μs |  1.44 |    0.03 |
| Continue | 100000 |  88.55 μs | 1.305 μs | 1.221 μs |  1.04 |    0.02 |
| Switch   | 100000 |  85.95 μs | 1.484 μs | 1.388 μs |  1.01 |    0.03 |
