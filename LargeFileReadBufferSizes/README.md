# LargeFileReadBufferSizes

This benchmark compares sequential reads of a randomly generated 5 GB integer file while varying the read buffer size.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | BufferSizeBytes | Mean    | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |---------------- |--------:|---------:|---------:|------:|--------:|----------:|------------:|
| **ReadFileBuffered** | **4096**            | **8.694 s** | **0.1725 s** | **0.3639 s** |  **1.00** |    **0.06** |     **464 B** |        **1.00** |
|                  |                 |         |          |          |       |         |           |             |
| **ReadFileBuffered** | **1048576**         | **4.038 s** | **0.0141 s** | **0.0132 s** |  **1.00** |    **0.00** |     **464 B** |        **1.00** |
|                  |                 |         |          |          |       |         |           |             |
| **ReadFileBuffered** | **16777216**        | **4.058 s** | **0.0214 s** | **0.0201 s** |  **1.00** |    **0.01** |     **464 B** |        **1.00** |
|                  |                 |         |          |          |       |         |           |             |
| **ReadFileBuffered** | **25165824**        | **4.075 s** | **0.0193 s** | **0.0180 s** |  **1.00** |    **0.01** |     **464 B** |        **1.00** |
|                  |                 |         |          |          |       |         |           |             |
| **ReadFileBuffered** | **1073741824**      | **4.111 s** | **0.0099 s** | **0.0093 s** |  **1.00** |    **0.00** |     **464 B** |        **1.00** |
