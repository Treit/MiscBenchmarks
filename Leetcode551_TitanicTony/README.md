# Leetcode problem 551 Student Attendance Record 1 from Discord user TitanicTony#9947





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method       | Job       | Runtime   | Count | Mean          | Error        | StdDev       |
|------------- |---------- |---------- |------ |--------------:|-------------:|-------------:|
| **TestVersionA** | **.NET 10.0** | **.NET 10.0** | **10**    |     **104.11 ns** |     **1.328 ns** |     **1.242 ns** |
| TestVersionB | .NET 10.0 | .NET 10.0 | 10    |      92.20 ns |     1.524 ns |     1.273 ns |
| TestVersionA | .NET 9.0  | .NET 9.0  | 10    |     102.51 ns |     1.441 ns |     1.277 ns |
| TestVersionB | .NET 9.0  | .NET 9.0  | 10    |      90.92 ns |     1.813 ns |     2.087 ns |
| **TestVersionA** | **.NET 10.0** | **.NET 10.0** | **10000** | **396,998.42 ns** | **7,910.988 ns** | **7,012.885 ns** |
| TestVersionB | .NET 10.0 | .NET 10.0 | 10000 | 365,848.31 ns | 3,274.976 ns | 3,063.415 ns |
| TestVersionA | .NET 9.0  | .NET 9.0  | 10000 | 393,286.09 ns | 7,479.484 ns | 6,630.367 ns |
| TestVersionB | .NET 9.0  | .NET 9.0  | 10000 | 383,711.18 ns | 2,190.361 ns | 1,829.051 ns |
