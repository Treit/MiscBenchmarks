# Turning a single item into an IEnumerable.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| SingleItemIntEnumerableDotRepeat       | 8.1230 ns | 0.1114 ns | 0.1042 ns | 8.1006 ns | 1.000 |    0.02 | 0.0019 |      32 B |        1.00 |
| SingleItemIntEnumerableNewArray        | 3.1597 ns | 0.0614 ns | 0.0575 ns | 3.1584 ns | 0.389 |    0.01 | 0.0019 |      32 B |        1.00 |
| SingleItemIntEnumerableWrapperClass    | 0.0008 ns | 0.0010 ns | 0.0008 ns | 0.0005 ns | 0.000 |    0.00 |      - |         - |        0.00 |
| SingleItemStringEnumerableDotRepeat    | 8.9478 ns | 0.0755 ns | 0.0706 ns | 8.9565 ns | 1.102 |    0.02 | 0.0024 |      40 B |        1.25 |
| SingleItemStringEnumerableNewArray     | 3.1465 ns | 0.0658 ns | 0.0615 ns | 3.1370 ns | 0.387 |    0.01 | 0.0019 |      32 B |        1.00 |
| SingleItemStringEnumerableWrapperClass | 0.0030 ns | 0.0019 ns | 0.0016 ns | 0.0034 ns | 0.000 |    0.00 |      - |         - |        0.00 |
