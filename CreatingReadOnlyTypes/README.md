# Testing creating records vs. primary constructors and other ways of creating read-only types.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27943.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count  | Mean           | Error          | StdDev          | Median         | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------- |------- |---------------:|---------------:|----------------:|---------------:|------:|--------:|---------:|----------:|------------:|
| **New_ClassInit**               | **1**      |       **8.857 ns** |      **0.3668 ns** |       **1.0640 ns** |       **8.742 ns** |  **1.00** |    **0.00** |   **0.0074** |      **32 B** |        **1.00** |
| New_RecordPositional        | 1      |       8.160 ns |      0.2698 ns |       0.7785 ns |       8.042 ns |  0.93 |    0.12 |   0.0074 |      32 B |        1.00 |
| New_RecordInitProperties    | 1      |       9.249 ns |      0.4889 ns |       1.4338 ns |       8.820 ns |  1.06 |    0.22 |   0.0074 |      32 B |        1.00 |
| New_ClassExpressionBodied   | 1      |       9.052 ns |      0.4060 ns |       1.1907 ns |       8.774 ns |  1.04 |    0.18 |   0.0074 |      32 B |        1.00 |
| New_ClassPrimaryConstructor | 1      |       8.200 ns |      0.2934 ns |       0.8557 ns |       7.963 ns |  0.94 |    0.15 |   0.0074 |      32 B |        1.00 |
|                             |        |                |                |                 |                |       |         |          |           |             |
| **New_ClassInit**               | **1000**   |   **7,711.168 ns** |    **351.5671 ns** |   **1,036.6035 ns** |   **7,436.658 ns** |  **1.00** |    **0.00** |   **7.4158** |   **32000 B** |        **1.00** |
| New_RecordPositional        | 1000   |   7,519.106 ns |    210.0590 ns |     616.0667 ns |   7,549.061 ns |  0.99 |    0.13 |   7.4158 |   32000 B |        1.00 |
| New_RecordInitProperties    | 1000   |   7,507.411 ns |    198.9996 ns |     586.7548 ns |   7,428.877 ns |  0.99 |    0.16 |   7.4158 |   32000 B |        1.00 |
| New_ClassExpressionBodied   | 1000   |   7,556.135 ns |    281.3559 ns |     784.3078 ns |   7,371.612 ns |  1.00 |    0.17 |   7.4158 |   32000 B |        1.00 |
| New_ClassPrimaryConstructor | 1000   |   7,368.177 ns |    209.7573 ns |     598.4495 ns |   7,197.284 ns |  0.97 |    0.15 |   7.4158 |   32000 B |        1.00 |
|                             |        |                |                |                 |                |       |         |          |           |             |
| **New_ClassInit**               | **100000** | **699,733.474 ns** | **16,764.4311 ns** |  **48,369.2168 ns** | **697,031.152 ns** |  **1.00** |    **0.00** | **740.2344** | **3200001 B** |        **1.00** |
| New_RecordPositional        | 100000 | 715,685.047 ns | 18,998.2153 ns |  53,894.7746 ns | 706,139.844 ns |  1.03 |    0.11 | 741.2109 | 3200000 B |        1.00 |
| New_RecordInitProperties    | 100000 | 695,051.787 ns | 14,526.0877 ns |  40,732.7074 ns | 693,059.277 ns |  1.00 |    0.08 | 741.2109 | 3200000 B |        1.00 |
| New_ClassExpressionBodied   | 100000 | 673,210.782 ns | 13,301.0835 ns |  28,631.9855 ns | 673,827.539 ns |  0.95 |    0.08 | 741.2109 | 3200000 B |        1.00 |
| New_ClassPrimaryConstructor | 100000 | 764,438.237 ns | 37,534.9413 ns | 110,083.4853 ns | 728,979.492 ns |  1.09 |    0.17 | 741.2109 | 3200000 B |        1.00 |
