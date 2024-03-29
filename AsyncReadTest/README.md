Reading numbers from bytes

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26045.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                  | NumBytes | Mean             | Error            | StdDev           | Median           | Gen0        | Allocated    |
|------------------------ |--------- |-----------------:|-----------------:|-----------------:|-----------------:|------------:|-------------:|
| **NonAsync**                | **1024**     |       **3,250.9 ns** |         **64.01 ns** |        **144.48 ns** |       **3,243.6 ns** |      **1.9035** |       **8224 B** |
| NonAsyncWithArrayPool   | 1024     |       5,223.9 ns |        109.97 ns |        315.52 ns |       5,191.5 ns |           - |            - |
| NonAsyncWithFixedBuffer | 1024     |       1,963.7 ns |         32.48 ns |         28.80 ns |       1,969.0 ns |           - |            - |
| Async                   | 1024     |      10,117.8 ns |        205.39 ns |        569.13 ns |       9,983.2 ns |      6.1951 |      26776 B |
| AsyncWithAwait          | 1024     |      10,235.4 ns |        196.67 ns |        248.72 ns |      10,243.7 ns |      6.2103 |      26808 B |
| RawBytesAndSpan         | 1024     |         598.5 ns |          9.58 ns |          8.96 ns |         599.6 ns |           - |            - |
| **NonAsync**                | **1048576**  |   **3,221,134.3 ns** |     **58,806.44 ns** |     **84,338.44 ns** |   **3,203,907.6 ns** |   **1941.4063** |    **8388664 B** |
| NonAsyncWithArrayPool   | 1048576  |   4,992,204.6 ns |     98,349.20 ns |    113,259.08 ns |   4,979,602.7 ns |           - |         51 B |
| NonAsyncWithFixedBuffer | 1048576  |   1,999,823.3 ns |     33,357.66 ns |     31,202.77 ns |   1,986,736.3 ns |           - |          2 B |
| Async                   | 1048576  |  11,280,753.7 ns |    223,441.33 ns |    531,031.96 ns |  11,369,045.3 ns |   6312.5000 |   27263224 B |
| AsyncWithAwait          | 1048576  |  10,821,332.3 ns |    333,981.46 ns |    919,881.95 ns |  10,666,325.0 ns |   6312.5000 |   27263166 B |
| RawBytesAndSpan         | 1048576  |     604,770.8 ns |     10,236.35 ns |      8,547.82 ns |     606,142.0 ns |           - |            - |
| **NonAsync**                | **10485760** |  **33,133,081.2 ns** |  **1,003,084.83 ns** |  **2,878,038.42 ns** |  **32,217,153.1 ns** |  **19437.5000** |   **83886124 B** |
| NonAsyncWithArrayPool   | 10485760 |  60,446,852.8 ns |  1,207,448.44 ns |  3,138,319.03 ns |  59,449,914.3 ns |           - |        105 B |
| NonAsyncWithFixedBuffer | 10485760 |  20,878,286.8 ns |    403,939.92 ns |    525,235.99 ns |  20,885,445.3 ns |           - |         12 B |
| Async                   | 10485760 |  93,335,641.1 ns |  1,861,619.45 ns |  5,001,119.76 ns |  92,943,908.3 ns |  63166.6667 |  272629979 B |
| AsyncWithAwait          | 10485760 | 101,451,200.7 ns |  2,021,675.48 ns |  5,500,117.26 ns | 100,041,610.0 ns |  63200.0000 |  272630024 B |
| RawBytesAndSpan         | 10485760 |   6,347,551.4 ns |    126,633.09 ns |    303,404.80 ns |   6,252,613.3 ns |           - |          3 B |
| **NonAsync**                | **52428800** | **154,416,109.5 ns** |  **3,078,944.31 ns** |  **8,480,306.81 ns** | **152,126,566.7 ns** |  **97000.0000** |  **419430565 B** |
| NonAsyncWithArrayPool   | 52428800 | 267,746,846.9 ns |  7,536,860.52 ns | 19,855,105.23 ns | 265,921,600.0 ns |           - |        736 B |
| NonAsyncWithFixedBuffer | 52428800 | 100,256,602.9 ns |  1,004,781.69 ns |    890,712.80 ns | 100,188,100.0 ns |           - |         80 B |
| Async                   | 52428800 | 469,896,165.9 ns |  9,352,481.70 ns | 25,284,978.10 ns | 463,531,400.0 ns | 316000.0000 | 1363149352 B |
| AsyncWithAwait          | 52428800 | 517,961,125.6 ns | 13,634,687.10 ns | 38,008,057.84 ns | 507,618,650.0 ns | 316000.0000 | 1363149384 B |
| RawBytesAndSpan         | 52428800 |  30,365,263.9 ns |    559,864.11 ns |    549,861.41 ns |  30,378,085.9 ns |           - |         12 B |
