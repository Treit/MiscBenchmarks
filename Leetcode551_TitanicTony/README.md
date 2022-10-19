# Leetcode problem 551 Student Attendance Record 1 from Discord user TitanicTony#9947

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25227
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|       Method | Count |         Mean |        Error |      StdDev |       Median |
|------------- |------ |-------------:|-------------:|------------:|-------------:|
| **TestVersionA** |    **10** |     **202.5 ns** |      **4.71 ns** |    **13.67 ns** |     **199.7 ns** |
| TestVersionB |    10 |     177.0 ns |      6.36 ns |    18.14 ns |     171.2 ns |
| **TestVersionA** | **10000** | **547,882.9 ns** | **10,604.15 ns** | **9,919.13 ns** | **549,219.4 ns** |
| TestVersionB | 10000 | 489,727.1 ns |  8,634.97 ns | 8,077.16 ns | 489,427.7 ns |
