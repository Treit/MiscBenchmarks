# Making HashSets


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                     Method | Count |       Mean |     Error |    StdDev | Ratio |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|------------------------------------------- |------ |-----------:|----------:|----------:|------:|---------:|---------:|---------:|----------:|------------:|
|                                 **NewHashSet** |   **100** |   **2.384 μs** | **0.0101 μs** | **0.0094 μs** |  **1.00** |   **0.1335** |        **-** |        **-** |   **2.24 KB** |        **1.00** |
|                              LinqToHashSet |   100 |   2.462 μs | 0.0141 μs | 0.0125 μs |  1.03 |   0.1335 |        - |        - |   2.24 KB |        1.00 |
|                     LinqToImmutableHashSet |   100 |   2.416 μs | 0.0168 μs | 0.0157 μs |  1.01 |   0.1335 |        - |        - |   2.24 KB |        1.00 |
|                           ManualAddViaLoop |   100 |   2.667 μs | 0.0255 μs | 0.0239 μs |  1.12 |   0.4387 |   0.0114 |        - |    7.2 KB |        3.21 |
|                CollisionSafeImplementation |   100 |   2.787 μs | 0.0214 μs | 0.0189 μs |  1.17 |   0.4425 |   0.0153 |        - |   7.29 KB |        3.25 |
| CollisionSafeImplementationWithExtraToList |   100 |   2.927 μs | 0.0209 μs | 0.0196 μs |  1.23 |   0.4959 |   0.0153 |        - |   8.13 KB |        3.62 |
|                                            |       |            |           |           |       |          |          |          |           |             |
|                                 **NewHashSet** | **10000** | **342.939 μs** | **1.0074 μs** | **0.9423 μs** |  **1.00** |  **49.8047** |  **49.8047** |  **49.8047** | **197.49 KB** |        **1.00** |
|                              LinqToHashSet | 10000 | 340.813 μs | 1.2866 μs | 1.1406 μs |  0.99 |  49.8047 |  49.8047 |  49.8047 | 197.49 KB |        1.00 |
|                     LinqToImmutableHashSet | 10000 | 341.835 μs | 0.6019 μs | 0.5630 μs |  1.00 |  49.8047 |  49.8047 |  49.8047 | 197.49 KB |        1.00 |
|                           ManualAddViaLoop | 10000 | 435.312 μs | 2.5764 μs | 2.2839 μs |  1.27 | 124.5117 | 124.5117 | 124.5117 | 657.31 KB |        3.33 |
|                CollisionSafeImplementation | 10000 | 448.125 μs | 3.1450 μs | 2.9419 μs |  1.31 | 124.5117 | 124.5117 | 124.5117 |  657.4 KB |        3.33 |
| CollisionSafeImplementationWithExtraToList | 10000 | 467.792 μs | 3.1747 μs | 2.4786 μs |  1.36 | 124.5117 | 124.5117 | 124.5117 | 735.58 KB |        3.72 |
