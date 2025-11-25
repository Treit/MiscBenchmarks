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
| SetPropertyNormally                 |  6.728 ns | 0.0965 ns | 0.0903 ns |  1.00 |    0.02 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingDynamic             | 12.871 ns | 0.0699 ns | 0.0546 ns |  1.91 |    0.03 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingReflection          | 39.065 ns | 0.2877 ns | 0.2402 ns |  5.81 |    0.08 | 0.0014 |      24 B |        1.00 |
| SetPropertyUsingNonGenericInterface | 10.234 ns | 0.1033 ns | 0.0966 ns |  1.52 |    0.02 | 0.0014 |      24 B |        1.00 |
