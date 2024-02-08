# IntersectAny


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26052.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-IPPBLB : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  InvocationCount=1  MemoryRandomization=True  
UnrollFactor=1  

```
| Method                              | Count  | Location    | Mean            | Error           | StdDev          | Median          | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------ |------- |------------ |----------------:|----------------:|----------------:|----------------:|------:|--------:|----------:|------------:|
| **ListIntersectAnyLinq**                | **10**     | **AtBeginning** |      **7,999.0 ns** |     **1,028.09 ns** |     **3,031.33 ns** |      **7,300.0 ns** |  **1.00** |    **0.00** |     **912 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | AtBeginning |      2,330.0 ns |        72.07 ns |       212.49 ns |      2,300.0 ns |  0.31 |    0.05 |     608 B |        0.67 |
| ListIntersectAnyWithHashSet         | 10     | AtBeginning |      6,762.0 ns |       650.78 ns |     1,918.85 ns |      5,950.0 ns |  0.90 |    0.31 |     776 B |        0.85 |
| ListIntersectAnyNestedLoop          | 10     | AtBeginning |        797.0 ns |        26.16 ns |        77.14 ns |        800.0 ns |  0.10 |    0.02 |     112 B |        0.12 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | AtBeginning |      1,122.0 ns |        56.54 ns |       166.72 ns |      1,100.0 ns |  0.15 |    0.03 |     400 B |        0.44 |
| ArrayIntersectAnyLinq               | 10     | AtBeginning |      7,808.0 ns |     1,111.02 ns |     3,275.86 ns |      7,000.0 ns |  1.01 |    0.38 |     896 B |        0.98 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | AtBeginning |        757.0 ns |        51.98 ns |       153.25 ns |        700.0 ns |  0.10 |    0.03 |     400 B |        0.44 |
| ArrayIntersectAnyWithHashSet        | 10     | AtBeginning |      5,812.0 ns |       572.67 ns |     1,688.54 ns |      5,300.0 ns |  0.76 |    0.26 |     768 B |        0.84 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | AtBeginning |        876.0 ns |        48.47 ns |       142.93 ns |        900.0 ns |  0.12 |    0.03 |     400 B |        0.44 |
|                                     |        |             |                 |                 |                 |                 |       |         |           |             |
| **ListIntersectAnyLinq**                | **10**     | **InMiddle**    |      **7,566.0 ns** |       **247.08 ns** |       **728.53 ns** |      **7,400.0 ns** |  **1.00** |    **0.00** |     **912 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | InMiddle    |      3,215.0 ns |       594.14 ns |     1,751.85 ns |      3,000.0 ns |  0.43 |    0.24 |     608 B |        0.67 |
| ListIntersectAnyWithHashSet         | 10     | InMiddle    |      6,802.0 ns |     1,843.14 ns |     5,434.55 ns |      6,000.0 ns |  0.88 |    0.48 |     776 B |        0.85 |
| ListIntersectAnyNestedLoop          | 10     | InMiddle    |      1,458.0 ns |        72.66 ns |       214.23 ns |      1,400.0 ns |  0.19 |    0.03 |     112 B |        0.12 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | InMiddle    |      1,692.0 ns |        99.34 ns |       292.91 ns |      1,600.0 ns |  0.23 |    0.04 |      64 B |        0.07 |
| ArrayIntersectAnyLinq               | 10     | InMiddle    |      7,271.0 ns |       302.98 ns |       893.33 ns |      7,000.0 ns |  0.97 |    0.16 |     896 B |        0.98 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | InMiddle    |      1,335.0 ns |       112.16 ns |       330.71 ns |      1,200.0 ns |  0.18 |    0.05 |     400 B |        0.44 |
| ArrayIntersectAnyWithHashSet        | 10     | InMiddle    |      5,808.0 ns |       600.22 ns |     1,769.76 ns |      5,450.0 ns |  0.77 |    0.26 |     768 B |        0.84 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | InMiddle    |      1,442.0 ns |       131.33 ns |       387.21 ns |      1,300.0 ns |  0.19 |    0.05 |     400 B |        0.44 |
|                                     |        |             |                 |                 |                 |                 |       |         |           |             |
| **ListIntersectAnyLinq**                | **10**     | **AtEnd**       |      **8,233.0 ns** |     **1,383.19 ns** |     **4,078.37 ns** |      **7,500.0 ns** |  **1.00** |    **0.00** |     **912 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | AtEnd       |      5,002.0 ns |       959.03 ns |     2,827.71 ns |      4,700.0 ns |  0.65 |    0.41 |     608 B |        0.67 |
| ListIntersectAnyWithHashSet         | 10     | AtEnd       |      6,528.0 ns |       478.93 ns |     1,412.15 ns |      6,250.0 ns |  0.84 |    0.23 |     440 B |        0.48 |
| ListIntersectAnyNestedLoop          | 10     | AtEnd       |      2,219.0 ns |       232.97 ns |       686.92 ns |      2,000.0 ns |  0.29 |    0.11 |     400 B |        0.44 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | AtEnd       |      2,265.0 ns |       152.47 ns |       449.55 ns |      2,100.0 ns |  0.29 |    0.07 |     400 B |        0.44 |
| ArrayIntersectAnyLinq               | 10     | AtEnd       |      7,492.0 ns |       287.28 ns |       847.06 ns |      7,300.0 ns |  0.97 |    0.18 |     896 B |        0.98 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | AtEnd       |      1,965.0 ns |       157.12 ns |       463.27 ns |      1,800.0 ns |  0.25 |    0.07 |     400 B |        0.44 |
| ArrayIntersectAnyWithHashSet        | 10     | AtEnd       |      5,835.0 ns |       195.71 ns |       577.07 ns |      5,700.0 ns |  0.75 |    0.11 |     768 B |        0.84 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | AtEnd       |      2,284.0 ns |       250.89 ns |       739.74 ns |      2,100.0 ns |  0.29 |    0.10 |     400 B |        0.44 |
|                                     |        |             |                 |                 |                 |                 |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **AtBeginning** | **10,600,545.0 ns** | **1,340,791.15 ns** | **3,953,352.95 ns** |  **9,269,850.0 ns** |  **1.00** |    **0.00** | **2173312 B** |       **1.000** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | AtBeginning |  1,223,302.0 ns |    73,190.50 ns |   215,803.84 ns |  1,162,700.0 ns |  0.13 |    0.04 | 1600448 B |       0.736 |
| ListIntersectAnyWithHashSet         | 100000 | AtBeginning |  8,645,055.0 ns |   478,689.73 ns | 1,411,427.48 ns |  8,730,200.0 ns |  0.89 |    0.26 | 2173176 B |       1.000 |
| ListIntersectAnyNestedLoop          | 100000 | AtBeginning |  1,564,305.0 ns |    99,377.47 ns |   293,016.71 ns |  1,514,200.0 ns |  0.16 |    0.05 |      64 B |       0.000 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | AtBeginning |  1,045,260.0 ns |    85,885.92 ns |   253,236.57 ns |  1,105,750.0 ns |  0.10 |    0.02 |     400 B |       0.000 |
| ArrayIntersectAnyLinq               | 100000 | AtBeginning |  7,792,561.0 ns |   366,821.45 ns | 1,081,581.31 ns |  7,579,550.0 ns |  0.82 |    0.26 | 2173296 B |       1.000 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | AtBeginning |    928,129.0 ns |    61,327.63 ns |   180,825.90 ns |    884,900.0 ns |  0.10 |    0.03 |     400 B |       0.000 |
| ArrayIntersectAnyWithHashSet        | 100000 | AtBeginning |  7,404,116.0 ns |   307,357.03 ns |   906,249.14 ns |  7,198,000.0 ns |  0.77 |    0.21 | 2173168 B |       1.000 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | AtBeginning |    985,129.0 ns |    67,506.99 ns |   199,045.88 ns |    993,000.0 ns |  0.10 |    0.03 |     400 B |       0.000 |
|                                     |        |             |                 |                 |                 |                 |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **InMiddle**    |  **8,091,031.0 ns** |   **369,740.12 ns** | **1,090,187.09 ns** |  **7,989,550.0 ns** |  **1.00** |    **0.00** | **2173312 B** |       **1.000** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | InMiddle    | 12,114,438.0 ns |   409,356.46 ns | 1,206,996.76 ns | 12,038,900.0 ns |  1.53 |    0.28 | 1600112 B |       0.736 |
| ListIntersectAnyWithHashSet         | 100000 | InMiddle    |  8,020,882.0 ns |   356,229.63 ns | 1,050,351.10 ns |  7,957,400.0 ns |  1.00 |    0.12 | 2173176 B |       1.000 |
| ListIntersectAnyNestedLoop          | 100000 | InMiddle    | 21,302,236.0 ns |   726,272.19 ns | 2,141,429.93 ns | 20,782,800.0 ns |  2.68 |    0.47 |     400 B |       0.000 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | InMiddle    | 13,833,171.0 ns |   874,725.26 ns | 2,579,147.16 ns | 15,052,100.0 ns |  1.71 |    0.23 |     400 B |       0.000 |
| ArrayIntersectAnyLinq               | 100000 | InMiddle    |  7,685,565.0 ns |   377,179.68 ns | 1,112,122.80 ns |  7,315,400.0 ns |  0.96 |    0.15 | 2173296 B |       1.000 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | InMiddle    | 11,979,466.0 ns |   410,275.74 ns | 1,209,707.26 ns | 11,757,200.0 ns |  1.51 |    0.26 |     400 B |       0.000 |
| ArrayIntersectAnyWithHashSet        | 100000 | InMiddle    |  7,555,493.0 ns |   372,327.52 ns | 1,097,816.10 ns |  7,249,200.0 ns |  0.94 |    0.13 | 2173168 B |       1.000 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | InMiddle    | 13,656,332.0 ns |   587,542.03 ns | 1,732,380.94 ns | 13,587,800.0 ns |  1.71 |    0.30 |     400 B |       0.000 |
|                                     |        |             |                 |                 |                 |                 |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **AtEnd**       |  **8,067,638.0 ns** |   **405,650.15 ns** | **1,196,068.61 ns** |  **7,827,350.0 ns** |  **1.00** |    **0.00** | **2173312 B** |       **1.000** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | AtEnd       | 12,233,531.0 ns |   341,924.22 ns | 1,008,171.28 ns | 12,280,050.0 ns |  1.55 |    0.26 | 1600448 B |       0.736 |
| ListIntersectAnyWithHashSet         | 100000 | AtEnd       |  8,601,535.0 ns |   519,263.87 ns | 1,531,061.22 ns |  8,500,350.0 ns |  1.08 |    0.19 | 2173176 B |       1.000 |
| ListIntersectAnyNestedLoop          | 100000 | AtEnd       | 21,364,594.0 ns |   627,648.80 ns | 1,850,636.64 ns | 20,863,850.0 ns |  2.69 |    0.38 |     400 B |       0.000 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | AtEnd       | 13,818,780.0 ns |   863,978.85 ns | 2,547,461.14 ns | 15,071,800.0 ns |  1.72 |    0.25 |     400 B |       0.000 |
| ArrayIntersectAnyLinq               | 100000 | AtEnd       |  7,765,550.0 ns |   430,758.82 ns | 1,270,102.09 ns |  7,401,150.0 ns |  0.97 |    0.15 | 2173296 B |       1.000 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | AtEnd       | 11,987,926.0 ns |   537,730.96 ns | 1,585,511.88 ns | 11,850,150.0 ns |  1.51 |    0.27 |     400 B |       0.000 |
| ArrayIntersectAnyWithHashSet        | 100000 | AtEnd       |  7,518,038.0 ns |   358,647.17 ns | 1,057,479.28 ns |  7,207,050.0 ns |  0.94 |    0.11 | 2173168 B |       1.000 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | AtEnd       | 13,011,130.0 ns |   530,889.94 ns | 1,565,340.97 ns | 13,337,150.0 ns |  1.63 |    0.22 |     400 B |       0.000 |
