# DataReader vs DataSet
This benchmark assumes you have the AdventureWorks2019 sample database installed.


``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25151
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                  Method |      Mean |    Error |    StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|------------------------ |----------:|---------:|----------:|------:|--------:|-----------:|----------:|----------:|----------:|
| ReadDataUsingDataReader |  90.98 ms | 1.790 ms |  2.328 ms |  1.00 |    0.00 |   666.6667 |         - |         - |   3.29 MB |
|    ReadDataUsingDataSet | 338.72 ms | 6.535 ms | 11.950 ms |  3.73 |    0.11 | 10000.0000 | 4000.0000 | 2000.0000 |  78.12 MB |
