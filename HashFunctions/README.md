# Hash functions.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25346.1001)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
|                        Method | Size |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------------ |----- |-----------:|----------:|----------:|-------:|----------:|
|                   HashJenkins | 1024 | 1,486.8 ns |  14.05 ns |  12.45 ns |      - |         - |
|                     HashCRC32 | 1024 | 2,684.6 ns |  49.70 ns |  46.49 ns |      - |         - |
|      HashSystemIOHashingCRC32 | 1024 | 2,659.2 ns |  45.71 ns |  42.76 ns | 0.0114 |      56 B |
|                  HashMurmur32 | 1024 |   571.0 ns |  20.45 ns |  58.35 ns |      - |         - |
|                   HashFNV1_32 | 1024 | 1,193.3 ns |  22.77 ns |  26.23 ns |      - |         - |
|                  HashMurmur64 | 1024 |   506.0 ns |  27.43 ns |  79.57 ns |      - |         - |
|                   HashFNV1_64 | 1024 | 1,142.6 ns |  21.55 ns |  24.82 ns |      - |         - |
| HashFNV1_32_StackOverflowLinq | 1024 | 7,060.1 ns | 249.89 ns | 728.94 ns |      - |      32 B |
|            Hash64BitUsingSHA2 | 1024 | 3,370.3 ns |  75.31 ns | 217.28 ns | 0.0534 |     240 B |
