# Copying lists


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                  Method |   Count |           Mean |        Error |       StdDev |         Median | Ratio | RatioSD |
|------------------------ |-------- |---------------:|-------------:|-------------:|---------------:|------:|--------:|
| **CopyWithListConstructor** |    **1000** |       **179.5 ns** |      **3.62 ns** |      **6.43 ns** |       **179.2 ns** |  **1.00** |    **0.00** |
|          CopyWithToList |    1000 |       190.4 ns |      3.79 ns |      6.93 ns |       189.2 ns |  1.06 |    0.04 |
|          CopyExplicitly |    1000 |     1,730.3 ns |      9.13 ns |      8.54 ns |     1,733.2 ns |  9.49 |    0.23 |
|                         |         |                |              |              |                |       |         |
| **CopyWithListConstructor** |  **100000** |   **226,598.9 ns** | **14,004.34 ns** | **41,292.11 ns** |   **199,001.0 ns** |  **1.00** |    **0.00** |
|          CopyWithToList |  100000 |   224,319.3 ns | 13,364.02 ns | 39,404.12 ns |   196,210.1 ns |  1.02 |    0.24 |
|          CopyExplicitly |  100000 |   346,513.6 ns | 13,498.73 ns | 39,589.44 ns |   320,335.1 ns |  1.58 |    0.33 |
|                         |         |                |              |              |                |       |         |
| **CopyWithListConstructor** | **1000000** | **1,069,869.0 ns** | **17,197.69 ns** | **14,360.85 ns** | **1,066,441.8 ns** |  **1.00** |    **0.00** |
|          CopyWithToList | 1000000 | 1,073,771.7 ns | 19,260.05 ns | 17,073.54 ns | 1,066,814.8 ns |  1.00 |    0.02 |
|          CopyExplicitly | 1000000 | 2,254,764.5 ns | 43,714.79 ns | 65,430.25 ns | 2,241,351.0 ns |  2.11 |    0.08 |
