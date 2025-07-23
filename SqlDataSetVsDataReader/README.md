# DataReader vs DataSet vs EntityFramework
This benchmark assumes you have the AdventureWorks2019 sample database installed.

The benchmark task simply reads one column of values from a fairly large table into a List<short>, in an attempt to evaluate the overhead of each technqiue for reading the data.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27909.1000)
Unknown processor
.NET SDK 9.0.302
  [Host]     : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Mean      | Error    | StdDev   | Median    | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|----------------------------- |----------:|---------:|---------:|----------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| ReadDataUsingDataReader      |  24.39 ms | 0.999 ms | 2.850 ms |  23.27 ms |  1.00 |    0.00 |   93.7500 |   93.7500 |   93.7500 |   513.48 KB |        1.00 |
| ReadDataUsingDataSet         | 135.44 ms | 2.923 ms | 8.479 ms | 130.98 ms |  5.63 |    0.71 | 4500.0000 | 2500.0000 | 1000.0000 |  24965.8 KB |       48.62 |
| ReadDataUsingEntityFramework |  25.71 ms | 0.773 ms | 2.231 ms |  24.85 ms |  1.07 |    0.15 | 5406.2500 |  218.7500 |  125.0000 | 23265.03 KB |       45.31 |
