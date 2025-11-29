# Indicating an empty sequence.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                     | Job       | Runtime   | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------- |---------- |---------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| ReturnEnumerableEmpty      | .NET 10.0 | .NET 10.0 | 31.07 μs | 0.067 μs | 0.062 μs |  0.99 |    0.03 |         - |          NA |
| ReturnArrayEmpty           | .NET 10.0 | .NET 10.0 | 31.14 μs | 0.239 μs | 0.223 μs |  1.00 |    0.03 |         - |          NA |
| ReturnNewArray             | .NET 10.0 | .NET 10.0 | 31.11 μs | 0.182 μs | 0.170 μs |  0.99 |    0.03 |         - |          NA |
| ReturnNull                 | .NET 10.0 | .NET 10.0 | 31.30 μs | 0.618 μs | 0.943 μs |  1.00 |    0.04 |         - |          NA |
| ReturnCollectionExpression | .NET 10.0 | .NET 10.0 | 31.11 μs | 0.141 μs | 0.132 μs |  0.99 |    0.03 |         - |          NA |
|                            |           |           |          |          |          |       |         |           |             |
| ReturnEnumerableEmpty      | .NET 9.0  | .NET 9.0  | 31.16 μs | 0.168 μs | 0.158 μs |  1.00 |    0.01 |         - |          NA |
| ReturnArrayEmpty           | .NET 9.0  | .NET 9.0  | 31.16 μs | 0.221 μs | 0.207 μs |  1.00 |    0.01 |         - |          NA |
| ReturnNewArray             | .NET 9.0  | .NET 9.0  | 31.07 μs | 0.082 μs | 0.076 μs |  1.00 |    0.01 |         - |          NA |
| ReturnNull                 | .NET 9.0  | .NET 9.0  | 31.09 μs | 0.161 μs | 0.150 μs |  1.00 |    0.01 |         - |          NA |
| ReturnCollectionExpression | .NET 9.0  | .NET 9.0  | 31.11 μs | 0.082 μs | 0.077 μs |  1.00 |    0.01 |         - |          NA |
