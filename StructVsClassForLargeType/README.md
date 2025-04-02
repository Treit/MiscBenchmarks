# struct vs. class for relatively large types

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27828.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method          | Count  | Mean      | Error     | StdDev    | Gen0      | Gen1      | Gen2     | Allocated  |
|---------------- |------- |----------:|----------:|----------:|----------:|----------:|---------:|-----------:|
| SumStructFields | 100000 |  6.177 ms | 0.1223 ms | 0.2266 ms |         - |         - |        - |        3 B |
| SumClassFields  | 100000 |  6.010 ms | 0.1186 ms | 0.2475 ms |         - |         - |        - |        3 B |
| BoxStructs      | 100000 | 16.346 ms | 0.3715 ms | 1.0598 ms | 1875.0000 | 1187.5000 | 343.7500 | 10400212 B |
| StoreClasses    | 100000 |  1.196 ms | 0.0239 ms | 0.0591 ms |   62.5000 |   62.5000 |  62.5000 |   800529 B |
