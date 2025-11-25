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
| HashJenkins                   | 1024 | 1,581.2 ns |  4.91 ns |  3.84 ns |  9.70 |    0.06 |      - |      - |         - |          NA |
| HashCRC32                     | 1024 | 2,528.6 ns | 12.14 ns | 11.36 ns | 15.51 |    0.11 |      - |      - |         - |          NA |
| HashSystemIOHashingCRC32      | 1024 | 2,536.7 ns | 15.19 ns | 14.20 ns | 15.56 |    0.13 |      - |      - |      32 B |          NA |
| HashMurmur32                  | 1024 |   400.1 ns |  1.48 ns |  1.38 ns |  2.45 |    0.02 |      - |      - |         - |          NA |
| HashFNV1_32                   | 1024 | 1,255.8 ns |  5.71 ns |  5.35 ns |  7.70 |    0.06 |      - |      - |         - |          NA |
| HashMurmur64                  | 1024 |   163.0 ns |  1.07 ns |  1.00 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
| HashMD5GoogleGemini           | 1024 | 2,916.6 ns | 28.19 ns | 23.54 ns | 17.89 |    0.18 | 0.0114 | 0.0076 |     216 B |          NA |
| HashFNV1_64                   | 1024 | 1,255.5 ns |  5.65 ns |  5.29 ns |  7.70 |    0.06 |      - |      - |         - |          NA |
| HashFNV1_32_StackOverflowLinq | 1024 | 1,258.3 ns |  6.29 ns |  5.25 ns |  7.72 |    0.06 |      - |      - |         - |          NA |
| Hash64BitUsingSHA2            | 1024 | 1,112.7 ns |  9.01 ns |  8.43 ns |  6.83 |    0.06 | 0.0134 |      - |     248 B |          NA |
| Hash64BitUsingMD5ChatGPT      | 1024 | 2,708.2 ns | 17.73 ns | 14.80 ns | 16.61 |    0.13 | 0.0114 |      - |     216 B |          NA |
