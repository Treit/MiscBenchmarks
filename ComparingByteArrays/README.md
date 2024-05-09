# Comparing two byte arrays



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26212.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                            | Count | Mean           | Error        | StdDev       | Ratio  | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------------- |------ |---------------:|-------------:|-------------:|-------:|--------:|---------:|----------:|------------:|
| CompareNormal                     | 10000 |     4,366.7 ns |     82.99 ns |     73.57 ns |   1.00 |    0.00 |        - |         - |          NA |
| CompareUnsafeHandRolled           | 10000 |       543.0 ns |      4.40 ns |      3.67 ns |   0.12 |    0.00 |        - |         - |          NA |
| CompareStructuralEqualityComparer | 10000 | 1,083,122.8 ns | 24,207.99 ns | 69,066.76 ns | 241.53 |   20.16 | 109.3750 |  480001 B |          NA |
| CompareIStructuralEquatable       | 10000 | 1,025,597.4 ns | 20,195.14 ns | 39,389.08 ns | 235.22 |    6.16 | 109.3750 |  480001 B |          NA |
| CompareSpanSequenceEqual          | 10000 |       189.6 ns |      3.57 ns |      5.56 ns |   0.04 |    0.00 |        - |         - |          NA |
