# Hash functions.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Size | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------ |----- |-----------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| HashJenkins                   | 1024 | 1,582.6 ns |  5.58 ns |  4.94 ns |  9.71 |    0.06 |      - |      - |         - |          NA |
| HashCRC32                     | 1024 | 2,530.2 ns | 12.87 ns | 12.04 ns | 15.52 |    0.11 |      - |      - |         - |          NA |
| HashSystemIOHashingCRC32      | 1024 | 2,537.4 ns | 14.35 ns | 13.43 ns | 15.56 |    0.12 |      - |      - |      32 B |          NA |
| HashMurmur32                  | 1024 |   400.1 ns |  1.29 ns |  1.14 ns |  2.45 |    0.02 |      - |      - |         - |          NA |
| HashFNV1_32                   | 1024 | 1,257.1 ns |  7.13 ns |  6.67 ns |  7.71 |    0.06 |      - |      - |         - |          NA |
| HashMurmur64                  | 1024 |   163.1 ns |  1.04 ns |  0.97 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
| HashMD5GoogleGemini           | 1024 | 2,911.8 ns | 20.79 ns | 19.44 ns | 17.86 |    0.15 | 0.0114 | 0.0076 |     216 B |          NA |
| HashFNV1_64                   | 1024 | 1,256.4 ns |  6.17 ns |  5.77 ns |  7.70 |    0.06 |      - |      - |         - |          NA |
| HashFNV1_32_StackOverflowLinq | 1024 | 1,258.2 ns |  6.63 ns |  6.20 ns |  7.72 |    0.06 |      - |      - |         - |          NA |
| Hash64BitUsingSHA2            | 1024 | 1,132.1 ns |  9.43 ns |  8.83 ns |  6.94 |    0.07 | 0.0134 |      - |     248 B |          NA |
| Hash64BitUsingMD5ChatGPT      | 1024 | 2,722.2 ns | 12.53 ns | 11.11 ns | 16.69 |    0.12 | 0.0114 |      - |     216 B |          NA |
