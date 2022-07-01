# DataReader vs DataSet vs EntityFramework
This benchmark assumes you have the AdventureWorks2019 sample database installed.

The benchmark task simply reads one column of values from a fairly large table into a List<short>, in an attempt to evaluate the overhead of each technqiue for reading the data.


``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25151
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                       Method |      Mean |    Error |   StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|----------------------------- |----------:|---------:|---------:|------:|--------:|-----------:|----------:|----------:|----------:|
|      ReadDataUsingDataReader |  90.95 ms | 1.771 ms | 1.818 ms |  1.00 |    0.00 |   666.6667 |         - |         - |   3.29 MB |
|         ReadDataUsingDataSet | 337.08 ms | 4.061 ms | 3.391 ms |  3.69 |    0.08 | 10000.0000 | 4000.0000 | 2000.0000 |  78.12 MB |
| ReadDataUsingEntityFramework |  29.98 ms | 0.587 ms | 1.250 ms |  0.33 |    0.02 |  5000.0000 |         - |         - |  22.72 MB |
