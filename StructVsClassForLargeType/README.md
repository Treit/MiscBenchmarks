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
| SumStructFields | 100000 | 7,200.8 μs |  18.77 μs |  17.55 μs |        - |        - |        - |          - |
| SumClassFields  | 100000 | 6,986.4 μs |  20.33 μs |  19.02 μs |        - |        - |        - |          - |
| BoxStructs      | 100000 | 8,408.1 μs | 166.34 μs | 227.69 μs | 796.8750 | 781.2500 | 234.3750 | 10400154 B |
| StoreClasses    | 100000 |   572.5 μs |   4.77 μs |   4.47 μs |  69.3359 |  69.3359 |  69.3359 |   800602 B |
