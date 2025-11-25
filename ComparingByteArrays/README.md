# Comparing two byte arrays




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|---------------------------------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| CompareNormal                     | 10000 |   3,137.5 ns |    19.70 ns |    15.38 ns |  1.00 |    0.01 |       - |         - |          NA |
| CompareUnsafeHandRolled           | 10000 |     399.8 ns |     2.05 ns |     1.60 ns |  0.13 |    0.00 |       - |         - |          NA |
| CompareStructuralEqualityComparer | 10000 | 145,736.7 ns | 1,595.33 ns | 1,492.27 ns | 46.45 |    0.51 | 28.5645 |  480000 B |          NA |
| CompareIStructuralEquatable       | 10000 | 149,568.3 ns | 1,363.87 ns | 1,209.03 ns | 47.67 |    0.44 | 28.5645 |  480000 B |          NA |
| CompareSpanSequenceEqual          | 10000 |     201.4 ns |     0.96 ns |     0.90 ns |  0.06 |    0.00 |       - |         - |          NA |
