# Searching a list using Where().FirstOrDefault() vs. just FirstOrDefault()





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | Count   | Mean           | Error        | StdDev       | Ratio |
|------------------------ |---------- |---------- |-------- |---------------:|-------------:|-------------:|------:|
| **WhereThenFirstOrDefault** | **.NET 10.0** | **.NET 10.0** | **100**     |       **151.5 ns** |      **0.62 ns** |      **0.52 ns** |  **1.00** |
| FirstOrDefault          | .NET 10.0 | .NET 10.0 | 100     |       103.6 ns |      0.14 ns |      0.12 ns |  0.68 |
|                         |           |           |         |                |              |              |       |
| WhereThenFirstOrDefault | .NET 9.0  | .NET 9.0  | 100     |       152.8 ns |      0.65 ns |      0.58 ns |  1.00 |
| FirstOrDefault          | .NET 9.0  | .NET 9.0  | 100     |       131.6 ns |      0.27 ns |      0.22 ns |  0.86 |
|                         |           |           |         |                |              |              |       |
| **WhereThenFirstOrDefault** | **.NET 10.0** | **.NET 10.0** | **1000000** | **1,852,029.6 ns** | **13,614.06 ns** | **11,368.36 ns** |  **1.00** |
| FirstOrDefault          | .NET 10.0 | .NET 10.0 | 1000000 | 1,782,914.7 ns | 12,564.98 ns | 11,753.29 ns |  0.96 |
|                         |           |           |         |                |              |              |       |
| WhereThenFirstOrDefault | .NET 9.0  | .NET 9.0  | 1000000 | 1,860,388.0 ns | 10,179.77 ns |  9,522.17 ns |  1.00 |
| FirstOrDefault          | .NET 9.0  | .NET 9.0  | 1000000 | 1,786,495.3 ns |  9,644.05 ns |  9,021.05 ns |  0.96 |
