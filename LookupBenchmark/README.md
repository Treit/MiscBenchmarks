# Finding an item

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25961.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                 Method | Iterations |         Mean |       Error |      StdDev |       Median | Allocated |
|----------------------- |----------- |-------------:|------------:|------------:|-------------:|----------:|
|     **LookupUsingHashSet** |       **1000** |     **5.167 μs** |   **0.0678 μs** |   **0.0634 μs** |     **5.167 μs** |         **-** |
|        LookupUsingList |       1000 |     6.171 μs |   0.0360 μs |   0.0319 μs |     6.175 μs |         - |
| LookupUsingConditional |       1000 |     1.120 μs |   0.0139 μs |   0.0123 μs |     1.117 μs |         - |
|      LookupUsingSwitch |       1000 |     1.022 μs |   0.0199 μs |   0.0221 μs |     1.014 μs |         - |
|       LookupUsingRange |       1000 |     1.063 μs |   0.0098 μs |   0.0077 μs |     1.062 μs |         - |
|     **LookupUsingHashSet** |     **100000** |   **518.074 μs** |   **9.6728 μs** |   **7.5519 μs** |   **519.373 μs** |       **1 B** |
|        LookupUsingList |     100000 |   598.889 μs |   2.3193 μs |   2.0560 μs |   598.348 μs |       1 B |
| LookupUsingConditional |     100000 |   116.547 μs |   2.1606 μs |   5.8044 μs |   115.491 μs |         - |
|      LookupUsingSwitch |     100000 |    99.255 μs |   1.8396 μs |   1.7208 μs |    99.590 μs |         - |
|       LookupUsingRange |     100000 |   109.692 μs |   2.1859 μs |   4.4157 μs |   108.217 μs |         - |
|     **LookupUsingHashSet** |    **1000000** | **5,281.217 μs** | **102.1128 μs** | **252.3976 μs** | **5,204.021 μs** |       **4 B** |
|        LookupUsingList |    1000000 | 6,117.040 μs | 122.1362 μs | 186.5149 μs | 6,020.678 μs |       2 B |
| LookupUsingConditional |    1000000 | 1,102.374 μs |   9.8526 μs |   9.2162 μs | 1,102.192 μs |       1 B |
|      LookupUsingSwitch |    1000000 |   997.929 μs |  19.3948 μs |  31.3189 μs |   987.896 μs |       1 B |
|       LookupUsingRange |    1000000 | 1,088.862 μs |  21.5852 μs |  40.5423 μs | 1,072.775 μs |       1 B |
