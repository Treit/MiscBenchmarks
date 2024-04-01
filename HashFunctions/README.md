# Hash functions.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | Size | Mean       | Error    | StdDev    | Median     | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------ |----- |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|-------:|----------:|------------:|
| HashJenkins                   | 1024 | 1,402.6 ns | 19.91 ns |  18.62 ns | 1,403.4 ns |  6.40 |    0.16 |      - |      - |         - |          NA |
| HashCRC32                     | 1024 | 2,060.4 ns | 20.61 ns |  19.28 ns | 2,050.3 ns |  9.39 |    0.18 |      - |      - |         - |          NA |
| HashSystemIOHashingCRC32      | 1024 | 2,295.2 ns | 44.60 ns |  56.41 ns | 2,286.1 ns | 10.52 |    0.38 | 0.0114 |      - |      56 B |          NA |
| HashMurmur32                  | 1024 |   377.4 ns |  8.24 ns |  22.83 ns |   368.2 ns |  1.81 |    0.13 |      - |      - |         - |          NA |
| HashFNV1_32                   | 1024 | 1,120.2 ns | 16.97 ns |  15.87 ns | 1,119.5 ns |  5.12 |    0.09 |      - |      - |         - |          NA |
| HashMurmur64                  | 1024 |   219.2 ns |  4.34 ns |   3.84 ns |   217.9 ns |  1.00 |    0.00 |      - |      - |         - |          NA |
| HashMD5GoogleGemini           | 1024 | 2,897.9 ns | 52.07 ns |  43.48 ns | 2,913.2 ns | 13.21 |    0.33 | 0.0458 | 0.0420 |     208 B |          NA |
| HashFNV1_64                   | 1024 | 1,120.8 ns | 19.54 ns |  18.28 ns | 1,124.8 ns |  5.12 |    0.12 |      - |      - |         - |          NA |
| HashFNV1_32_StackOverflowLinq | 1024 | 1,676.0 ns | 11.69 ns |   9.76 ns | 1,672.8 ns |  7.64 |    0.13 | 0.0057 |      - |      32 B |          NA |
| Hash64BitUsingSHA2            | 1024 | 3,526.3 ns | 83.29 ns | 233.55 ns | 3,440.6 ns | 16.10 |    1.22 | 0.0534 |      - |     240 B |          NA |
| Hash64BitUsingMD5ChatGPT      | 1024 | 2,551.5 ns | 50.36 ns |  49.46 ns | 2,549.4 ns | 11.68 |    0.34 | 0.0458 |      - |     208 B |          NA |
