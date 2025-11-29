## Setting a property








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Job       | Runtime   | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------ |---------- |---------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| SetPropertyNormally                 | .NET 10.0 | .NET 10.0 |  6.746 ns | 0.0626 ns | 0.0586 ns |  1.00 |    0.01 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingDynamic             | .NET 10.0 | .NET 10.0 | 12.561 ns | 0.1128 ns | 0.1000 ns |  1.86 |    0.02 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingReflection          | .NET 10.0 | .NET 10.0 | 38.958 ns | 0.1185 ns | 0.1108 ns |  5.78 |    0.05 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingNonGenericInterface | .NET 10.0 | .NET 10.0 |  9.588 ns | 0.0632 ns | 0.0560 ns |  1.42 |    0.01 | 0.0014 |      24 B |        1.00 |
|                                     |           |           |           |           |           |       |         |        |           |             |
| SetPropertyNormally                 | .NET 9.0  | .NET 9.0  |  6.771 ns | 0.0946 ns | 0.0885 ns |  1.00 |    0.02 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingDynamic             | .NET 9.0  | .NET 9.0  | 12.500 ns | 0.0663 ns | 0.0588 ns |  1.85 |    0.02 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingReflection          | .NET 9.0  | .NET 9.0  | 39.332 ns | 0.1921 ns | 0.1797 ns |  5.81 |    0.08 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingNonGenericInterface | .NET 9.0  | .NET 9.0  |  9.629 ns | 0.1099 ns | 0.1028 ns |  1.42 |    0.02 | 0.0014 |      24 B |        1.00 |
