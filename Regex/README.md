# Traditional Regex vs. Source Generated Regex





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Count  | Mean           | Error         | StdDev        | Gen0      | Allocated   |
|----------------------------- |------- |---------------:|--------------:|--------------:|----------:|------------:|
| **FindTokenUsingRegex**          | **10**     |      **38.083 μs** |     **0.1576 μs** |     **0.1474 μs** |    **0.1221** |     **2.73 KB** |
| FindTokenUsingCompiledRegex  | 10     |       9.332 μs |     0.0530 μs |     0.0496 μs |    0.1526 |     2.73 KB |
| FindTokenUsingSourceGenRegex | 10     |       8.220 μs |     0.0482 μs |     0.0451 μs |    0.1526 |     2.73 KB |
| **FindTokenUsingRegex**          | **100000** | **824,149.347 μs** | **2,850.9433 μs** | **2,666.7742 μs** | **1000.0000** | **27344.19 KB** |
| FindTokenUsingCompiledRegex  | 100000 | 101,441.744 μs |   679.8924 μs |   635.9718 μs | 1600.0000 | 27344.15 KB |
| FindTokenUsingSourceGenRegex | 100000 |  92,472.111 μs |   572.2575 μs |   507.2914 μs | 1666.6667 | 27344.16 KB |
