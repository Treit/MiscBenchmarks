# Iterating a List with and without CollectionsMarshal.AsSpan



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26080.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                 | Count  | Mean     | Error    | StdDev    | Allocated |
|--------------------------------------- |------- |---------:|---------:|----------:|----------:|
| SumUsingForEach                        | 100000 | 80.56 μs | 4.676 μs | 13.786 μs |         - |
| SumUsingForEachCollectionMarshalAsSpan | 100000 | 35.93 μs | 0.715 μs |  1.271 μs |         - |
