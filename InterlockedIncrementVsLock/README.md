# Incrementing a counter from multiple threads.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-YEYQLV : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method                    | Count   | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------- |-------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| IncrementUsingInterlocked | 1000000 | 25.05 ms | 0.294 ms | 0.245 ms |  1.00 |    0.00 |   3.68 KB |        1.00 |
| IncrementUsingLock        | 1000000 | 76.82 ms | 1.013 ms | 0.947 ms |  3.06 |    0.04 |   3.96 KB |        1.08 |
