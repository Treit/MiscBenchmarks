# Hash functions.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Size | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------ |---------- |---------- |----- |-----------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| HashJenkins                   | .NET 10.0 | .NET 10.0 | 1024 | 1,584.4 ns |  6.79 ns |  6.02 ns |  9.71 |    0.06 |      - |      - |         - |          NA |
| HashCRC32                     | .NET 10.0 | .NET 10.0 | 1024 | 2,534.9 ns | 13.56 ns | 12.69 ns | 15.54 |    0.11 |      - |      - |         - |          NA |
| HashSystemIOHashingCRC32      | .NET 10.0 | .NET 10.0 | 1024 | 2,539.0 ns | 12.72 ns | 11.90 ns | 15.56 |    0.11 |      - |      - |      32 B |          NA |
| HashMurmur32                  | .NET 10.0 | .NET 10.0 | 1024 |   401.3 ns |  1.97 ns |  1.84 ns |  2.46 |    0.02 |      - |      - |         - |          NA |
| HashFNV1_32                   | .NET 10.0 | .NET 10.0 | 1024 | 1,256.8 ns |  6.60 ns |  6.18 ns |  7.70 |    0.05 |      - |      - |         - |          NA |
| HashMurmur64                  | .NET 10.0 | .NET 10.0 | 1024 |   163.2 ns |  0.90 ns |  0.84 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
| HashMD5GoogleGemini           | .NET 10.0 | .NET 10.0 | 1024 | 2,844.8 ns | 21.36 ns | 18.93 ns | 17.44 |    0.14 | 0.0114 | 0.0076 |     216 B |          NA |
| HashFNV1_64                   | .NET 10.0 | .NET 10.0 | 1024 | 1,256.9 ns |  6.48 ns |  6.06 ns |  7.70 |    0.05 |      - |      - |         - |          NA |
| HashFNV1_32_StackOverflowLinq | .NET 10.0 | .NET 10.0 | 1024 | 1,260.4 ns |  7.05 ns |  6.59 ns |  7.73 |    0.06 |      - |      - |         - |          NA |
| Hash64BitUsingSHA2            | .NET 10.0 | .NET 10.0 | 1024 | 1,131.3 ns |  9.48 ns |  8.87 ns |  6.93 |    0.06 | 0.0134 |      - |     248 B |          NA |
| Hash64BitUsingMD5ChatGPT      | .NET 10.0 | .NET 10.0 | 1024 | 2,725.2 ns | 15.64 ns | 13.87 ns | 16.70 |    0.12 | 0.0114 |      - |     216 B |          NA |
|                               |           |           |      |            |          |          |       |         |        |        |           |             |
| HashJenkins                   | .NET 9.0  | .NET 9.0  | 1024 | 1,583.0 ns |  5.81 ns |  5.15 ns |  9.70 |    0.07 |      - |      - |         - |          NA |
| HashCRC32                     | .NET 9.0  | .NET 9.0  | 1024 | 2,530.3 ns | 13.42 ns | 12.55 ns | 15.50 |    0.13 |      - |      - |         - |          NA |
| HashSystemIOHashingCRC32      | .NET 9.0  | .NET 9.0  | 1024 | 2,538.5 ns | 12.12 ns | 11.34 ns | 15.55 |    0.12 |      - |      - |      32 B |          NA |
| HashMurmur32                  | .NET 9.0  | .NET 9.0  | 1024 |   400.4 ns |  1.76 ns |  1.38 ns |  2.45 |    0.02 |      - |      - |         - |          NA |
| HashFNV1_32                   | .NET 9.0  | .NET 9.0  | 1024 | 1,257.6 ns |  6.23 ns |  5.83 ns |  7.70 |    0.06 |      - |      - |         - |          NA |
| HashMurmur64                  | .NET 9.0  | .NET 9.0  | 1024 |   163.3 ns |  1.17 ns |  1.10 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
| HashMD5GoogleGemini           | .NET 9.0  | .NET 9.0  | 1024 | 2,887.8 ns | 14.91 ns | 13.22 ns | 17.69 |    0.14 | 0.0114 | 0.0076 |     216 B |          NA |
| HashFNV1_64                   | .NET 9.0  | .NET 9.0  | 1024 | 1,257.4 ns |  7.08 ns |  6.62 ns |  7.70 |    0.06 |      - |      - |         - |          NA |
| HashFNV1_32_StackOverflowLinq | .NET 9.0  | .NET 9.0  | 1024 | 1,258.7 ns |  6.41 ns |  5.99 ns |  7.71 |    0.06 |      - |      - |         - |          NA |
| Hash64BitUsingSHA2            | .NET 9.0  | .NET 9.0  | 1024 | 1,132.6 ns |  8.06 ns |  7.54 ns |  6.94 |    0.06 | 0.0134 |      - |     248 B |          NA |
| Hash64BitUsingMD5ChatGPT      | .NET 9.0  | .NET 9.0  | 1024 | 2,723.3 ns | 13.01 ns | 11.54 ns | 16.68 |    0.13 | 0.0114 |      - |     216 B |          NA |
