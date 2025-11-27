# Counting strings trying to see the difference where bounds checks are elided vs. not.

Assigning a field to a local variable is supposed to be needed to have the bounds checks removed.

Also lulz variants to try optimizing the counting code by GrabYoutPitchforks.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Code Size |
|------------------------------ |---------- |---------- |------ |---------:|----------:|----------:|----------:|
| ForLoopCountField             | .NET 10.0 | .NET 10.0 | 10000 | 7.347 μs | 0.0300 μs | 0.0266 μs |      70 B |
| ForLoopCountLocalVariable     | .NET 10.0 | .NET 10.0 | 10000 | 5.291 μs | 0.0419 μs | 0.0392 μs |      54 B |
| ForEachLoopCountField         | .NET 10.0 | .NET 10.0 | 10000 | 5.315 μs | 0.0368 μs | 0.0344 μs |      54 B |
| ForEachLoopCountLocalVariable | .NET 10.0 | .NET 10.0 | 10000 | 5.366 μs | 0.0397 μs | 0.0371 μs |      55 B |
| Lulz1                         | .NET 10.0 | .NET 10.0 | 10000 | 5.633 μs | 0.0351 μs | 0.0329 μs |      60 B |
| Lulz2                         | .NET 10.0 | .NET 10.0 | 10000 | 5.619 μs | 0.0501 μs | 0.0469 μs |      68 B |
| Lulz3                         | .NET 10.0 | .NET 10.0 | 10000 | 5.714 μs | 0.0392 μs | 0.0366 μs |      58 B |
| ForLoopCountField             | .NET 9.0  | .NET 9.0  | 10000 | 7.386 μs | 0.0219 μs | 0.0194 μs |      70 B |
| ForLoopCountLocalVariable     | .NET 9.0  | .NET 9.0  | 10000 | 5.363 μs | 0.0519 μs | 0.0486 μs |      55 B |
| ForEachLoopCountField         | .NET 9.0  | .NET 9.0  | 10000 | 5.254 μs | 0.0437 μs | 0.0409 μs |      54 B |
| ForEachLoopCountLocalVariable | .NET 9.0  | .NET 9.0  | 10000 | 5.294 μs | 0.0394 μs | 0.0369 μs |      54 B |
| Lulz1                         | .NET 9.0  | .NET 9.0  | 10000 | 5.686 μs | 0.0315 μs | 0.0279 μs |      60 B |
| Lulz2                         | .NET 9.0  | .NET 9.0  | 10000 | 5.609 μs | 0.0359 μs | 0.0318 μs |      68 B |
| Lulz3                         | .NET 9.0  | .NET 9.0  | 10000 | 5.583 μs | 0.0438 μs | 0.0410 μs |      58 B |

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
       jle       short M00_L03
       add       rcx,10
       jmp       short M00_L02
       nop       dword ptr [rax+rax]
       nop       dword ptr [rax+rax]
M00_L00:
       inc       eax
M00_L01:
       add       rcx,8
       dec       edx
       je        short M00_L03
M00_L02:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       jmp       short M00_L00
M00_L03:
       ret
; Total bytes of code 55
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
       jle       short M00_L03
       add       rcx,10
       jmp       short M00_L02
       nop       dword ptr [rax+rax]
       nop       dword ptr [rax+rax]
M00_L00:
       inc       eax
M00_L01:
       add       rcx,8
       dec       edx
       je        short M00_L03
M00_L02:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       jne       short M00_L01
       jmp       short M00_L00
M00_L03:
       ret
; Total bytes of code 55
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

