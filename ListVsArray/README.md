# Array vs. List


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  Job-EVTPHR : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|        Method |   Count |      Mean |     Error |    StdDev |
|-------------- |-------- |----------:|----------:|----------:|
|  **PopulateList** |   **10000** |  **21.14 μs** |  **0.372 μs** |  **0.348 μs** |
| PopulateArray |   10000 |  26.68 μs |  0.449 μs |  0.398 μs |
|       SumList |   10000 |  17.88 μs |  0.291 μs |  0.258 μs |
|      SumArray |   10000 |  13.09 μs |  0.267 μs |  0.698 μs |
|  **PopulateList** | **1000000** | **974.83 μs** | **14.981 μs** | **14.013 μs** |
| PopulateArray | 1000000 | 494.26 μs |  9.380 μs |  8.315 μs |
|       SumList | 1000000 | 638.68 μs |  5.767 μs |  5.395 μs |
|      SumArray | 1000000 | 434.70 μs |  8.611 μs | 13.905 μs |
