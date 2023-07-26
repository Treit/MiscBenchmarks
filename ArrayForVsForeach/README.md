# Counting strings using a for loop vs. a foreach loop.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|           Method |  Count |         Mean |       Error |      StdDev |       Median | Ratio | RatioSD | Code Size | Allocated | Alloc Ratio |
|----------------- |------- |-------------:|------------:|------------:|-------------:|------:|--------:|----------:|----------:|------------:|
|     **ForLoopCount** |    **100** |     **110.6 ns** |     **4.25 ns** |    **12.05 ns** |     **105.7 ns** |  **1.20** |    **0.09** |      **62 B** |         **-** |          **NA** |
| ForEachLoopCount |    100 |     102.9 ns |     1.65 ns |     1.47 ns |     102.6 ns |  1.00 |    0.00 |         - |         - |          NA |
|                  |        |              |             |             |              |       |         |           |           |             |
|     **ForLoopCount** | **100000** | **129,425.6 ns** | **2,573.47 ns** | **6,913.47 ns** | **129,554.3 ns** |  **1.03** |    **0.08** |      **62 B** |         **-** |          **NA** |
| ForEachLoopCount | 100000 | 126,201.3 ns | 2,522.44 ns | 6,420.41 ns | 127,334.1 ns |  1.00 |    0.00 |         - |         - |          NA |


## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCount()
;             int count = 0;
;             ^^^^^^^^^^^^^^
;             for (int i = 0; i < _strings.Length; i++)
;                  ^^^^^^^^^
;                 if (_strings[i].Length == 0)
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;                     count++;
;                     ^^^^^^^^
;             return count;
;             ^^^^^^^^^^^^^
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
M00_L00:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L03
       mov       r9d,edx
       mov       r8,[r8+r9*8+10]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       inc       eax
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 62
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCount()
;             int count = 0;
;             ^^^^^^^^^^^^^^
;             for (int i = 0; i < _strings.Length; i++)
;                  ^^^^^^^^^
;                 if (_strings[i].Length == 0)
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;                     count++;
;                     ^^^^^^^^
;             return count;
;             ^^^^^^^^^^^^^
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
M00_L00:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L03
       mov       r9d,edx
       mov       r8,[r8+r9*8+10]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       inc       eax
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 62
```

