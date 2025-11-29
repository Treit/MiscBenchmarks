# struct vs. class for relatively large types




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Job       | Runtime   | Count  | Mean       | Error     | StdDev    | Gen0     | Gen1     | Gen2     | Allocated  |
|---------------- |---------- |---------- |------- |-----------:|----------:|----------:|---------:|---------:|---------:|-----------:|
| SumStructFields | .NET 10.0 | .NET 10.0 | 100000 | 7,235.6 μs |   3.28 μs |   2.56 μs |        - |        - |        - |          - |
| SumClassFields  | .NET 10.0 | .NET 10.0 | 100000 | 7,039.3 μs |   8.93 μs |   7.46 μs |        - |        - |        - |          - |
| BoxStructs      | .NET 10.0 | .NET 10.0 | 100000 | 8,260.0 μs |  23.10 μs |  19.29 μs | 796.8750 | 781.2500 | 234.3750 | 10400154 B |
| StoreClasses    | .NET 10.0 | .NET 10.0 | 100000 |   562.7 μs |   3.65 μs |   3.23 μs |  69.3359 |  69.3359 |  69.3359 |   800598 B |
| SumStructFields | .NET 9.0  | .NET 9.0  | 100000 | 7,257.6 μs |   4.15 μs |   3.46 μs |        - |        - |        - |          - |
| SumClassFields  | .NET 9.0  | .NET 9.0  | 100000 | 6,993.7 μs |  13.72 μs |  12.83 μs |        - |        - |        - |          - |
| BoxStructs      | .NET 9.0  | .NET 9.0  | 100000 | 8,275.5 μs | 163.85 μs | 145.24 μs | 796.8750 | 781.2500 | 234.3750 | 10400154 B |
| StoreClasses    | .NET 9.0  | .NET 9.0  | 100000 |   564.6 μs |   3.21 μs |   3.00 μs |  69.3359 |  69.3359 |  69.3359 |   800598 B |
