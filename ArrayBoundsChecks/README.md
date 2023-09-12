# Counting strings trying to see the difference where bounds checks are elided vs. not.

Assigning a field to a local variable is supposed to be needed to have the bounds checks removed.

Also lulz variants to try optimizing the counting code by GrabYoutPitchforks.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25947.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|                        Method | Count |     Mean |     Error |    StdDev | Code Size |
|------------------------------ |------ |---------:|----------:|----------:|----------:|
|             ForLoopCountField | 10000 | 9.760 μs | 0.1518 μs | 0.1345 μs |      62 B |
|     ForLoopCountLocalVariable | 10000 | 9.785 μs | 0.1901 μs | 0.1685 μs |      57 B |
|         ForEachLoopCountField | 10000 | 9.781 μs | 0.1905 μs | 0.1957 μs |      57 B |
| ForEachLoopCountLocalVariable | 10000 | 9.831 μs | 0.1875 μs | 0.2232 μs |      57 B |
|                         Lulz1 | 10000 | 6.096 μs | 0.0994 μs | 0.0881 μs |      64 B |
|                         Lulz2 | 10000 | 6.557 μs | 0.1094 μs | 0.1302 μs |      72 B |
|                         Lulz3 | 10000 | 6.307 μs | 0.1210 μs | 0.1011 μs |      62 B |

## .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountField()
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

## .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForLoopCountLocalVariable()
       xor       eax,eax
       mov       rdx,[rcx+8]
       xor       ecx,ecx
       mov       r8d,[rdx+8]
       test      r8d,r8d
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r9d,ecx
       mov       r9,[rdx+r9*8+10]
       cmp       dword ptr [r9+8],0
       jne       short M00_L01
       inc       eax
M00_L01:
       inc       ecx
       cmp       r8d,ecx
       jg        short M00_L00
M00_L02:
       ret
; Total bytes of code 57
```

## .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCountField()
       xor       eax,eax
       mov       rdx,[rcx+8]
       xor       ecx,ecx
       mov       r8d,[rdx+8]
       test      r8d,r8d
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r9d,ecx
       mov       r9,[rdx+r9*8+10]
       cmp       dword ptr [r9+8],0
       jne       short M00_L01
       inc       eax
M00_L01:
       inc       ecx
       cmp       r8d,ecx
       jg        short M00_L00
M00_L02:
       ret
; Total bytes of code 57
```

## .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.ForEachLoopCountLocalVariable()
       xor       eax,eax
       mov       rdx,[rcx+8]
       xor       ecx,ecx
       mov       r8d,[rdx+8]
       test      r8d,r8d
       jle       short M00_L02
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r9d,ecx
       mov       r9,[rdx+r9*8+10]
       cmp       dword ptr [r9+8],0
       jne       short M00_L01
       inc       eax
M00_L01:
       inc       ecx
       cmp       r8d,ecx
       jg        short M00_L00
M00_L02:
       ret
; Total bytes of code 57
```

## .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Lulz1()
       mov       rax,[rcx+8]
       mov       edx,[rax+8]
       xor       ecx,ecx
       mov       r8d,[rax+8]
       test      r8d,r8d
       jle       short M00_L01
       nop       dword ptr [rax]
       nop       dword ptr [rax]
M00_L00:
       mov       r9d,ecx
       mov       r9,[rax+r9*8+10]
       mov       r9d,[r9+8]
       neg       r9d
       sar       r9d,1F
       add       edx,r9d
       inc       ecx
       cmp       r8d,ecx
       jg        short M00_L00
M00_L01:
       mov       eax,edx
       ret
; Total bytes of code 64
```

## .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Lulz2()
       mov       rax,[rcx+8]
       mov       edx,[rax+8]
       shl       rdx,1F
       xor       ecx,ecx
       mov       r8d,[rax+8]
       test      r8d,r8d
       jle       short M00_L01
       nop       word ptr [rax+rax]
M00_L00:
       mov       r9d,ecx
       mov       r9,[rax+r9*8+10]
       mov       r9d,[r9+8]
       neg       r9d
       and       r9d,80000000
       sub       rdx,r9
       inc       ecx
       cmp       r8d,ecx
       jg        short M00_L00
M00_L01:
       mov       rax,rdx
       shr       rax,1F
       ret
; Total bytes of code 72
```

## .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```assembly
; Test.Benchmark.Lulz3()
       xor       eax,eax
       mov       rdx,[rcx+8]
       xor       ecx,ecx
       mov       r8d,[rdx+8]
       test      r8d,r8d
       jle       short M00_L01
       nop       dword ptr [rax]
       nop       dword ptr [rax+rax]
M00_L00:
       mov       r9d,ecx
       mov       r9,[rdx+r9*8+10]
       mov       r9d,[r9+8]
       dec       r9d
       shr       r9d,1F
       add       eax,r9d
       inc       ecx
       cmp       r8d,ecx
       jg        short M00_L00
M00_L01:
       ret
; Total bytes of code 62
```

