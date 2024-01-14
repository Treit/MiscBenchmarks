# Counting strings trying to see the difference where bounds checks are elided vs. not.

Assigning a field to a local variable is supposed to be needed to have the bounds checks removed.

Also lulz variants to try optimizing the counting code by GrabYoutPitchforks.




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                        Method | Count |     Mean |     Error |    StdDev | Code Size |
|------------------------------ |------ |---------:|----------:|----------:|----------:|
|             ForLoopCountField | 10000 | 7.574 μs | 0.0255 μs | 0.0239 μs |      78 B |
|     ForLoopCountLocalVariable | 10000 | 4.470 μs | 0.0450 μs | 0.0399 μs |      59 B |
|         ForEachLoopCountField | 10000 | 4.482 μs | 0.0378 μs | 0.0354 μs |      59 B |
| ForEachLoopCountLocalVariable | 10000 | 4.368 μs | 0.0179 μs | 0.0149 μs |      59 B |
|                         Lulz1 | 10000 | 5.481 μs | 0.0331 μs | 0.0310 μs |      64 B |
|                         Lulz2 | 10000 | 5.588 μs | 0.0346 μs | 0.0307 μs |      72 B |
|                         Lulz3 | 10000 | 5.450 μs | 0.0196 μs | 0.0153 μs |      62 B |

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountField()
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
; Test.Benchmark.ForLoopCountLocalVariable()
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
; Test.Benchmark.ForEachLoopCountField()
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
; Test.Benchmark.ForEachLoopCountLocalVariable()
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
; Test.Benchmark.Lulz1()
       mov       rax,[rcx+8]
       mov       ecx,[rax+8]
       xor       edx,edx
       mov       r8d,[rax+8]
       test      r8d,r8d
       jle       short M00_L01
       nop       dword ptr [rax]
       nop       dword ptr [rax]
M00_L00:
       mov       r10d,edx
       mov       r10,[rax+r10*8+10]
       mov       r10d,[r10+8]
       neg       r10d
       sar       r10d,1F
       add       ecx,r10d
       inc       edx
       cmp       r8d,edx
       jg        short M00_L00
M00_L01:
       mov       eax,ecx
       ret
; Total bytes of code 64
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Lulz2()
       mov       rax,[rcx+8]
       mov       ecx,[rax+8]
       shl       rcx,1F
       xor       edx,edx
       mov       r8d,[rax+8]
       test      r8d,r8d
       jle       short M00_L01
       nop       word ptr [rax+rax]
M00_L00:
       mov       r10d,edx
       mov       r10,[rax+r10*8+10]
       mov       r10d,[r10+8]
       neg       r10d
       and       r10d,80000000
       sub       rcx,r10
       inc       edx
       cmp       r8d,edx
       jg        short M00_L00
M00_L01:
       mov       rax,rcx
       shr       rax,1F
       ret
; Total bytes of code 72
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Lulz3()
       xor       eax,eax
       mov       rcx,[rcx+8]
       xor       edx,edx
       mov       r8d,[rcx+8]
       test      r8d,r8d
       jle       short M00_L01
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r10d,edx
       mov       r10,[rcx+r10*8+10]
       mov       r10d,[r10+8]
       dec       r10d
       shr       r10d,1F
       add       eax,r10d
       inc       edx
       cmp       r8d,edx
       jg        short M00_L00
M00_L01:
       ret
; Total bytes of code 62
```

