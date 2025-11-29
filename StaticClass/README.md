# Calling static methods on static and non-static classes.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Job       | Runtime   | Count  | Mean         | Error       | StdDev      | Gen0    | Allocated  |
|--------------------------------- |---------- |---------- |------- |-------------:|------------:|------------:|--------:|-----------:|
| **CallStaticMethodOnStaticClass**    | **.NET 10.0** | **.NET 10.0** | **100**    |     **413.7 ns** |     **5.62 ns** |     **4.70 ns** |  **0.0992** |    **1.63 KB** |
| CallStaticMethodOnNonStaticClass | .NET 10.0 | .NET 10.0 | 100    |     416.3 ns |     8.16 ns |     8.02 ns |  0.0992 |    1.63 KB |
| CallStaticMethodOnStaticClass    | .NET 9.0  | .NET 9.0  | 100    |     413.5 ns |     5.81 ns |     5.44 ns |  0.0992 |    1.63 KB |
| CallStaticMethodOnNonStaticClass | .NET 9.0  | .NET 9.0  | 100    |     410.6 ns |     3.13 ns |     2.78 ns |  0.0992 |    1.63 KB |
| **CallStaticMethodOnStaticClass**    | **.NET 10.0** | **.NET 10.0** | **100000** | **367,483.6 ns** | **4,604.45 ns** | **4,307.00 ns** | **95.2148** | **1562.56 KB** |
| CallStaticMethodOnNonStaticClass | .NET 10.0 | .NET 10.0 | 100000 | 374,640.2 ns | 7,075.95 ns | 7,266.48 ns | 95.2148 | 1562.56 KB |
| CallStaticMethodOnStaticClass    | .NET 9.0  | .NET 9.0  | 100000 | 364,786.8 ns | 5,622.97 ns | 4,695.44 ns | 95.2148 | 1562.56 KB |
| CallStaticMethodOnNonStaticClass | .NET 9.0  | .NET 9.0  | 100000 | 367,300.2 ns | 6,203.81 ns | 5,499.52 ns | 95.2148 | 1562.56 KB |
