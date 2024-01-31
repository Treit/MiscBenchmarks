# Case insensitive string comparisons.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26045.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                     | Count | Mean      | Error    | StdDev    | Median    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------------------------- |------ |----------:|---------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| StringComparisonOrdinalIgnoreCase          | 1000  |  61.48 μs | 1.161 μs |  2.803 μs |  61.04 μs |  1.00 |    0.00 |       - |         - |          NA |
| ToLower                                    | 1000  |  92.19 μs | 3.754 μs | 10.588 μs |  87.37 μs |  1.50 |    0.20 | 33.5693 |  144936 B |          NA |
| ToUpper                                    | 1000  |  86.21 μs | 2.143 μs |  6.046 μs |  84.81 μs |  1.41 |    0.14 | 25.1465 |  108736 B |          NA |
| ToLowerInvariant                           | 1000  |  85.47 μs | 2.563 μs |  7.355 μs |  82.97 μs |  1.39 |    0.14 | 33.5693 |  144936 B |          NA |
| ToUpperInvariant                           | 1000  |  80.09 μs | 1.587 μs |  3.484 μs |  79.03 μs |  1.30 |    0.08 | 25.1465 |  108736 B |          NA |
| StringComparisonIgnoreCaseFlag             | 1000  | 209.28 μs | 7.041 μs | 20.314 μs | 202.55 μs |  3.42 |    0.35 |       - |         - |          NA |
| StringComparisonInvariantCultureIgnoreCase | 1000  | 196.41 μs | 3.904 μs | 11.010 μs | 194.82 μs |  3.21 |    0.24 |       - |         - |          NA |
| StringComparisonCurrentCultureIgnoreCase   | 1000  | 205.47 μs | 6.015 μs | 17.640 μs | 200.60 μs |  3.37 |    0.28 |       - |         - |          NA |

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.ToLower()
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,38
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       xor       edi,edi
       mov       ebp,[rsi+8]
       test      ebp,ebp
       jle       near ptr M00_L12
       mov       rcx,gs:[58]
       mov       rcx,[rcx+48]
       cmp       dword ptr [rcx+188],2
       jl        near ptr M00_L13
       mov       rcx,[rcx+190]
       mov       rcx,[rcx+10]
       test      rcx,rcx
       je        near ptr M00_L13
       mov       r14,[rcx]
       add       r14,10
M00_L00:
       mov       ecx,edi
       shl       rcx,4
       lea       rcx,[rsi+rcx+10]
       mov       r15,[rcx]
       mov       r13,[rcx+8]
       cmp       [r15],r15b
       mov       rcx,[r14+8]
       test      rcx,rcx
       jne       short M00_L01
       mov       rcx,183DBC00438
       mov       rcx,[rcx]
       test      rcx,rcx
       jne       short M00_L01
       mov       rcx,183DBC00418
       mov       rcx,[rcx]
       test      rcx,rcx
       je        near ptr M00_L14
M00_L01:
       mov       r12,rcx
       mov       rcx,offset MT_System.Globalization.CultureInfo
       cmp       [r12],rcx
       jne       near ptr M00_L07
       cmp       qword ptr [r12+10],0
       je        near ptr M00_L15
M00_L02:
       mov       rcx,[r12+10]
M00_L03:
       cmp       [rcx],cl
       mov       rdx,r15
       call      qword ptr [7FFC794A7378]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToLowerConversion, System.Private.CoreLib]](System.String)
       mov       r12,rax
       cmp       [r13],r13b
       mov       rcx,[r14+8]
       test      rcx,rcx
       jne       short M00_L04
       mov       rcx,183DBC00438
       mov       rcx,[rcx]
       test      rcx,rcx
       jne       short M00_L04
       mov       rcx,183DBC00418
       mov       rcx,[rcx]
       test      rcx,rcx
       je        near ptr M00_L16
M00_L04:
       mov       r15,rcx
       mov       rcx,offset MT_System.Globalization.CultureInfo
       cmp       [r15],rcx
       jne       short M00_L09
       cmp       qword ptr [r15+10],0
       je        near ptr M00_L17
M00_L05:
       mov       rcx,[r15+10]
M00_L06:
       cmp       [rcx],cl
       mov       rdx,r13
       call      qword ptr [7FFC794A7378]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToLowerConversion, System.Private.CoreLib]](System.String)
       mov       rdx,rax
       cmp       r12,rdx
       je        short M00_L10
       test      r12,r12
       je        short M00_L11
       jmp       short M00_L08
M00_L07:
       mov       rcx,r12
       mov       rax,[r12]
       mov       rax,[rax+48]
       call      qword ptr [rax+38]
       mov       rcx,rax
       jmp       near ptr M00_L03
M00_L08:
       test      rdx,rdx
       je        short M00_L11
       mov       r8d,[r12+8]
       cmp       r8d,[rdx+8]
       jne       short M00_L11
       lea       rcx,[r12+0C]
       mov       r8d,[r12+8]
       add       r8d,r8d
       add       rdx,0C
       call      qword ptr [7FFC790E5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       je        short M00_L11
       jmp       short M00_L10
M00_L09:
       mov       rcx,r15
       mov       rax,[r15]
       mov       rax,[rax+48]
       call      qword ptr [rax+38]
       mov       rcx,rax
       jmp       short M00_L06
M00_L10:
       inc       ebx
M00_L11:
       inc       edi
       cmp       ebp,edi
       jg        near ptr M00_L00
M00_L12:
       mov       eax,ebx
       add       rsp,38
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M00_L13:
       mov       ecx,2
       call      CORINFO_HELP_GETSHARED_GCTHREADSTATIC_BASE_NOCTOR_OPTIMIZED
       mov       r14,rax
       jmp       near ptr M00_L00
M00_L14:
       call      qword ptr [7FFC7913E070]; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       mov       rcx,rax
       jmp       near ptr M00_L01
M00_L15:
       mov       rcx,offset MT_System.Globalization.TextInfo
       call      CORINFO_HELP_NEWSFAST
       mov       [rsp+30],rax
       mov       rdx,[r12+30]
       mov       rcx,rax
       call      qword ptr [7FFC791FEE08]; System.Globalization.TextInfo..ctor(System.Globalization.CultureData)
       movzx     ecx,byte ptr [r12+60]
       mov       rax,[rsp+30]
       mov       [rax+30],cl
       lea       rcx,[r12+10]
       mov       rdx,rax
       call      CORINFO_HELP_ASSIGN_REF
       jmp       near ptr M00_L02
M00_L16:
       call      qword ptr [7FFC7913E070]; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       mov       rcx,rax
       jmp       near ptr M00_L04
M00_L17:
       mov       rcx,offset MT_System.Globalization.TextInfo
       call      CORINFO_HELP_NEWSFAST
       mov       [rsp+28],rax
       mov       rdx,[r15+30]
       mov       rcx,rax
       call      qword ptr [7FFC791FEE08]; System.Globalization.TextInfo..ctor(System.Globalization.CultureData)
       movzx     ecx,byte ptr [r15+60]
       mov       rax,[rsp+28]
       mov       [rax+30],cl
       lea       rcx,[r15+10]
       mov       rdx,rax
       call      CORINFO_HELP_ASSIGN_REF
       jmp       near ptr M00_L05
; Total bytes of code 615
```
```assembly
; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToLowerConversion, System.Private.CoreLib]](System.String)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,68
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       vmovdqa   xmmword ptr [rsp+40],xmm4
       vmovdqa   xmmword ptr [rsp+50],xmm4
       xor       eax,eax
       mov       [rsp+60],rax
       mov       rsi,rcx
       mov       rbx,rdx
       mov       edi,[rbx+8]
       test      edi,edi
       je        near ptr M01_L13
       lea       rcx,[rbx+0C]
       mov       [rsp+60],rcx
       mov       rbp,[rsp+60]
       xor       r14d,r14d
       cmp       byte ptr [rsi+31],0
       je        near ptr M01_L10
M01_L00:
       cmp       byte ptr [rsi+31],2
       jne       near ptr M01_L17
       cmp       edi,2
       jl        short M01_L02
       lea       eax,[rdi-2]
M01_L01:
       mov       ecx,[rbp+r14*2]
       test      ecx,0FF80FF80
       jne       near ptr M01_L17
       lea       edx,[rcx+3F003F]
       add       ecx,250025
       xor       ecx,edx
       test      ecx,800080
       jne       short M01_L04
       add       r14,2
       cmp       r14,rax
       jbe       short M01_L01
M01_L02:
       test      dil,1
       je        short M01_L03
       movzx     eax,word ptr [rbp+r14*2]
       cmp       eax,7F
       ja        near ptr M01_L17
       add       eax,0FFFFFFBF
       cmp       eax,19
       jbe       short M01_L04
