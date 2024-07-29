# Producing a list of the first five keys from an existing list of KeyValuePairs.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                     | ListSize | Mean            | Error         | StdDev        | Ratio     | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------- |--------- |----------------:|--------------:|--------------:|----------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **SelectDotToListDotGetRange** | **100**      |       **356.59 ns** |      **6.949 ns** |      **5.426 ns** |      **3.06** |    **0.06** |   **0.2389** |        **-** |        **-** |    **1032 B** |        **4.45** |
| GetRangeDotSelectDotToList | 100      |       115.66 ns |      2.375 ns |      2.333 ns |      0.99 |    0.02 |   0.0722 |        - |        - |     312 B |        1.34 |
| SelectDotTakeDotToList     | 100      |       116.58 ns |      0.942 ns |      0.881 ns |      1.00 |    0.00 |   0.0536 |        - |        - |     232 B |        1.00 |
| TakeDotSelectDotToList     | 100      |       114.88 ns |      0.680 ns |      0.603 ns |      0.98 |    0.01 |   0.0482 |        - |        - |     208 B |        0.90 |
| NewListAndForLoop          | 100      |        29.75 ns |      0.610 ns |      0.950 ns |      0.26 |    0.01 |   0.0222 |        - |        - |      96 B |        0.41 |
|                            |          |                 |               |               |           |         |          |          |          |           |             |
| **SelectDotToListDotGetRange** | **1000000**  | **8,067,341.85 ns** | **61,747.329 ns** | **54,737.399 ns** | **68,204.59** |  **978.37** | **234.3750** | **234.3750** | **234.3750** | **8000312 B** |   **34,484.10** |
| GetRangeDotSelectDotToList | 1000000  |       118.40 ns |      2.120 ns |      3.173 ns |      1.00 |    0.03 |   0.0722 |        - |        - |     312 B |        1.34 |
| SelectDotTakeDotToList     | 1000000  |       118.37 ns |      1.648 ns |      1.376 ns |      1.00 |    0.00 |   0.0536 |        - |        - |     232 B |        1.00 |
| TakeDotSelectDotToList     | 1000000  |       115.65 ns |      2.350 ns |      4.054 ns |      0.97 |    0.04 |   0.0482 |        - |        - |     208 B |        0.90 |
| NewListAndForLoop          | 1000000  |        33.17 ns |      0.642 ns |      0.570 ns |      0.28 |    0.01 |   0.0222 |        - |        - |      96 B |        0.41 |
