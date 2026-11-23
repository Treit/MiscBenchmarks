# TSV string concatenation vs. StringBuilder

Compare the original `text += row[field].ToString() + "\t"` loop with a
`StringBuilder` that is reused across rows within each call. Both methods return
a `List<string>` of TSV rows and use `TrimEnd('\t')`, as the original code does.

Each invocation converts a complete dataset. Inputs contain 100 or 10,000 rows,
10 or 100 columns, and deterministic 64-character ASCII fields. The largest
dataset produces 64,990,000 characters across its rows, about 62 MiB of TSV
when encoded as UTF-8 with one line feed per row.

Input generation happens in `GlobalSetup`. Database access, file writes, and
joining rows into a single string are excluded. Inputs are stored as objects
so both methods perform the original `ToString()` call. The objects contain
strings to isolate concatenation from numeric formatting. Benchmark jobs use
.NET 10 and restrict runtime roll-forward to patch updates.

Concatenation repeatedly copies the growing row. More rows increase total work;
more columns increase the repeated copying within each row. `MemoryDiagnoser`
reports allocated bytes per dataset and garbage collections per 1,000 datasets.

Run from this directory:


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26320.9877) (Hyper-V)
Unknown processor
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.26.53018), X64 RyuJIT AVX2
  Job-ZKAWDP : .NET 10.0.15 (10.0.1526.53008), X64 RyuJIT AVX2

EnvironmentVariables=DOTNET_ROLL_FORWARD=LatestPatch  Runtime=.NET 10.0  

```
| Method                    | RowCount | ColumnCount | Mean          | Error         | StdDev        | Ratio | RatioSD | Gen0        | Gen1       | Gen2     | Allocated     | Alloc Ratio |
|-------------------------- |--------- |------------ |--------------:|--------------:|--------------:|------:|--------:|------------:|-----------:|---------:|--------------:|------------:|
| **BuildTsvWithConcat**        | **100**      | **10**          |      **64.04 μs** |      **1.712 μs** |      **5.020 μs** |  **1.01** |    **0.11** |     **52.2461** |    **17.4561** |        **-** |      **853.7 KB** |        **1.00** |
| BuildTsvWithStringBuilder | 100      | 10          |      25.93 μs |      0.626 μs |      1.816 μs |  0.41 |    0.04 |     16.2048 |     5.3711 |        - |      264.7 KB |        0.31 |
|                           |          |             |               |               |               |       |         |             |            |          |               |             |
| **BuildTsvWithConcat**        | **100**      | **100**         |   **4,712.32 μs** |    **158.121 μs** |    **463.741 μs** |  **1.01** |    **0.14** |   **4015.6250** |   **554.6875** |        **-** |   **65629.48 KB** |        **1.00** |
| BuildTsvWithStringBuilder | 100      | 100         |     280.11 μs |      5.950 μs |     17.451 μs |  0.06 |    0.01 |    157.7148 |    52.7344 |        - |    2577.78 KB |        0.04 |
|                           |          |             |               |               |               |       |         |             |            |          |               |             |
| **BuildTsvWithConcat**        | **10000**    | **10**          |  **22,634.80 μs** |    **513.482 μs** |  **1,481.513 μs** |  **1.00** |    **0.09** |   **5781.2500** |  **2468.7500** | **562.5000** |   **85412.96 KB** |        **1.00** |
| BuildTsvWithStringBuilder | 10000    | 10          |  18,605.86 μs |    416.475 μs |  1,214.878 μs |  0.83 |    0.07 |   2125.0000 |  2093.7500 | 562.5000 |   26120.41 KB |        0.31 |
|                           |          |             |               |               |               |       |         |             |            |          |               |             |
| **BuildTsvWithConcat**        | **10000**    | **100**         | **559,126.43 μs** | **18,140.661 μs** | **52,917.163 μs** |  **1.01** |    **0.13** | **401000.0000** | **24000.0000** |        **-** | **6562990.68 KB** |        **1.00** |
| BuildTsvWithStringBuilder | 10000    | 100         |  98,181.05 μs |  1,956.651 μs |  4,040.823 μs |  0.18 |    0.02 |  16333.3333 | 16166.6667 | 833.3333 |  254664.13 KB |        0.04 |
