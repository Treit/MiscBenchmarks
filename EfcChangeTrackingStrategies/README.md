# Small DBO

## Benchmark with 502 Properties DBO

``` ini
BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22621.2506)
AMD Ryzen 7 5800X3D, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
  Job-KAVUZH : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
```


|              Method | ChangeTrackingStrategy |         Mean |      Error |     StdDev |
|-------------------- |----------------------- |-------------:|-----------:|-----------:|
|             Add_500 |               Snapshot | 1,425.693 ms | 14.3113 ms | 13.3868 ms |
|             Add_500 |   ChangedNotifications | 1,395.192 ms | 11.5371 ms | 10.7918 ms |
|             Add_500 |   ChangingAndChangedNotifications | 1,349.691 ms |  9.6848 ms |  9.0592 ms |
|             Add_500 |   ChangingAndChangedNotificationsWithOriginalValues | 1,399.471 ms |  9.6454 ms |  8.5504 ms |
| | | | | |
|             Add_One |               Snapshot |     3.774 ms |  0.0748 ms |  0.0998 ms |
|             Add_One |   ChangedNotifications |     3.743 ms |  0.0746 ms |  0.1184 ms |
|             Add_One |   ChangingAndChangedNotifications |     3.575 ms |  0.0359 ms |  0.0318 ms |
|             Add_One |   ChangingAndChangedNotificationsWithOriginalValues |     3.790 ms |  0.0753 ms |  0.1080 ms |
| | | | | |
|          Update_All |               Snapshot |   144.146 ms |  1.5040 ms |  1.3333 ms |
|          Update_All |   ChangedNotifications |    92.255 ms |  0.8700 ms |  0.7265 ms |
|          Update_All |   ChangingAndChangedNotifications |    46.085 ms |  0.5827 ms |  0.5165 ms |
|          Update_All |   ChangingAndChangedNotificationsWithOriginalValues |    46.927 ms |  0.6423 ms |  0.5694 ms |
| | | | | |
| Update_Quarter_Init |               Snapshot |   142.603 ms |  0.8525 ms |  0.7975 ms |
| Update_Quarter_Init |   ChangedNotifications |    92.323 ms |  1.1483 ms |  1.0179 ms |
| Update_Quarter_Init |   ChangingAndChangedNotifications |    46.200 ms |  0.6689 ms |  0.5929 ms |
| Update_Quarter_Init |   ChangingAndChangedNotificationsWithOriginalValues |    46.933 ms |  0.9000 ms |  1.0365 ms |

---

# Small DBO

## Benchmark with 3 Properties DBO

``` ini
BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22621.2506)
AMD Ryzen 7 5800X3D, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
  Job-KAVUZH : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
```


|              Method | ChangeTrackingStrategy |       Mean |      Error |     StdDev |     Median |
|-------------------- |----------------------- |-----------:|-----------:|-----------:|-----------:|
|             Add_500 |               Snapshot |  15.222 ms |  0.3017 ms |  0.4028 ms |  15.154 ms |
|             Add_500 |   ChangedNotifications |  15.150 ms |  0.3027 ms |  0.2973 ms |  15.126 ms |
|             Add_500 |   ChangingAndChangedNotifications |  15.364 ms |  0.3034 ms |  0.5548 ms |  15.154 ms |
|             Add_500 |   ChangingAndChangedNotificationsWithOriginalValues |  14.934 ms |  0.2019 ms |  0.1790 ms |  14.921 ms |
| | | | | |
|             Add_One |               Snapshot |   1.110 ms |  0.0213 ms |  0.0498 ms |   1.094 ms |
|             Add_One |   ChangedNotifications |   1.118 ms |  0.0329 ms |  0.0960 ms |   1.064 ms |
|             Add_One |   ChangingAndChangedNotifications |   1.054 ms |  0.0196 ms |  0.0354 ms |   1.050 ms |
|             Add_One |   ChangingAndChangedNotificationsWithOriginalValues |   1.033 ms |  0.0206 ms |  0.0202 ms |   1.030 ms |
| | | | | |
|          Update_All |               Snapshot | 684.286 ms | 11.7951 ms | 11.0331 ms | 679.281 ms |
|          Update_All |   ChangedNotifications | 599.957 ms |  8.2997 ms |  7.7635 ms | 600.404 ms |
|          Update_All |   ChangingAndChangedNotifications | 573.341 ms |  8.2749 ms |  7.3355 ms | 571.475 ms |
|          Update_All |   ChangingAndChangedNotificationsWithOriginalValues | 575.693 ms |  2.9184 ms |  2.4370 ms | 575.990 ms |
| | | | | |
| Update_Quarter_Init |               Snapshot | 717.805 ms | 12.6788 ms | 11.2394 ms | 719.733 ms |
| Update_Quarter_Init |   ChangedNotifications | 575.933 ms |  6.2576 ms |  5.8533 ms | 574.887 ms |
| Update_Quarter_Init |   ChangingAndChangedNotifications | 543.376 ms |  3.0684 ms |  2.8702 ms | 542.503 ms |
| Update_Quarter_Init |   ChangingAndChangedNotificationsWithOriginalValues | 546.123 ms |  4.6848 ms |  4.3822 ms | 544.370 ms |