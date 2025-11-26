## Setting a property







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------ |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| SetPropertyNormally                 |  7.387 ns | 0.1992 ns | 0.1863 ns |  1.00 |    0.03 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingDynamic             | 13.039 ns | 0.1573 ns | 0.1472 ns |  1.77 |    0.05 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingReflection          | 39.841 ns | 0.2620 ns | 0.2323 ns |  5.40 |    0.13 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingNonGenericInterface | 10.229 ns | 0.1212 ns | 0.1134 ns |  1.39 |    0.04 | 0.0014 |      24 B |        1.00 |
