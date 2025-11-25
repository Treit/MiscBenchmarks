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
| **CallStaticMethodOnStaticClass**    | **100**    |     **428.9 ns** |     **8.36 ns** |     **7.82 ns** |  **0.0992** |    **1.63 KB** |
| CallStaticMethodOnNonStaticClass | 100    |     419.3 ns |     6.01 ns |     5.62 ns |  0.0992 |    1.63 KB |
| **CallStaticMethodOnStaticClass**    | **100000** | **377,750.1 ns** | **5,927.66 ns** | **5,544.74 ns** | **95.2148** | **1562.56 KB** |
| CallStaticMethodOnNonStaticClass | 100000 | 384,698.6 ns | 5,033.05 ns | 4,707.91 ns | 95.2148 | 1562.56 KB |
