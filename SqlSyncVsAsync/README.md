# Synchronous vs. Asynchronous reads of SQL data.
This benchmark assumes you have the AdventureWorks2019 sample database installed.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                        | Mean     | Error   | StdDev   | Ratio | RatioSD | Gen0      | Allocated | Alloc Ratio |
|---------------------------------------------- |---------:|--------:|---------:|------:|--------:|----------:|----------:|------------:|
| SynchronousExecuteAndSynchronousReadAllRows   | 132.4 ms | 2.62 ms |  6.44 ms |  1.00 |    0.09 |  500.0000 |   2.79 MB |        1.00 |
| AsynchronousExecuteAndSynchronousReadAllRows  | 131.3 ms | 4.41 ms | 12.36 ms |  1.00 |    0.00 |  500.0000 |    2.8 MB |        1.00 |
| AsynchronousExecuteAndAsynchronousReadAllRows | 197.6 ms | 3.89 ms |  5.19 ms |  1.46 |    0.16 | 3000.0000 |     13 MB |        4.65 |
