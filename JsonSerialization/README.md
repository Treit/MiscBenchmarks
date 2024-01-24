# Serializing and deserializng JSON



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                             Method | Count |         Mean |      Error |     StdDev |     Gen0 |   Gen1 |  Allocated |
|--------------------------------------------------- |------ |-------------:|-----------:|-----------:|---------:|-------:|-----------:|
|                         **SerializeAndDeserializeSTJ** |    **10** |     **6.044 μs** |  **0.0159 μs** |  **0.0141 μs** |   **0.1526** |      **-** |    **2.58 KB** |
|            SerializeAndDeserializeSTJCachedOptions |    10 |     5.902 μs |  0.0355 μs |  0.0332 μs |   0.1526 |      - |    2.58 KB |
|                SerializeAndDeserializeSTJSourceGen |    10 |     6.137 μs |  0.0340 μs |  0.0318 μs |   0.1373 |      - |    2.34 KB |
|          SerializeAndDeserializeSTJCaseInsensitive |    10 |     6.626 μs |  0.0180 μs |  0.0159 μs |   0.1602 | 0.0076 |    2.75 KB |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen |    10 |     6.520 μs |  0.0147 μs |  0.0138 μs |   0.1526 | 0.0076 |    2.52 KB |
|                  SerializeAndDeserializeNewtonsoft |    10 |    11.077 μs |  0.1248 μs |  0.1168 μs |   2.5787 | 0.0153 |   42.27 KB |
|                         **SerializeAndDeserializeSTJ** |  **1000** |   **616.725 μs** |  **2.3846 μs** |  **2.2305 μs** |  **16.6016** |      **-** |  **273.28 KB** |
|            SerializeAndDeserializeSTJCachedOptions |  1000 |   617.210 μs |  1.3512 μs |  1.1283 μs |  16.6016 |      - |  273.28 KB |
|                SerializeAndDeserializeSTJSourceGen |  1000 |   623.769 μs |  2.0513 μs |  1.9188 μs |  14.6484 |      - |  249.84 KB |
|          SerializeAndDeserializeSTJCaseInsensitive |  1000 |   612.225 μs |  1.7566 μs |  1.5572 μs |  16.6016 |      - |  273.47 KB |
| SerializeAndDeserializeSTJCaseInsensitiveSourceGen |  1000 |   625.236 μs |  1.9212 μs |  1.7031 μs |  14.6484 |      - |  250.01 KB |
|                  SerializeAndDeserializeNewtonsoft |  1000 | 1,070.701 μs | 11.6657 μs | 10.9121 μs | 257.8125 |      - | 4242.03 KB |
