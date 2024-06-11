# Copying array of floats using Array.Copy vs. Buffer.BlockCopy

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26236.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method          | Count  | Mean     | Error   | StdDev   | Ratio | RatioSD | Code Size |
|---------------- |------- |---------:|--------:|---------:|------:|--------:|----------:|
| ArrayCopy       | 100000 | 257.1 μs | 5.50 μs | 16.05 μs |  1.00 |    0.00 |     263 B |
| BufferBlockCopy | 100000 | 272.6 μs | 8.75 μs | 25.81 μs |  1.06 |    0.11 |     705 B |

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.ArrayCopy()
       push      rsi
       push      rbx
       sub       rsp,28
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Single[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       r8d,[rbx+8]
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFB62B87738]; System.Array.Copy(System.Array, System.Array, Int32)
       mov       rax,rsi
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 57
```
```assembly
; System.Array.Copy(System.Array, System.Array, Int32)
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       mov       rbx,rcx
       mov       rsi,rdx
       mov       edi,r8d
       test      rbx,rbx
       je        near ptr M01_L01
       test      rsi,rsi
       je        near ptr M01_L02
       mov       rcx,[rbx]
       cmp       rcx,[rsi]
       jne       short M01_L00
       cmp       dword ptr [rcx+4],18
       ja        short M01_L00
       cmp       edi,[rbx+8]
       ja        short M01_L00
       cmp       edi,[rsi+8]
       ja        short M01_L00
       mov       r8d,edi
       movzx     edx,word ptr [rcx]
       imul      r8,rdx
       lea       rdx,[rbx+10]
       add       rsi,10
       test      dword ptr [rcx],1000000
       jne       short M01_L03
       mov       rcx,rsi
       call      qword ptr [7FFB62CE5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L00:
       mov       rcx,rbx
       xor       edx,edx
       call      qword ptr [7FFB62B875D0]; System.Array.GetLowerBound(Int32)
       mov       ebp,eax
       mov       rcx,rsi
       xor       edx,edx
       call      qword ptr [7FFB62B875D0]; System.Array.GetLowerBound(Int32)
       mov       r9d,eax
       mov       [rsp+20],edi
       xor       edx,edx
       mov       [rsp+28],edx
       mov       edx,ebp
       mov       r8,rsi
       mov       rcx,rbx
       call      qword ptr [7FFB62B87450]; System.Array.CopyImpl(System.Array, Int32, System.Array, Int32, Int32, Boolean)
       nop
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L01:
       mov       ecx,41
       call      qword ptr [7FFB62EC5AE8]
       int       3
M01_L02:
       mov       ecx,43
       call      qword ptr [7FFB62EC5AE8]
       int       3
M01_L03:
       mov       rcx,rsi
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       qword ptr [7FFB62CE5BC0]
; Total bytes of code 206
```

## .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.BufferBlockCopy()
       push      rsi
       push      rbx
       sub       rsp,28
       mov       rbx,[rcx+8]
       mov       edx,[rbx+8]
       mov       rcx,offset MT_System.Single[]
       call      CORINFO_HELP_NEWARR_1_VC
       mov       rsi,rax
       mov       ecx,[rbx+8]
       shl       ecx,2
       mov       [rsp+20],ecx
       mov       rcx,rbx
       mov       r8,rsi
       xor       edx,edx
       xor       r9d,r9d
       call      qword ptr [7FFB62D15AE8]; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
       mov       rax,rsi
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 68
```
```assembly
; System.Buffer.BlockCopy(System.Array, Int32, System.Array, Int32, Int32)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rbx,rcx
       mov       edi,edx
       mov       rsi,r8
       mov       ebp,r9d
       mov       r14d,[rsp+90]
       test      rbx,rbx
       je        near ptr M01_L02
       test      rsi,rsi
       je        near ptr M01_L03
       mov       r15d,[rbx+8]
       mov       r13,offset MT_System.Byte[]
       cmp       [rbx],r13
       je        short M01_L00
       mov       rcx,rbx
       call      System.Array.GetCorElementTypeOfElementType()
       mov       ecx,1
       shlx      ecx,ecx,eax
       test      ecx,3003FFC
       je        near ptr M01_L04
       mov       rcx,[rbx]
       movzx     ecx,word ptr [rcx]
       imul      r15,rcx
M01_L00:
       mov       r12,r15
       cmp       rbx,rsi
       je        short M01_L01
       mov       r12d,[rsi+8]
       cmp       [rsi],r13
       je        short M01_L01
       mov       rcx,rsi
       call      System.Array.GetCorElementTypeOfElementType()
       mov       edx,1
       shlx      edx,edx,eax
       test      edx,3003FFC
       je        near ptr M01_L05
       mov       rdx,[rsi]
       movzx     edx,word ptr [rdx]
       imul      r12,rdx
M01_L01:
       test      edi,edi
       jl        near ptr M01_L06
       test      ebp,ebp
       jl        near ptr M01_L07
       test      r14d,r14d
       jl        near ptr M01_L08
       movsxd    r8,r14d
       movsxd    rdx,edi
       movsxd    rcx,ebp
       lea       rax,[rdx+r8]
       cmp       rax,r15
       ja        near ptr M01_L09
       lea       rax,[rcx+r8]
       cmp       rax,r12
       ja        near ptr M01_L09
       lea       rax,[rsi+8]
       mov       r10,[rsi]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       rax,r10
       add       rcx,rax
       lea       rax,[rbx+8]
       mov       r10,[rbx]
       mov       r10d,[r10+4]
       add       r10,0FFFFFFFFFFFFFFF0
       add       r10,rax
       add       rdx,r10
       call      qword ptr [7FFB62D15B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       nop
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L02:
       mov       ecx,18F
       mov       rdx,7FFB62B14000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FFB62D86790]
       int       3
M01_L03:
       mov       ecx,197
       mov       rdx,7FFB62B14000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      qword ptr [7FFB62D86790]
       int       3
M01_L04:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       call      qword ptr [7FFB630DD950]
       mov       rbp,rax
       mov       ecx,18F
       mov       rdx,7FFB62B14000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,rbp
       mov       rcx,rdi
       call      qword ptr [7FFB62C6F750]
       mov       rcx,rdi
       call      CORINFO_HELP_THROW
M01_L05:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       r14,rax
       call      qword ptr [7FFB630DD950]
       mov       rbx,rax
       mov       ecx,197
       mov       rdx,7FFB62B14000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,rbx
       mov       rcx,r14
       call      qword ptr [7FFB62C6F750]
       mov       rcx,r14
       call      CORINFO_HELP_THROW
M01_L06:
       mov       ecx,19F
       mov       rdx,7FFB62B14000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,edi
       call      qword ptr [7FFB63107B58]
       int       3
M01_L07:
       mov       ecx,1B3
       mov       rdx,7FFB62B14000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,ebp
       call      qword ptr [7FFB63107B58]
       int       3
M01_L08:
       mov       ecx,1C7
       mov       rdx,7FFB62B14000
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       ecx,r14d
       call      qword ptr [7FFB63107B58]
       int       3
M01_L09:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFB630DED78]
       mov       rdx,rax
       mov       rcx,rbx
       call      qword ptr [7FFB62C6F708]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 637
```

