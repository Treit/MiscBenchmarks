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
| Method        | Count | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| NewDictionary | 1000  | 10.8608 ns | 0.3504 ns | 1.0109 ns | 10.6151 ns | 23.90 |    8.61 | 0.0185 |      80 B |          NA |
| NullCheck     | 1000  |  0.4965 ns | 0.0457 ns | 0.1188 ns |  0.5330 ns |  1.00 |    0.00 |      - |         - |          NA |
