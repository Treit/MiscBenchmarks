# DataReader vs DataSet vs EntityFramework
This benchmark assumes you have the AdventureWorks2019 sample database installed.

The benchmark task simply reads one column of values from a fairly large table into a List<short>, in an attempt to evaluate the overhead of each technqiue for reading the data.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.28000.1199)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]    : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  .NET 10.0 : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  .NET 9.0  : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Job       | Runtime   | Mean      | Error    | StdDev    | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|----------------------------- |---------- |---------- |----------:|---------:|----------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| ReadDataUsingDataReader      | .NET 10.0 | .NET 10.0 |  37.65 ms | 2.221 ms |  6.478 ms |  1.03 |    0.25 |  400.0000 |  400.0000 |         - |    513.4 KB |        1.00 |
| ReadDataUsingDataSet         | .NET 10.0 | .NET 10.0 | 194.53 ms | 9.188 ms | 26.657 ms |  5.32 |    1.16 | 4333.3333 | 2666.6667 | 1000.0000 | 24967.66 KB |       48.63 |
| ReadDataUsingEntityFramework | .NET 10.0 | .NET 10.0 |  59.84 ms | 3.287 ms |  9.431 ms |  1.64 |    0.38 | 5333.3333 |  222.2222 |  111.1111 |    23265 KB |       45.32 |
|                              |           |           |           |          |           |       |         |           |           |           |             |             |
| ReadDataUsingDataReader      | .NET 9.0  | .NET 9.0  |  54.88 ms | 2.965 ms |  8.314 ms |  1.02 |    0.22 |  222.2222 |  222.2222 |         - |    513.4 KB |        1.00 |
| ReadDataUsingDataSet         | .NET 9.0  | .NET 9.0  | 222.27 ms | 8.942 ms | 26.084 ms |  4.14 |    0.80 | 4000.0000 | 2000.0000 | 1000.0000 | 24965.43 KB |       48.63 |
| ReadDataUsingEntityFramework | .NET 9.0  | .NET 9.0  |  62.61 ms | 3.584 ms | 10.399 ms |  1.17 |    0.26 | 5375.0000 |  250.0000 |  125.0000 | 23265.01 KB |       45.32 |
