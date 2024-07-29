# Producing a list of the first five keys from an existing list of KeyValuePairs.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                     | ListSize | Mean           | Error         | StdDev        | Ratio     | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------- |--------- |---------------:|--------------:|--------------:|----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **SelectDotToListDotGetRange** | **100**      |       **352.4 ns** |       **5.76 ns** |       **5.39 ns** |      **3.00** |     **0.10** |   **0.2389** |        **-** |        **-** |    **1032 B** |        **4.45** |
| GetRangeDotSelectDotToList | 100      |       114.6 ns |       1.82 ns |       2.02 ns |      0.98 |     0.03 |   0.0722 |        - |        - |     312 B |        1.34 |
| SelectDotTakeDotToList     | 100      |       116.9 ns |       2.40 ns |       2.94 ns |      1.00 |     0.00 |   0.0536 |        - |        - |     232 B |        1.00 |
| TakeDotSelectDotToList     | 100      |       115.6 ns |       2.31 ns |       2.38 ns |      0.99 |     0.03 |   0.0482 |        - |        - |     208 B |        0.90 |
|                            |          |                |               |               |           |          |          |          |          |           |             |
| **SelectDotToListDotGetRange** | **1000000**  | **7,860,964.1 ns** | **132,862.67 ns** | **158,163.56 ns** | **68,022.99** | **1,855.38** | **234.3750** | **234.3750** | **234.3750** | **8000312 B** |   **34,484.10** |
| GetRangeDotSelectDotToList | 1000000  |       113.7 ns |       2.23 ns |       1.98 ns |      0.98 |     0.02 |   0.0722 |        - |        - |     312 B |        1.34 |
| SelectDotTakeDotToList     | 1000000  |       116.2 ns |       1.06 ns |       0.83 ns |      1.00 |     0.00 |   0.0536 |        - |        - |     232 B |        1.00 |
| TakeDotSelectDotToList     | 1000000  |       111.5 ns |       1.07 ns |       1.00 ns |      0.96 |     0.01 |   0.0482 |        - |        - |     208 B |        0.90 |
