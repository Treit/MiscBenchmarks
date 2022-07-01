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
|                       Method |      Mean |    Error |   StdDev | Ratio | RatioSD |     Gen 0 |     Gen 1 |    Gen 2 |   Allocated |
|----------------------------- |----------:|---------:|---------:|------:|--------:|----------:|----------:|---------:|------------:|
|      ReadDataUsingDataReader |  23.68 ms | 0.473 ms | 0.901 ms |  1.00 |    0.00 |   93.7500 |   93.7500 |  93.7500 |   513.48 KB |
|         ReadDataUsingDataSet | 152.92 ms | 1.721 ms | 1.437 ms |  6.49 |    0.31 | 4250.0000 | 2000.0000 | 750.0000 |  24966.4 KB |
| ReadDataUsingEntityFramework |  33.21 ms | 0.906 ms | 2.584 ms |  1.43 |    0.12 | 5000.0000 |         - |        - | 23266.52 KB |