M01_L03:
       mov       rax,rbx
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L04:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       rbp,rax
       lea       r15,[rbp+0C]
       mov       r13d,[rbp+8]
       mov       eax,r14d
       cmp       edi,eax
       jb        near ptr M01_L18
       lea       rdx,[rbx+0C]
       cmp       eax,r13d
       ja        near ptr M01_L20
       mov       r12d,eax
       mov       r8,r12
       add       r8,r8
       mov       rcx,r15
       call      qword ptr [7FFC790E5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       ecx,r14d
       lea       rbx,[rbx+r12*2+0C]
       sub       edi,ecx
       mov       ecx,r14d
       lea       r14,[r15+r12*2]
       sub       r13d,ecx
       test      edi,edi
       je        near ptr M01_L09
       xor       ecx,ecx
       mov       [rsp+50],ecx
       cmp       byte ptr [rsi+31],0
       je        short M01_L06
M01_L05:
       cmp       byte ptr [rsi+31],2
       jne       near ptr M01_L16
       imul      ecx,edi,2
       jo        near ptr M01_L14
       imul      eax,r13d,2
       jo        near ptr M01_L14
       test      ecx,ecx
       je        near ptr M01_L12
       test      eax,eax
       je        near ptr M01_L12
       mov       r15,r14
       sub       r15,rbx
       mov       ecx,ecx
       cmp       r15,rcx
       jb        near ptr M01_L15
       jmp       near ptr M01_L11
M01_L06:
       mov       rcx,rsi
       call      qword ptr [7FFC791FF0F0]; System.Globalization.TextInfo.PopulateIsAsciiCasingSameAsInvariant()
       jmp       short M01_L05
M01_L07:
       mov       r15d,r13d
       mov       r12d,1
M01_L08:
       mov       [rsp+38],rbx
       mov       rcx,rbx
       mov       [rsp+30],r14
       mov       rdx,r14
       mov       r8,r15
       call      qword ptr [7FFC794A73A8]; System.Text.Ascii.ChangeCase[[System.UInt16, System.Private.CoreLib],[System.UInt16, System.Private.CoreLib],[System.Text.Ascii+ToLowerConversion, System.Private.CoreLib]](UInt16*, UInt16*, UIntPtr)
       mov       [rsp+50],eax
       mov       ecx,3
       cmp       r15,rax
       cmovne    r12d,ecx
       xor       eax,eax
       mov       [rsp+38],rax
       mov       [rsp+30],rax
       cmp       r12d,3
       je        short M01_L16
M01_L09:
       xor       eax,eax
       mov       [rsp+48],rax
       mov       [rsp+40],rax
       mov       rax,rbp
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L10:
       mov       rcx,rsi
       call      qword ptr [7FFC791FF0F0]; System.Globalization.TextInfo.PopulateIsAsciiCasingSameAsInvariant()
       jmp       near ptr M01_L00
M01_L11:
       mov       ecx,eax
       neg       rcx
       cmp       rcx,r15
       jb        short M01_L15
M01_L12:
       cmp       edi,r13d
       jg        near ptr M01_L07
       mov       r15d,edi
       xor       r12d,r12d
       jmp       near ptr M01_L08
M01_L13:
       mov       rax,18380200008
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L14:
       call      CORINFO_HELP_OVERFLOW
M01_L15:
       mov       ecx,48
       call      qword ptr [7FFC792C5BA8]
       int       3
M01_L16:
       mov       [rsp+48],rbx
       mov       [rsp+40],r14
       movsxd    rcx,dword ptr [rsp+50]
       lea       rdx,[rbx+rcx*2]
       mov       r8d,edi
       sub       r8d,[rsp+50]
       movsxd    rcx,dword ptr [rsp+50]
       lea       r9,[r14+rcx*2]
       sub       r13d,[rsp+50]
       mov       [rsp+20],r13d
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rsi
       call      qword ptr [7FFC791FF1B0]
       xor       ecx,ecx
       mov       [rsp+40],rcx
       mov       [rsp+48],rcx
       jmp       near ptr M01_L09
M01_L17:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       r15,rax
       test      r14,r14
       je        short M01_L21
       lea       rcx,[r15+0C]
       mov       eax,[r15+8]
       mov       r13d,r14d
       cmp       edi,r13d
       jae       short M01_L19
M01_L18:
       mov       ecx,21
       call      qword ptr [7FFC792C5B18]
       int       3
M01_L19:
       add       rbx,0C
       mov       rdx,rbx
       cmp       r13d,eax
       ja        short M01_L20
       mov       r8d,r13d
       add       r8,r8
       call      qword ptr [7FFC790E5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M01_L21
M01_L20:
       call      qword ptr [7FFC792C57D0]
       int       3
M01_L21:
       test      r15,r15
       jne       short M01_L22
       xor       r9d,r9d
       jmp       short M01_L23
M01_L22:
       lea       r9,[r15+0C]
       mov       [rsp+58],r9
       mov       r9,[rsp+58]
M01_L23:
       mov       edx,[r15+8]
       sub       edx,r14d
       mov       [rsp+20],edx
       xor       edx,edx
       mov       [rsp+28],edx
       lea       rdx,[rbp+r14*2]
       mov       r8d,edi
       sub       r8d,r14d
       lea       r9,[r9+r14*2]
       mov       rcx,rsi
       call      qword ptr [7FFC791FF1B0]
       xor       eax,eax
       mov       [rsp+58],rax
       mov       rax,r15
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 816
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       cmp       r8,8
       jae       short M02_L03
       cmp       r8,4
       jae       short M02_L02
       xor       eax,eax
       mov       r10,r8
       and       r10,2
       je        short M02_L00
       movzx     eax,word ptr [rcx]
       movzx     r9d,word ptr [rdx]
       sub       eax,r9d
M02_L00:
       test      r8b,1
       je        short M02_L01
       movzx     r8d,byte ptr [rcx+r10]
       movzx     ecx,byte ptr [rdx+r10]
       sub       r8d,ecx
       or        r8d,eax
       mov       eax,r8d
M02_L01:
       test      eax,eax
       sete      al
       movzx     eax,al
       jmp       short M02_L04
M02_L02:
       add       r8,0FFFFFFFFFFFFFFFC
       mov       eax,[rcx]
       sub       eax,[rdx]
       mov       ecx,[rcx+r8]
       sub       ecx,[rdx+r8]
       or        eax,ecx
       sete      al
       movzx     eax,al
       jmp       short M02_L04
M02_L03:
       cmp       rcx,rdx
       je        short M02_L05
       jmp       short M02_L06
M02_L04:
       vzeroupper
       ret
M02_L05:
       mov       eax,1
       vzeroupper
       ret
M02_L06:
       cmp       r8,20
       jb        short M02_L09
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFE0
       je        short M02_L08
M02_L07:
       vmovups   ymm0,[rcx+rax]
       vpcmpnequb k1,ymm0,[rdx+rax]
       kortestd  k1,k1
       nop       dword ptr [rax]
       jne       near ptr M02_L13
       add       rax,20
       cmp       r8,rax
       ja        short M02_L07
M02_L08:
       vmovups   ymm0,[rcx+r8]
       vpcmpeqb  k1,ymm0,[rdx+r8]
       kortestd  k1,k1
       nop       dword ptr [rax]
       jae       short M02_L13
       jmp       short M02_L05
       xchg      ax,ax
M02_L09:
       cmp       r8,10
       jb        short M02_L12
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFF0
       je        short M02_L11
M02_L10:
       vmovups   xmm0,[rcx+rax]
       vpcmpnequb k1,xmm0,[rdx+rax]
       kortestw  k1,k1
       jne       short M02_L13
       add       rax,10
       cmp       r8,rax
       ja        short M02_L10
M02_L11:
       vmovups   xmm0,[rcx+r8]
       vpcmpeqb  k1,xmm0,[rdx+r8]
       kortestw  k1,k1
       jae       short M02_L13
       jmp       near ptr M02_L05
M02_L12:
       lea       rax,[r8-8]
       mov       r8,[rcx]
       sub       r8,[rdx]
       mov       rcx,[rcx+rax]
       sub       rcx,[rdx+rax]
       or        rcx,r8
       sete      al
       movzx     eax,al
       jmp       near ptr M02_L04
M02_L13:
       xor       eax,eax
       vzeroupper
       ret
; Total bytes of code 298
```
```assembly
; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       push      rsi
       push      rbx
       sub       rsp,28
       call      qword ptr [7FFCD34A31F0]
       mov       rbx,rax
       lea       rsi,[rbx+3E0]
       call      qword ptr [7FFCD34B6B48]
       mov       rdx,rax
       mov       rcx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFCD34B7B40]; System.Threading.Interlocked.CompareExchange(System.Object ByRef, System.Object, System.Object)
       mov       rax,[rbx+3E0]
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 57
```
```assembly
; System.Globalization.TextInfo..ctor(System.Globalization.CultureData)
       push      rbx
       sub       rsp,20
       mov       rbx,rcx
       lea       rcx,[rbx+18]
       call      qword ptr [7FFCD34A2D30]; CORINFO_HELP_ASSIGN_REF
       mov       rcx,[rbx+18]
       cmp       [rcx],ecx
       call      qword ptr [7FFCD34B6668]; Precode of System.Globalization.CultureData.get_CultureName()
       lea       rcx,[rbx+10]
       mov       rdx,rax
       call      qword ptr [7FFCD34A2D30]; CORINFO_HELP_ASSIGN_REF
       mov       rcx,[rbx+18]
       mov       rdx,[rcx+8]
       lea       rcx,[rbx+20]
       call      qword ptr [7FFCD34A2D30]; CORINFO_HELP_ASSIGN_REF
       call      qword ptr [7FFCD34A2EC0]
       cmp       byte ptr [rax+0AE8],0
       jne       short M04_L01
M04_L00:
       add       rsp,20
       pop       rbx
       ret
M04_L01:
       mov       rcx,[rbx+20]
       call      qword ptr [7FFCD34B6550]
       mov       [rbx+28],rax
       jmp       short M04_L00
; Total bytes of code 98
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.ToUpper()
       push      r15
       push      r14
       push      r13
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       xor       edi,edi
       mov       ebp,[rsi+8]
       test      ebp,ebp
       jle       near ptr M00_L05
       mov       rcx,gs:[58]
       mov       rcx,[rcx+48]
       cmp       dword ptr [rcx+188],2
       jl        near ptr M00_L06
       mov       rcx,[rcx+190]
       mov       rcx,[rcx+10]
       test      rcx,rcx
       je        near ptr M00_L06
       mov       r14,[rcx]
       add       r14,10
M00_L00:
       mov       ecx,edi
       shl       rcx,4
       lea       rcx,[rsi+rcx+10]
       mov       r15,[rcx]
       mov       r13,[rcx+8]
       cmp       [r15],r15b
       mov       rcx,[r14+8]
       test      rcx,rcx
       jne       short M00_L01
       mov       rcx,1DB2D000438
       mov       rcx,[rcx]
       test      rcx,rcx
       jne       short M00_L01
       mov       rcx,1DB2D000418
       mov       rcx,[rcx]
       test      rcx,rcx
       je        near ptr M00_L07
M00_L01:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       call      qword ptr [rax+38]
       cmp       [rax],al
       mov       rcx,rax
       mov       rdx,r15
       call      qword ptr [7FFC793CF828]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToUpperConversion, System.Private.CoreLib]](System.String)
       mov       r15,rax
       cmp       [r13],r13b
       mov       rcx,[r14+8]
       test      rcx,rcx
       jne       short M00_L02
       mov       rcx,1DB2D000438
       mov       rcx,[rcx]
       test      rcx,rcx
       jne       short M00_L02
       mov       rcx,1DB2D000418
       mov       rcx,[rcx]
       test      rcx,rcx
       je        near ptr M00_L08
