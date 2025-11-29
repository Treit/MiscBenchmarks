# Producing a list of the first five keys from an existing list of KeyValuePairs.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                     | Job       | Runtime   | ListSize | Mean            | Error         | StdDev         | Median          | Ratio      | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------- |---------- |---------- |--------- |----------------:|--------------:|---------------:|----------------:|-----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **SelectDotToListDotGetRange** | **.NET 10.0** | **.NET 10.0** | **100**      |       **262.41 ns** |      **5.288 ns** |      **14.477 ns** |       **255.05 ns** |       **9.93** |     **0.55** |   **0.0596** |        **-** |        **-** |    **1000 B** |       **10.42** |
| GetRangeDotSelectDotToList | .NET 10.0 | .NET 10.0 | 100      |        49.86 ns |      0.501 ns |       0.444 ns |        49.84 ns |       1.89 |     0.02 |   0.0186 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | .NET 10.0 | .NET 10.0 | 100      |        48.78 ns |      0.570 ns |       0.533 ns |        48.62 ns |       1.85 |     0.03 |   0.0138 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | .NET 10.0 | .NET 10.0 | 100      |        47.74 ns |      0.451 ns |       0.399 ns |        47.61 ns |       1.81 |     0.02 |   0.0124 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | .NET 10.0 | .NET 10.0 | 100      |        26.42 ns |      0.265 ns |       0.248 ns |        26.37 ns |       1.00 |     0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                            |           |           |          |                 |               |                |                 |            |          |          |          |          |           |             |
| SelectDotToListDotGetRange | .NET 9.0  | .NET 9.0  | 100      |       268.80 ns |      5.429 ns |      16.008 ns |       267.66 ns |      10.24 |     0.61 |   0.0596 |        - |        - |    1000 B |       10.42 |
| GetRangeDotSelectDotToList | .NET 9.0  | .NET 9.0  | 100      |        50.07 ns |      0.479 ns |       0.425 ns |        50.05 ns |       1.91 |     0.02 |   0.0186 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | .NET 9.0  | .NET 9.0  | 100      |        48.76 ns |      0.511 ns |       0.478 ns |        48.63 ns |       1.86 |     0.02 |   0.0138 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | .NET 9.0  | .NET 9.0  | 100      |        48.52 ns |      0.586 ns |       0.519 ns |        48.50 ns |       1.85 |     0.02 |   0.0124 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | .NET 9.0  | .NET 9.0  | 100      |        26.24 ns |      0.206 ns |       0.193 ns |        26.22 ns |       1.00 |     0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                            |           |           |          |                 |               |                |                 |            |          |          |          |          |           |             |
| **SelectDotToListDotGetRange** | **.NET 10.0** | **.NET 10.0** | **1000000**  | **4,974,465.26 ns** | **99,344.799 ns** | **102,019.795 ns** | **4,943,405.47 ns** | **187,198.54** | **3,850.80** | **132.8125** | **132.8125** | **132.8125** | **8001019 B** |   **83,343.95** |
| GetRangeDotSelectDotToList | .NET 10.0 | .NET 10.0 | 1000000  |        49.71 ns |      0.315 ns |       0.280 ns |        49.61 ns |       1.87 |     0.01 |   0.0186 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | .NET 10.0 | .NET 10.0 | 1000000  |        47.94 ns |      0.461 ns |       0.409 ns |        47.91 ns |       1.80 |     0.02 |   0.0138 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | .NET 10.0 | .NET 10.0 | 1000000  |        48.98 ns |      0.490 ns |       0.458 ns |        49.07 ns |       1.84 |     0.02 |   0.0124 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | .NET 10.0 | .NET 10.0 | 1000000  |        26.57 ns |      0.149 ns |       0.139 ns |        26.57 ns |       1.00 |     0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
|                            |           |           |          |                 |               |                |                 |            |          |          |          |          |           |             |
| SelectDotToListDotGetRange | .NET 9.0  | .NET 9.0  | 1000000  | 4,980,883.88 ns | 94,808.000 ns |  88,683.462 ns | 4,982,683.20 ns | 188,187.86 | 3,598.97 | 132.8125 | 132.8125 | 132.8125 | 8001151 B |   83,345.32 |
| GetRangeDotSelectDotToList | .NET 9.0  | .NET 9.0  | 1000000  |        48.00 ns |      0.407 ns |       0.318 ns |        48.05 ns |       1.81 |     0.02 |   0.0186 |        - |        - |     312 B |        3.25 |
| SelectDotTakeDotToList     | .NET 9.0  | .NET 9.0  | 1000000  |        48.77 ns |      0.371 ns |       0.310 ns |        48.75 ns |       1.84 |     0.02 |   0.0138 |        - |        - |     232 B |        2.42 |
| TakeDotSelectDotToList     | .NET 9.0  | .NET 9.0  | 1000000  |        47.77 ns |      0.509 ns |       0.476 ns |        47.77 ns |       1.80 |     0.02 |   0.0124 |        - |        - |     208 B |        2.17 |
| NewListAndForLoop          | .NET 9.0  | .NET 9.0  | 1000000  |        26.47 ns |      0.241 ns |       0.225 ns |        26.49 ns |       1.00 |     0.01 |   0.0057 |        - |        - |      96 B |        1.00 |
