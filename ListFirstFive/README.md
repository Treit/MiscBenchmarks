# Producing a list of the first five keys from an existing list of KeyValuePairs.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | ListSize | Mean            | Error          | StdDev         | Ratio      | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------- |--------- |----------------:|---------------:|---------------:|-----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **SelectDotToListDotGetRange** | **100**      |       **278.14 ns** |       **5.601 ns** |      **16.249 ns** |       **9.50** |     **0.56** |   **0.0596** |        **-** |        **-** |    **1000 B** |       **10.42** |
| GetRangeDotSelectDotToList | 100      |        49.93 ns |       0.600 ns |       0.561 ns |       1.71 |     0.02 |   0.0186 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | 100      |        49.46 ns |       1.053 ns |       1.127 ns |       1.69 |     0.04 |   0.0138 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | 100      |        48.68 ns |       0.672 ns |       0.628 ns |       1.66 |     0.02 |   0.0124 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | 100      |        29.28 ns |       0.274 ns |       0.243 ns |       1.00 |     0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                            |          |                 |                |                |            |          |          |          |          |           |             |
| **SelectDotToListDotGetRange** | **1000000**  | **5,715,275.30 ns** | **112,988.267 ns** | **165,616.750 ns** | **216,547.53** | **6,828.82** | **132.8125** | **132.8125** | **132.8125** | **8001189 B** |   **83,345.72** |
| GetRangeDotSelectDotToList | 1000000  |        50.02 ns |       0.648 ns |       0.541 ns |       1.90 |     0.03 |   0.0186 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | 1000000  |        48.56 ns |       0.298 ns |       0.233 ns |       1.84 |     0.03 |   0.0138 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | 1000000  |        49.75 ns |       0.560 ns |       0.524 ns |       1.89 |     0.03 |   0.0124 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | 1000000  |        26.40 ns |       0.394 ns |       0.368 ns |       1.00 |     0.02 |   0.0057 |        - |        - |      96 B |        1.00 |
