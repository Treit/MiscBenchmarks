# IntersectAny



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-OKCFRN : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  InvocationCount=1  MemoryRandomization=True  
UnrollFactor=1  

```
| Method                              | Count  | Location    | Mean           | Error         | StdDev         | Median         | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------ |------- |------------ |---------------:|--------------:|---------------:|---------------:|------:|--------:|----------:|------------:|
| **ListIntersectAnyLinq**                | **10**     | **AtBeginning** |    **11,341.0 ns** |     **996.18 ns** |     **2,937.3 ns** |    **11,200.0 ns** |  **1.07** |    **0.42** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | AtBeginning |     5,535.0 ns |     760.29 ns |     2,241.7 ns |     6,050.0 ns |  0.52 |    0.26 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | 10     | AtBeginning |     9,202.0 ns |   1,112.11 ns |     3,279.1 ns |     9,300.0 ns |  0.87 |    0.40 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | 10     | AtBeginning |       741.0 ns |      60.80 ns |       179.3 ns |       700.0 ns |  0.07 |    0.03 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | AtBeginning |       652.0 ns |      66.88 ns |       197.2 ns |       600.0 ns |  0.06 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 10     | AtBeginning |    10,205.0 ns |     877.84 ns |     2,588.3 ns |    10,450.0 ns |  0.97 |    0.37 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | AtBeginning |       668.0 ns |      61.33 ns |       180.8 ns |       600.0 ns |  0.06 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 10     | AtBeginning |     8,082.0 ns |     701.73 ns |     2,069.1 ns |     8,600.0 ns |  0.76 |    0.30 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | AtBeginning |       921.0 ns |      97.64 ns |       287.9 ns |       850.0 ns |  0.09 |    0.04 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **10**     | **InMiddle**    |    **10,494.0 ns** |     **907.87 ns** |     **2,676.9 ns** |    **10,600.0 ns** |  **1.07** |    **0.40** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | InMiddle    |     6,080.0 ns |     856.27 ns |     2,524.7 ns |     6,200.0 ns |  0.62 |    0.31 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | 10     | InMiddle    |     9,296.0 ns |   1,319.04 ns |     3,889.2 ns |     9,250.0 ns |  0.95 |    0.48 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | 10     | InMiddle    |     1,256.0 ns |     106.74 ns |       314.7 ns |     1,200.0 ns |  0.13 |    0.05 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | InMiddle    |       994.0 ns |      72.12 ns |       212.6 ns |     1,000.0 ns |  0.10 |    0.04 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 10     | InMiddle    |    10,135.0 ns |     773.78 ns |     2,281.5 ns |    10,650.0 ns |  1.03 |    0.37 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | InMiddle    |       977.0 ns |      50.29 ns |       148.3 ns |     1,000.0 ns |  0.10 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 10     | InMiddle    |     8,275.0 ns |     675.81 ns |     1,992.6 ns |     8,900.0 ns |  0.84 |    0.31 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | InMiddle    |     1,043.0 ns |      85.86 ns |       253.2 ns |     1,000.0 ns |  0.11 |    0.04 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **10**     | **AtEnd**       |    **11,444.0 ns** |   **2,221.96 ns** |     **6,551.5 ns** |    **10,950.0 ns** |  **1.13** |    **0.76** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | AtEnd       |     6,499.0 ns |     764.97 ns |     2,255.5 ns |     7,050.0 ns |  0.64 |    0.30 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | 10     | AtEnd       |     9,372.0 ns |   1,122.62 ns |     3,310.1 ns |     9,400.0 ns |  0.93 |    0.44 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | 10     | AtEnd       |     1,907.0 ns |     150.85 ns |       444.8 ns |     1,700.0 ns |  0.19 |    0.07 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | AtEnd       |     1,442.0 ns |     141.87 ns |       418.3 ns |     1,300.0 ns |  0.14 |    0.06 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 10     | AtEnd       |     9,661.0 ns |     637.44 ns |     1,879.5 ns |    10,300.0 ns |  0.96 |    0.35 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | AtEnd       |     1,563.0 ns |     149.80 ns |       441.7 ns |     1,400.0 ns |  0.15 |    0.07 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 10     | AtEnd       |     8,447.0 ns |     640.27 ns |     1,887.8 ns |     8,950.0 ns |  0.84 |    0.32 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | AtEnd       |     1,499.0 ns |     166.25 ns |       490.2 ns |     1,300.0 ns |  0.15 |    0.07 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **AtBeginning** | **5,028,855.0 ns** | **409,401.52 ns** | **1,207,129.7 ns** | **4,877,750.0 ns** |  **1.06** |    **0.35** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | AtBeginning |   571,872.0 ns |  41,305.71 ns |   121,790.8 ns |   551,900.0 ns |  0.12 |    0.04 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | 100000 | AtBeginning | 5,200,163.0 ns | 471,226.59 ns | 1,389,422.3 ns | 4,898,900.0 ns |  1.09 |    0.38 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | 100000 | AtBeginning |   391,362.0 ns |  33,668.26 ns |    99,271.6 ns |   373,000.0 ns |  0.08 |    0.03 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | AtBeginning |   347,184.0 ns |  27,604.53 ns |    81,392.6 ns |   332,850.0 ns |  0.07 |    0.02 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 100000 | AtBeginning | 4,804,182.0 ns | 450,389.54 ns | 1,327,983.8 ns | 4,098,300.0 ns |  1.01 |    0.36 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | AtBeginning |   358,551.0 ns |  29,549.51 ns |    87,127.4 ns |   344,400.0 ns |  0.08 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 100000 | AtBeginning | 4,634,881.0 ns | 443,188.54 ns | 1,306,751.5 ns | 4,086,700.0 ns |  0.97 |    0.35 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | AtBeginning |   345,502.0 ns |  25,868.54 ns |    76,274.0 ns |   339,450.0 ns |  0.07 |    0.02 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **InMiddle**    | **5,078,816.0 ns** | **386,158.31 ns** | **1,138,596.6 ns** | **4,939,200.0 ns** |  **1.05** |    **0.33** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | InMiddle    | 4,534,351.0 ns | 310,327.53 ns |   915,007.8 ns | 4,424,800.0 ns |  0.94 |    0.28 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | 100000 | InMiddle    | 5,187,553.0 ns | 437,462.63 ns | 1,289,868.5 ns | 4,945,150.0 ns |  1.07 |    0.35 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | 100000 | InMiddle    | 4,706,783.0 ns | 160,342.82 ns |   472,774.5 ns | 4,603,250.0 ns |  0.97 |    0.23 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | InMiddle    | 4,256,438.3 ns |  85,074.46 ns |   190,281.2 ns | 4,231,300.0 ns |  0.88 |    0.19 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 100000 | InMiddle    | 4,867,167.0 ns | 470,133.31 ns | 1,386,198.8 ns | 4,115,650.0 ns |  1.01 |    0.36 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | InMiddle    | 4,291,515.0 ns | 131,751.59 ns |   388,472.6 ns | 4,241,950.0 ns |  0.89 |    0.21 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 100000 | InMiddle    | 4,607,686.0 ns | 438,183.77 ns | 1,291,994.8 ns | 4,054,400.0 ns |  0.95 |    0.34 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | InMiddle    | 4,208,333.0 ns |  90,015.27 ns |   265,412.1 ns | 4,174,800.0 ns |  0.87 |    0.19 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **AtEnd**       | **5,183,969.0 ns** | **449,105.46 ns** | **1,324,197.7 ns** | **4,923,100.0 ns** |  **1.06** |    **0.38** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | AtEnd       | 4,412,666.0 ns | 156,038.38 ns |   460,082.7 ns | 4,317,050.0 ns |  0.90 |    0.24 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | 100000 | AtEnd       | 5,084,842.0 ns | 417,943.14 ns | 1,232,314.9 ns | 4,869,200.0 ns |  1.04 |    0.36 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | 100000 | AtEnd       | 4,778,756.0 ns | 142,001.15 ns |   418,693.6 ns | 4,634,200.0 ns |  0.98 |    0.25 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | AtEnd       | 4,261,682.0 ns | 268,211.48 ns |   790,827.7 ns | 4,150,650.0 ns |  0.87 |    0.27 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 100000 | AtEnd       | 4,731,712.0 ns | 436,434.04 ns | 1,286,835.7 ns | 4,100,400.0 ns |  0.97 |    0.36 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | AtEnd       | 4,306,938.0 ns |  89,182.91 ns |   262,957.9 ns | 4,234,600.0 ns |  0.88 |    0.22 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 100000 | AtEnd       | 4,669,360.0 ns | 472,179.53 ns | 1,392,232.1 ns | 4,121,700.0 ns |  0.96 |    0.37 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | AtEnd       | 4,199,224.0 ns | 129,691.17 ns |   382,397.4 ns | 4,125,700.0 ns |  0.86 |    0.22 |         - |        0.00 |