M00_L02:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       call      qword ptr [rax+38]
       cmp       [rax],al
       mov       rcx,rax
       mov       rdx,r13
       call      qword ptr [7FFC793CF828]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToUpperConversion, System.Private.CoreLib]](System.String)
       mov       rdx,rax
       cmp       r15,rdx
       je        short M00_L03
       test      r15,r15
       je        short M00_L04
       test      rdx,rdx
       je        short M00_L04
       mov       r8d,[r15+8]
       cmp       r8d,[rdx+8]
       jne       short M00_L04
       lea       rcx,[r15+0C]
       add       r8d,r8d
       add       rdx,0C
       call      qword ptr [7FFC790C5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       je        short M00_L04
M00_L03:
       inc       ebx
M00_L04:
       inc       edi
       cmp       ebp,edi
       jg        near ptr M00_L00
M00_L05:
       mov       eax,ebx
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r13
       pop       r14
       pop       r15
       ret
M00_L06:
       mov       ecx,2
       call      CORINFO_HELP_GETSHARED_GCTHREADSTATIC_BASE_NOCTOR_OPTIMIZED
       mov       r14,rax
       jmp       near ptr M00_L00
M00_L07:
       call      qword ptr [7FFC7911E070]; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       mov       rcx,rax
       jmp       near ptr M00_L01
M00_L08:
       call      qword ptr [7FFC7911E070]; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       mov       rcx,rax
       jmp       near ptr M00_L02
; Total bytes of code 384
```
```assembly
; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToUpperConversion, System.Private.CoreLib]](System.String)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,68
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       vmovdqa   xmmword ptr [rsp+40],xmm4
       vmovdqa   xmmword ptr [rsp+50],xmm4
       xor       eax,eax
       mov       [rsp+60],rax
       mov       rsi,rcx
       mov       rbx,rdx
       mov       edi,[rbx+8]
       test      edi,edi
       je        near ptr M01_L13
       lea       rcx,[rbx+0C]
       mov       [rsp+60],rcx
       mov       rbp,[rsp+60]
       xor       r14d,r14d
       cmp       byte ptr [rsi+31],0
       je        near ptr M01_L11
M01_L00:
       cmp       byte ptr [rsi+31],2
       jne       near ptr M01_L17
       cmp       edi,2
       jl        short M01_L02
       lea       eax,[rdi-2]
M01_L01:
       mov       ecx,[rbp+r14*2]
       test      ecx,0FF80FF80
       jne       near ptr M01_L17
       lea       edx,[rcx+1F001F]
       add       ecx,50005
       xor       ecx,edx
       test      ecx,800080
       jne       short M01_L04
       add       r14,2
       cmp       r14,rax
       jbe       short M01_L01
M01_L02:
       test      dil,1
       je        short M01_L03
       movzx     eax,word ptr [rbp+r14*2]
       cmp       eax,7F
       ja        near ptr M01_L17
       add       eax,0FFFFFF9F
       cmp       eax,19
       jbe       short M01_L04
M01_L03:
       mov       rax,rbx
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L04:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       rbp,rax
       lea       r15,[rbp+0C]
       mov       r13d,[rbp+8]
       mov       eax,r14d
       cmp       edi,eax
       jb        near ptr M01_L18
       lea       rdx,[rbx+0C]
       cmp       eax,r13d
       ja        near ptr M01_L20
       mov       r12d,eax
       add       r12,r12
       mov       r8,r12
       mov       rcx,r15
       call      qword ptr [7FFC790C5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       ecx,r14d
       lea       rbx,[rbx+r12+0C]
       sub       edi,ecx
       mov       ecx,r14d
       add       r15,r12
       sub       r13d,ecx
       test      edi,edi
       je        near ptr M01_L10
       xor       ecx,ecx
       mov       [rsp+50],ecx
       cmp       byte ptr [rsi+31],0
       je        short M01_L06
M01_L05:
       cmp       byte ptr [rsi+31],2
       jne       near ptr M01_L16
       imul      ecx,edi,2
       jo        near ptr M01_L14
       imul      eax,r13d,2
       jo        near ptr M01_L14
       test      ecx,ecx
       je        short M01_L08
       test      eax,eax
       je        short M01_L08
       mov       r14,r15
       sub       r14,rbx
       cmp       r14,rcx
       jb        near ptr M01_L15
       jmp       short M01_L07
M01_L06:
       mov       rcx,rsi
       call      qword ptr [7FFC791DF0F0]; System.Globalization.TextInfo.PopulateIsAsciiCasingSameAsInvariant()
       jmp       short M01_L05
M01_L07:
       mov       ecx,eax
       neg       rcx
       cmp       rcx,r14
       jb        near ptr M01_L15
M01_L08:
       cmp       edi,r13d
       jg        short M01_L12
       mov       r14d,edi
       xor       r12d,r12d
M01_L09:
       mov       [rsp+38],rbx
       mov       rcx,rbx
       mov       [rsp+30],r15
       mov       rdx,r15
       mov       r8,r14
       call      qword ptr [7FFC79405D10]; System.Text.Ascii.ChangeCase[[System.UInt16, System.Private.CoreLib],[System.UInt16, System.Private.CoreLib],[System.Text.Ascii+ToUpperConversion, System.Private.CoreLib]](UInt16*, UInt16*, UIntPtr)
       mov       [rsp+50],eax
       mov       ecx,3
       cmp       r14,rax
       cmovne    r12d,ecx
       xor       eax,eax
       mov       [rsp+38],rax
       mov       [rsp+30],rax
       cmp       r12d,3
       je        short M01_L16
M01_L10:
       xor       eax,eax
       mov       [rsp+48],rax
       mov       [rsp+40],rax
       mov       rax,rbp
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L11:
       mov       rcx,rsi
       call      qword ptr [7FFC791DF0F0]; System.Globalization.TextInfo.PopulateIsAsciiCasingSameAsInvariant()
       jmp       near ptr M01_L00
M01_L12:
       mov       r14d,r13d
       mov       r12d,1
       jmp       short M01_L09
M01_L13:
       mov       rax,1DB00200008
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L14:
       call      CORINFO_HELP_OVERFLOW
M01_L15:
       mov       ecx,48
       call      qword ptr [7FFC792A5BA8]
       int       3
M01_L16:
       mov       [rsp+48],rbx
       mov       [rsp+40],r15
       movsxd    rcx,dword ptr [rsp+50]
       lea       rdx,[rbx+rcx*2]
       mov       r8d,edi
       sub       r8d,[rsp+50]
       movsxd    rcx,dword ptr [rsp+50]
       lea       r9,[r15+rcx*2]
       sub       r13d,[rsp+50]
       mov       [rsp+20],r13d
       mov       dword ptr [rsp+28],1
       mov       rcx,rsi
       call      qword ptr [7FFC791DF1B0]
       xor       ecx,ecx
       mov       [rsp+40],rcx
       mov       [rsp+48],rcx
       jmp       near ptr M01_L10
M01_L17:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       r15,rax
       test      r14,r14
       je        short M01_L21
       lea       rcx,[r15+0C]
       mov       eax,[r15+8]
       mov       r13d,r14d
       cmp       edi,r13d
       jae       short M01_L19
M01_L18:
       mov       ecx,21
       call      qword ptr [7FFC792A5B18]
       int       3
M01_L19:
       add       rbx,0C
       mov       rdx,rbx
       cmp       r13d,eax
       ja        short M01_L20
       mov       r8d,r13d
       add       r8,r8
       call      qword ptr [7FFC790C5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M01_L21
M01_L20:
       call      qword ptr [7FFC792A57D0]
       int       3
M01_L21:
       test      r15,r15
       jne       short M01_L22
       xor       r9d,r9d
       jmp       short M01_L23
M01_L22:
       lea       r9,[r15+0C]
       mov       [rsp+58],r9
       mov       r9,[rsp+58]
M01_L23:
       mov       edx,[r15+8]
       sub       edx,r14d
       mov       [rsp+20],edx
       mov       dword ptr [rsp+28],1
       lea       rdx,[rbp+r14*2]
       mov       r8d,edi
       sub       r8d,r14d
       lea       r9,[r9+r14*2]
       mov       rcx,rsi
       call      qword ptr [7FFC791DF1B0]
       xor       eax,eax
       mov       [rsp+58],rax
       mov       rax,r15
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 803
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       cmp       r8,8
       jae       short M02_L03
       cmp       r8,4
       jae       short M02_L02
       xor       eax,eax
       mov       r10,r8
       and       r10,2
       je        short M02_L00
       movzx     eax,word ptr [rcx]
       movzx     r9d,word ptr [rdx]
       sub       eax,r9d
M02_L00:
       test      r8b,1
       je        short M02_L01
       movzx     r8d,byte ptr [rcx+r10]
       movzx     ecx,byte ptr [rdx+r10]
       sub       r8d,ecx
       or        r8d,eax
       mov       eax,r8d
M02_L01:
       test      eax,eax
       sete      al
       movzx     eax,al
       jmp       short M02_L04
M02_L02:
       add       r8,0FFFFFFFFFFFFFFFC
       mov       eax,[rcx]
       sub       eax,[rdx]
       mov       ecx,[rcx+r8]
       sub       ecx,[rdx+r8]
       or        eax,ecx
       sete      al
       movzx     eax,al
       jmp       short M02_L04
M02_L03:
       cmp       rcx,rdx
       je        short M02_L05
       jmp       short M02_L06
M02_L04:
       vzeroupper
       ret
M02_L05:
       mov       eax,1
       vzeroupper
       ret
M02_L06:
       cmp       r8,20
       jb        short M02_L09
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFE0
       je        short M02_L08
M02_L07:
       vmovups   ymm0,[rcx+rax]
       vpcmpnequb k1,ymm0,[rdx+rax]
       kortestd  k1,k1
       nop       dword ptr [rax]
       jne       near ptr M02_L13
       add       rax,20
       cmp       r8,rax
       ja        short M02_L07
M02_L08:
       vmovups   ymm0,[rcx+r8]
       vpcmpeqb  k1,ymm0,[rdx+r8]
       kortestd  k1,k1
       nop       dword ptr [rax]
       jae       short M02_L13
       jmp       short M02_L05
       xchg      ax,ax
M02_L09:
       cmp       r8,10
       jb        short M02_L12
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFF0
       je        short M02_L11
M02_L10:
       vmovups   xmm0,[rcx+rax]
       vpcmpnequb k1,xmm0,[rdx+rax]
       kortestw  k1,k1
       jne       short M02_L13
       add       rax,10
       cmp       r8,rax
       ja        short M02_L10
M02_L11:
       vmovups   xmm0,[rcx+r8]
       vpcmpeqb  k1,xmm0,[rdx+r8]
       kortestw  k1,k1
       jae       short M02_L13
       jmp       near ptr M02_L05
M02_L12:
       lea       rax,[r8-8]
       mov       r8,[rcx]
       sub       r8,[rdx]
       mov       rcx,[rcx+rax]
       sub       rcx,[rdx+rax]
       or        rcx,r8
       sete      al
       movzx     eax,al
       jmp       near ptr M02_L04
M02_L13:
       xor       eax,eax
       vzeroupper
       ret
; Total bytes of code 298
```
```assembly
; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       push      rsi
       push      rbx
       sub       rsp,28
       call      qword ptr [7FFCD34A31F0]
       mov       rbx,rax
       lea       rsi,[rbx+3E0]
       call      qword ptr [7FFCD34B6B48]
       mov       rdx,rax
       mov       rcx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFCD34B7B40]; System.Threading.Interlocked.CompareExchange(System.Object ByRef, System.Object, System.Object)
       mov       rax,[rbx+3E0]
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 57
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.ToLowerInvariant()
       push      r15
       push      r14
       push      r13
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       xor       edi,edi
       mov       ebp,[rsi+8]
       test      ebp,ebp
       jle       short M00_L03
M00_L00:
       mov       ecx,edi
       shl       rcx,4
       lea       rcx,[rsi+rcx+10]
       mov       rdx,[rcx]
       mov       r14,[rcx+8]
       cmp       [rdx],dl
       mov       rcx,19C4E800590
       mov       r15,[rcx]
       mov       rcx,r15
       call      qword ptr [7FFC794B7378]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToLowerConversion, System.Private.CoreLib]](System.String)
       mov       r13,rax
       cmp       [r14],r14b
       mov       rcx,r15
       mov       rdx,r14
       call      qword ptr [7FFC794B7378]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToLowerConversion, System.Private.CoreLib]](System.String)
       mov       rdx,rax
       cmp       r13,rdx
       je        short M00_L01
       test      r13,r13
       je        short M00_L02
       test      rdx,rdx
       je        short M00_L02
       mov       r8d,[r13+8]
       cmp       r8d,[rdx+8]
       jne       short M00_L02
       lea       rcx,[r13+0C]
       mov       r8d,[r13+8]
       add       r8d,r8d
       add       rdx,0C
       call      qword ptr [7FFC790F5068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       je        short M00_L02
M00_L01:
       inc       ebx
M00_L02:
       inc       edi
       cmp       ebp,edi
       jg        short M00_L00
M00_L03:
       mov       eax,ebx
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 167
```
```assembly
; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToLowerConversion, System.Private.CoreLib]](System.String)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,68
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       vmovdqa   xmmword ptr [rsp+40],xmm4
       vmovdqa   xmmword ptr [rsp+50],xmm4
       xor       eax,eax
       mov       [rsp+60],rax
       mov       rsi,rcx
       mov       rbx,rdx
       mov       edi,[rbx+8]
       test      edi,edi
       je        near ptr M01_L13
       lea       rcx,[rbx+0C]
       mov       [rsp+60],rcx
       mov       rbp,[rsp+60]
       xor       r14d,r14d
       cmp       byte ptr [rsi+31],0
       je        near ptr M01_L11
