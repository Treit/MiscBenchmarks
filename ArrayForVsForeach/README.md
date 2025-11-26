# Counting strings using a for loop vs. a foreach loop.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count  | Mean          | Error         | StdDev        | Code Size |
|------------------------ |------- |--------------:|--------------:|--------------:|----------:|
| **ForLoopCountFieldAccess** | **10**     |      **6.755 ns** |     **0.0954 ns** |     **0.0846 ns** |      **75 B** |
| ForLoopCountLocalAccess | 10     |      4.702 ns |     0.0281 ns |     0.0249 ns |      55 B |
| ForEachLoopCount        | 10     |      4.705 ns |     0.0397 ns |     0.0371 ns |      55 B |
| **ForLoopCountFieldAccess** | **100**    |     **77.803 ns** |     **0.4407 ns** |     **0.3907 ns** |      **70 B** |
| ForLoopCountLocalAccess | 100    |     51.578 ns |     0.5637 ns |     0.5273 ns |      54 B |
| ForEachLoopCount        | 100    |     51.608 ns |     0.5147 ns |     0.4298 ns |      54 B |
| **ForLoopCountFieldAccess** | **100000** | **73,586.052 ns** |   **745.0112 ns** |   **696.8839 ns** |      **70 B** |
| ForLoopCountLocalAccess | 100000 | 62,550.683 ns | 1,225.7146 ns | 2,047.8938 ns |      54 B |
| ForEachLoopCount        | 100000 | 62,303.753 ns | 1,233.2760 ns | 2,654.7568 ns |      54 B |

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
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
       mov       r8,[r8+rdx*8+10]
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
; Total bytes of code 75
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalAccess()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L02
       add       rcx,10
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       add       rcx,8
       dec       edx
       jne       short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 55
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCount()
       xor       eax,eax
       mov       rcx,[rcx+8]
       mov       edx,[rcx+8]
       test      edx,edx
       jle       short M00_L02
       add       rcx,10
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r8,[rcx]
       cmp       dword ptr [r8+8],0
       je        short M00_L03
M00_L01:
       add       rcx,8
       dec       edx
       jne       short M00_L00
M00_L02:
       ret
M00_L03:
       inc       eax
       jmp       short M00_L01
; Total bytes of code 55
```

## .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountFieldAccess()
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
; Test.Benchmark.ForLoopCountLocalAccess()
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
; Test.Benchmark.ForEachLoopCount()
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
; Test.Benchmark.ForLoopCountFieldAccess()
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
; Test.Benchmark.ForLoopCountLocalAccess()
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
; Test.Benchmark.ForEachLoopCount()
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

