# Synchronous vs. Asynchronous reads of SQL data.
This benchmark assumes you have the AdventureWorks2019 sample database installed.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Job       | Runtime   | Mean | Error | Ratio | RatioSD | Alloc Ratio |
|---------------------------------------------- |---------- |---------- |-----:|------:|------:|--------:|------------:|
| SynchronousExecuteAndSynchronousReadAllRows   | .NET 10.0 | .NET 10.0 |   NA |    NA |     ? |       ? |           ? |
| AsynchronousExecuteAndSynchronousReadAllRows  | .NET 10.0 | .NET 10.0 |   NA |    NA |     ? |       ? |           ? |
| AsynchronousExecuteAndAsynchronousReadAllRows | .NET 10.0 | .NET 10.0 |   NA |    NA |     ? |       ? |           ? |
|                                               |           |           |      |       |       |         |             |
| SynchronousExecuteAndSynchronousReadAllRows   | .NET 9.0  | .NET 9.0  |   NA |    NA |     ? |       ? |           ? |
| AsynchronousExecuteAndSynchronousReadAllRows  | .NET 9.0  | .NET 9.0  |   NA |    NA |     ? |       ? |           ? |
| AsynchronousExecuteAndAsynchronousReadAllRows | .NET 9.0  | .NET 9.0  |   NA |    NA |     ? |       ? |           ? |

Benchmarks with issues:
  Benchmark.SynchronousExecuteAndSynchronousReadAllRows: .NET 10.0(Runtime=.NET 10.0)
  Benchmark.AsynchronousExecuteAndSynchronousReadAllRows: .NET 10.0(Runtime=.NET 10.0)
  Benchmark.AsynchronousExecuteAndAsynchronousReadAllRows: .NET 10.0(Runtime=.NET 10.0)
  Benchmark.SynchronousExecuteAndSynchronousReadAllRows: .NET 9.0(Runtime=.NET 9.0)
  Benchmark.AsynchronousExecuteAndSynchronousReadAllRows: .NET 9.0(Runtime=.NET 9.0)
  Benchmark.AsynchronousExecuteAndAsynchronousReadAllRows: .NET 9.0(Runtime=.NET 9.0)
