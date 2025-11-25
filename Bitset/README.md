# Bitsets



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method             | Count   | Mean             | Error         | StdDev        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------- |-------- |-----------------:|--------------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **ReadCustomBitSet**   | **64**      |         **89.10 ns** |      **0.392 ns** |      **0.328 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| ReadBitArray       | 64      |         64.10 ns |      0.973 ns |      0.863 ns |  0.72 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | 64      |         44.23 ns |      0.179 ns |      0.168 ns |  0.50 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | 64      |        592.46 ns |      7.613 ns |      7.121 ns |  6.65 |    0.08 | 0.0181 |     304 B |          NA |
| WriteBitArray      | 64      |        559.62 ns |      6.891 ns |      6.446 ns |  6.28 |    0.07 | 0.0181 |     304 B |          NA |
| WriteReacherBitSet | 64      |        516.39 ns |      6.400 ns |      5.986 ns |  5.80 |    0.07 | 0.0181 |     304 B |          NA |
|                    |         |                  |               |               |       |         |        |           |             |
| **ReadCustomBitSet**   | **1024**    |      **1,479.07 ns** |      **8.606 ns** |      **8.050 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| ReadBitArray       | 1024    |      1,048.49 ns |      9.864 ns |      8.744 ns |  0.71 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | 1024    |        815.87 ns |      2.772 ns |      2.315 ns |  0.55 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | 1024    |      5,317.40 ns |     36.506 ns |     30.484 ns |  3.60 |    0.03 | 0.0153 |     304 B |          NA |
| WriteBitArray      | 1024    |      4,536.04 ns |     28.147 ns |     23.504 ns |  3.07 |    0.02 | 0.0153 |     304 B |          NA |
| WriteReacherBitSet | 1024    |      3,605.83 ns |     22.821 ns |     21.346 ns |  2.44 |    0.02 | 0.0153 |     304 B |          NA |
|                    |         |                  |               |               |       |         |        |           |             |
| **ReadCustomBitSet**   | **1000000** |  **5,636,867.41 ns** | **28,188.155 ns** | **24,988.065 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| ReadBitArray       | 1000000 |  5,426,084.79 ns | 22,297.994 ns | 20,857.557 ns |  0.96 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | 1000000 |    790,240.72 ns |  3,091.290 ns |  2,891.595 ns |  0.14 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | 1000000 | 12,653,189.40 ns | 64,222.956 ns | 56,931.978 ns |  2.24 |    0.01 |      - |     304 B |          NA |
| WriteBitArray      | 1000000 | 12,466,032.08 ns | 51,956.997 ns | 48,600.607 ns |  2.21 |    0.01 |      - |     304 B |          NA |
| WriteReacherBitSet | 1000000 | 12,101,006.15 ns | 83,247.246 ns | 77,869.526 ns |  2.15 |    0.02 |      - |     304 B |          NA |
