# IterateNullDictionary
This benchmark comes from a real-world case where a dictionary is going to be iterated, but it may be null.

The original code did:




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27902.1000)
Unknown processor
.NET SDK 9.0.302
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                 | Count | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| NewDictionary          | 1000  | 12.8563 ns | 0.3815 ns | 1.1189 ns | 12.6304 ns | 57.22 |   28.62 | 0.0185 |      80 B |          NA |
| EmptyCollectionLiteral | 1000  | 13.4026 ns | 0.4217 ns | 1.2166 ns | 13.4459 ns | 59.18 |   27.69 | 0.0185 |      80 B |          NA |
| NullCheck              | 1000  |  0.2918 ns | 0.0556 ns | 0.1594 ns |  0.2273 ns |  1.00 |    0.00 |      - |         - |          NA |
