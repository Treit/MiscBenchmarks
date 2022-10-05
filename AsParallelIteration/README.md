AsParallel iteration

```cs
// Version A
var rows = _keywords.AsParallel();

foreach (var predicate in predicates)
{
    rows = rows.Where(predicate);
}

return rows.ToList();

// Version B
IEnumerable<Keyword> rows = _keywords.AsParallel();

foreach (var predicate in predicates)
{
    rows = rows.Where(predicate);
}

return rows.ToList();


// Version C
IEnumerable<Keyword> rows = _keywords;

foreach (var predicate in predicates)
{
    rows = rows.AsParallel().Where(predicate);
}

return rows.ToList();
```

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.25211
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT


```
|     Method |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD |     Gen 0 |    Gen 1 | Allocated |
|----------- |----------:|---------:|----------:|----------:|------:|--------:|----------:|---------:|----------:|
| NoParallel | 138.27 ms | 6.125 ms | 17.965 ms | 134.72 ms |  2.64 |    0.38 | 7400.0000 | 200.0000 |     32 MB |
|  ParallelA |  55.29 ms | 1.153 ms |  3.382 ms |  54.75 ms |  1.06 |    0.08 | 7090.9091 | 454.5455 |     33 MB |
|  ParallelB | 145.76 ms | 4.960 ms | 14.310 ms | 140.68 ms |  2.78 |    0.31 | 7250.0000 |        - |     32 MB |
|  ParallelC |  52.58 ms | 1.043 ms |  3.074 ms |  52.52 ms |  1.00 |    0.00 | 7500.0000 | 100.0000 |     32 MB |

