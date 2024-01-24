# Leetcode problem 551 Student Attendance Record 1 from Discord user TitanicTony#9947


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|       Method | Count |         Mean |     Error |    StdDev |
|------------- |------ |-------------:|----------:|----------:|
| **TestVersionA** |    **10** |     **136.1 ns** |   **1.77 ns** |   **1.57 ns** |
| TestVersionB |    10 |     111.2 ns |   1.30 ns |   1.22 ns |
| **TestVersionA** | **10000** | **382,845.6 ns** | **550.06 ns** | **487.62 ns** |
| TestVersionB | 10000 | 380,428.0 ns | 304.57 ns | 254.33 ns |
