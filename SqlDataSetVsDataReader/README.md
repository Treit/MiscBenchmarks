# DataReader vs DataSet vs EntityFramework
This benchmark assumes you have the AdventureWorks2019 sample database installed.

The benchmark task simply reads one column of values from a fairly large table into a List<short>, in an attempt to evaluate the overhead of each technqiue for reading the data.



``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                       Method | Mean | Error | Ratio | RatioSD | Alloc Ratio |
|----------------------------- |-----:|------:|------:|--------:|------------:|
|      ReadDataUsingDataReader |   NA |    NA |     ? |       ? |           ? |
|         ReadDataUsingDataSet |   NA |    NA |     ? |       ? |           ? |
| ReadDataUsingEntityFramework |   NA |    NA |     ? |       ? |           ? |

Benchmarks with issues:
  Benchmark.ReadDataUsingDataReader: DefaultJob
  Benchmark.ReadDataUsingDataSet: DefaultJob
  Benchmark.ReadDataUsingEntityFramework: DefaultJob
