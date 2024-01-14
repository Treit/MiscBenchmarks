# Counting strings using a for loop vs. a foreach loop.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|           Method |  Count |          Mean |         Error |        StdDev | Code Size |
|----------------- |------- |--------------:|--------------:|--------------:|----------:|
|     **ForLoopCount** |     **10** |      **7.665 ns** |     **0.0225 ns** |     **0.0188 ns** |      **78 B** |
| ForEachLoopCount |     10 |      4.388 ns |     0.0279 ns |     0.0248 ns |      59 B |
|     **ForLoopCount** |    **100** |     **80.556 ns** |     **0.8420 ns** |     **0.7876 ns** |      **78 B** |
| ForEachLoopCount |    100 |     46.016 ns |     0.6950 ns |     0.6501 ns |      59 B |
|     **ForLoopCount** | **100000** | **75,068.564 ns** |   **934.6431 ns** |   **874.2658 ns** |      **78 B** |
| ForEachLoopCount | 100000 | 56,700.293 ns | 2,338.8038 ns | 6,896.0158 ns |      59 B |

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCount()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax]
M00_L00:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L04
       mov       r10d,edx
       mov       r8,[r8+r10*8+10]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 78
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       xor       edx,edx
       mov       r8d,[rcx+8]
       test      r8d,r8d
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r10d,edx
       mov       r10,[rcx+r10*8+10]
       cmp       dword ptr [r10+8],0
       je        short M00_L03
M00_L01:
       inc       edx
       cmp       r8d,edx
       jg        short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 59
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCount()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax]
M00_L00:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L04
       mov       r10d,edx
       mov       r8,[r8+r10*8+10]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 78
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       xor       edx,edx
       mov       r8d,[rcx+8]
       test      r8d,r8d
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r10d,edx
       mov       r10,[rcx+r10*8+10]
       cmp       dword ptr [r10+8],0
       je        short M00_L03
M00_L01:
       inc       edx
       cmp       r8d,edx
       jg        short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 59
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCount()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax]
M00_L00:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L04
       mov       r10d,edx
       mov       r8,[r8+r10*8+10]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jg        short M00_L00
M00_L02:
       add       rsp,28
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 78
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       xor       edx,edx
       mov       r8d,[rcx+8]
       test      r8d,r8d
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r10d,edx
       mov       r10,[rcx+r10*8+10]
       cmp       dword ptr [r10+8],0
       je        short M00_L03
M00_L01:
       inc       edx
       cmp       r8d,edx
       jg        short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 59
```

