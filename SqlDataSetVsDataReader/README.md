# DataReader vs DataSet vs EntityFramework
This benchmark assumes you have the AdventureWorks2019 sample database installed.

The benchmark task simply reads one column of values from a fairly large table into a List<short>, in an attempt to evaluate the overhead of each technqiue for reading the data.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|----------------------------- |----------:|---------:|---------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| ReadDataUsingDataReader      |  24.59 ms | 0.483 ms | 0.997 ms |  1.00 |    0.00 |   93.7500 |   93.7500 |   93.7500 |   513.66 KB |        1.00 |
| ReadDataUsingDataSet         | 148.78 ms | 2.927 ms | 5.710 ms |  6.07 |    0.32 | 4500.0000 | 2500.0000 | 1000.0000 |  24966.6 KB |       48.61 |
| ReadDataUsingEntityFramework |  39.86 ms | 0.713 ms | 0.793 ms |  1.65 |    0.08 | 5384.6154 |  230.7692 |   76.9231 | 23265.61 KB |       45.29 |
