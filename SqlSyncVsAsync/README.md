# Synchronous vs. Asynchronous reads of SQL data.
This benchmark assumes you have the AdventureWorks2019 sample database installed.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Mean | Error | Ratio | RatioSD | Alloc Ratio |
|---------------------------------------------- |-----:|------:|------:|--------:|------------:|
| SynchronousExecuteAndSynchronousReadAllRows   |   NA |    NA |     ? |       ? |           ? |
| AsynchronousExecuteAndSynchronousReadAllRows  |   NA |    NA |     ? |       ? |           ? |
| AsynchronousExecuteAndAsynchronousReadAllRows |   NA |    NA |     ? |       ? |           ? |

Benchmarks with issues:
  Benchmark.SynchronousExecuteAndSynchronousReadAllRows: DefaultJob
  Benchmark.AsynchronousExecuteAndSynchronousReadAllRows: DefaultJob
  Benchmark.AsynchronousExecuteAndAsynchronousReadAllRows: DefaultJob
