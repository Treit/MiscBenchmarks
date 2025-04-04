# Deserializing JSON using a few different techniques with a large complex object

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27828.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | Count | Mean     | Error     | StdDev    | Gen0     | Gen1     | Gen2     | Allocated  |
|------------------------------ |------ |---------:|----------:|----------:|---------:|---------:|---------:|-----------:|
| DeserializeWithJsonDocument   | 100   | 1.616 ms | 0.0322 ms | 0.0440 ms | 136.7188 |  68.3594 |        - |  713.17 KB |
| DeserializeWithJsonNode       | 100   | 3.226 ms | 0.0504 ms | 0.0495 ms | 328.1250 | 218.7500 | 109.3750 | 2053.64 KB |
| DeserializeWithJsonSerializer | 100   | 1.599 ms | 0.0287 ms | 0.0503 ms | 121.0938 |  72.2656 |        - |  635.23 KB |
| DeserializeWithSourceGen      | 100   | 1.579 ms | 0.0302 ms | 0.0268 ms | 121.0938 |  72.2656 |        - |  635.23 KB |
