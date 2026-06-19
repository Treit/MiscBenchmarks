# JsonVsLinq

Compares the cost of JSON serialization (without source generation) of a model with 20 small string properties vs. a simple LINQ `Where` over 100 elements.

## Results


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.28120.2315)
Unknown processor
.NET SDK 10.0.201
  [Host]    : .NET 10.0.8 (10.0.826.23019), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  .NET 10.0 : .NET 10.0.8 (10.0.826.23019), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

Job=.NET 10.0  Runtime=.NET 10.0  

```
| Method        | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------- |-----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| JsonSerialize | 1,027.7 ns | 25.07 ns | 71.93 ns |  1.00 |    0.10 | 0.1564 |     680 B |        1.00 |
| LinqWhere     |   200.3 ns |  3.23 ns |  2.87 ns |  0.20 |    0.01 | 0.0758 |     328 B |        0.48 |
