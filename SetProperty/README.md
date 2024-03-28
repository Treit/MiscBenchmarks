## Setting a property





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                              | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| SetPropertyNormally                 |  7.258 ns | 0.1425 ns | 0.1264 ns |  7.230 ns |  1.00 |    0.00 | 0.0056 |      24 B |        1.00 |
| SetPropertyUsingDynamic             | 17.479 ns | 0.3208 ns | 0.8339 ns | 17.553 ns |  2.30 |    0.12 | 0.0055 |      24 B |        1.00 |
| SetPropertyUsingReflection          | 61.975 ns | 1.7267 ns | 5.0912 ns | 60.521 ns |  7.89 |    0.27 | 0.0055 |      24 B |        1.00 |
| SetPropertyUsingNonGenericInterface | 13.603 ns | 0.4300 ns | 1.2129 ns | 13.215 ns |  1.95 |    0.14 | 0.0055 |      24 B |        1.00 |
