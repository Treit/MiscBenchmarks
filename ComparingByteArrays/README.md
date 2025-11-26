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
| CompareNormal                     | 10000 |   3,149.3 ns |     8.50 ns |     7.54 ns |  1.00 |    0.00 |       - |         - |          NA |
| CompareUnsafeHandRolled           | 10000 |     411.4 ns |     8.27 ns |    10.46 ns |  0.13 |    0.00 |       - |         - |          NA |
| CompareStructuralEqualityComparer | 10000 | 146,078.1 ns | 1,326.24 ns | 1,107.47 ns | 46.38 |    0.36 | 28.5645 |  480000 B |          NA |
| CompareIStructuralEquatable       | 10000 | 147,260.6 ns | 1,468.76 ns | 1,302.02 ns | 46.76 |    0.41 | 28.5645 |  480000 B |          NA |
| CompareSpanSequenceEqual          | 10000 |     202.1 ns |     0.67 ns |     0.59 ns |  0.06 |    0.00 |       - |         - |          NA |
