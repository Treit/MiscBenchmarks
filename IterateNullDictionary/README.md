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
| Method                 | Count | Mean      | Error     | StdDev    | Ratio  | RatioSD | Allocated | Alloc Ratio |
|----------------------- |------ |----------:|----------:|----------:|-------:|--------:|----------:|------------:|
| NewDictionary          | 1000  | 0.0000 ns | 0.0000 ns | 0.0000 ns |  0.000 |    0.00 |         - |          NA |
| EmptyCollectionLiteral | 1000  | 0.7023 ns | 0.0236 ns | 0.0221 ns |  3.071 |    0.29 |         - |          NA |
| EnumerableDotEmpty     | 1000  | 3.0310 ns | 0.0277 ns | 0.0216 ns | 13.256 |    1.17 |         - |          NA |
| NullCheck              | 1000  | 0.2305 ns | 0.0234 ns | 0.0219 ns |  1.008 |    0.13 |         - |          NA |
