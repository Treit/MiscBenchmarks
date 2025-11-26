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
| SingleItemIntEnumerableDotRepeat       | 8.2067 ns | 0.1218 ns | 0.1139 ns | 8.2330 ns | 1.000 |    0.02 | 0.0019 |      32 B |        1.00 |
| SingleItemIntEnumerableNewArray        | 3.1471 ns | 0.0712 ns | 0.0632 ns | 3.1485 ns | 0.384 |    0.01 | 0.0019 |      32 B |        1.00 |
| SingleItemIntEnumerableWrapperClass    | 0.0047 ns | 0.0025 ns | 0.0023 ns | 0.0048 ns | 0.001 |    0.00 |      - |         - |        0.00 |
| SingleItemStringEnumerableDotRepeat    | 9.0095 ns | 0.0894 ns | 0.0792 ns | 8.9951 ns | 1.098 |    0.02 | 0.0024 |      40 B |        1.25 |
| SingleItemStringEnumerableNewArray     | 3.1655 ns | 0.0659 ns | 0.0616 ns | 3.1617 ns | 0.386 |    0.01 | 0.0019 |      32 B |        1.00 |
| SingleItemStringEnumerableWrapperClass | 0.0005 ns | 0.0009 ns | 0.0008 ns | 0.0000 ns | 0.000 |    0.00 |      - |         - |        0.00 |
