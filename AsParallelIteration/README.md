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
|     Method | ItemCount | PredicateCount |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |     Gen 0 |    Gen 1 | Allocated |
|----------- |---------- |--------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|---------:|----------:|
| **NoParallel** |    **100000** |              **1** | **12.574 ms** | **0.3127 ms** | **0.8921 ms** | **12.468 ms** |  **2.55** |    **0.23** |  **750.0000** |  **15.6250** |      **3 MB** |
|  ParallelA |    100000 |              1 |  5.490 ms | 0.1798 ms | 0.5301 ms |  5.284 ms |  1.11 |    0.12 |  773.4375 | 140.6250 |      3 MB |
|  ParallelB |    100000 |              1 | 12.891 ms | 0.2570 ms | 0.7289 ms | 12.674 ms |  2.62 |    0.22 |  750.0000 |  15.6250 |      3 MB |
|  ParallelC |    100000 |              1 |  4.945 ms | 0.1028 ms | 0.3031 ms |  4.907 ms |  1.00 |    0.00 |  773.4375 | 187.5000 |      3 MB |
|            |           |                |           |           |           |           |       |         |           |          |           |
| **NoParallel** |    **100000** |              **4** | **15.257 ms** | **0.3622 ms** | **1.0623 ms** | **15.036 ms** |  **1.74** |    **1.03** |  **843.7500** |        **-** |      **3 MB** |
|  ParallelA |    100000 |              4 |  5.445 ms | 0.1077 ms | 0.2075 ms |  5.413 ms |  0.48 |    0.26 |  867.1875 |  23.4375 |      4 MB |
|  ParallelB |    100000 |              4 | 15.949 ms | 0.4845 ms | 1.4057 ms | 15.928 ms |  1.77 |    1.04 |  843.7500 |        - |      3 MB |
|  ParallelC |    100000 |              4 | 12.503 ms | 2.3624 ms | 6.9657 ms | 12.588 ms |  1.00 |    0.00 |         - |        - |      4 MB |
|            |           |                |           |           |           |           |       |         |           |          |           |
| **NoParallel** |    **100000** |             **10** | **19.215 ms** | **0.4219 ms** | **1.2037 ms** | **19.221 ms** |  **1.13** |    **0.66** | **1000.0000** |  **31.2500** |      **4 MB** |
|  ParallelA |    100000 |             10 |  7.107 ms | 0.1900 ms | 0.5543 ms |  7.046 ms |  0.41 |    0.24 | 1031.2500 | 234.3750 |      4 MB |
|  ParallelB |    100000 |             10 | 25.943 ms | 1.6668 ms | 4.9147 ms | 24.782 ms |  1.57 |    1.10 | 1000.0000 |  31.2500 |      4 MB |
|  ParallelC |    100000 |             10 | 21.960 ms | 3.2402 ms | 9.4518 ms | 23.019 ms |  1.00 |    0.00 |         - |        - |      5 MB |
