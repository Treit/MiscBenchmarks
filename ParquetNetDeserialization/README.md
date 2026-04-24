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

```
