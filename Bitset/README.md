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
| **ReadCustomBitSet**   | **64**      |         **89.13 ns** |      **0.479 ns** |      **0.425 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| ReadBitArray       | 64      |         72.88 ns |      1.430 ns |      1.530 ns |  0.82 |    0.02 |      - |         - |          NA |
| ReadReacherBitSet  | 64      |         44.19 ns |      0.310 ns |      0.275 ns |  0.50 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | 64      |        598.10 ns |      8.163 ns |      7.236 ns |  6.71 |    0.08 | 0.0181 |     304 B |          NA |
| WriteBitArray      | 64      |        562.63 ns |      3.813 ns |      3.380 ns |  6.31 |    0.05 | 0.0181 |     304 B |          NA |
| WriteReacherBitSet | 64      |        514.45 ns |      5.274 ns |      4.404 ns |  5.77 |    0.05 | 0.0181 |     304 B |          NA |
|                    |         |                  |               |               |       |         |        |           |             |
| **ReadCustomBitSet**   | **1024**    |      **1,473.83 ns** |      **9.794 ns** |      **8.179 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| ReadBitArray       | 1024    |      1,051.33 ns |     10.264 ns |      9.099 ns |  0.71 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | 1024    |        819.74 ns |      3.973 ns |      3.717 ns |  0.56 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | 1024    |      5,156.02 ns |     45.480 ns |     40.317 ns |  3.50 |    0.03 | 0.0153 |     304 B |          NA |
| WriteBitArray      | 1024    |      4,436.00 ns |     38.596 ns |     34.214 ns |  3.01 |    0.03 | 0.0153 |     304 B |          NA |
| WriteReacherBitSet | 1024    |      3,608.51 ns |     13.366 ns |     11.161 ns |  2.45 |    0.02 | 0.0153 |     304 B |          NA |
|                    |         |                  |               |               |       |         |        |           |             |
| **ReadCustomBitSet**   | **1000000** |  **5,634,858.12 ns** | **26,322.176 ns** | **24,621.779 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| ReadBitArray       | 1000000 |  5,403,467.79 ns | 26,668.280 ns | 24,945.525 ns |  0.96 |    0.01 |      - |         - |          NA |
| ReadReacherBitSet  | 1000000 |    791,894.50 ns |  3,214.147 ns |  2,849.257 ns |  0.14 |    0.00 |      - |         - |          NA |
| WriteCustomBitSet  | 1000000 | 12,685,148.12 ns | 56,620.333 ns | 52,962.694 ns |  2.25 |    0.01 |      - |     304 B |          NA |
| WriteBitArray      | 1000000 | 12,532,185.83 ns | 58,240.415 ns | 54,478.121 ns |  2.22 |    0.01 |      - |     304 B |          NA |
| WriteReacherBitSet | 1000000 | 12,097,344.58 ns | 66,406.903 ns | 62,117.058 ns |  2.15 |    0.01 |      - |     304 B |          NA |
