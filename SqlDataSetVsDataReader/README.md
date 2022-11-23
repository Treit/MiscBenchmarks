# DataReader vs DataSet vs EntityFramework
This benchmark assumes you have the AdventureWorks2019 sample database installed.

The benchmark task simply reads one column of values from a fairly large table into a List<short>, in an attempt to evaluate the overhead of each technqiue for reading the data.


``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.25252.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|                       Method |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |      Gen0 |      Gen1 |      Gen2 |   Allocated | Alloc Ratio |
|----------------------------- |----------:|---------:|---------:|----------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
|      ReadDataUsingDataReader |  26.99 ms | 1.001 ms | 2.888 ms |  26.62 ms |  1.00 |    0.00 |   93.7500 |   93.7500 |   93.7500 |   513.48 KB |        1.00 |
|         ReadDataUsingDataSet | 145.53 ms | 2.549 ms | 2.833 ms | 144.85 ms |  5.80 |    0.66 | 4500.0000 | 2750.0000 | 1000.0000 | 24968.49 KB |       48.63 |
| ReadDataUsingEntityFramework |  28.99 ms | 0.760 ms | 2.131 ms |  28.14 ms |  1.09 |    0.12 | 5406.2500 |  218.7500 |  125.0000 | 23264.94 KB |       45.31 |
