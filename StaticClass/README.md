# Calling static methods on static and non-static classes.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Count  | Mean         | Error       | StdDev      | Gen0    | Allocated  |
|--------------------------------- |------- |-------------:|------------:|------------:|--------:|-----------:|
| **CallStaticMethodOnStaticClass**    | **100**    |     **414.8 ns** |     **4.39 ns** |     **3.43 ns** |  **0.0992** |    **1.63 KB** |
| CallStaticMethodOnNonStaticClass | 100    |     419.7 ns |     4.61 ns |     4.31 ns |  0.0992 |    1.63 KB |
| **CallStaticMethodOnStaticClass**    | **100000** | **389,040.6 ns** | **7,641.00 ns** | **9,096.07 ns** | **95.2148** | **1562.56 KB** |
| CallStaticMethodOnNonStaticClass | 100000 | 382,155.5 ns | 5,736.87 ns | 5,366.28 ns | 95.2148 | 1562.56 KB |