M01_L00:
       cmp       byte ptr [rsi+31],2
       jne       near ptr M01_L17
       cmp       edi,2
       jl        short M01_L02
       lea       eax,[rdi-2]
M01_L01:
       mov       ecx,[rbp+r14*2]
       test      ecx,0FF80FF80
       jne       near ptr M01_L17
       lea       edx,[rcx+3F003F]
       add       ecx,250025
       xor       ecx,edx
       test      ecx,800080
       jne       short M01_L04
       add       r14,2
       cmp       r14,rax
       jbe       short M01_L01
M01_L02:
       test      dil,1
       je        short M01_L03
       movzx     eax,word ptr [rbp+r14*2]
       cmp       eax,7F
       ja        near ptr M01_L17
       add       eax,0FFFFFFBF
       cmp       eax,19
       jbe       short M01_L04
M01_L03:
       mov       rax,rbx
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L04:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       rbp,rax
       lea       r15,[rbp+0C]
       mov       r13d,[rbp+8]
       mov       eax,r14d
       cmp       edi,eax
       jb        near ptr M01_L18
       lea       rdx,[rbx+0C]
       cmp       eax,r13d
       ja        near ptr M01_L20
       mov       r12d,eax
       mov       r8,r12
       add       r8,r8
       mov       rcx,r15
       call      qword ptr [7FFC790F5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       ecx,r14d
       lea       rbx,[rbx+r12*2+0C]
       sub       edi,ecx
       mov       ecx,r14d
       lea       r14,[r15+r12*2]
       sub       r13d,ecx
       test      edi,edi
       je        near ptr M01_L10
       xor       ecx,ecx
       mov       [rsp+50],ecx
       cmp       byte ptr [rsi+31],0
       je        short M01_L06
M01_L05:
       cmp       byte ptr [rsi+31],2
       jne       near ptr M01_L16
       imul      ecx,edi,2
       jo        near ptr M01_L14
       imul      eax,r13d,2
       jo        near ptr M01_L14
       test      ecx,ecx
       je        short M01_L08
       test      eax,eax
       je        short M01_L08
       mov       r15,r14
       sub       r15,rbx
       cmp       r15,rcx
       jb        near ptr M01_L15
       jmp       short M01_L07
M01_L06:
       mov       rcx,rsi
       call      qword ptr [7FFC7920F0F0]
       jmp       short M01_L05
M01_L07:
       mov       ecx,eax
       neg       rcx
       cmp       rcx,r15
       jb        near ptr M01_L15
M01_L08:
       cmp       edi,r13d
       jg        short M01_L12
       mov       r15d,edi
       xor       r12d,r12d
M01_L09:
       mov       [rsp+38],rbx
       mov       rcx,rbx
       mov       [rsp+30],r14
       mov       rdx,r14
       mov       r8,r15
       call      qword ptr [7FFC794B73A8]; System.Text.Ascii.ChangeCase[[System.UInt16, System.Private.CoreLib],[System.UInt16, System.Private.CoreLib],[System.Text.Ascii+ToLowerConversion, System.Private.CoreLib]](UInt16*, UInt16*, UIntPtr)
       mov       [rsp+50],eax
       mov       ecx,3
       cmp       r15,rax
       cmovne    r12d,ecx
       xor       eax,eax
       mov       [rsp+38],rax
       mov       [rsp+30],rax
       cmp       r12d,3
       je        short M01_L16
M01_L10:
       xor       eax,eax
       mov       [rsp+48],rax
       mov       [rsp+40],rax
       mov       rax,rbp
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L11:
       mov       rcx,rsi
       call      qword ptr [7FFC7920F0F0]
       jmp       near ptr M01_L00
M01_L12:
       mov       r15d,r13d
       mov       r12d,1
       jmp       short M01_L09
M01_L13:
       mov       rax,19C00300008
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L14:
       call      CORINFO_HELP_OVERFLOW
M01_L15:
       mov       ecx,48
       call      qword ptr [7FFC792D5BA8]
       int       3
M01_L16:
       mov       [rsp+48],rbx
       mov       [rsp+40],r14
       movsxd    rcx,dword ptr [rsp+50]
       lea       rdx,[rbx+rcx*2]
       mov       r8d,edi
       sub       r8d,[rsp+50]
       movsxd    rcx,dword ptr [rsp+50]
       lea       r9,[r14+rcx*2]
       sub       r13d,[rsp+50]
       mov       [rsp+20],r13d
       xor       ecx,ecx
       mov       [rsp+28],ecx
       mov       rcx,rsi
       call      qword ptr [7FFC7920F1B0]
       xor       ecx,ecx
       mov       [rsp+40],rcx
       mov       [rsp+48],rcx
       jmp       near ptr M01_L10
M01_L17:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       r15,rax
       test      r14,r14
       je        short M01_L21
       lea       rcx,[r15+0C]
       mov       eax,[r15+8]
       mov       r13d,r14d
       cmp       edi,r13d
       jae       short M01_L19
M01_L18:
       mov       ecx,21
       call      qword ptr [7FFC792D5B18]
       int       3
M01_L19:
       add       rbx,0C
       mov       rdx,rbx
       cmp       r13d,eax
       ja        short M01_L20
       mov       r8d,r13d
       add       r8,r8
       call      qword ptr [7FFC790F5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M01_L21
M01_L20:
       call      qword ptr [7FFC792D57D0]
       int       3
M01_L21:
       test      r15,r15
       jne       short M01_L22
       xor       r9d,r9d
       jmp       short M01_L23
M01_L22:
       lea       r9,[r15+0C]
       mov       [rsp+58],r9
       mov       r9,[rsp+58]
M01_L23:
       mov       edx,[r15+8]
       sub       edx,r14d
       mov       [rsp+20],edx
       xor       edx,edx
       mov       [rsp+28],edx
       lea       rdx,[rbp+r14*2]
       mov       r8d,edi
       sub       r8d,r14d
       lea       r9,[r9+r14*2]
       mov       rcx,rsi
       call      qword ptr [7FFC7920F1B0]
       xor       eax,eax
       mov       [rsp+58],rax
       mov       rax,r15
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 800
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       cmp       r8,8
       jae       short M02_L03
       cmp       r8,4
       jae       short M02_L02
       xor       eax,eax
       mov       r10,r8
       and       r10,2
       je        short M02_L00
       movzx     eax,word ptr [rcx]
       movzx     r9d,word ptr [rdx]
       sub       eax,r9d
M02_L00:
       test      r8b,1
       je        short M02_L01
       movzx     r8d,byte ptr [rcx+r10]
       movzx     ecx,byte ptr [rdx+r10]
       sub       r8d,ecx
       or        r8d,eax
       mov       eax,r8d
M02_L01:
       test      eax,eax
       sete      al
       movzx     eax,al
       jmp       short M02_L04
M02_L02:
       add       r8,0FFFFFFFFFFFFFFFC
       mov       eax,[rcx]
       sub       eax,[rdx]
       mov       ecx,[rcx+r8]
       sub       ecx,[rdx+r8]
       or        eax,ecx
       sete      al
       movzx     eax,al
       jmp       short M02_L04
M02_L03:
       cmp       rcx,rdx
       je        short M02_L05
       jmp       short M02_L06
M02_L04:
       vzeroupper
       ret
M02_L05:
       mov       eax,1
       vzeroupper
       ret
M02_L06:
       cmp       r8,20
       jb        short M02_L09
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFE0
       je        short M02_L08
M02_L07:
       vmovups   ymm0,[rcx+rax]
       vpcmpnequb k1,ymm0,[rdx+rax]
       kortestd  k1,k1
       nop       dword ptr [rax]
       jne       near ptr M02_L13
       add       rax,20
       cmp       r8,rax
       ja        short M02_L07
M02_L08:
       vmovups   ymm0,[rcx+r8]
       vpcmpeqb  k1,ymm0,[rdx+r8]
       kortestd  k1,k1
       nop       dword ptr [rax]
       jae       short M02_L13
       jmp       short M02_L05
       xchg      ax,ax
M02_L09:
       cmp       r8,10
       jb        short M02_L12
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFF0
       je        short M02_L11
M02_L10:
       vmovups   xmm0,[rcx+rax]
       vpcmpnequb k1,xmm0,[rdx+rax]
       kortestw  k1,k1
       jne       short M02_L13
       add       rax,10
       cmp       r8,rax
       ja        short M02_L10
M02_L11:
       vmovups   xmm0,[rcx+r8]
       vpcmpeqb  k1,xmm0,[rdx+r8]
       kortestw  k1,k1
       jae       short M02_L13
       jmp       near ptr M02_L05
M02_L12:
       lea       rax,[r8-8]
       mov       r8,[rcx]
       sub       r8,[rdx]
       mov       rcx,[rcx+rax]
       sub       rcx,[rdx+rax]
       or        rcx,r8
       sete      al
       movzx     eax,al
       jmp       near ptr M02_L04
M02_L13:
       xor       eax,eax
       vzeroupper
       ret
; Total bytes of code 298
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.ToUpperInvariant()
       push      r15
       push      r14
       push      r13
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       xor       edi,edi
       mov       ebp,[rsi+8]
       test      ebp,ebp
       jle       short M00_L03
M00_L00:
       mov       ecx,edi
       shl       rcx,4
       lea       rcx,[rsi+rcx+10]
       mov       rdx,[rcx]
       mov       r14,[rcx+8]
       cmp       [rdx],dl
       mov       rcx,2A282800590
       mov       r15,[rcx]
       mov       rcx,r15
       call      qword ptr [7FFC7940F828]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToUpperConversion, System.Private.CoreLib]](System.String)
       mov       r13,rax
       cmp       [r14],r14b
       mov       rcx,r15
       mov       rdx,r14
       call      qword ptr [7FFC7940F828]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToUpperConversion, System.Private.CoreLib]](System.String)
       mov       rdx,rax
       cmp       r13,rdx
       je        short M00_L01
       test      r13,r13
       je        short M00_L02
       test      rdx,rdx
       je        short M00_L02
       mov       r8d,[r13+8]
       cmp       r8d,[rdx+8]
       jne       short M00_L02
       lea       rcx,[r13+0C]
       mov       r8d,[r13+8]
       add       r8d,r8d
       add       rdx,0C
       call      qword ptr [7FFC79105068]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       test      eax,eax
       je        short M00_L02
