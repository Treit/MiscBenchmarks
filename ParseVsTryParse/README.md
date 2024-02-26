## Parse vs TryParse for weeding out bad input.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                    | Count  | Mean           | Error          | StdDev         | Median         | Ratio  | RatioSD | Gen0      | Allocated  | Alloc Ratio   |
|-------------------------- |------- |---------------:|---------------:|---------------:|---------------:|-------:|--------:|----------:|-----------:|--------------:|
| **FindValidIntsWithParse**    | **100**    |     **591.865 μs** |     **19.0546 μs** |     **54.6714 μs** |     **573.623 μs** | **349.77** |   **54.62** |    **7.8125** |    **34840 B** |            **NA** |
| FindValidIntsWithTryParse | 100    |       1.717 μs |      0.0681 μs |      0.1966 μs |       1.687 μs |   1.00 |    0.00 |         - |          - |            NA |
|                           |        |                |                |                |                |        |         |           |            |               |
| **FindValidIntsWithParse**    | **1000**   |   **5,997.244 μs** |    **259.1925 μs** |    **722.5250 μs** |   **5,714.311 μs** | **283.79** |   **53.93** |   **85.9375** |   **372963 B** |            **NA** |
| FindValidIntsWithTryParse | 1000   |      21.561 μs |      1.1357 μs |      3.3486 μs |      20.872 μs |   1.00 |    0.00 |         - |          - |            NA |
|                           |        |                |                |                |                |        |         |           |            |               |
| **FindValidIntsWithParse**    | **10000**  |  **56,324.590 μs** |  **1,113.7276 μs** |  **2,834.7923 μs** |  **55,843.983 μs** | **270.96** |   **20.29** |  **833.3333** |  **3766963 B** |            **NA** |
| FindValidIntsWithTryParse | 10000  |     210.365 μs |      4.1478 μs |      3.6769 μs |     210.400 μs |   1.00 |    0.00 |         - |          - |            NA |
|                           |        |                |                |                |                |        |         |           |            |               |
| **FindValidIntsWithParse**    | **100000** | **605,477.551 μs** | **20,878.2911 μs** | **58,544.9666 μs** | **593,863.600 μs** | **279.07** |   **29.93** | **8000.0000** | **37505216 B** | **18,752,608.00** |
| FindValidIntsWithTryParse | 100000 |   2,202.754 μs |     42.2310 μs |     80.3489 μs |   2,170.074 μs |   1.00 |    0.00 |         - |        2 B |          1.00 |
