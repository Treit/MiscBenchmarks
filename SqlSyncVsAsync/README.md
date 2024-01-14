# Synchronous vs. Asynchronous reads of SQL data.
This benchmark assumes you have the AdventureWorks2019 sample database installed.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                        Method | Mean | Error | Ratio | RatioSD | Alloc Ratio |
|---------------------------------------------- |-----:|------:|------:|--------:|------------:|
|   SynchronousExecuteAndSynchronousReadAllRows |   NA |    NA |     ? |       ? |           ? |
|  AsynchronousExecuteAndSynchronousReadAllRows |   NA |    NA |     ? |       ? |           ? |
| AsynchronousExecuteAndAsynchronousReadAllRows |   NA |    NA |     ? |       ? |           ? |

Benchmarks with issues:
  Benchmark.SynchronousExecuteAndSynchronousReadAllRows: DefaultJob
  Benchmark.AsynchronousExecuteAndSynchronousReadAllRows: DefaultJob
  Benchmark.AsynchronousExecuteAndAsynchronousReadAllRows: DefaultJob
