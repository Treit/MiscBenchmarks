# Representing objects having many properties

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22587
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                                      Method |  Count |           Mean |         Error |         StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|-------------------------------------------- |------- |---------------:|--------------:|---------------:|------:|--------:|-----------:|----------:|----------:|-------------:|
| **NullablePropertiesCreeateAndSet50Properties** |     **10** |       **1.751 μs** |     **0.0363 μs** |      **0.1069 μs** |  **1.00** |    **0.00** |     **3.7766** |    **0.0019** |         **-** |     **15.91 KB** |
|     SentinelValuesCreeateAndSet50Properties |     10 |       1.271 μs |     0.0327 μs |      0.0964 μs |  0.73 |    0.06 |     1.9226 |         - |         - |       8.1 KB |
|           BitArrayCreeateAndSet50Properties |     10 |       3.332 μs |     0.0901 μs |      0.2627 μs |  1.91 |    0.18 |     2.1057 |    0.0038 |         - |      8.88 KB |
|                                             |        |                |               |                |       |         |            |           |           |              |
| **NullablePropertiesCreeateAndSet50Properties** |   **1000** |     **312.526 μs** |     **6.2380 μs** |     **14.8254 μs** |  **1.00** |    **0.00** |   **258.7891** |  **129.3945** |         **-** |   **1585.99 KB** |
|     SentinelValuesCreeateAndSet50Properties |   1000 |     168.732 μs |     3.3677 μs |      8.1333 μs |  0.54 |    0.03 |   131.3477 |   65.6738 |         - |    804.74 KB |
|           BitArrayCreeateAndSet50Properties |   1000 |     432.371 μs |    10.0387 μs |     29.1242 μs |  1.39 |    0.11 |   144.0430 |   71.7773 |         - |    882.87 KB |
|                                             |        |                |               |                |       |         |            |           |           |              |
| **NullablePropertiesCreeateAndSet50Properties** | **100000** | **146,933.760 μs** | **3,647.5992 μs** | **10,697.7770 μs** |  **1.00** |    **0.00** | **26800.0000** | **9800.0000** | **1200.0000** | **158595.35 KB** |
|     SentinelValuesCreeateAndSet50Properties | 100000 | 106,762.914 μs | 2,380.4785 μs |  7,018.8947 μs |  0.73 |    0.07 | 14000.0000 | 5285.7143 | 1000.0000 |   80469.5 KB |
|           BitArrayCreeateAndSet50Properties | 100000 | 195,991.230 μs | 3,809.0546 μs |  6,258.3859 μs |  1.34 |    0.10 | 14666.6667 | 5333.3333 |  666.6667 |  88281.98 KB |
