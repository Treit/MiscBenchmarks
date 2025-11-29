# IntersectAny





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  InvocationCount=1  MemoryRandomization=True  
UnrollFactor=1  

```
| Method                              | Job       | Runtime   | Count  | Location    | Mean           | Error         | StdDev         | Median         | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------ |---------- |---------- |------- |------------ |---------------:|--------------:|---------------:|---------------:|------:|--------:|----------:|------------:|
| **ListIntersectAnyLinq**                | **.NET 10.0** | **.NET 10.0** | **10**     | **AtBeginning** |     **6,917.0 ns** |     **550.03 ns** |     **1,621.8 ns** |     **6,500.0 ns** |  **1.03** |    **0.29** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | .NET 10.0 | .NET 10.0 | 10     | AtBeginning |     2,754.0 ns |     273.39 ns |       806.1 ns |     2,500.0 ns |  0.41 |    0.14 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | .NET 10.0 | .NET 10.0 | 10     | AtBeginning |     5,785.0 ns |     851.07 ns |     2,509.4 ns |     5,300.0 ns |  0.86 |    0.40 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | .NET 10.0 | .NET 10.0 | 10     | AtBeginning |       871.0 ns |      66.50 ns |       196.1 ns |       800.0 ns |  0.13 |    0.04 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 10.0 | .NET 10.0 | 10     | AtBeginning |       836.0 ns |     156.83 ns |       462.4 ns |       800.0 ns |  0.12 |    0.07 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 10.0 | .NET 10.0 | 10     | AtBeginning |     7,120.0 ns |     396.13 ns |     1,168.0 ns |     6,950.0 ns |  1.06 |    0.24 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 10.0 | .NET 10.0 | 10     | AtBeginning |       676.0 ns |      62.69 ns |       184.8 ns |       600.0 ns |  0.10 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 10.0 | .NET 10.0 | 10     | AtBeginning |     5,184.0 ns |     342.89 ns |     1,011.0 ns |     4,900.0 ns |  0.77 |    0.19 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 10.0 | .NET 10.0 | 10     | AtBeginning |       949.0 ns |      83.42 ns |       246.0 ns |       900.0 ns |  0.14 |    0.04 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| ListIntersectAnyLinq                | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |     8,069.0 ns |   2,512.85 ns |     7,409.2 ns |     6,750.0 ns |  1.13 |    1.07 |     512 B |        1.00 |
| ListIntersectAnyNestedLoopAsArray   | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |     2,626.0 ns |     224.54 ns |       662.0 ns |     2,400.0 ns |  0.37 |    0.12 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |     5,908.0 ns |     745.12 ns |     2,197.0 ns |     5,400.0 ns |  0.83 |    0.35 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |       810.0 ns |      54.32 ns |       160.2 ns |       750.0 ns |  0.11 |    0.03 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |       669.0 ns |      66.57 ns |       196.3 ns |       600.0 ns |  0.09 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |     7,326.0 ns |     666.39 ns |     1,964.9 ns |     6,950.0 ns |  1.03 |    0.34 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |       683.0 ns |      51.93 ns |       153.1 ns |       700.0 ns |  0.10 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |     4,843.0 ns |     289.32 ns |       853.1 ns |     4,600.0 ns |  0.68 |    0.18 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 9.0  | .NET 9.0  | 10     | AtBeginning |       888.0 ns |      61.97 ns |       182.7 ns |       800.0 ns |  0.12 |    0.03 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **.NET 10.0** | **.NET 10.0** | **10**     | **InMiddle**    |     **7,319.0 ns** |     **462.26 ns** |     **1,363.0 ns** |     **6,900.0 ns** |  **1.03** |    **0.24** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | .NET 10.0 | .NET 10.0 | 10     | InMiddle    |     2,731.0 ns |     156.03 ns |       460.1 ns |     2,600.0 ns |  0.38 |    0.08 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | .NET 10.0 | .NET 10.0 | 10     | InMiddle    |     6,233.0 ns |     829.14 ns |     2,444.7 ns |     5,500.0 ns |  0.87 |    0.37 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | .NET 10.0 | .NET 10.0 | 10     | InMiddle    |     1,464.0 ns |     101.63 ns |       299.7 ns |     1,300.0 ns |  0.21 |    0.05 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 10.0 | .NET 10.0 | 10     | InMiddle    |     1,040.0 ns |      96.53 ns |       284.6 ns |       900.0 ns |  0.15 |    0.05 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 10.0 | .NET 10.0 | 10     | InMiddle    |     6,967.0 ns |     478.81 ns |     1,411.8 ns |     6,500.0 ns |  0.98 |    0.24 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 10.0 | .NET 10.0 | 10     | InMiddle    |     1,094.0 ns |      84.44 ns |       249.0 ns |     1,000.0 ns |  0.15 |    0.04 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 10.0 | .NET 10.0 | 10     | InMiddle    |     5,321.0 ns |     396.08 ns |     1,167.9 ns |     5,050.0 ns |  0.75 |    0.20 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 10.0 | .NET 10.0 | 10     | InMiddle    |     1,155.0 ns |      78.82 ns |       232.4 ns |     1,100.0 ns |  0.16 |    0.04 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| ListIntersectAnyLinq                | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |     7,350.0 ns |     500.39 ns |     1,475.4 ns |     6,900.0 ns |  1.03 |    0.27 |     512 B |        1.00 |
| ListIntersectAnyNestedLoopAsArray   | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |     2,829.0 ns |     282.99 ns |       834.4 ns |     2,600.0 ns |  0.40 |    0.14 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |     6,155.0 ns |     736.69 ns |     2,172.2 ns |     5,650.0 ns |  0.87 |    0.34 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |     1,385.0 ns |     111.33 ns |       328.3 ns |     1,300.0 ns |  0.19 |    0.06 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |       983.0 ns |      66.63 ns |       196.5 ns |       950.0 ns |  0.14 |    0.04 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |     6,998.0 ns |     421.70 ns |     1,243.4 ns |     6,600.0 ns |  0.98 |    0.24 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |     1,015.0 ns |      87.35 ns |       257.6 ns |       900.0 ns |  0.14 |    0.04 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |     4,907.0 ns |     343.99 ns |     1,014.3 ns |     4,600.0 ns |  0.69 |    0.18 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 9.0  | .NET 9.0  | 10     | InMiddle    |     1,216.0 ns |      94.06 ns |       277.3 ns |     1,100.0 ns |  0.17 |    0.05 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **.NET 10.0** | **.NET 10.0** | **10**     | **AtEnd**       |     **6,970.0 ns** |     **376.32 ns** |     **1,109.6 ns** |     **6,700.0 ns** |  **1.02** |    **0.20** |     **512 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | .NET 10.0 | .NET 10.0 | 10     | AtEnd       |     3,368.0 ns |     319.79 ns |       942.9 ns |     3,200.0 ns |  0.49 |    0.15 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | .NET 10.0 | .NET 10.0 | 10     | AtEnd       |     5,978.0 ns |     771.28 ns |     2,274.1 ns |     5,400.0 ns |  0.87 |    0.35 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | .NET 10.0 | .NET 10.0 | 10     | AtEnd       |     2,013.0 ns |     175.58 ns |       517.7 ns |     1,800.0 ns |  0.29 |    0.08 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 10.0 | .NET 10.0 | 10     | AtEnd       |     2,277.0 ns |   2,915.74 ns |     8,597.1 ns |     1,150.0 ns |  0.33 |    1.26 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 10.0 | .NET 10.0 | 10     | AtEnd       |     7,258.0 ns |     439.46 ns |     1,295.8 ns |     7,000.0 ns |  1.06 |    0.23 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 10.0 | .NET 10.0 | 10     | AtEnd       |     1,664.0 ns |     174.91 ns |       515.7 ns |     1,400.0 ns |  0.24 |    0.08 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 10.0 | .NET 10.0 | 10     | AtEnd       |     5,287.0 ns |     492.72 ns |     1,452.8 ns |     5,000.0 ns |  0.77 |    0.23 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 10.0 | .NET 10.0 | 10     | AtEnd       |     1,601.0 ns |     168.96 ns |       498.2 ns |     1,400.0 ns |  0.23 |    0.08 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| ListIntersectAnyLinq                | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     8,157.0 ns |     882.66 ns |     2,602.5 ns |     7,400.0 ns |  1.06 |    0.39 |     512 B |        1.00 |
| ListIntersectAnyNestedLoopAsArray   | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     3,453.0 ns |     345.65 ns |     1,019.2 ns |     3,100.0 ns |  0.45 |    0.16 |     208 B |        0.41 |
| ListIntersectAnyWithHashSet         | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     6,026.0 ns |     648.02 ns |     1,910.7 ns |     5,500.0 ns |  0.78 |    0.29 |     376 B |        0.73 |
| ListIntersectAnyNestedLoop          | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     2,067.0 ns |     171.79 ns |       506.5 ns |     1,800.0 ns |  0.27 |    0.08 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     1,564.0 ns |     170.47 ns |       502.6 ns |     1,300.0 ns |  0.20 |    0.08 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     7,738.0 ns |     646.25 ns |     1,905.5 ns |     7,200.0 ns |  1.00 |    0.31 |     496 B |        0.97 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     1,509.0 ns |     171.19 ns |       504.7 ns |     1,300.0 ns |  0.20 |    0.08 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     5,450.0 ns |     324.11 ns |       955.6 ns |     5,200.0 ns |  0.71 |    0.18 |     368 B |        0.72 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 9.0  | .NET 9.0  | 10     | AtEnd       |     1,811.0 ns |     211.05 ns |       622.3 ns |     1,500.0 ns |  0.23 |    0.09 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **.NET 10.0** | **.NET 10.0** | **100000** | **AtBeginning** | **5,064,361.0 ns** | **434,457.40 ns** | **1,281,007.5 ns** | **4,819,300.0 ns** |  **1.06** |    **0.37** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | .NET 10.0 | .NET 10.0 | 100000 | AtBeginning |   548,325.0 ns |  45,983.16 ns |   135,582.4 ns |   513,500.0 ns |  0.11 |    0.04 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | .NET 10.0 | .NET 10.0 | 100000 | AtBeginning | 4,507,983.0 ns | 356,170.86 ns | 1,050,177.9 ns | 4,075,750.0 ns |  0.94 |    0.32 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | .NET 10.0 | .NET 10.0 | 100000 | AtBeginning |   371,005.0 ns |  29,396.19 ns |    86,675.3 ns |   349,100.0 ns |  0.08 |    0.03 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 10.0 | .NET 10.0 | 100000 | AtBeginning |   324,828.0 ns |  28,612.22 ns |    84,363.8 ns |   314,150.0 ns |  0.07 |    0.02 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 10.0 | .NET 10.0 | 100000 | AtBeginning | 4,783,353.0 ns | 420,629.70 ns | 1,240,236.2 ns | 4,092,450.0 ns |  1.00 |    0.35 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 10.0 | .NET 10.0 | 100000 | AtBeginning |   354,267.0 ns |  35,354.30 ns |   104,243.0 ns |   326,600.0 ns |  0.07 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 10.0 | .NET 10.0 | 100000 | AtBeginning | 3,885,824.0 ns | 271,938.18 ns |   801,815.9 ns | 3,791,100.0 ns |  0.81 |    0.26 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 10.0 | .NET 10.0 | 100000 | AtBeginning |   346,630.0 ns |  28,288.11 ns |    83,408.1 ns |   334,550.0 ns |  0.07 |    0.02 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| ListIntersectAnyLinq                | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning | 5,191,591.0 ns | 506,916.09 ns | 1,494,653.6 ns | 4,857,800.0 ns |  1.07 |    0.41 | 2172872 B |        1.00 |
| ListIntersectAnyNestedLoopAsArray   | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning |   551,317.0 ns |  45,611.54 ns |   134,486.7 ns |   519,650.0 ns |  0.11 |    0.04 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning | 4,448,072.0 ns | 344,494.00 ns | 1,015,748.4 ns | 4,045,700.0 ns |  0.92 |    0.31 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning |   387,834.0 ns |  54,400.31 ns |   160,400.5 ns |   358,100.0 ns |  0.08 |    0.04 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning |   334,457.0 ns |  37,597.12 ns |   110,856.0 ns |   315,950.0 ns |  0.07 |    0.03 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning | 4,745,435.0 ns | 407,530.64 ns | 1,201,613.4 ns | 4,080,950.0 ns |  0.98 |    0.35 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning |   349,579.0 ns |  28,422.97 ns |    83,805.8 ns |   334,400.0 ns |  0.07 |    0.02 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning | 4,613,248.0 ns | 437,466.50 ns | 1,289,879.9 ns | 4,077,600.0 ns |  0.95 |    0.36 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 9.0  | .NET 9.0  | 100000 | AtBeginning |   357,843.0 ns |  45,518.44 ns |   134,212.2 ns |   327,900.0 ns |  0.07 |    0.03 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **.NET 10.0** | **.NET 10.0** | **100000** | **InMiddle**    | **5,225,072.0 ns** | **531,031.93 ns** | **1,565,759.7 ns** | **4,896,800.0 ns** |  **1.07** |    **0.42** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | .NET 10.0 | .NET 10.0 | 100000 | InMiddle    | 4,231,678.0 ns | 159,653.49 ns |   470,741.9 ns | 4,134,400.0 ns |  0.87 |    0.24 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | .NET 10.0 | .NET 10.0 | 100000 | InMiddle    | 4,486,057.0 ns | 372,149.07 ns | 1,097,290.0 ns | 4,111,000.0 ns |  0.92 |    0.33 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | .NET 10.0 | .NET 10.0 | 100000 | InMiddle    | 4,758,211.0 ns | 270,141.30 ns |   796,517.8 ns | 4,547,000.0 ns |  0.98 |    0.30 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 10.0 | .NET 10.0 | 100000 | InMiddle    | 4,073,607.0 ns | 288,612.09 ns |   850,979.3 ns | 3,951,800.0 ns |  0.84 |    0.27 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 10.0 | .NET 10.0 | 100000 | InMiddle    | 4,934,380.0 ns | 534,610.23 ns | 1,576,310.4 ns | 4,195,750.0 ns |  1.01 |    0.42 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 10.0 | .NET 10.0 | 100000 | InMiddle    | 4,481,944.0 ns | 177,610.80 ns |   523,689.5 ns | 4,403,550.0 ns |  0.92 |    0.25 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 10.0 | .NET 10.0 | 100000 | InMiddle    | 5,037,042.0 ns | 578,369.67 ns | 1,705,336.2 ns | 4,203,600.0 ns |  1.04 |    0.44 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 10.0 | .NET 10.0 | 100000 | InMiddle    | 4,225,831.0 ns | 393,818.58 ns | 1,161,183.1 ns | 3,951,600.0 ns |  0.87 |    0.33 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| ListIntersectAnyLinq                | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 5,280,766.0 ns | 513,436.95 ns | 1,513,880.5 ns | 4,914,700.0 ns |  1.08 |    0.42 | 2172872 B |        1.00 |
| ListIntersectAnyNestedLoopAsArray   | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 4,841,403.0 ns | 124,552.55 ns |   367,246.0 ns | 4,781,850.0 ns |  0.99 |    0.27 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 5,303,924.0 ns | 616,107.74 ns | 1,816,607.7 ns | 4,875,850.0 ns |  1.08 |    0.47 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 4,619,673.0 ns | 117,582.37 ns |   346,694.3 ns | 4,534,550.0 ns |  0.94 |    0.25 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 3,785,636.0 ns | 253,107.68 ns |   746,293.8 ns | 3,638,650.0 ns |  0.77 |    0.25 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 4,752,808.0 ns | 472,907.68 ns | 1,394,379.1 ns | 4,045,450.0 ns |  0.97 |    0.38 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 4,329,351.0 ns | 184,587.38 ns |   544,260.1 ns | 4,233,100.0 ns |  0.88 |    0.25 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 4,627,349.0 ns | 458,032.90 ns | 1,350,520.4 ns | 4,061,000.0 ns |  0.94 |    0.37 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 9.0  | .NET 9.0  | 100000 | InMiddle    | 3,954,057.0 ns | 121,517.29 ns |   358,296.5 ns | 3,923,600.0 ns |  0.81 |    0.22 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| **ListIntersectAnyLinq**                | **.NET 10.0** | **.NET 10.0** | **100000** | **AtEnd**       | **5,169,810.0 ns** | **527,172.72 ns** | **1,554,380.8 ns** | **4,928,700.0 ns** |  **1.07** |    **0.42** | **2172872 B** |        **1.00** |
| ListIntersectAnyNestedLoopAsArray   | .NET 10.0 | .NET 10.0 | 100000 | AtEnd       | 4,571,931.0 ns | 275,681.76 ns |   812,854.0 ns | 4,399,200.0 ns |  0.95 |    0.29 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | .NET 10.0 | .NET 10.0 | 100000 | AtEnd       | 5,111,872.0 ns | 417,822.31 ns | 1,231,958.6 ns | 4,871,350.0 ns |  1.06 |    0.36 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | .NET 10.0 | .NET 10.0 | 100000 | AtEnd       | 4,660,777.0 ns | 250,455.49 ns |   738,473.7 ns | 4,527,850.0 ns |  0.97 |    0.28 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 10.0 | .NET 10.0 | 100000 | AtEnd       | 3,968,087.0 ns | 186,345.35 ns |   549,443.5 ns | 3,953,350.0 ns |  0.82 |    0.23 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 10.0 | .NET 10.0 | 100000 | AtEnd       | 4,761,275.0 ns | 424,719.57 ns | 1,252,295.3 ns | 4,113,700.0 ns |  0.99 |    0.36 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 10.0 | .NET 10.0 | 100000 | AtEnd       | 4,221,787.0 ns | 108,649.67 ns |   320,356.0 ns | 4,164,200.0 ns |  0.87 |    0.22 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 10.0 | .NET 10.0 | 100000 | AtEnd       | 3,936,183.0 ns | 280,329.16 ns |   826,556.9 ns | 3,814,450.0 ns |  0.82 |    0.26 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 10.0 | .NET 10.0 | 100000 | AtEnd       | 3,990,473.0 ns | 129,051.68 ns |   380,511.8 ns | 3,987,000.0 ns |  0.83 |    0.21 |         - |        0.00 |
|                                     |           |           |        |             |                |               |                |                |       |         |           |             |
| ListIntersectAnyLinq                | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 5,057,715.0 ns | 430,503.41 ns | 1,269,349.1 ns | 4,823,950.0 ns |  1.06 |    0.37 | 2172872 B |        1.00 |
| ListIntersectAnyNestedLoopAsArray   | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 4,388,005.0 ns | 102,034.33 ns |   300,850.6 ns | 4,328,400.0 ns |  0.92 |    0.22 | 1600048 B |        0.74 |
| ListIntersectAnyWithHashSet         | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 4,402,285.0 ns | 277,912.57 ns |   819,431.5 ns | 4,069,700.0 ns |  0.92 |    0.28 | 2172776 B |        1.00 |
| ListIntersectAnyNestedLoop          | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 4,582,445.0 ns | 112,319.62 ns |   331,177.0 ns | 4,529,350.0 ns |  0.96 |    0.24 |         - |        0.00 |
| ListIntersectAnyNestedLoopWithSpan  | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 3,972,596.0 ns | 105,142.09 ns |   310,013.8 ns | 3,991,150.0 ns |  0.83 |    0.21 |         - |        0.00 |
| ArrayIntersectAnyLinq               | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 4,716,782.0 ns | 404,253.41 ns | 1,191,950.4 ns | 4,069,300.0 ns |  0.99 |    0.34 | 2172864 B |        1.00 |
| ArrayIntersectAnyNestedLoopAsArray  | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 4,312,651.0 ns | 271,799.77 ns |   801,407.8 ns | 4,215,450.0 ns |  0.90 |    0.27 |         - |        0.00 |
| ArrayIntersectAnyWithHashSet        | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 3,942,317.0 ns | 289,338.85 ns |   853,122.2 ns | 3,799,250.0 ns |  0.83 |    0.27 | 2172736 B |        1.00 |
| ArrayIntersectAnyNestedLoopWithSpan | .NET 9.0  | .NET 9.0  | 100000 | AtEnd       | 4,169,802.0 ns | 183,741.43 ns |   541,765.8 ns | 4,102,350.0 ns |  0.87 |    0.24 |         - |        0.00 |
