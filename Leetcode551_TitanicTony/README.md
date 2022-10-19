# Leetcode problem 551 Student Attendance Record 1 from Discord user TitanicTony#9947

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25227
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|       Method | Count |         Mean |       Error |       StdDev |
|------------- |------ |-------------:|------------:|-------------:|
| **TestVersionA** |    **10** |     **191.9 ns** |     **3.87 ns** |      **4.90 ns** |
| TestVersionB |    10 |     125.7 ns |     2.52 ns |      5.43 ns |
| **TestVersionA** | **10000** | **529,737.7 ns** | **9,947.63 ns** |  **8,818.31 ns** |
| TestVersionB | 10000 | 443,668.6 ns | 8,563.05 ns | 10,193.70 ns |
