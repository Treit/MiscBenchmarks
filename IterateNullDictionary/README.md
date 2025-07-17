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
| Method        | Count | Mean          | Error       | StdDev        | Median        | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------- |------ |--------------:|------------:|--------------:|--------------:|------:|--------:|--------:|----------:|------------:|
| **NewDictionary** | **10**    |     **96.609 ns** |   **2.0401 ns** |     **5.7207 ns** |     **94.910 ns** | **20.27** |    **1.24** |  **0.1855** |     **800 B** |          **NA** |
| NullCheck     | 10    |      4.667 ns |   0.1343 ns |     0.2353 ns |      4.620 ns |  1.00 |    0.00 |       - |         - |          NA |
|               |       |               |             |               |               |       |         |         |           |             |
| **NewDictionary** | **1000**  | **11,068.359 ns** | **455.5639 ns** | **1,299.7493 ns** | **10,821.960 ns** | **33.92** |    **3.42** | **18.5394** |   **80000 B** |          **NA** |
| NullCheck     | 1000  |    324.540 ns |   5.9577 ns |     5.2813 ns |    324.313 ns |  1.00 |    0.00 |       - |         - |          NA |
