# Deserializing JSON using a few different techniques



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27828.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | Count | Mean     | Error    | StdDev   | Gen0    | Gen1   | Allocated |
|------------------------------ |------ |---------:|---------:|---------:|--------:|-------:|----------:|
| DeserializeWithJsonDocument   | 100   | 30.91 μs | 0.581 μs | 0.939 μs |  2.0142 | 0.0610 |   8.64 KB |
| DeserializeWithJsonNode       | 100   | 60.91 μs | 1.200 μs | 1.179 μs | 15.1367 | 2.0752 |  64.23 KB |
| DeserializeWithJsonSerializer | 100   | 40.96 μs | 0.815 μs | 1.531 μs |  5.0049 |      - |  21.27 KB |
| DeserializeWithSourceGen      | 100   | 46.70 μs | 0.889 μs | 0.694 μs |  4.4556 |      - |  18.93 KB |
