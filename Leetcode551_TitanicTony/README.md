# Leetcode problem 551 Student Attendance Record 1 from Discord user TitanicTony#9947



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method       | Count | Mean          | Error        | StdDev       |
|------------- |------ |--------------:|-------------:|-------------:|
| **TestVersionA** | **10**    |      **97.37 ns** |     **1.961 ns** |     **2.014 ns** |
| TestVersionB | 10    |     103.90 ns |     0.544 ns |     0.454 ns |
| **TestVersionA** | **10000** | **388,692.97 ns** | **1,249.087 ns** | **1,043.044 ns** |
| TestVersionB | 10000 | 382,289.87 ns | 1,417.185 ns | 1,325.636 ns |
