# LargeFileReadBufferSizes

This benchmark compares sequential reads of a randomly generated 5 GB integer file while varying the read buffer size.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27975.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method           | BufferSizeBytes | Mean    | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |---------------- |--------:|---------:|---------:|------:|--------:|----------:|------------:|
| **ReadFileBuffered** | **4096**            | **8.786 s** | **0.1728 s** | **0.3410 s** |  **1.00** |    **0.05** |     **456 B** |        **1.00** |
|                  |                 |         |          |          |       |         |           |             |
| **ReadFileBuffered** | **1048576**         | **2.075 s** | **0.0366 s** | **0.0325 s** |  **1.00** |    **0.02** |     **456 B** |        **1.00** |
|                  |                 |         |          |          |       |         |           |             |
| **ReadFileBuffered** | **16777216**        | **2.357 s** | **0.0440 s** | **0.0390 s** |  **1.00** |    **0.02** |     **456 B** |        **1.00** |
|                  |                 |         |          |          |       |         |           |             |
| **ReadFileBuffered** | **25165824**        | **2.370 s** | **0.0468 s** | **0.0481 s** |  **1.00** |    **0.03** |     **456 B** |        **1.00** |
|                  |                 |         |          |          |       |         |           |             |
| **ReadFileBuffered** | **1073741824**      | **2.368 s** | **0.0422 s** | **0.0395 s** |  **1.00** |    **0.02** |     **456 B** |        **1.00** |
