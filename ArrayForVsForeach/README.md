# Counting strings using a for loop vs. a foreach loop.


``` ini

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22621.3737/22H2/2022Update/SunValley2)
AMD Ryzen 9 5950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method                  | Count  | Mean          | Error       | StdDev      | Code Size |
|------------------------ |------- |--------------:|------------:|------------:|----------:|
| ForLoopCountFieldAccess | 10     |      5.478 ns |   0.0332 ns |   0.0310 ns |      78 B |
| ForLoopCountLocalAccess | 10     |      2.999 ns |   0.0168 ns |   0.0157 ns |      59 B |
| ForEachLoopCount        | 10     |      3.004 ns |   0.0135 ns |   0.0112 ns |      59 B |
| ForLoopCountFieldAccess | 100    |     54.543 ns |   0.4449 ns |   0.4162 ns |      78 B |
| ForLoopCountLocalAccess | 100    |     32.095 ns |   0.6275 ns |   1.0133 ns |      59 B |
| ForEachLoopCount        | 100    |     31.939 ns |   0.6707 ns |   0.9403 ns |      59 B |
| ForLoopCountFieldAccess | 100000 | 51,594.918 ns | 386.5606 ns | 361.5890 ns |      78 B |
| ForLoopCountLocalAccess | 100000 | 33,187.575 ns | 340.7506 ns | 318.7383 ns |      59 B |
| ForEachLoopCount        | 100000 | 32,964.418 ns | 272.0465 ns | 254.4724 ns |      59 B |

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
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

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
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

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
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

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
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

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
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

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
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

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
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

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
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

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
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

