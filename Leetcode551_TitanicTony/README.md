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
| **TestVersionA** | **10**    |     **106.90 ns** |     **0.714 ns** |     **0.668 ns** |
| TestVersionB | 10    |      92.47 ns |     0.881 ns |     0.824 ns |
| **TestVersionA** | **10000** | **393,658.56 ns** | **1,635.295 ns** | **1,449.647 ns** |
| TestVersionB | 10000 | 394,545.45 ns | 1,894.184 ns | 1,581.729 ns |
