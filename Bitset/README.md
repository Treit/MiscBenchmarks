# Bitsets


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|             Method |   Count |             Mean |         Error |        StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------- |-------- |-----------------:|--------------:|--------------:|------:|--------:|-------:|----------:|------------:|
|   **ReadCustomBitSet** |      **64** |         **98.51 ns** |      **0.367 ns** |      **0.343 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
|       ReadBitArray |      64 |         58.19 ns |      1.136 ns |      1.866 ns |  0.60 |    0.02 |      - |         - |          NA |
|  ReadReacherBitSet |      64 |         58.84 ns |      0.147 ns |      0.138 ns |  0.60 |    0.00 |      - |         - |          NA |
|  WriteCustomBitSet |      64 |        633.34 ns |      0.603 ns |      0.503 ns |  6.43 |    0.02 | 0.0181 |     304 B |          NA |
|      WriteBitArray |      64 |        569.26 ns |      1.796 ns |      1.592 ns |  5.78 |    0.02 | 0.0181 |     304 B |          NA |
| WriteReacherBitSet |      64 |        564.64 ns |      1.860 ns |      1.554 ns |  5.73 |    0.02 | 0.0181 |     304 B |          NA |
|                    |         |                  |               |               |       |         |        |           |             |
|   **ReadCustomBitSet** |    **1024** |      **1,564.53 ns** |      **0.747 ns** |      **0.583 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
|       ReadBitArray |    1024 |      1,234.12 ns |      2.144 ns |      1.674 ns |  0.79 |    0.00 |      - |         - |          NA |
|  ReadReacherBitSet |    1024 |        720.62 ns |      2.835 ns |      2.513 ns |  0.46 |    0.00 |      - |         - |          NA |
|  WriteCustomBitSet |    1024 |      5,152.16 ns |      5.948 ns |      4.644 ns |  3.29 |    0.00 | 0.0153 |     304 B |          NA |
|      WriteBitArray |    1024 |      3,953.15 ns |      3.092 ns |      2.892 ns |  2.53 |    0.00 | 0.0153 |     304 B |          NA |
| WriteReacherBitSet |    1024 |      3,535.30 ns |     11.737 ns |     10.405 ns |  2.26 |    0.01 | 0.0153 |     304 B |          NA |
|                    |         |                  |               |               |       |         |        |           |             |
|   **ReadCustomBitSet** | **1000000** |  **5,168,838.12 ns** |  **5,911.658 ns** |  **5,529.768 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
|       ReadBitArray | 1000000 |  5,113,899.80 ns |  1,888.579 ns |  1,474.478 ns |  0.99 |    0.00 |      - |         - |          NA |
|  ReadReacherBitSet | 1000000 |    701,147.72 ns |  5,849.343 ns |  5,471.479 ns |  0.14 |    0.00 |      - |         - |          NA |
|  WriteCustomBitSet | 1000000 | 12,425,566.52 ns | 20,103.811 ns | 17,821.505 ns |  2.40 |    0.01 |      - |     310 B |          NA |
|      WriteBitArray | 1000000 | 11,832,379.02 ns | 22,104.408 ns | 19,594.982 ns |  2.29 |    0.00 |      - |     310 B |          NA |
| WriteReacherBitSet | 1000000 | 11,829,652.50 ns | 25,837.608 ns | 24,168.515 ns |  2.29 |    0.01 |      - |     310 B |          NA |
