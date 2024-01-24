# Hash functions.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                        Method | Size |       Mean |   Error |  StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------------ |----- |-----------:|--------:|--------:|------:|--------:|-------:|----------:|------------:|
|                   HashJenkins | 1024 | 1,574.0 ns | 0.56 ns | 0.44 ns |  7.45 |    0.03 |      - |         - |          NA |
|                     HashCRC32 | 1024 | 2,519.7 ns | 1.79 ns | 1.67 ns | 11.92 |    0.05 |      - |         - |          NA |
|      HashSystemIOHashingCRC32 | 1024 | 2,532.9 ns | 3.03 ns | 2.69 ns | 11.99 |    0.05 |      - |      56 B |          NA |
|                  HashMurmur32 | 1024 |   391.2 ns | 0.13 ns | 0.12 ns |  1.85 |    0.01 |      - |         - |          NA |
|                   HashFNV1_32 | 1024 | 1,248.2 ns | 0.52 ns | 0.43 ns |  5.91 |    0.02 |      - |         - |          NA |
|                  HashMurmur64 | 1024 |   211.3 ns | 0.86 ns | 0.81 ns |  1.00 |    0.00 |      - |         - |          NA |
|                   HashFNV1_64 | 1024 | 1,248.8 ns | 0.37 ns | 0.29 ns |  5.91 |    0.02 |      - |         - |          NA |
| HashFNV1_32_StackOverflowLinq | 1024 | 1,281.6 ns | 0.64 ns | 0.54 ns |  6.07 |    0.02 | 0.0019 |      32 B |          NA |
|            Hash64BitUsingSHA2 | 1024 | 1,117.0 ns | 3.33 ns | 2.78 ns |  5.29 |    0.02 | 0.0134 |     240 B |          NA |
|      Hash64BitUsingMD5ChatGPT | 1024 | 2,702.6 ns | 5.74 ns | 5.37 ns | 12.79 |    0.05 | 0.0114 |     208 B |          NA |
