# Parquet.Net Deserialization Approaches

Compares two ways to read a Parquet file with Parquet.Net:

`SerializerDeserialize` uses `ParquetSerializer.DeserializeAsync<T>`, the high-level API
that maps each row to a new heap-allocated class instance. `ColumnApiDeserialize` uses
`ParquetReader` directly, reading each column as a typed array with no per-row allocation.

The memory diagnoser makes the allocation story visible. At 500,000 rows the serializer
allocates on the order of tens of thousands of objects per millisecond of elapsed time,
which drives GC pressure and inflates wall-clock time well beyond what raw Parquet I/O
would cost.

## Results



```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6936/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.202
  [Host]     : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3


```
| Method                | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated | Alloc Ratio |
|---------------------- |-----------:|---------:|---------:|------:|--------:|-----------:|-----------:|----------:|----------:|------------:|
| SerializerDeserialize | 1,279.6 ms | 20.84 ms | 19.49 ms |  1.00 |    0.02 | 29000.0000 | 28000.0000 | 4000.0000 | 757.01 MB |        1.00 |
| ColumnApiDeserialize  |   935.0 ms | 18.54 ms | 37.87 ms |  0.73 |    0.03 | 18000.0000 | 17000.0000 | 3000.0000 | 697.05 MB |        0.92 |
