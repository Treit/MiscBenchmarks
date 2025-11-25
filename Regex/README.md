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
| **FindTokenUsingRegex**          | **10**     |      **38.720 μs** |     **0.4092 μs** |     **0.3828 μs** |    **0.1221** |     **2.73 KB** |
| FindTokenUsingCompiledRegex  | 10     |       9.378 μs |     0.1040 μs |     0.0922 μs |    0.1526 |     2.73 KB |
| FindTokenUsingSourceGenRegex | 10     |       8.780 μs |     0.0810 μs |     0.0758 μs |    0.1526 |     2.73 KB |
| **FindTokenUsingRegex**          | **100000** | **833,140.150 μs** | **5,423.1629 μs** | **4,807.4926 μs** | **1000.0000** | **27344.19 KB** |
| FindTokenUsingCompiledRegex  | 100000 | 101,493.203 μs | 1,068.1582 μs |   891.9605 μs | 1600.0000 | 27344.15 KB |
| FindTokenUsingSourceGenRegex | 100000 |  93,583.649 μs |   808.2806 μs |   716.5197 μs | 1666.6667 | 27344.16 KB |
