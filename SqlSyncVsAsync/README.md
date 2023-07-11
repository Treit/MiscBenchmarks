# Synchronous vs. Asynchronous reads of SQL data.
This benchmark assumes you have the AdventureWorks2019 sample database installed.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25900.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2


```
|                                        Method |     Mean |   Error |   StdDev |   Median | Ratio | RatioSD |      Gen0 | Allocated | Alloc Ratio |
|---------------------------------------------- |---------:|--------:|---------:|---------:|------:|--------:|----------:|----------:|------------:|
|   SynchronousExecuteAndSynchronousReadAllRows | 116.2 ms | 2.32 ms |  6.24 ms | 114.7 ms |  1.00 |    0.00 |  500.0000 |   2.79 MB |        1.00 |
|  AsynchronousExecuteAndSynchronousReadAllRows | 131.8 ms | 6.00 ms | 17.03 ms | 132.0 ms |  1.14 |    0.17 |  600.0000 |   2.79 MB |        1.00 |
| AsynchronousExecuteAndAsynchronousReadAllRows | 186.8 ms | 4.99 ms | 14.01 ms | 181.9 ms |  1.60 |    0.11 | 3000.0000 |     13 MB |        4.65 |
