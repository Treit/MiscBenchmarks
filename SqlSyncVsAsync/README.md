# Synchronous vs. Asynchronous reads of SQL data.
This benchmark assumes you have the AdventureWorks2019 sample database installed.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.5 (CoreCLR 6.0.522.21309, CoreFX 6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.5 (CoreCLR 6.0.522.21309, CoreFX 6.0.522.21309), X64 RyuJIT


```
|                                        Method |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |---------:|---------:|---------:|---------:|------:|--------:|----------:|------:|------:|----------:|
|   SynchronousExecuteAndSynchronousReadAllRows | 185.6 ms | 13.05 ms | 38.47 ms | 189.0 ms |  1.00 |    0.00 |         - |     - |     - |   2.79 MB |
|  AsynchronousExecuteAndSynchronousReadAllRows | 165.0 ms | 12.30 ms | 34.89 ms | 151.2 ms |  0.93 |    0.27 |  666.6667 |     - |     - |   2.79 MB |
| AsynchronousExecuteAndAsynchronousReadAllRows | 227.8 ms |  3.95 ms |  4.39 ms | 226.0 ms |  1.20 |    0.27 | 3333.3333 |     - |     - |     13 MB |
