# LargeFileReadBufferSizes

This benchmark compares sequential reads of a randomly generated 5 GB integer file while varying the read buffer size.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27975.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method           | BufferSizeBytes | Mean    | Error    | StdDev   | Median  | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |---------------- |--------:|---------:|---------:|--------:|------:|--------:|----------:|------------:|
| **ReadFileBuffered** | **4096**            | **9.049 s** | **0.1808 s** | **0.4366 s** | **9.012 s** |  **1.00** |    **0.07** |     **456 B** |        **1.00** |
|                  |                 |         |          |          |         |       |         |           |             |
| **ReadFileBuffered** | **1048576**         | **2.187 s** | **0.0494 s** | **0.1433 s** | **2.160 s** |  **1.00** |    **0.09** |     **456 B** |        **1.00** |
|                  |                 |         |          |          |         |       |         |           |             |
| **ReadFileBuffered** | **16777216**        | **2.518 s** | **0.0490 s** | **0.1247 s** | **2.493 s** |  **1.00** |    **0.07** |     **456 B** |        **1.00** |
|                  |                 |         |          |          |         |       |         |           |             |
| **ReadFileBuffered** | **25165824**        | **2.422 s** | **0.0477 s** | **0.0510 s** | **2.433 s** |  **1.00** |    **0.03** |     **456 B** |        **1.00** |
|                  |                 |         |          |          |         |       |         |           |             |
| **ReadFileBuffered** | **1073741824**      | **2.544 s** | **0.0528 s** | **0.1515 s** | **2.497 s** |  **1.00** |    **0.08** |     **456 B** |        **1.00** |
