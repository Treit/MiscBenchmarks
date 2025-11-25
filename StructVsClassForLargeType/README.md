# struct vs. class for relatively large types


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Count  | Mean       | Error     | StdDev    | Gen0     | Gen1     | Gen2     | Allocated  |
|---------------- |------- |-----------:|----------:|----------:|---------:|---------:|---------:|-----------:|
| SumStructFields | 100000 | 7,259.7 μs |  15.47 μs |  12.92 μs |        - |        - |        - |          - |
| SumClassFields  | 100000 | 7,013.6 μs |  18.89 μs |  17.67 μs |        - |        - |        - |          - |
| BoxStructs      | 100000 | 8,517.2 μs | 161.98 μs | 135.26 μs | 796.8750 | 781.2500 | 234.3750 | 10400154 B |
| StoreClasses    | 100000 |   602.3 μs |   4.97 μs |   4.65 μs |  69.3359 |  69.3359 |  69.3359 |   800633 B |