M00_L01:
       inc       ebx
M00_L02:
       inc       edi
       cmp       ebp,edi
       jg        short M00_L00
M00_L03:
       mov       eax,ebx
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 167
```
```assembly
; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToUpperConversion, System.Private.CoreLib]](System.String)
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,68
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       vmovdqa   xmmword ptr [rsp+40],xmm4
       vmovdqa   xmmword ptr [rsp+50],xmm4
       xor       eax,eax
       mov       [rsp+60],rax
       mov       rsi,rcx
       mov       rbx,rdx
       mov       edi,[rbx+8]
       test      edi,edi
       je        near ptr M01_L13
       lea       rcx,[rbx+0C]
       mov       [rsp+60],rcx
       mov       rbp,[rsp+60]
       xor       r14d,r14d
       cmp       byte ptr [rsi+31],0
       je        near ptr M01_L11
M01_L00:
       cmp       byte ptr [rsi+31],2
       jne       near ptr M01_L17
       cmp       edi,2
       jl        short M01_L02
       lea       eax,[rdi-2]
M01_L01:
       mov       ecx,[rbp+r14*2]
       test      ecx,0FF80FF80
       jne       near ptr M01_L17
       lea       edx,[rcx+1F001F]
       add       ecx,50005
       xor       ecx,edx
       test      ecx,800080
       jne       short M01_L04
       add       r14,2
       cmp       r14,rax
       jbe       short M01_L01
M01_L02:
       test      dil,1
       je        short M01_L03
       movzx     eax,word ptr [rbp+r14*2]
       cmp       eax,7F
       ja        near ptr M01_L17
       add       eax,0FFFFFF9F
       cmp       eax,19
       jbe       short M01_L04
