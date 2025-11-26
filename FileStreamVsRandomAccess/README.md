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
| **HashFileLocationsUsingFileStreamCrc32**         | **3145728**    | **160.41 ms** | **0.768 ms** | **0.719 ms** |  **1.00** |
| HashFileLocationsUsingRandomAccessCrc32       | 3145728    | 163.19 ms | 0.716 ms | 0.670 ms |  1.02 |
| HashFileLocationsUsingFileStreamMurmurHash    | 3145728    |  27.59 ms | 0.125 ms | 0.117 ms |  0.17 |
| HashFileLocationsUsingRandomAccessMurmurHash  | 3145728    |  30.20 ms | 0.155 ms | 0.138 ms |  0.19 |
| HashFileLocationsUsingFileStreamJenkinsHash   | 3145728    | 101.61 ms | 0.756 ms | 0.707 ms |  0.63 |
| HashFileLocationsUsingRandomAccessJenkinsHash | 3145728    | 104.07 ms | 0.797 ms | 0.746 ms |  0.65 |
|                                               |            |           |          |          |       |
| **HashFileLocationsUsingFileStreamCrc32**         | **1073741824** | **161.63 ms** | **0.806 ms** | **0.754 ms** |  **1.00** |
| HashFileLocationsUsingRandomAccessCrc32       | 1073741824 | 163.69 ms | 0.962 ms | 0.852 ms |  1.01 |
| HashFileLocationsUsingFileStreamMurmurHash    | 1073741824 |  29.00 ms | 0.207 ms | 0.194 ms |  0.18 |
| HashFileLocationsUsingRandomAccessMurmurHash  | 1073741824 |  30.83 ms | 0.171 ms | 0.143 ms |  0.19 |
| HashFileLocationsUsingFileStreamJenkinsHash   | 1073741824 | 103.27 ms | 0.724 ms | 0.677 ms |  0.64 |
| HashFileLocationsUsingRandomAccessJenkinsHash | 1073741824 | 105.13 ms | 0.811 ms | 0.759 ms |  0.65 |
