# Counting strings trying to see the difference where bounds checks are elided vs. not.

Assigning a field to a local variable is supposed to be needed to have the bounds checks removed.

Also lulz variants to try optimizing the counting code by GrabYoutPitchforks.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count | Mean     | Error     | StdDev    | Code Size |
|------------------------------ |------ |---------:|----------:|----------:|----------:|
| ForLoopCountField             | 10000 | 7.501 μs | 0.1302 μs | 0.1598 μs |      70 B |
| ForLoopCountLocalVariable     | 10000 | 5.262 μs | 0.0545 μs | 0.0510 μs |      54 B |
| ForEachLoopCountField         | 10000 | 5.305 μs | 0.0967 μs | 0.0905 μs |      54 B |
| ForEachLoopCountLocalVariable | 10000 | 5.247 μs | 0.0478 μs | 0.0447 μs |      54 B |
| Lulz1                         | 10000 | 5.475 μs | 0.0497 μs | 0.0465 μs |      60 B |
| Lulz2                         | 10000 | 5.516 μs | 0.0544 μs | 0.0482 μs |      68 B |
| Lulz3                         | 10000 | 5.563 μs | 0.0487 μs | 0.0431 μs |      58 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountField()
       sub       rsp,28
       xor       eax,eax
       xor       edx,edx
       mov       rcx,[rcx+8]
       cmp       dword ptr [rcx+8],0
       jg        short M00_L02
M00_L00:
       add       rsp,28
       ret
       nop       word ptr [rax+rax]
M00_L01:
       inc       edx
       cmp       [rcx+8],edx
       jle       short M00_L00
M00_L02:
       mov       r8,rcx
       cmp       edx,[r8+8]
       jae       short M00_L03
       mov       r8,[r8+rdx*8+10]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       inc       eax
       jmp       short M00_L01
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 70
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalVariable()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCountField()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCountLocalVariable()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L00
       add       rcx,10
       jmp       short M00_L03
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       ret
M00_L01:
       inc       eax
M00_L02:
       add       rcx,8
       dec       edx
       je        short M00_L00
M00_L03:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L02
       jmp       short M00_L01
; Total bytes of code 54
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Lulz1()
       mov       rax,[rcx+8]
       mov       ecx,[rax+8]
       mov       edx,[rax+8]
       test      edx,edx
       jle       short M00_L01
       add       rax,10
       nop       dword ptr [rax]
       nop       dword ptr [rax]
M00_L00:
       mov       r8,[rax]
       mov       r8d,[r8+8]
       neg       r8d
       sar       r8d,1F
       add       ecx,r8d
       add       rax,8
       dec       edx
       jne       short M00_L00
M00_L01:
       mov       eax,ecx
       ret
; Total bytes of code 60
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Lulz2()
       mov       rax,[rcx+8]
       mov       ecx,[rax+8]
       shl       rcx,1F
       mov       edx,[rax+8]
       test      edx,edx
       jle       short M00_L01
       add       rax,10
       nop       word ptr [rax+rax]
M00_L00:
       mov       r8,[rax]
       mov       r8d,[r8+8]
       neg       r8d
       and       r8d,80000000
       sub       rcx,r8
       add       rax,8
       dec       edx
       jne       short M00_L00
M00_L01:
       mov       rax,rcx
       shr       rax,1F
       ret
; Total bytes of code 68
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Lulz3()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L01
       add       rcx,10
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r8,[rcx]
       mov       r8d,[r8+8]
       dec       r8d
       shr       r8d,1F
       add       eax,r8d
       add       rcx,8
       dec       edx
       jne       short M00_L00
M00_L01:
       ret
; Total bytes of code 58
```

