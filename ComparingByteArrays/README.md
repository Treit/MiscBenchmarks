# Comparing two byte arrays






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|---------------------------------- |---------- |---------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| CompareNormal                     | .NET 10.0 | .NET 10.0 | 10000 |   3,151.1 ns |    19.87 ns |    16.60 ns |  1.00 |    0.01 |       - |         - |          NA |
| CompareUnsafeHandRolled           | .NET 10.0 | .NET 10.0 | 10000 |     401.8 ns |     2.74 ns |     2.43 ns |  0.13 |    0.00 |       - |         - |          NA |
| CompareStructuralEqualityComparer | .NET 10.0 | .NET 10.0 | 10000 | 144,896.5 ns | 2,046.18 ns | 1,914.00 ns | 45.98 |    0.63 | 28.5645 |  480000 B |          NA |
| CompareIStructuralEquatable       | .NET 10.0 | .NET 10.0 | 10000 | 147,593.0 ns | 2,324.41 ns | 1,940.98 ns | 46.84 |    0.64 | 28.5645 |  480000 B |          NA |
| CompareSpanSequenceEqual          | .NET 10.0 | .NET 10.0 | 10000 |     200.6 ns |     1.55 ns |     1.45 ns |  0.06 |    0.00 |       - |         - |          NA |
|                                   |           |           |       |              |             |             |       |         |         |           |             |
| CompareNormal                     | .NET 9.0  | .NET 9.0  | 10000 |   3,146.9 ns |    14.48 ns |    11.30 ns |  1.00 |    0.00 |       - |         - |          NA |
| CompareUnsafeHandRolled           | .NET 9.0  | .NET 9.0  | 10000 |     402.5 ns |     3.76 ns |     3.52 ns |  0.13 |    0.00 |       - |         - |          NA |
| CompareStructuralEqualityComparer | .NET 9.0  | .NET 9.0  | 10000 | 146,817.2 ns | 1,741.31 ns | 1,543.62 ns | 46.66 |    0.50 | 28.5645 |  480000 B |          NA |
| CompareIStructuralEquatable       | .NET 9.0  | .NET 9.0  | 10000 | 147,666.8 ns | 2,359.89 ns | 2,207.45 ns | 46.93 |    0.70 | 28.5645 |  480000 B |          NA |
| CompareSpanSequenceEqual          | .NET 9.0  | .NET 9.0  | 10000 |     202.5 ns |     1.37 ns |     1.22 ns |  0.06 |    0.00 |       - |         - |          NA |
