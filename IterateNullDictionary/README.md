# IterateNullDictionary
This benchmark comes from a real-world case where a dictionary is going to be iterated, but it may be null.

The original code did:





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| NewDictionary          | 1000  | 0.5338 ns | 0.0126 ns | 0.0118 ns |  2.48 |    0.07 |         - |          NA |
| EmptyCollectionLiteral | 1000  | 0.5614 ns | 0.0179 ns | 0.0168 ns |  2.61 |    0.09 |         - |          NA |
| EnumerableDotEmpty     | 1000  | 3.0173 ns | 0.0300 ns | 0.0281 ns | 14.00 |    0.27 |         - |          NA |
| NullCheck              | 1000  | 0.2155 ns | 0.0044 ns | 0.0037 ns |  1.00 |    0.02 |         - |          NA |
