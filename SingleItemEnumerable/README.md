# Turning a single item into an IEnumerable.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Job       | Runtime   | Mean      | Error     | StdDev    | Median    | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |---------- |---------- |----------:|----------:|----------:|----------:|------:|-------:|----------:|------------:|
| SingleItemIntEnumerableDotRepeat       | .NET 10.0 | .NET 10.0 | 8.0245 ns | 0.0788 ns | 0.0737 ns | 8.0353 ns | 1.000 | 0.0019 |      32 B |        1.00 |
| SingleItemIntEnumerableNewArray        | .NET 10.0 | .NET 10.0 | 3.0905 ns | 0.0604 ns | 0.0565 ns | 3.0847 ns | 0.385 | 0.0019 |      32 B |        1.00 |
| SingleItemIntEnumerableWrapperClass    | .NET 10.0 | .NET 10.0 | 0.0092 ns | 0.0162 ns | 0.0135 ns | 0.0022 ns | 0.001 |      - |         - |        0.00 |
| SingleItemStringEnumerableDotRepeat    | .NET 10.0 | .NET 10.0 | 8.8581 ns | 0.0865 ns | 0.0809 ns | 8.8696 ns | 1.104 | 0.0024 |      40 B |        1.25 |
| SingleItemStringEnumerableNewArray     | .NET 10.0 | .NET 10.0 | 4.4763 ns | 0.0567 ns | 0.0531 ns | 4.4815 ns | 0.558 | 0.0019 |      32 B |        1.00 |
| SingleItemStringEnumerableWrapperClass | .NET 10.0 | .NET 10.0 | 0.0018 ns | 0.0038 ns | 0.0034 ns | 0.0000 ns | 0.000 |      - |         - |        0.00 |
|                                        |           |           |           |           |           |           |       |        |           |             |
| SingleItemIntEnumerableDotRepeat       | .NET 9.0  | .NET 9.0  | 7.9486 ns | 0.0615 ns | 0.0545 ns | 7.9450 ns | 1.000 | 0.0019 |      32 B |        1.00 |
| SingleItemIntEnumerableNewArray        | .NET 9.0  | .NET 9.0  | 4.1373 ns | 0.0350 ns | 0.0310 ns | 4.1366 ns | 0.521 | 0.0019 |      32 B |        1.00 |
| SingleItemIntEnumerableWrapperClass    | .NET 9.0  | .NET 9.0  | 0.0028 ns | 0.0038 ns | 0.0036 ns | 0.0010 ns | 0.000 |      - |         - |        0.00 |
| SingleItemStringEnumerableDotRepeat    | .NET 9.0  | .NET 9.0  | 8.8785 ns | 0.0620 ns | 0.0580 ns | 8.8716 ns | 1.117 | 0.0024 |      40 B |        1.25 |
| SingleItemStringEnumerableNewArray     | .NET 9.0  | .NET 9.0  | 3.1086 ns | 0.0382 ns | 0.0358 ns | 3.1023 ns | 0.391 | 0.0019 |      32 B |        1.00 |
| SingleItemStringEnumerableWrapperClass | .NET 9.0  | .NET 9.0  | 0.0016 ns | 0.0013 ns | 0.0011 ns | 0.0013 ns | 0.000 |      - |         - |        0.00 |
