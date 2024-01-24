## FileStream vs. RandomAccess for reading random portions of a file.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                        Method |      Count |      Mean |    Error |   StdDev | Ratio |
|---------------------------------------------- |----------- |----------:|---------:|---------:|------:|
|         **HashFileLocationsUsingFileStreamCrc32** |    **3145728** | **159.60 ms** | **0.153 ms** | **0.143 ms** |  **1.00** |
|       HashFileLocationsUsingRandomAccessCrc32 |    3145728 | 162.54 ms | 0.742 ms | 0.694 ms |  1.02 |
|    HashFileLocationsUsingFileStreamMurmurHash |    3145728 |  25.96 ms | 0.065 ms | 0.061 ms |  0.16 |
|  HashFileLocationsUsingRandomAccessMurmurHash |    3145728 |  27.74 ms | 0.082 ms | 0.076 ms |  0.17 |
|   HashFileLocationsUsingFileStreamJenkinsHash |    3145728 | 100.76 ms | 0.147 ms | 0.123 ms |  0.63 |
| HashFileLocationsUsingRandomAccessJenkinsHash |    3145728 | 103.13 ms | 0.118 ms | 0.099 ms |  0.65 |
|                                               |            |           |          |          |       |
|         **HashFileLocationsUsingFileStreamCrc32** | **1073741824** | **160.79 ms** | **0.263 ms** | **0.205 ms** |  **1.00** |
|       HashFileLocationsUsingRandomAccessCrc32 | 1073741824 | 162.75 ms | 0.184 ms | 0.154 ms |  1.01 |
|    HashFileLocationsUsingFileStreamMurmurHash | 1073741824 |  27.18 ms | 0.079 ms | 0.074 ms |  0.17 |
|  HashFileLocationsUsingRandomAccessMurmurHash | 1073741824 |  29.44 ms | 0.502 ms | 0.598 ms |  0.18 |
|   HashFileLocationsUsingFileStreamJenkinsHash | 1073741824 | 102.19 ms | 0.170 ms | 0.159 ms |  0.64 |
| HashFileLocationsUsingRandomAccessJenkinsHash | 1073741824 | 104.12 ms | 0.221 ms | 0.207 ms |  0.65 |
