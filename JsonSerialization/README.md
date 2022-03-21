# Serializing and deserializng JSON

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22581
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 5.0.15 (CoreCLR 5.0.1522.11506, CoreFX 5.0.1522.11506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.15 (CoreCLR 5.0.1522.11506, CoreFX 5.0.1522.11506), X64 RyuJIT


```
|                            Method |  Count |           Mean |         Error |         StdDev |       Gen 0 | Gen 1 | Gen 2 |    Allocated |
|---------------------------------- |------- |---------------:|--------------:|---------------:|------------:|------:|------:|-------------:|
|        **SerializeAndDeserializeSTJ** |     **10** |       **9.592 μs** |     **0.1902 μs** |      **0.4772 μs** |      **1.1749** |     **-** |     **-** |         **5 KB** |
| SerializeAndDeserializeNewtonsoft |     10 |      20.734 μs |     0.4125 μs |      0.9804 μs |     10.0098 |     - |     - |     42.27 KB |
|        **SerializeAndDeserializeSTJ** |   **1000** |     **962.272 μs** |    **19.0466 μs** |     **44.5207 μs** |    **122.0703** |     **-** |     **-** |    **515.47 KB** |
| SerializeAndDeserializeNewtonsoft |   1000 |   2,087.079 μs |    41.6474 μs |     99.7846 μs |   1005.8594 |     - |     - |   4242.03 KB |
|        **SerializeAndDeserializeSTJ** | **100000** | **106,549.932 μs** | **2,106.8257 μs** |  **4,668.5803 μs** |  **12400.0000** |     **-** |     **-** |  **52335.84 KB** |
| SerializeAndDeserializeNewtonsoft | 100000 | 220,404.413 μs | 5,631.1433 μs | 16,065.9687 μs | 100000.0000 |     - |     - | 424992.03 KB |
