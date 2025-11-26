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
| **ListIntersectAnyLinq**                | **10**     | **AtBeginning** |    **12,017.0 ns** |   **1,572.78 ns** |     **4,637.4 ns** |    **11,250.0 ns** |  **1.15** |    **0.66** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | AtBeginning |     6,377.0 ns |     974.73 ns |     2,874.0 ns |     6,200.0 ns |  0.61 |    0.38 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | 10     | AtBeginning |     9,136.0 ns |     975.01 ns |     2,874.8 ns |     8,950.0 ns |  0.88 |    0.45 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | 10     | AtBeginning |       817.0 ns |      85.43 ns |       251.9 ns |       800.0 ns |  0.08 |    0.04 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | AtBeginning |       800.0 ns |      75.61 ns |       222.9 ns |       700.0 ns |  0.08 |    0.04 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 10     | AtBeginning |    10,953.0 ns |   1,082.22 ns |     3,190.9 ns |    10,550.0 ns |  1.05 |    0.53 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | AtBeginning |       736.0 ns |      68.09 ns |       200.8 ns |       700.0 ns |  0.07 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 10     | AtBeginning |     9,929.0 ns |   3,004.68 ns |     8,859.4 ns |     8,700.0 ns |  0.95 |    0.98 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | AtBeginning |       910.0 ns |     107.41 ns |       316.7 ns |       800.0 ns |  0.09 |    0.05 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **10**     | **InMiddle**    |    **10,829.0 ns** |   **1,019.72 ns** |     **3,006.7 ns** |    **10,750.0 ns** |  **1.08** |    **0.45** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | InMiddle    |     6,355.0 ns |     902.74 ns |     2,661.8 ns |     6,450.0 ns |  0.64 |    0.34 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | 10     | InMiddle    |    10,238.0 ns |   1,306.42 ns |     3,852.0 ns |     9,550.0 ns |  1.02 |    0.51 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | 10     | InMiddle    |     1,348.0 ns |     136.47 ns |       402.4 ns |     1,200.0 ns |  0.13 |    0.06 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | InMiddle    |     1,139.0 ns |     103.49 ns |       305.1 ns |     1,000.0 ns |  0.11 |    0.05 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 10     | InMiddle    |    10,503.0 ns |     950.06 ns |     2,801.3 ns |    10,500.0 ns |  1.05 |    0.43 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | InMiddle    |     1,037.0 ns |      88.45 ns |       260.8 ns |     1,000.0 ns |  0.10 |    0.04 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 10     | InMiddle    |     8,931.0 ns |     970.08 ns |     2,860.3 ns |     8,700.0 ns |  0.89 |    0.40 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | InMiddle    |     1,194.0 ns |     133.49 ns |       393.6 ns |     1,000.0 ns |  0.12 |    0.05 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **10**     | **AtEnd**       |    **11,426.0 ns** |     **984.71 ns** |     **2,903.5 ns** |    **11,350.0 ns** |  **1.07** |    **0.40** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 10     | AtEnd       |     7,488.0 ns |   1,621.60 ns |     4,781.3 ns |     7,050.0 ns |  0.70 |    0.50 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | 10     | AtEnd       |    10,630.0 ns |   1,268.90 ns |     3,741.4 ns |    10,350.0 ns |  0.99 |    0.45 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | 10     | AtEnd       |     1,987.0 ns |     185.36 ns |       546.6 ns |     1,750.0 ns |  0.19 |    0.07 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 10     | AtEnd       |     1,584.0 ns |     197.27 ns |       581.7 ns |     1,400.0 ns |  0.15 |    0.07 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 10     | AtEnd       |    10,439.0 ns |     803.82 ns |     2,370.1 ns |    10,300.0 ns |  0.97 |    0.34 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | 10     | AtEnd       |     1,577.0 ns |     175.86 ns |       518.5 ns |     1,350.0 ns |  0.15 |    0.06 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 10     | AtEnd       |     9,418.0 ns |     987.52 ns |     2,911.7 ns |     9,300.0 ns |  0.88 |    0.36 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | 10     | AtEnd       |     1,712.0 ns |     189.49 ns |       558.7 ns |     1,500.0 ns |  0.16 |    0.07 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **AtBeginning** | **5,039,765.0 ns** | **421,777.02 ns** | **1,243,619.1 ns** | **4,913,100.0 ns** |  **1.06** |    **0.36** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | AtBeginning |   599,097.0 ns |  82,045.52 ns |   241,913.1 ns |   544,100.0 ns |  0.13 |    0.06 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | 100000 | AtBeginning | 5,177,554.0 ns | 478,189.89 ns | 1,409,953.8 ns | 4,905,450.0 ns |  1.09 |    0.39 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | 100000 | AtBeginning |   403,230.0 ns |  38,141.10 ns |   112,459.9 ns |   373,100.0 ns |  0.08 |    0.03 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | AtBeginning |   363,086.0 ns |  27,746.11 ns |    81,810.1 ns |   346,000.0 ns |  0.08 |    0.02 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 100000 | AtBeginning | 4,737,039.0 ns | 506,356.67 ns | 1,493,004.2 ns | 4,078,450.0 ns |  0.99 |    0.39 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | AtBeginning |   366,060.0 ns |  29,355.81 ns |    86,556.3 ns |   356,350.0 ns |  0.08 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 100000 | AtBeginning | 4,630,783.0 ns | 478,083.91 ns | 1,409,641.3 ns | 4,072,600.0 ns |  0.97 |    0.38 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | AtBeginning |   361,775.0 ns |  40,621.22 ns |   119,772.6 ns |   343,650.0 ns |  0.08 |    0.03 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **InMiddle**    | **5,087,951.0 ns** | **434,777.44 ns** | **1,281,951.2 ns** | **4,898,200.0 ns** |  **1.06** |    **0.37** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | InMiddle    | 4,655,157.0 ns | 214,212.86 ns |   631,611.5 ns | 4,529,650.0 ns |  0.97 |    0.26 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | 100000 | InMiddle    | 5,161,814.0 ns | 402,298.06 ns | 1,186,185.0 ns | 4,923,550.0 ns |  1.08 |    0.35 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | 100000 | InMiddle    | 5,058,992.0 ns | 231,696.48 ns |   683,162.4 ns | 4,877,100.0 ns |  1.05 |    0.28 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | InMiddle    | 4,275,982.9 ns |  85,490.42 ns |   217,600.4 ns | 4,242,850.0 ns |  0.89 |    0.21 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 100000 | InMiddle    | 4,810,472.0 ns | 409,510.69 ns | 1,207,451.6 ns | 4,215,200.0 ns |  1.00 |    0.35 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | InMiddle    | 4,416,761.0 ns | 296,442.45 ns |   874,067.3 ns | 4,250,050.0 ns |  0.92 |    0.28 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 100000 | InMiddle    | 4,626,423.0 ns | 434,360.04 ns | 1,280,720.5 ns | 4,106,900.0 ns |  0.96 |    0.35 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | InMiddle    | 4,215,672.0 ns |  83,883.69 ns |   222,447.7 ns | 4,217,400.0 ns |  0.88 |    0.21 |         - |        0.00 |
|                                     |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **100000** | **AtEnd**       | **5,152,103.0 ns** | **511,039.27 ns** | **1,506,810.9 ns** | **4,923,550.0 ns** |  **1.07** |    **0.41** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | 100000 | AtEnd       | 4,768,870.0 ns | 213,212.15 ns |   628,660.9 ns | 4,670,950.0 ns |  0.99 |    0.27 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | 100000 | AtEnd       | 5,149,042.0 ns | 428,100.93 ns | 1,262,265.3 ns | 4,928,100.0 ns |  1.07 |    0.37 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | 100000 | AtEnd       | 5,125,169.0 ns | 206,507.41 ns |   608,891.8 ns | 4,865,700.0 ns |  1.06 |    0.29 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | 100000 | AtEnd       | 4,239,013.6 ns |  84,668.49 ns |   223,050.7 ns | 4,200,900.0 ns |  0.88 |    0.22 |         - |        0.00 |
| ArrayIntersectAnyLinq               | 100000 | AtEnd       | 4,699,212.0 ns | 406,978.08 ns | 1,199,984.1 ns | 4,111,900.0 ns |  0.98 |    0.35 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | 100000 | AtEnd       | 4,285,647.4 ns |  85,247.81 ns |   247,319.4 ns | 4,260,100.0 ns |  0.89 |    0.22 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | 100000 | AtEnd       | 4,627,937.0 ns | 462,179.84 ns | 1,362,747.8 ns | 4,111,600.0 ns |  0.96 |    0.37 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | 100000 | AtEnd       | 4,296,482.7 ns |  85,855.17 ns |   216,967.0 ns | 4,269,000.0 ns |  0.89 |    0.22 |         - |        0.00 |
