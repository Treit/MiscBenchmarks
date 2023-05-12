# Hash functions.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25346.1001)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
|                        Method | Size |       Mean |     Error |    StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------------ |----- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
|                   HashJenkins | 1024 | 1,465.6 ns |  19.74 ns |  16.49 ns |  3.68 |    0.29 |      - |         - |          NA |
|                     HashCRC32 | 1024 | 2,682.3 ns |  49.83 ns |  63.02 ns |  6.69 |    0.45 |      - |         - |          NA |
|      HashSystemIOHashingCRC32 | 1024 | 2,684.0 ns |  53.17 ns |  54.60 ns |  6.76 |    0.44 | 0.0114 |      56 B |          NA |
|                  HashMurmur32 | 1024 |   605.8 ns |  23.76 ns |  66.63 ns |  1.37 |    0.18 |      - |         - |          NA |
|                   HashFNV1_32 | 1024 | 1,139.5 ns |  14.53 ns |  13.59 ns |  2.88 |    0.22 |      - |         - |          NA |
|                  HashMurmur64 | 1024 |   444.6 ns |  14.29 ns |  41.92 ns |  1.00 |    0.00 |      - |         - |          NA |
|                   HashFNV1_64 | 1024 | 1,169.6 ns |  23.22 ns |  31.78 ns |  2.86 |    0.25 |      - |         - |          NA |
| HashFNV1_32_StackOverflowLinq | 1024 | 7,207.9 ns | 245.21 ns | 703.55 ns | 16.30 |    2.24 |      - |      32 B |          NA |
|            Hash64BitUsingSHA2 | 1024 | 3,494.6 ns |  94.44 ns | 269.45 ns |  7.89 |    0.95 | 0.0534 |     240 B |          NA |
|      Hash64BitUsingMD5ChatGPT | 1024 | 2,724.8 ns |  52.81 ns |  46.82 ns |  6.86 |    0.54 | 0.0458 |     208 B |          NA |
