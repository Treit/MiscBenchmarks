# Producing a list of the first five keys from an existing list of KeyValuePairs.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | ListSize | Mean            | Error         | StdDev        | Ratio      | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------- |--------- |----------------:|--------------:|--------------:|-----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **SelectDotToListDotGetRange** | **100**      |       **258.88 ns** |      **5.173 ns** |      **6.158 ns** |       **9.75** |     **0.27** |   **0.0596** |        **-** |        **-** |    **1000 B** |       **10.42** |
| GetRangeDotSelectDotToList | 100      |        51.90 ns |      0.975 ns |      0.864 ns |       1.96 |     0.04 |   0.0186 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | 100      |        50.29 ns |      0.677 ns |      0.633 ns |       1.89 |     0.04 |   0.0138 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | 100      |        49.53 ns |      0.619 ns |      0.549 ns |       1.87 |     0.03 |   0.0124 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | 100      |        26.55 ns |      0.417 ns |      0.390 ns |       1.00 |     0.02 |   0.0057 |        - |        - |      96 B |        1.00 |
|                            |          |                 |               |               |            |          |          |          |          |           |             |
| **SelectDotToListDotGetRange** | **1000000**  | **5,662,518.18 ns** | **92,125.554 ns** | **86,174.300 ns** | **213,038.90** | **3,668.84** | **132.8125** | **132.8125** | **132.8125** | **8001131 B** |   **83,345.11** |
| GetRangeDotSelectDotToList | 1000000  |        48.67 ns |      0.674 ns |      0.597 ns |       1.83 |     0.03 |   0.0186 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | 1000000  |        50.78 ns |      0.840 ns |      0.786 ns |       1.91 |     0.03 |   0.0138 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | 1000000  |        51.98 ns |      0.586 ns |      0.548 ns |       1.96 |     0.03 |   0.0124 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | 1000000  |        26.58 ns |      0.262 ns |      0.245 ns |       1.00 |     0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
