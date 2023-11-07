# Big DBO

## Benchmark with 502 Properties DBO (1/2 int, 1/2 string)

``` ini
BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19045.3570)
12th Gen Intel Core i7-1255U, 1 CPU, 12 logical and 10 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
  Job-XLOGWS : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
```

|              Method | ChangeTrackingStrategy |         Mean |      Error |     StdDev |
|-------------------- |----------------------- |-------------:|-----------:|-----------:|
|             Add_500 |               Snapshot | 1,040.358 ms | 18.2853 ms | 15.2691 ms |
|             Add_500 |   ChangedNotifications |   994.598 ms | 15.4188 ms | 12.8754 ms |
|             Add_500 |   ChangingAndChangedNotifications |   973.407 ms |  7.4765 ms |  6.2432 ms |
|             Add_500 |   ChangingAndChangedNotificationsWithOriginalValues | 1,009.971 ms | 18.2202 ms | 15.2147 ms |
| | | | | |
|             Add_One |               Snapshot |     3.684 ms |  0.0712 ms |  0.1592 ms |
|             Add_One |   ChangedNotifications |     3.577 ms |  0.0710 ms |  0.2037 ms |
|             Add_One |   ChangingAndChangedNotifications |     3.460 ms |  0.0685 ms |  0.1628 ms |
|             Add_One |   ChangingAndChangedNotificationsWithOriginalValues |     3.616 ms |  0.0717 ms |  0.1986 ms |
| | | | | |
|          Update_All |               Snapshot |   126.632 ms |  1.9461 ms |  1.8204 ms |
|          Update_All |   ChangedNotifications |    69.876 ms |  1.3267 ms |  1.9447 ms |
|          Update_All |   ChangingAndChangedNotifications |    55.474 ms |  1.0826 ms |  1.3691 ms |
|          Update_All |   ChangingAndChangedNotificationsWithOriginalValues |    56.346 ms |  0.9987 ms |  1.0686 ms |
| | | | | |
| Update_Quarter_Init |               Snapshot |   128.518 ms |  2.5677 ms |  3.1534 ms |
| Update_Quarter_Init |   ChangedNotifications |    70.205 ms |  1.0912 ms |  1.1206 ms |
| Update_Quarter_Init |   ChangingAndChangedNotifications |    55.577 ms |  0.9314 ms |  0.8257 ms |
| Update_Quarter_Init |   ChangingAndChangedNotificationsWithOriginalValues |    54.799 ms |  0.9521 ms |  0.8906 ms |


---

# Small DBO

## Benchmark with 3 Properties DBO

``` ini
BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19045.3570)
12th Gen Intel Core i7-1255U, 1 CPU, 12 logical and 10 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
  Job-HMQITW : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
```

|              Method | ChangeTrackingStrategy |       Mean |      Error |     StdDev |     Median |
|-------------------- |----------------------- |-----------:|-----------:|-----------:|-----------:|
|             Add_500 |               Snapshot |   8.544 ms |  0.1931 ms |  0.5693 ms |   8.500 ms |
|             Add_500 |   ChangedNotifications |   8.408 ms |  0.1598 ms |  0.3117 ms |   8.381 ms |
|             Add_500 |   ChangingAndChangedNotifications |   7.486 ms |  0.1640 ms |  0.4758 ms |   7.253 ms |
|             Add_500 |   ChangingAndChangedNotificationsWithOriginalValues |   7.419 ms |  0.1365 ms |  0.2908 ms |   7.354 ms |
| | | | | |
|             Add_One |               Snapshot |   1.321 ms |  0.0466 ms |  0.1359 ms |   1.337 ms |
|             Add_One |   ChangedNotifications |   1.196 ms |  0.0414 ms |  0.1207 ms |   1.173 ms |
|             Add_One |   ChangingAndChangedNotifications |   1.154 ms |  0.0406 ms |  0.1165 ms |   1.135 ms |
|             Add_One |   ChangingAndChangedNotificationsWithOriginalValues |   1.179 ms |  0.0396 ms |  0.1148 ms |   1.164 ms |
| | | | | |
|          Update_All |               Snapshot | 631.568 ms | 12.0559 ms | 16.0942 ms | 627.689 ms |
|          Update_All |   ChangedNotifications | 609.746 ms | 11.3041 ms | 19.1952 ms | 604.924 ms |
|          Update_All |   ChangingAndChangedNotifications | 541.926 ms |  4.9950 ms |  4.4280 ms | 540.161 ms |
|          Update_All |   ChangingAndChangedNotificationsWithOriginalValues | 581.040 ms | 11.4865 ms | 20.1176 ms | 576.844 ms |
| | | | | |
| Update_Quarter_Init |               Snapshot | 646.169 ms | 12.1462 ms | 12.9963 ms | 648.254 ms |
| Update_Quarter_Init |   ChangedNotifications | 557.612 ms | 11.0603 ms | 22.3424 ms | 550.617 ms |
| Update_Quarter_Init |   ChangingAndChangedNotifications | 515.369 ms | 10.2457 ms | 16.5450 ms | 508.943 ms |
| Update_Quarter_Init |   ChangingAndChangedNotificationsWithOriginalValues | 517.236 ms |  6.2605 ms |  6.1487 ms | 518.485 ms |