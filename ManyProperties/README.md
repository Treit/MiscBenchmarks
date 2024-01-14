# Representing objects having many properties


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                      Method |  Count |            Mean |           Error |          StdDev | Ratio | RatioSD |       Gen0 |       Gen1 |      Gen2 |    Allocated | Alloc Ratio |
|-------------------------------------------- |------- |----------------:|----------------:|----------------:|------:|--------:|-----------:|-----------:|----------:|-------------:|------------:|
| **NullablePropertiesCreeateAndSet50Properties** |     **10** |        **718.3 ns** |        **14.41 ns** |        **26.34 ns** |  **1.00** |    **0.00** |     **0.9737** |     **0.0811** |         **-** |     **15.91 KB** |        **1.00** |
|     SentinelValuesCreeateAndSet50Properties |     10 |        660.1 ns |         8.00 ns |         7.09 ns |  0.89 |    0.02 |     0.4950 |     0.0305 |         - |       8.1 KB |        0.51 |
|           BitArrayCreeateAndSet50Properties |     10 |      1,248.1 ns |        14.83 ns |        13.87 ns |  1.68 |    0.04 |     0.5436 |     0.0343 |         - |      8.88 KB |        0.56 |
|                                             |        |                 |                 |                 |       |         |            |            |           |              |             |
| **NullablePropertiesCreeateAndSet50Properties** |   **1000** |     **97,859.5 ns** |     **1,703.43 ns** |     **1,593.39 ns** |  **1.00** |    **0.00** |    **97.0459** |    **96.9238** |         **-** |   **1585.99 KB** |        **1.00** |
|     SentinelValuesCreeateAndSet50Properties |   1000 |     72,671.9 ns |     1,249.64 ns |     1,168.91 ns |  0.74 |    0.02 |    49.1943 |    36.6211 |         - |    804.74 KB |        0.51 |
|           BitArrayCreeateAndSet50Properties |   1000 |    138,432.7 ns |     1,150.78 ns |     1,020.14 ns |  1.42 |    0.03 |    53.9551 |    46.3867 |         - |    882.87 KB |        0.56 |
|                                             |        |                 |                 |                 |       |         |            |            |           |              |             |
| **NullablePropertiesCreeateAndSet50Properties** | **100000** | **59,089,292.6 ns** | **1,156,819.49 ns** | **2,880,881.96 ns** |  **1.00** |    **0.00** | **10500.0000** | **10400.0000** |  **900.0000** | **158594.42 KB** |        **1.00** |
|     SentinelValuesCreeateAndSet50Properties | 100000 | 44,245,460.8 ns |   878,865.60 ns | 2,330,626.88 ns |  0.75 |    0.05 |  5818.1818 |  5727.2727 | 1000.0000 |  80469.78 KB |        0.51 |
|           BitArrayCreeateAndSet50Properties | 100000 | 80,971,824.5 ns | 1,598,394.47 ns | 3,079,563.50 ns |  1.37 |    0.10 |  6142.8571 |  6000.0000 |  857.1429 |  88281.82 KB |        0.56 |
