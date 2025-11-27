# Iterating a List with and without CollectionsMarshal.AsSpan








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Job       | Runtime   | Count  | Mean     | Error    | StdDev   | Ratio | RatioSD |
|-------------------------------------------- |---------- |---------- |------- |---------:|---------:|---------:|------:|--------:|
| IterateUsingForEach                         | .NET 10.0 | .NET 10.0 | 100000 | 63.02 μs | 0.622 μs | 0.582 μs |  1.92 |    0.03 |
| IterateUsingForEachCollectionsMarshalAsSpan | .NET 10.0 | .NET 10.0 | 100000 | 32.87 μs | 0.432 μs | 0.404 μs |  1.00 |    0.02 |
|                                             |           |           |        |          |          |          |       |         |
| IterateUsingForEach                         | .NET 9.0  | .NET 9.0  | 100000 | 62.83 μs | 0.717 μs | 0.670 μs |  1.89 |    0.02 |
| IterateUsingForEachCollectionsMarshalAsSpan | .NET 9.0  | .NET 9.0  | 100000 | 33.24 μs | 0.277 μs | 0.259 μs |  1.00 |    0.01 |
