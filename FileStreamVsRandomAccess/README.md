## FileStream vs. RandomAccess for reading random portions of a file.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Count      | Mean      | Error    | StdDev   | Ratio |
|---------------------------------------------- |----------- |----------:|---------:|---------:|------:|
| **HashFileLocationsUsingFileStreamCrc32**         | **3145728**    | **160.32 ms** | **0.844 ms** | **0.789 ms** |  **1.00** |
| HashFileLocationsUsingRandomAccessCrc32       | 3145728    | 162.82 ms | 0.942 ms | 0.835 ms |  1.02 |
| HashFileLocationsUsingFileStreamMurmurHash    | 3145728    |  27.64 ms | 0.153 ms | 0.128 ms |  0.17 |
| HashFileLocationsUsingRandomAccessMurmurHash  | 3145728    |  29.98 ms | 0.140 ms | 0.124 ms |  0.19 |
| HashFileLocationsUsingFileStreamJenkinsHash   | 3145728    | 101.70 ms | 0.773 ms | 0.723 ms |  0.63 |
| HashFileLocationsUsingRandomAccessJenkinsHash | 3145728    | 104.46 ms | 0.853 ms | 0.798 ms |  0.65 |
|                                               |            |           |          |          |       |
| **HashFileLocationsUsingFileStreamCrc32**         | **1073741824** | **161.48 ms** | **0.778 ms** | **0.728 ms** |  **1.00** |
| HashFileLocationsUsingRandomAccessCrc32       | 1073741824 | 163.24 ms | 1.101 ms | 1.030 ms |  1.01 |
| HashFileLocationsUsingFileStreamMurmurHash    | 1073741824 |  28.62 ms | 0.085 ms | 0.075 ms |  0.18 |
| HashFileLocationsUsingRandomAccessMurmurHash  | 1073741824 |  30.29 ms | 0.224 ms | 0.199 ms |  0.19 |
| HashFileLocationsUsingFileStreamJenkinsHash   | 1073741824 | 102.50 ms | 0.500 ms | 0.468 ms |  0.63 |
| HashFileLocationsUsingRandomAccessJenkinsHash | 1073741824 | 104.26 ms | 0.640 ms | 0.598 ms |  0.65 |
