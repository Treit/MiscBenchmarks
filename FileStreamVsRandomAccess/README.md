## FileStream vs. RandomAccess for reading random portions of a file.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Job       | Runtime   | Count      | Mean      | Error    | StdDev   | Ratio |
|---------------------------------------------- |---------- |---------- |----------- |----------:|---------:|---------:|------:|
| **HashFileLocationsUsingFileStreamCrc32**         | **.NET 10.0** | **.NET 10.0** | **3145728**    | **159.55 ms** | **0.207 ms** | **0.184 ms** |  **1.00** |
| HashFileLocationsUsingRandomAccessCrc32       | .NET 10.0 | .NET 10.0 | 3145728    | 162.03 ms | 0.236 ms | 0.184 ms |  1.02 |
| HashFileLocationsUsingFileStreamMurmurHash    | .NET 10.0 | .NET 10.0 | 3145728    |  27.42 ms | 0.059 ms | 0.050 ms |  0.17 |
| HashFileLocationsUsingRandomAccessMurmurHash  | .NET 10.0 | .NET 10.0 | 3145728    |  29.89 ms | 0.096 ms | 0.085 ms |  0.19 |
| HashFileLocationsUsingFileStreamJenkinsHash   | .NET 10.0 | .NET 10.0 | 3145728    | 101.00 ms | 0.237 ms | 0.198 ms |  0.63 |
| HashFileLocationsUsingRandomAccessJenkinsHash | .NET 10.0 | .NET 10.0 | 3145728    | 103.97 ms | 0.329 ms | 0.307 ms |  0.65 |
|                                               |           |           |            |           |          |          |       |
| HashFileLocationsUsingFileStreamCrc32         | .NET 9.0  | .NET 9.0  | 3145728    | 159.87 ms | 0.212 ms | 0.177 ms |  1.00 |
| HashFileLocationsUsingRandomAccessCrc32       | .NET 9.0  | .NET 9.0  | 3145728    | 162.70 ms | 0.205 ms | 0.160 ms |  1.02 |
| HashFileLocationsUsingFileStreamMurmurHash    | .NET 9.0  | .NET 9.0  | 3145728    |  27.45 ms | 0.088 ms | 0.073 ms |  0.17 |
| HashFileLocationsUsingRandomAccessMurmurHash  | .NET 9.0  | .NET 9.0  | 3145728    |  29.83 ms | 0.373 ms | 0.312 ms |  0.19 |
| HashFileLocationsUsingFileStreamJenkinsHash   | .NET 9.0  | .NET 9.0  | 3145728    | 101.01 ms | 0.215 ms | 0.180 ms |  0.63 |
| HashFileLocationsUsingRandomAccessJenkinsHash | .NET 9.0  | .NET 9.0  | 3145728    | 103.63 ms | 0.220 ms | 0.184 ms |  0.65 |
|                                               |           |           |            |           |          |          |       |
| **HashFileLocationsUsingFileStreamCrc32**         | **.NET 10.0** | **.NET 10.0** | **1073741824** | **160.88 ms** | **0.382 ms** | **0.357 ms** |  **1.00** |
| HashFileLocationsUsingRandomAccessCrc32       | .NET 10.0 | .NET 10.0 | 1073741824 | 162.67 ms | 0.270 ms | 0.225 ms |  1.01 |
| HashFileLocationsUsingFileStreamMurmurHash    | .NET 10.0 | .NET 10.0 | 1073741824 |  28.74 ms | 0.080 ms | 0.071 ms |  0.18 |
| HashFileLocationsUsingRandomAccessMurmurHash  | .NET 10.0 | .NET 10.0 | 1073741824 |  30.59 ms | 0.410 ms | 0.364 ms |  0.19 |
| HashFileLocationsUsingFileStreamJenkinsHash   | .NET 10.0 | .NET 10.0 | 1073741824 | 102.05 ms | 0.156 ms | 0.138 ms |  0.63 |
| HashFileLocationsUsingRandomAccessJenkinsHash | .NET 10.0 | .NET 10.0 | 1073741824 | 104.33 ms | 0.556 ms | 0.521 ms |  0.65 |
|                                               |           |           |            |           |          |          |       |
| HashFileLocationsUsingFileStreamCrc32         | .NET 9.0  | .NET 9.0  | 1073741824 | 160.78 ms | 0.287 ms | 0.254 ms |  1.00 |
| HashFileLocationsUsingRandomAccessCrc32       | .NET 9.0  | .NET 9.0  | 1073741824 | 162.85 ms | 0.321 ms | 0.300 ms |  1.01 |
| HashFileLocationsUsingFileStreamMurmurHash    | .NET 9.0  | .NET 9.0  | 1073741824 |  28.60 ms | 0.076 ms | 0.067 ms |  0.18 |
| HashFileLocationsUsingRandomAccessMurmurHash  | .NET 9.0  | .NET 9.0  | 1073741824 |  30.43 ms | 0.229 ms | 0.178 ms |  0.19 |
| HashFileLocationsUsingFileStreamJenkinsHash   | .NET 9.0  | .NET 9.0  | 1073741824 | 102.40 ms | 0.204 ms | 0.181 ms |  0.64 |
| HashFileLocationsUsingRandomAccessJenkinsHash | .NET 9.0  | .NET 9.0  | 1073741824 | 104.08 ms | 0.328 ms | 0.291 ms |  0.65 |