M01_L03:
       mov       rax,rbx
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L04:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       rbp,rax
       lea       r15,[rbp+0C]
       mov       r13d,[rbp+8]
       mov       eax,r14d
       cmp       edi,eax
       jb        near ptr M01_L18
       lea       rdx,[rbx+0C]
       cmp       eax,r13d
       ja        near ptr M01_L20
       mov       r12d,eax
       add       r12,r12
       mov       r8,r12
       mov       rcx,r15
       call      qword ptr [7FFC79105B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       ecx,r14d
       lea       rbx,[rbx+r12+0C]
       sub       edi,ecx
       mov       ecx,r14d
       add       r15,r12
       sub       r13d,ecx
       test      edi,edi
       je        near ptr M01_L10
       xor       ecx,ecx
       mov       [rsp+50],ecx
       cmp       byte ptr [rsi+31],0
       je        short M01_L06
M01_L05:
       cmp       byte ptr [rsi+31],2
       jne       near ptr M01_L16
       imul      ecx,edi,2
       jo        near ptr M01_L14
       imul      eax,r13d,2
       jo        near ptr M01_L14
       test      ecx,ecx
       je        short M01_L08
       test      eax,eax
       je        short M01_L08
       mov       r14,r15
       sub       r14,rbx
       cmp       r14,rcx
       jb        near ptr M01_L15
       jmp       short M01_L07
M01_L06:
       mov       rcx,rsi
       call      qword ptr [7FFC7921F0F0]
       jmp       short M01_L05
M01_L07:
       mov       ecx,eax
       neg       rcx
       cmp       rcx,r14
       jb        near ptr M01_L15
M01_L08:
       cmp       edi,r13d
       jg        short M01_L12
       mov       r14d,edi
       xor       r12d,r12d
M01_L09:
       mov       [rsp+38],rbx
       mov       rcx,rbx
       mov       [rsp+30],r15
       mov       rdx,r15
       mov       r8,r14
       call      qword ptr [7FFC79445D10]; System.Text.Ascii.ChangeCase[[System.UInt16, System.Private.CoreLib],[System.UInt16, System.Private.CoreLib],[System.Text.Ascii+ToUpperConversion, System.Private.CoreLib]](UInt16*, UInt16*, UIntPtr)
       mov       [rsp+50],eax
       mov       ecx,3
       cmp       r14,rax
       cmovne    r12d,ecx
       xor       eax,eax
       mov       [rsp+38],rax
       mov       [rsp+30],rax
       cmp       r12d,3
       je        short M01_L16
M01_L10:
       xor       eax,eax
       mov       [rsp+48],rax
       mov       [rsp+40],rax
       mov       rax,rbp
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L11:
       mov       rcx,rsi
       call      qword ptr [7FFC7921F0F0]
       jmp       near ptr M01_L00
M01_L12:
       mov       r14d,r13d
       mov       r12d,1
       jmp       short M01_L09
M01_L13:
       mov       rax,2A280200008
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M01_L14:
       call      CORINFO_HELP_OVERFLOW
M01_L15:
       mov       ecx,48
       call      qword ptr [7FFC792E5BA8]
       int       3
M01_L16:
       mov       [rsp+48],rbx
       mov       [rsp+40],r15
       movsxd    rcx,dword ptr [rsp+50]
       lea       rdx,[rbx+rcx*2]
       mov       r8d,edi
       sub       r8d,[rsp+50]
       movsxd    rcx,dword ptr [rsp+50]
       lea       r9,[r15+rcx*2]
       sub       r13d,[rsp+50]
       mov       [rsp+20],r13d
       mov       dword ptr [rsp+28],1
       mov       rcx,rsi
       call      qword ptr [7FFC7921F1B0]
       xor       ecx,ecx
       mov       [rsp+40],rcx
       mov       [rsp+48],rcx
       jmp       near ptr M01_L10
M01_L17:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       r15,rax
       test      r14,r14
       je        short M01_L21
       lea       rcx,[r15+0C]
       mov       eax,[r15+8]
       mov       r13d,r14d
       cmp       edi,r13d
       jae       short M01_L19
M01_L18:
       mov       ecx,21
       call      qword ptr [7FFC792E5B18]
       int       3
M01_L19:
       add       rbx,0C
       mov       rdx,rbx
       cmp       r13d,eax
       ja        short M01_L20
       mov       r8d,r13d
       add       r8,r8
       call      qword ptr [7FFC79105B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M01_L21
M01_L20:
       call      qword ptr [7FFC792E57D0]
       int       3
M01_L21:
       test      r15,r15
       jne       short M01_L22
       xor       r9d,r9d
       jmp       short M01_L23
M01_L22:
       lea       r9,[r15+0C]
       mov       [rsp+58],r9
       mov       r9,[rsp+58]
M01_L23:
       mov       edx,[r15+8]
       sub       edx,r14d
       mov       [rsp+20],edx
       mov       dword ptr [rsp+28],1
       lea       rdx,[rbp+r14*2]
       mov       r8d,edi
       sub       r8d,r14d
       lea       r9,[r9+r14*2]
       mov       rcx,rsi
       call      qword ptr [7FFC7921F1B0]
       xor       eax,eax
       mov       [rsp+58],rax
       mov       rax,r15
       add       rsp,68
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
; Total bytes of code 803
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       cmp       r8,8
       jae       short M02_L03
       cmp       r8,4
       jae       short M02_L02
       xor       eax,eax
       mov       r10,r8
       and       r10,2
       je        short M02_L00
       movzx     eax,word ptr [rcx]
       movzx     r9d,word ptr [rdx]
       sub       eax,r9d
M02_L00:
       test      r8b,1
       je        short M02_L01
       movzx     r8d,byte ptr [rcx+r10]
       movzx     ecx,byte ptr [rdx+r10]
       sub       r8d,ecx
       or        r8d,eax
       mov       eax,r8d
M02_L01:
       test      eax,eax
       sete      al
       movzx     eax,al
       jmp       short M02_L04
M02_L02:
       add       r8,0FFFFFFFFFFFFFFFC
       mov       eax,[rcx]
       sub       eax,[rdx]
       mov       ecx,[rcx+r8]
       sub       ecx,[rdx+r8]
       or        eax,ecx
       sete      al
       movzx     eax,al
       jmp       short M02_L04
M02_L03:
       cmp       rcx,rdx
       je        short M02_L05
       jmp       short M02_L06
M02_L04:
       vzeroupper
       ret
M02_L05:
       mov       eax,1
       vzeroupper
       ret
M02_L06:
       cmp       r8,20
       jb        short M02_L09
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFE0
       je        short M02_L08
M02_L07:
       vmovups   ymm0,[rcx+rax]
       vpcmpnequb k1,ymm0,[rdx+rax]
       kortestd  k1,k1
       nop       dword ptr [rax]
       jne       near ptr M02_L13
       add       rax,20
       cmp       r8,rax
       ja        short M02_L07
M02_L08:
       vmovups   ymm0,[rcx+r8]
       vpcmpeqb  k1,ymm0,[rdx+r8]
       kortestd  k1,k1
       nop       dword ptr [rax]
       jae       short M02_L13
       jmp       short M02_L05
       xchg      ax,ax
M02_L09:
       cmp       r8,10
       jb        short M02_L12
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFF0
       je        short M02_L11
M02_L10:
       vmovups   xmm0,[rcx+rax]
       vpcmpnequb k1,xmm0,[rdx+rax]
       kortestw  k1,k1
       jne       short M02_L13
       add       rax,10
       cmp       r8,rax
       ja        short M02_L10
M02_L11:
       vmovups   xmm0,[rcx+r8]
       vpcmpeqb  k1,xmm0,[rdx+r8]
       kortestw  k1,k1
       jae       short M02_L13
       jmp       near ptr M02_L05
M02_L12:
       lea       rax,[r8-8]
       mov       r8,[rcx]
       sub       r8,[rdx]
       mov       rcx,[rcx+rax]
       sub       rcx,[rdx+rax]
       or        rcx,r8
       sete      al
       movzx     eax,al
       jmp       near ptr M02_L04
M02_L13:
       xor       eax,eax
       vzeroupper
       ret
; Total bytes of code 298
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.StringComparisonIgnoreCaseFlag()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       xor       edi,edi
       mov       ebp,[rsi+8]
       test      ebp,ebp
       jle       short M00_L02
M00_L00:
       mov       ecx,edi
       shl       rcx,4
       lea       rcx,[rsi+rcx+10]
       mov       rdx,[rcx]
       mov       r8,[rcx+8]
       mov       rcx,rdx
       mov       rdx,r8
       mov       r8d,1
       call      qword ptr [7FFC79035FE0]; System.String.Compare(System.String, System.String, System.StringComparison)
       test      eax,eax
       jne       short M00_L01
       inc       ebx
M00_L01:
       inc       edi
       cmp       ebp,edi
       jg        short M00_L00
M00_L02:
       mov       eax,ebx
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 82
```
```assembly
; System.String.Compare(System.String, System.String, System.StringComparison)
       push      r15
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,48
       xor       eax,eax
       mov       [rsp+28],rax
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       mov       [rsp+40],rax
       mov       rbx,rcx
       mov       rsi,rdx
       mov       edi,r8d
M01_L00:
       cmp       rbx,rsi
       je        short M01_L01
       test      rbx,rbx
       je        near ptr M01_L06
       test      rsi,rsi
       je        near ptr M01_L07
       cmp       edi,5
       ja        near ptr M01_L17
       mov       ecx,edi
       lea       rdx,[7FFC79068F48]
       mov       edx,[rdx+rcx*4]
       lea       r8,[M01_L00]
       add       rdx,r8
       jmp       rdx
       mov       rcx,gs:[58]
       mov       rcx,[rcx+48]
       cmp       dword ptr [rcx+188],2
       jl        near ptr M01_L10
       mov       rcx,[rcx+190]
       mov       rcx,[rcx+10]
       test      rcx,rcx
       je        near ptr M01_L10
       mov       rax,[rcx]
       add       rax,10
       jmp       short M01_L02
M01_L01:
       cmp       edi,5
       ja        near ptr M01_L08
       xor       eax,eax
       add       rsp,48
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M01_L02:
       mov       rcx,[rax+8]
       test      rcx,rcx
       jne       short M01_L03
       mov       rcx,26E62C00438
       mov       rcx,[rcx]
       test      rcx,rcx
       jne       short M01_L03
       mov       rcx,26E62C00418
       mov       rcx,[rcx]
       test      rcx,rcx
       je        near ptr M01_L11
M01_L03:
       mov       rdx,offset MT_System.Globalization.CultureInfo
       cmp       [rcx],rdx
       jne       near ptr M01_L15
       mov       rbp,rcx
       mov       rcx,[rbp+8]
       test      rcx,rcx
       je        near ptr M01_L12
M01_L04:
       mov       r9d,edi
       and       r9d,1
       cmp       [rcx],cl
       lea       rdx,[rbx+0C]
       mov       r8d,[rbx+8]
       lea       rax,[rsi+0C]
       mov       r10d,[rsi+8]
       mov       [rsp+38],rdx
       mov       [rsp+40],r8d
       mov       [rsp+28],rax
       mov       [rsp+30],r10d
       lea       rdx,[rsp+38]
       lea       r8,[rsp+28]
       call      qword ptr [7FFC793B5278]; System.Globalization.CompareInfo.Compare(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>, System.Globalization.CompareOptions)
M01_L05:
       nop
       add       rsp,48
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M01_L06:
       cmp       edi,5
       ja        short M01_L08
       mov       eax,0FFFFFFFF
       add       rsp,48
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M01_L07:
       cmp       edi,5
       jbe       short M01_L09
M01_L08:
       mov       ecx,1B
       mov       edx,29
       call      qword ptr [7FFC792C5AA0]
       int       3
M01_L09:
       mov       eax,1
       add       rsp,48
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       pop       r15
       ret
M01_L10:
       mov       ecx,2
       call      CORINFO_HELP_GETSHARED_GCTHREADSTATIC_BASE_NOCTOR_OPTIMIZED
       jmp       near ptr M01_L02
M01_L11:
       call      qword ptr [7FFC7913E070]; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       mov       rcx,rax
       jmp       near ptr M01_L03
M01_L12:
       mov       rcx,[rbp+30]
       mov       r14,rbp
       cmp       byte ptr [rcx+1B9],0
       jne       short M01_L13
       mov       rcx,offset MT_System.Globalization.CompareInfo
       call      CORINFO_HELP_NEWSFAST
       mov       r15,rax
       mov       rcx,r15
       mov       rdx,r14
       call      qword ptr [7FFC793B5050]
       jmp       short M01_L14
M01_L13:
       mov       r14,rbp
       mov       rcx,[r14+40]
       call      qword ptr [7FFC7913E670]; System.Globalization.CultureInfo.GetCultureInfo(System.String)
       mov       rcx,rax
       mov       rax,[rax]
       mov       rax,[rax+48]
       call      qword ptr [rax+30]
       mov       r15,rax
M01_L14:
       lea       rcx,[r14+8]
       mov       rdx,r15
       call      CORINFO_HELP_ASSIGN_REF
       mov       rcx,r15
       jmp       near ptr M01_L04
M01_L15:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       call      qword ptr [rax+30]
       mov       rcx,rax
       jmp       near ptr M01_L04
       mov       rcx,7FFC78F75120
       mov       edx,24F
       call      CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE
       mov       rcx,26E62C003D8
       mov       rcx,[rcx]
       mov       r9d,edi
       and       r9d,1
       mov       rdx,rbx
       mov       r8,rsi
       cmp       [rcx],ecx
       call      qword ptr [7FFC793B51E8]; System.Globalization.CompareInfo.Compare(System.String, System.String, System.Globalization.CompareOptions)
       jmp       near ptr M01_L05
       movzx     eax,word ptr [rbx+0C]
       cmp       ax,[rsi+0C]
       je        short M01_L16
       movzx     eax,word ptr [rbx+0C]
       movzx     ecx,word ptr [rsi+0C]
       sub       eax,ecx
       jmp       near ptr M01_L05
M01_L16:
       mov       rcx,rbx
       mov       rdx,rsi
       call      qword ptr [7FFC79035F98]; System.String.CompareOrdinalHelper(System.String, System.String)
       jmp       near ptr M01_L05
       lea       rcx,[rbx+0C]
       mov       edx,[rbx+8]
       lea       r8,[rsi+0C]
       mov       r9d,[rsi+8]
       call      qword ptr [7FFC794A76F0]
       jmp       near ptr M01_L05
M01_L17:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      qword ptr [7FFC794B5338]
       mov       rsi,rax
       mov       ecx,16F3
       mov       rdx,7FFC78EE4000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbx
       call      qword ptr [7FFC7903F750]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 742
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.StringComparisonOrdinalIgnoreCase()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       xor       edi,edi
       cmp       dword ptr [rsi+8],0
       jle       short M00_L03
M00_L00:
       mov       r8d,edi
       shl       r8,4
       lea       r8,[rsi+r8+10]
       mov       r9,[r8]
       mov       rcx,[r8+8]
       cmp       r9,rcx
       je        short M00_L01
       test      r9,r9
       je        short M00_L02
       test      rcx,rcx
       je        short M00_L02
       lea       rdx,[r9+0C]
       mov       eax,[r9+8]
       lea       r8,[rcx+0C]
       mov       r9d,[rcx+8]
       mov       rcx,rdx
       mov       edx,eax
       call      qword ptr [7FFC794A7378]; System.Globalization.Ordinal.CompareStringIgnoreCase(Char ByRef, Int32, Char ByRef, Int32)
       test      eax,eax
       jne       short M00_L02
M00_L01:
       inc       ebx
M00_L02:
       inc       edi
       cmp       [rsi+8],edi
       jg        short M00_L00
M00_L03:
       mov       eax,ebx
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 105
```
```assembly
; System.Globalization.Ordinal.CompareStringIgnoreCase(Char ByRef, Int32, Char ByRef, Int32)
       push      rdi
       push      rsi
       push      rbx
       cmp       edx,r9d
       mov       eax,r9d
       cmovle    eax,edx
       mov       r10d,eax
       jmp       short M01_L02
M01_L00:
       cmp       r11d,ebx
       jne       short M01_L04
M01_L01:
       dec       eax
       add       rcx,2
       add       r8,2
M01_L02:
       test      eax,eax
       je        short M01_L03
       movzx     r11d,word ptr [rcx]
       cmp       r11d,7F
       jg        short M01_L06
       movzx     ebx,word ptr [r8]
       cmp       ebx,7F
       jle       short M01_L00
M01_L03:
       test      eax,eax
       jne       short M01_L06
       mov       eax,edx
       sub       eax,r9d
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L04:
       mov       esi,r11d
       or        esi,20
       mov       edi,ebx
       or        edi,20
       cmp       esi,edi
       jne       short M01_L05
       add       esi,0FFFFFF9F
       cmp       esi,19
       jbe       short M01_L01
M01_L05:
       mov       eax,r11d
       mov       r10d,ebx
       add       r11d,0FFFFFF9F
       lea       r9d,[rax-20]
       cmp       r11d,19
       cmovbe    eax,r9d
       add       ebx,0FFFFFF9F
       lea       r9d,[r10-20]
       cmp       ebx,19
       cmovbe    r10d,r9d
       sub       eax,r10d
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L06:
       sub       r10d,eax
       sub       r9d,r10d
       sub       edx,r10d
       pop       rbx
       pop       rsi
       pop       rdi
       jmp       qword ptr [7FFC794A7390]
; Total bytes of code 152
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.StringComparisonInvariantCultureIgnoreCase()
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,40
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+20],xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       xor       edi,edi
       cmp       dword ptr [rsi+8],0
       jle       short M00_L02
M00_L00:
       mov       ecx,edi
       shl       rcx,4
       lea       rcx,[rsi+rcx+10]
       mov       rdx,[rcx]
       mov       rcx,[rcx+8]
       cmp       rdx,rcx
       je        short M00_L03
       test      rdx,rdx
       je        short M00_L01
       test      rcx,rcx
       je        short M00_L01
       mov       r8,1A627C003D8
       mov       r8,[r8]
       lea       r9,[rdx+0C]
       mov       edx,[rdx+8]
       lea       rax,[rcx+0C]
       mov       ecx,[rcx+8]
       mov       [rsp+30],r9
       mov       [rsp+38],edx
       mov       [rsp+20],rax
       mov       [rsp+28],ecx
       mov       rcx,r8
       lea       rdx,[rsp+30]
       lea       r8,[rsp+20]
       mov       r9d,1
       call      qword ptr [7FFC793C5278]; System.Globalization.CompareInfo.Compare(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>, System.Globalization.CompareOptions)
       test      eax,eax
       je        short M00_L03
M00_L01:
       inc       edi
       cmp       [rsi+8],edi
       jg        short M00_L00
M00_L02:
       mov       eax,ebx
       add       rsp,40
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M00_L03:
       inc       ebx
       jmp       short M00_L01
; Total bytes of code 165
```
```assembly
; System.Globalization.CompareInfo.Compare(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>, System.Globalization.CompareOptions)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,0A8
       lea       rbp,[rsp+0E0]
       xor       ebx,ebx
       mov       [rbp-40],rbx
       mov       [rbp-48],rbx
       mov       r14,rcx
       mov       rbx,rdx
       mov       rsi,r8
       mov       edi,r9d
       lea       rcx,[rbp-0A0]
       mov       rdx,r10
       call      CORINFO_HELP_INIT_PINVOKE_FRAME
       mov       r15,rax
       mov       rcx,rsp
       mov       [rbp-80],rcx
       mov       rcx,rbp
       mov       [rbp-70],rcx
       mov       r8,[rsi]
       mov       r9d,[rsi+8]
       mov       rcx,[rbx]
       mov       edx,[rbx+8]
       cmp       edx,r9d
       je        near ptr M01_L03
M01_L00:
       test      edi,0DFFFFFE0
       jne       near ptr M01_L05
       mov       [rbp-40],rcx
       mov       [rbp-48],r8
       mov       rax,[r14+20]
       mov       [rbp-50],rcx
       mov       [rbp-54],edx
       mov       [rbp-60],r8
       mov       [rsp+20],r9d
       mov       [rsp+28],edi
       mov       rcx,rax
       mov       rdx,[rbp-50]
       mov       r8d,[rbp-54]
       mov       r9,[rbp-60]
       mov       rax,offset MD_Interop+Globalization.CompareString(IntPtr, Char*, Int32, Char*, Int32, System.Globalization.CompareOptions)
       mov       [rbp-90],rax
       lea       rax,[M01_L01]
       mov       [rbp-78],rax
       lea       rax,[rbp-0A0]
       mov       [r15+10],rax
       mov       byte ptr [r15+0C],0
       mov       rax,7FFCD8B7B2B0
       call      rax
M01_L01:
       mov       byte ptr [r15+0C],1
       cmp       dword ptr [7FFCD8EE605C],0
       je        short M01_L02
       call      qword ptr [7FFCD8ED6398]; CORINFO_HELP_STOP_FOR_GC
M01_L02:
       mov       rcx,[rbp-98]
       mov       [r15+10],rcx
       jmp       short M01_L04
M01_L03:
       cmp       rcx,r8
       jne       near ptr M01_L00
       jmp       short M01_L08
M01_L04:
       add       rsp,0A8
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
M01_L05:
       cmp       edi,40000000
       jne       short M01_L06
       call      qword ptr [7FFC790F51D0]
       jmp       short M01_L04
M01_L06:
       cmp       edi,10000000
       jne       short M01_L07
       call      qword ptr [7FFC794F5AB8]
       jmp       short M01_L04
M01_L07:
       mov       ecx,edi
       call      qword ptr [7FFC793C52A8]
       int       3
M01_L08:
       test      edi,0DFFFFFE0
       je        short M01_L09
       cmp       edi,40000000
       je        short M01_L09
       cmp       edi,10000000
       jne       short M01_L07
M01_L09:
       xor       eax,eax
       jmp       short M01_L04
; Total bytes of code 351
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; Test.Benchmark.StringComparisonCurrentCultureIgnoreCase()
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,48
       xor       eax,eax
       mov       [rsp+28],rax
       vxorps    xmm4,xmm4,xmm4
       vmovdqa   xmmword ptr [rsp+30],xmm4
       mov       [rsp+40],rax
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       xor       edi,edi
       cmp       dword ptr [rsi+8],0
       jle       near ptr M00_L05
M00_L00:
       mov       ecx,edi
       shl       rcx,4
       lea       rcx,[rsi+rcx+10]
       mov       rbp,[rcx]
       mov       r14,[rcx+8]
       cmp       rbp,r14
       je        near ptr M00_L06
       test      rbp,rbp
       je        near ptr M00_L04
       test      r14,r14
       je        near ptr M00_L04
       mov       rcx,gs:[58]
       mov       rcx,[rcx+48]
       cmp       dword ptr [rcx+188],2
       jl        near ptr M00_L07
       mov       rcx,[rcx+190]
       mov       rcx,[rcx+10]
       test      rcx,rcx
       je        near ptr M00_L07
       mov       rax,[rcx]
       add       rax,10
M00_L01:
       mov       rcx,[rax+8]
       test      rcx,rcx
       jne       short M00_L02
       mov       rcx,164F8C00438
       mov       rcx,[rcx]
       test      rcx,rcx
       jne       short M00_L02
       mov       rcx,164F8C00418
       mov       rcx,[rcx]
       test      rcx,rcx
       je        near ptr M00_L08
M00_L02:
       mov       rdx,offset MT_System.Globalization.CultureInfo
       cmp       [rcx],rdx
       jne       near ptr M00_L12
       mov       r15,rcx
       mov       rcx,[r15+8]
       test      rcx,rcx
       je        near ptr M00_L09
M00_L03:
       cmp       [rcx],cl
       lea       rdx,[rbp+0C]
       mov       r8d,[rbp+8]
       lea       r9,[r14+0C]
       mov       eax,[r14+8]
       mov       [rsp+38],rdx
       mov       [rsp+40],r8d
       mov       [rsp+28],r9
       mov       [rsp+30],eax
       lea       rdx,[rsp+38]
       lea       r8,[rsp+28]
       mov       r9d,1
       call      qword ptr [7FFC793B5278]; System.Globalization.CompareInfo.Compare(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>, System.Globalization.CompareOptions)
       test      eax,eax
       je        short M00_L06
M00_L04:
       inc       edi
       cmp       [rsi+8],edi
       jg        near ptr M00_L00
M00_L05:
       mov       eax,ebx
       add       rsp,48
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       ret
M00_L06:
       inc       ebx
       jmp       short M00_L04
M00_L07:
       mov       ecx,2
       call      CORINFO_HELP_GETSHARED_GCTHREADSTATIC_BASE_NOCTOR_OPTIMIZED
       jmp       near ptr M00_L01
M00_L08:
       call      qword ptr [7FFC7913E070]; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       mov       rcx,rax
       jmp       near ptr M00_L02
M00_L09:
       mov       rcx,[r15+30]
       mov       r13,r15
       cmp       byte ptr [rcx+1B9],0
       jne       short M00_L10
       mov       rcx,offset MT_System.Globalization.CompareInfo
       call      CORINFO_HELP_NEWSFAST
       mov       r12,rax
       mov       rdx,[r13+40]
       lea       rcx,[r12+8]
       call      CORINFO_HELP_ASSIGN_REF
       mov       rcx,r12
       mov       rdx,r13
       call      qword ptr [7FFC793B5128]; System.Globalization.CompareInfo.InitSort(System.Globalization.CultureInfo)
       jmp       short M00_L11
M00_L10:
       mov       r13,r15
       mov       rcx,[r13+40]
       call      qword ptr [7FFC7913E670]; System.Globalization.CultureInfo.GetCultureInfo(System.String)
       mov       rcx,rax
       mov       rax,[rax]
       mov       rax,[rax+48]
       call      qword ptr [rax+30]
       mov       r12,rax
M00_L11:
       lea       rcx,[r13+8]
       mov       rdx,r12
       call      CORINFO_HELP_ASSIGN_REF
       mov       rcx,r12
       jmp       near ptr M00_L03
M00_L12:
       mov       rax,[rcx]
       mov       rax,[rax+48]
       call      qword ptr [rax+30]
       mov       rcx,rax
       jmp       near ptr M00_L03
; Total bytes of code 493
```
```assembly
; System.Globalization.CompareInfo.Compare(System.ReadOnlySpan`1<Char>, System.ReadOnlySpan`1<Char>, System.Globalization.CompareOptions)
       push      rbp
       push      r15
       push      r14
       push      r13
       push      r12
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,0A8
       lea       rbp,[rsp+0E0]
       xor       ebx,ebx
       mov       [rbp-40],rbx
       mov       [rbp-48],rbx
       mov       r14,rcx
       mov       rbx,rdx
       mov       rsi,r8
       mov       edi,r9d
       lea       rcx,[rbp-0A0]
       mov       rdx,r10
       call      CORINFO_HELP_INIT_PINVOKE_FRAME
       mov       r15,rax
       mov       rcx,rsp
       mov       [rbp-80],rcx
       mov       rcx,rbp
       mov       [rbp-70],rcx
       mov       r8,[rsi]
       mov       r9d,[rsi+8]
       mov       rcx,[rbx]
       mov       edx,[rbx+8]
       cmp       edx,r9d
       je        near ptr M01_L03
M01_L00:
       test      edi,0DFFFFFE0
       jne       near ptr M01_L05
       mov       [rbp-40],rcx
       mov       [rbp-48],r8
       mov       rax,[r14+20]
       mov       [rbp-50],rcx
       mov       [rbp-54],edx
       mov       [rbp-60],r8
       mov       [rsp+20],r9d
       mov       [rsp+28],edi
       mov       rcx,rax
       mov       rdx,[rbp-50]
       mov       r8d,[rbp-54]
       mov       r9,[rbp-60]
       mov       rax,offset MD_Interop+Globalization.CompareString(IntPtr, Char*, Int32, Char*, Int32, System.Globalization.CompareOptions)
       mov       [rbp-90],rax
       lea       rax,[M01_L01]
       mov       [rbp-78],rax
       lea       rax,[rbp-0A0]
       mov       [r15+10],rax
       mov       byte ptr [r15+0C],0
       mov       rax,7FFCD8B7B2B0
       call      rax
M01_L01:
       mov       byte ptr [r15+0C],1
       cmp       dword ptr [7FFCD8EE605C],0
       je        short M01_L02
       call      qword ptr [7FFCD8ED6398]; CORINFO_HELP_STOP_FOR_GC
M01_L02:
       mov       rcx,[rbp-98]
       mov       [r15+10],rcx
       jmp       short M01_L04
M01_L03:
       cmp       rcx,r8
       jne       near ptr M01_L00
       jmp       short M01_L08
M01_L04:
       add       rsp,0A8
       pop       rbx
       pop       rsi
       pop       rdi
       pop       r12
       pop       r13
       pop       r14
       pop       r15
       pop       rbp
       ret
M01_L05:
       cmp       edi,40000000
       jne       short M01_L06
       call      qword ptr [7FFC790E51D0]
       jmp       short M01_L04
M01_L06:
       cmp       edi,10000000
       jne       short M01_L07
       call      qword ptr [7FFC794A76F0]
       jmp       short M01_L04
M01_L07:
       mov       ecx,edi
       call      qword ptr [7FFC793B52A8]
       int       3
M01_L08:
       test      edi,0DFFFFFE0
       je        short M01_L09
       cmp       edi,40000000
       je        short M01_L09
       cmp       edi,10000000
       jne       short M01_L07
M01_L09:
       xor       eax,eax
       jmp       short M01_L04
; Total bytes of code 351
```
```assembly
; System.Globalization.CultureInfo.InitializeUserDefaultCulture()
       push      rsi
       push      rbx
       sub       rsp,28
       call      qword ptr [7FFCD34A31F0]
       mov       rbx,rax
       lea       rsi,[rbx+3E0]
       call      qword ptr [7FFCD34B6B48]
       mov       rdx,rax
       mov       rcx,rsi
       xor       r8d,r8d
       call      qword ptr [7FFCD34B7B40]; System.Threading.Interlocked.CompareExchange(System.Object ByRef, System.Object, System.Object)
       mov       rax,[rbx+3E0]
       add       rsp,28
       pop       rbx
       pop       rsi
       ret
; Total bytes of code 57
```
```assembly
; System.Globalization.CompareInfo.InitSort(System.Globalization.CultureInfo)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rsi,rcx
       mov       rbx,rdx
       mov       rdx,[rbx+50]
       test      rdx,rdx
       jne       short M03_L00
       mov       rcx,[rbx+30]
       mov       rdi,[rcx+8]
       lea       rcx,[rbx+50]
       mov       rdx,rdi
       call      qword ptr [7FFCD34A2D30]; CORINFO_HELP_ASSIGN_REF
       mov       rdx,rdi
M03_L00:
       lea       rcx,[rsi+10]
       call      qword ptr [7FFCD34A2D30]; CORINFO_HELP_ASSIGN_REF
       call      qword ptr [7FFCD34A2EC0]
       cmp       byte ptr [rax+0AE8],0
       jne       short M03_L01
       mov       rdx,[rbx+30]
       mov       rdx,[rdx+10]
       mov       rcx,rsi
       lea       rax,[7FFCD34B6478]
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       jmp       qword ptr [rax]
M03_L01:
       mov       rcx,rsi
       lea       rax,[7FFCD34B6548]
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       jmp       qword ptr [rax]
; Total bytes of code 119
```
```assembly
; System.Globalization.CultureInfo.GetCultureInfo(System.String)
       push      rbp
       push      rsi
       push      rbx
       sub       rsp,60
       lea       rbp,[rsp+70]
       xor       eax,eax
       mov       [rbp-30],rax
       mov       [rbp-18],rax
       mov       [rbp-50],rsp
       mov       [rbp+10],rcx
       cmp       qword ptr [rbp+10],0
       je        near ptr M04_L09
       mov       rcx,[rbp+10]
       call      qword ptr [7FFCD34B74E0]; Precode of System.Globalization.TextInfo.ToLowerAsciiInvariant(System.String)
       mov       [rbp+10],rax
       call      qword ptr [7FFCD34B6B38]; Precode of System.Globalization.CultureInfo.get_CachedCulturesByName()
       mov       [rbp-30],rax
       mov       [rbp-38],rax
       xor       edx,edx
       mov       [rbp-20],edx
       cmp       byte ptr [rbp-20],0
       jne       short M04_L00
       lea       rdx,[rbp-20]
       mov       rcx,rax
       call      qword ptr [7FFCD34B7B68]; System.Threading.Monitor.ReliableEnter(System.Object, Boolean ByRef)
       jmp       short M04_L01
M04_L00:
       call      qword ptr [7FFCD34B7B60]
       int       3
M04_L01:
       lea       r8,[rbp-18]
       mov       rcx,[rbp-38]
       mov       rdx,[rbp+10]
       cmp       [rcx],ecx
       call      qword ptr [7FFCD34C4C40]; Precode of System.Collections.Generic.Dictionary`2[[System.__Canon, System.Private.CoreLib],[System.__Canon, System.Private.CoreLib]].TryGetValue(System.__Canon, System.__Canon ByRef)
       test      eax,eax
       je        short M04_L03
       mov       rbx,[rbp-18]
       cmp       byte ptr [rbp-20],0
       je        short M04_L02
       mov       rcx,[rbp-38]
       call      qword ptr [7FFCD34B7B78]; System.Threading.Monitor.Exit(System.Object)
M04_L02:
       mov       rax,rbx
       add       rsp,60
       pop       rbx
       pop       rsi
       pop       rbp
       ret
M04_L03:
       mov       rcx,rsp
       call      M04_L10
       nop
       mov       rcx,[rbp+10]
       xor       edx,edx
       call      qword ptr [7FFCD34B6640]; Precode of System.Globalization.CultureData.GetCultureData(System.String, Boolean)
       mov       rbx,rax
       test      rbx,rbx
       jne       short M04_L04
       xor       esi,esi
       jmp       short M04_L05
M04_L04:
       call      qword ptr [7FFCD34AB2C0]
       mov       rsi,rax
       lea       rcx,[rsi+30]
       mov       rdx,rbx
       call      qword ptr [7FFCD34A2D30]; CORINFO_HELP_ASSIGN_REF
       mov       rcx,rbx
       call      qword ptr [7FFCD34B6668]; Precode of System.Globalization.CultureData.get_CultureName()
       lea       rcx,[rsi+40]
       mov       rdx,rax
       call      qword ptr [7FFCD34A2D30]; CORINFO_HELP_ASSIGN_REF
       mov       byte ptr [rsi+60],0
M04_L05:
       test      rsi,rsi
       jne       short M04_L06
       call      qword ptr [7FFCD34AB2C8]
       mov       rsi,rax
       call      qword ptr [7FFCD34B6A08]
       mov       r9,rax
       mov       rdx,[7FFCD34CF9C0]
       mov       rdx,[rdx]
       mov       r8,[rbp+10]
       mov       rcx,rsi
       call      qword ptr [7FFCD34B6B68]
       mov       rcx,rsi
       call      qword ptr [7FFCD34A2D08]; CORINFO_HELP_THROW
M04_L06:
       mov       [rbp-18],rsi
       mov       rcx,[rbp-18]
       mov       byte ptr [rcx+60],1
       mov       rcx,[rbp-18]
       mov       rcx,[rcx+40]
       call      qword ptr [7FFCD34B74E0]; Precode of System.Globalization.TextInfo.ToLowerAsciiInvariant(System.String)
       mov       [rbp+10],rax
       mov       rcx,[rbp-30]
       mov       [rbp-40],rcx
       xor       eax,eax
       mov       [rbp-28],eax
       cmp       byte ptr [rbp-28],0
       je        short M04_L07
       call      qword ptr [7FFCD34B7B60]
       int       3
M04_L07:
       lea       rdx,[rbp-28]
       call      qword ptr [7FFCD34B7B68]; System.Threading.Monitor.ReliableEnter(System.Object, Boolean ByRef)
       mov       r8,[rbp-18]
       mov       rcx,[rbp-40]
       cmp       [rcx],cl
       mov       rdx,[rbp+10]
       mov       r9d,1
       call      qword ptr [7FFCD34C4BE8]; Precode of System.Collections.Generic.Dictionary`2[[System.__Canon, System.Private.CoreLib],[System.__Canon, System.Private.CoreLib]].TryInsert(System.__Canon, System.__Canon, System.Collections.Generic.InsertionBehavior)
       nop
       cmp       byte ptr [rbp-28],0
       je        short M04_L08
       mov       rcx,[rbp-40]
       call      qword ptr [7FFCD34B7B78]; System.Threading.Monitor.Exit(System.Object)
M04_L08:
       mov       rax,[rbp-18]
       add       rsp,60
       pop       rbx
       pop       rsi
       pop       rbp
       ret
M04_L09:
       mov       rcx,[7FFCD34CF9C0]
       mov       rcx,[rcx]
       call      qword ptr [7FFCD34B28F0]
       int       3
M04_L10:
       push      rbp
       push      rsi
       push      rbx
       sub       rsp,30
       mov       rbp,[rcx+20]
       mov       [rsp+20],rbp
       lea       rbp,[rbp+70]
       cmp       byte ptr [rbp-20],0
       je        short M04_L11
       mov       rcx,[rbp-30]
       call      qword ptr [7FFCD34B7B78]; System.Threading.Monitor.Exit(System.Object)
M04_L11:
       nop
       add       rsp,30
       pop       rbx
       pop       rsi
       pop       rbp
       ret
       push      rbp
       push      rsi
       push      rbx
       sub       rsp,30
       mov       rbp,[rcx+20]
       mov       [rsp+20],rbp
       lea       rbp,[rbp+70]
       cmp       byte ptr [rbp-28],0
       je        short M04_L12
       mov       rcx,[rbp-40]
       call      qword ptr [7FFCD34B7B78]; System.Threading.Monitor.Exit(System.Object)
M04_L12:
       nop
       add       rsp,30
       pop       rbx
       pop       rsi
       pop       rbp
       ret
; Total bytes of code 521
```

