# Producing a list of the first five keys from an existing list of KeyValuePairs.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                     | ListSize | Mean            | Error         | StdDev        | Median          | Ratio      | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------- |--------- |----------------:|--------------:|--------------:|----------------:|-----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **SelectDotToListDotGetRange** | **100**      |       **367.55 ns** |      **7.142 ns** |      **7.939 ns** |       **366.53 ns** |      **12.89** |     **0.35** |   **0.2389** |        **-** |        **-** |    **1032 B** |       **10.75** |
| GetRangeDotSelectDotToList | 100      |       127.35 ns |      2.739 ns |      7.452 ns |       124.74 ns |       4.48 |     0.26 |   0.0722 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | 100      |       129.84 ns |      4.833 ns |     13.712 ns |       123.96 ns |       5.10 |     0.56 |   0.0536 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | 100      |       117.90 ns |      2.237 ns |      4.910 ns |       116.34 ns |       4.26 |     0.23 |   0.0482 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | 100      |        28.54 ns |      0.310 ns |      0.290 ns |        28.51 ns |       1.00 |     0.00 |   0.0222 |        - |        - |      96 B |        1.00 |
|                            |          |                 |               |               |                 |            |          |          |          |          |           |             |
| **SelectDotToListDotGetRange** | **1000000**  | **7,835,907.92 ns** | **88,119.654 ns** | **78,115.778 ns** | **7,821,928.91 ns** | **231,504.12** | **7,564.98** | **234.3750** | **234.3750** | **234.3750** | **8000312 B** |   **83,336.58** |
| GetRangeDotSelectDotToList | 1000000  |       115.92 ns |      2.183 ns |      1.936 ns |       115.46 ns |       3.42 |     0.11 |   0.0722 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | 1000000  |       120.16 ns |      2.413 ns |      3.965 ns |       118.60 ns |       3.47 |     0.18 |   0.0536 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | 1000000  |       117.65 ns |      2.246 ns |      3.291 ns |       117.01 ns |       3.41 |     0.15 |   0.0482 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | 1000000  |        35.35 ns |      0.774 ns |      1.793 ns |        34.81 ns |       1.00 |     0.00 |   0.0222 |        - |        - |      96 B |        1.00 |
