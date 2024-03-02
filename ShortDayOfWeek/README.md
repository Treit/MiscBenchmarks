# Getting a short day of week abbreviaton.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Code Size | Gen0    | Allocated | Alloc Ratio |
|----------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|--------:|----------:|------------:|
| GetDayOfWeekSubstring        | 1000  | 41.970 μs | 1.0777 μs | 3.1265 μs | 40.890 μs | 12.62 |    1.01 |   1,765 B | 20.3857 |   88013 B |          NA |
| GetDayOfWeekSwitchExpression | 1000  | 12.525 μs | 0.2503 μs | 0.2571 μs | 12.485 μs |  3.75 |    0.10 |     305 B |       - |         - |          NA |
| GetDayOfWeekLookup           | 1000  |  3.351 μs | 0.0645 μs | 0.0603 μs |  3.346 μs |  1.00 |    0.00 |     154 B |       - |         - |          NA |

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; ShortDayOfWeek.Benchmarks.GetDayOfWeekSubstring()
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,20
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       mov       edi,[rsi+14]
       xor       ebp,ebp
       jmp       near ptr M00_L02
M00_L00:
       mov       rax,3FFFFFFFFFFFFFFF
       and       rdx,rax
       mov       rcx,28B8FFC778816079
       mov       rax,rdx
       mul       rcx
       shr       rdx,25
       lea       r14d,[rdx+1]
       mov       rdx,2492492492492493
       mov       eax,r14d
       mul       rdx
       imul      ecx,edx,7
       sub       r14d,ecx
       mov       rcx,offset MT_System.DayOfWeek
       call      CORINFO_HELP_NEWSFAST
       mov       [rax+8],r14d
       mov       rcx,rax
       call      qword ptr [7FFEE18873B8]; System.Enum.ToString()
       mov       r14,rax
       mov       ecx,[r14+8]
       cmp       ecx,3
       jb        near ptr M00_L06
       cmp       ecx,3
       je        short M00_L05
       mov       ecx,3
       call      System.String.FastAllocateString(Int32)
       mov       rdx,rax
       cmp       [rdx],dl
       lea       rcx,[rdx+0C]
       add       r14,0C
       mov       eax,[r14]
       mov       r8d,[r14+2]
       mov       [rcx],eax
       mov       [rcx+2],r8d
M00_L01:
       cmp       [rdx],dl
       mov       rcx,2FA15000590
       mov       rcx,[rcx]
       call      qword ptr [7FFEE1D3D0E0]; System.Globalization.TextInfo.ChangeCaseCommon[[System.Globalization.TextInfo+ToUpperConversion, System.Private.CoreLib]](System.String)
       mov       eax,[rax+8]
       add       rbx,rax
M00_L02:
       mov       rax,rsi
       cmp       edi,[rax+14]
       jne       short M00_L04
       mov       eax,[rsi+10]
       cmp       ebp,eax
       jae       short M00_L03
       mov       rax,[rsi+8]
       cmp       ebp,[rax+8]
       jae       short M00_L07
       mov       edx,ebp
       mov       rdx,[rax+rdx*8+10]
       inc       ebp
       jmp       near ptr M00_L00
M00_L03:
       mov       rax,rbx
       add       rsp,20
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M00_L04:
       call      qword ptr [7FFEE1BD5DD0]
       int       3
M00_L05:
       mov       rdx,r14
       jmp       short M00_L01
M00_L06:
       mov       rcx,r14
       xor       edx,edx
       mov       r8d,3
       call      qword ptr [7FFEE1947258]
       int       3
M00_L07:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 285
```
```assembly
; System.Enum.ToString()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rbx,rcx
M01_L00:
       mov       rcx,rbx
       call      System.Object.GetType()
       mov       rsi,rax
       lea       rdi,[rbx+8]
       mov       rcx,[rbx]
       call      System.Enum.InternalGetCorElementType(System.Runtime.CompilerServices.MethodTable*)
       add       eax,0FFFFFFFC
       cmp       eax,4
       jne       near ptr M01_L18
       mov       ebx,[rdi]
       mov       rcx,[rsi+10]
       test      rcx,rcx
       je        short M01_L09
       mov       rcx,[rcx]
M01_L01:
       test      rcx,rcx
       je        short M01_L03
       mov       rcx,[rcx+78]
M01_L02:
       test      rcx,rcx
       je        short M01_L11
       mov       rdx,offset MT_System.Enum+EnumInfo`1[[System.UInt32, System.Private.CoreLib]]
       cmp       [rcx],rdx
       jne       short M01_L11
       cmp       qword ptr [rcx+10],0
       je        short M01_L11
       jmp       short M01_L08
M01_L03:
       xor       ecx,ecx
       jmp       short M01_L02
M01_L04:
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L05:
       cmp       byte ptr [rcx+18],0
       jne       near ptr M01_L19
       mov       rsi,[rcx+10]
       cmp       byte ptr [rcx+19],0
       je        short M01_L10
       mov       ecx,ebx
       mov       edi,[rsi+8]
       cmp       edi,ecx
       jbe       near ptr M01_L35
       mov       ecx,ebx
       mov       rax,[rsi+rcx*8+10]
M01_L06:
       test      rax,rax
       je        near ptr M01_L34
M01_L07:
       jmp       short M01_L04
M01_L08:
       jmp       short M01_L05
M01_L09:
       xor       ecx,ecx
       jmp       short M01_L01
M01_L10:
       mov       rbp,[rcx+8]
       test      rbp,rbp
       jne       short M01_L12
       jmp       short M01_L14
M01_L11:
       mov       rcx,rsi
       mov       edx,1
       call      qword ptr [7FFEE1C46298]; System.Enum.<GetEnumInfo>g__InitializeEnumInfo|7_0[[System.UInt32, System.Private.CoreLib]](System.RuntimeType, Boolean)
       mov       rcx,rax
       jmp       short M01_L05
M01_L12:
       lea       rcx,[rbp+10]
       mov       r8d,[rbp+8]
M01_L13:
       cmp       dword ptr [rbp+8],20
       jle       short M01_L15
       jmp       short M01_L17
M01_L14:
       xor       ecx,ecx
       xor       r8d,r8d
       jmp       short M01_L13
M01_L15:
       mov       edx,ebx
       call      qword ptr [7FFEE1E3F780]
M01_L16:
       mov       edi,[rsi+8]
       cmp       edi,eax
       jbe       near ptr M01_L35
       mov       ecx,eax
       mov       rax,[rsi+rcx*8+10]
       jmp       short M01_L06
M01_L17:
       mov       edx,r8d
       mov       r8d,ebx
       call      qword ptr [7FFEE1E3F540]
       jmp       short M01_L16
M01_L18:
       cmp       eax,7
       ja        short M01_L20
       mov       ecx,eax
       lea       rdx,[7FFEE197A868]
       mov       edx,[rdx+rcx*4]
       lea       rax,[M01_L00]
       add       rdx,rax
       jmp       rdx
       mov       rcx,rsi
       mov       rdx,rdi
       call      qword ptr [7FFEE1E365E0]
       jmp       near ptr M01_L04
M01_L19:
       mov       edx,ebx
       call      qword ptr [7FFEE1E3F408]
       jmp       near ptr M01_L06
       mov       rcx,rsi
       mov       rdx,rdi
       call      qword ptr [7FFEE1E34DF8]
       jmp       near ptr M01_L04
       mov       rcx,rsi
       mov       rdx,rdi
       call      qword ptr [7FFEE1E34690]
       jmp       near ptr M01_L04
       mov       rcx,rsi
       mov       rdx,rdi
       call      qword ptr [7FFEE1E0EC10]
       jmp       near ptr M01_L04
M01_L20:
       mov       rcx,rsi
       mov       rdx,rdi
       call      qword ptr [7FFEE18945A0]
       jmp       near ptr M01_L04
       movzx     edi,byte ptr [rdi]
       mov       rcx,rsi
       call      qword ptr [7FFEE1896418]
       mov       rdx,rax
       mov       rcx,offset MT_System.Enum+EnumInfo`1[[System.Byte, System.Private.CoreLib]]
       call      qword ptr [7FFEE1944360]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       test      rax,rax
       je        short M01_L21
       cmp       qword ptr [rax+10],0
       jne       short M01_L22
M01_L21:
       mov       rcx,rsi
       mov       edx,1
       call      qword ptr [7FFEE1E3C750]
       mov       rcx,rax
       jmp       short M01_L23
M01_L22:
       mov       rcx,rax
M01_L23:
       cmp       byte ptr [rcx+18],0
       jne       short M01_L31
       mov       rsi,[rcx+10]
       cmp       byte ptr [rcx+19],0
       je        short M01_L24
       cmp       [rsi+8],edi
       jbe       short M01_L29
       mov       ecx,edi
       mov       rax,[rsi+rcx*8+10]
       jmp       short M01_L30
M01_L24:
       mov       rcx,[rcx+8]
       test      rcx,rcx
       jne       short M01_L25
       xor       edx,edx
       xor       r8d,r8d
       jmp       short M01_L26
M01_L25:
       lea       rdx,[rcx+10]
       mov       r8d,[rcx+8]
M01_L26:
       cmp       dword ptr [rcx+8],20
       jle       short M01_L27
       mov       rcx,rdx
       mov       edx,r8d
       mov       r8d,edi
       call      qword ptr [7FFEE1E3DB48]
       jmp       short M01_L28
M01_L27:
       mov       rcx,rdx
       mov       edx,edi
       call      qword ptr [7FFEE1E3F390]
M01_L28:
       cmp       [rsi+8],eax
       jbe       short M01_L29
       mov       ecx,eax
       mov       rax,[rsi+rcx*8+10]
       jmp       short M01_L30
M01_L29:
       xor       eax,eax
M01_L30:
       jmp       short M01_L32
M01_L31:
       mov       edx,edi
       call      qword ptr [7FFEE1E37CC0]
M01_L32:
       test      rax,rax
       jne       short M01_L33
       mov       ecx,edi
       call      qword ptr [7FFEE1A64468]; System.Number.UInt32ToDecStr(UInt32)
M01_L33:
       jmp       near ptr M01_L04
       mov       rcx,rsi
       mov       rdx,rdi
       call      qword ptr [7FFEE1E35E00]
       jmp       near ptr M01_L04
       mov       rcx,rsi
       mov       rdx,rdi
       call      qword ptr [7FFEE1E35DE8]
       jmp       near ptr M01_L04
M01_L34:
       mov       ecx,ebx
       call      qword ptr [7FFEE1A64300]; System.Number.Int32ToDecStr(Int32)
       jmp       near ptr M01_L07
M01_L35:
       xor       eax,eax
       jmp       near ptr M01_L06
; Total bytes of code 642
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
       mov       rbx,rcx
       mov       rsi,rdx
       mov       edi,[rsi+8]
       test      edi,edi
       je        near ptr M02_L13
       lea       rcx,[rsi+0C]
       mov       [rsp+60],rcx
       mov       rbp,[rsp+60]
       xor       r14d,r14d
       cmp       byte ptr [rbx+31],0
       je        near ptr M02_L11
M02_L00:
       cmp       byte ptr [rbx+31],2
       jne       near ptr M02_L19
       cmp       edi,2
       jl        near ptr M02_L09
       lea       ecx,[rdi-2]
       mov       r15d,ecx
M02_L01:
       mov       ecx,[rbp+r14*2]
       test      ecx,0FF80FF80
       jne       near ptr M02_L19
       lea       eax,[rcx+1F001F]
       add       ecx,50005
       xor       ecx,eax
       test      ecx,800080
       je        near ptr M02_L14
M02_L02:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       rbp,rax
       lea       r15,[rbp+0C]
       mov       r13d,[rbp+8]
       mov       eax,r14d
       cmp       edi,eax
       jb        near ptr M02_L20
       lea       rdx,[rsi+0C]
       cmp       eax,r13d
       ja        near ptr M02_L22
       mov       r12d,eax
       mov       r8,r12
       add       r8,r8
       mov       rcx,r15
       call      qword ptr [7FFEE19F5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       mov       ecx,r14d
       lea       rsi,[rsi+r12*2+0C]
       sub       edi,ecx
       lea       r15,[r15+r12*2]
       sub       r13d,r14d
       test      edi,edi
       je        near ptr M02_L08
       xor       ecx,ecx
       mov       [rsp+50],ecx
       cmp       byte ptr [rbx+31],0
       je        short M02_L04
M02_L03:
       cmp       byte ptr [rbx+31],2
       jne       near ptr M02_L18
       imul      ecx,edi,2
       jo        near ptr M02_L12
       imul      eax,r13d,2
       jo        near ptr M02_L12
       test      ecx,ecx
       je        short M02_L06
       test      eax,eax
       je        short M02_L06
       mov       r14,r15
       sub       r14,rsi
       cmp       r14,rcx
       jb        near ptr M02_L16
       jmp       short M02_L05
M02_L04:
       mov       rcx,rbx
       call      qword ptr [7FFEE1B0F0F0]
       jmp       short M02_L03
M02_L05:
       mov       eax,eax
       neg       rax
       cmp       rax,r14
       jb        near ptr M02_L16
M02_L06:
       cmp       edi,r13d
       jg        near ptr M02_L17
       mov       r12d,edi
       xor       r14d,r14d
M02_L07:
       mov       [rsp+38],rsi
       mov       rcx,rsi
       mov       [rsp+30],r15
       mov       rdx,r15
       mov       r8,r12
       call      qword ptr [7FFEE1D3F588]; System.Text.Ascii.ChangeCase[[System.UInt16, System.Private.CoreLib],[System.UInt16, System.Private.CoreLib],[System.Text.Ascii+ToUpperConversion, System.Private.CoreLib]](UInt16*, UInt16*, UIntPtr)
       mov       [rsp+50],eax
       mov       ecx,3
       cmp       r12,rax
       cmovne    r14d,ecx
       xor       eax,eax
       mov       [rsp+38],rax
       mov       [rsp+30],rax
       cmp       r14d,3
       je        near ptr M02_L18
M02_L08:
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
M02_L09:
       test      dil,1
       je        short M02_L15
M02_L10:
       movzx     ecx,word ptr [rbp+r14*2]
       cmp       ecx,7F
       ja        near ptr M02_L19
       add       ecx,0FFFFFF9F
       cmp       ecx,19
       ja        short M02_L15
       jmp       near ptr M02_L02
M02_L11:
       mov       rcx,rbx
       call      qword ptr [7FFEE1B0F0F0]
       jmp       near ptr M02_L00
M02_L12:
       call      CORINFO_HELP_OVERFLOW
M02_L13:
       mov       rax,2FA00200008
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
M02_L14:
       add       r14,2
       cmp       r14,r15
       jbe       near ptr M02_L01
       test      dil,1
       jne       short M02_L10
M02_L15:
       mov       rax,rsi
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
M02_L16:
       mov       ecx,48
       call      qword ptr [7FFEE1BD5BA8]
       int       3
M02_L17:
       mov       r12d,r13d
       mov       r14d,1
       jmp       near ptr M02_L07
M02_L18:
       mov       [rsp+48],rsi
       mov       [rsp+40],r15
       movsxd    rcx,dword ptr [rsp+50]
       lea       rdx,[rsi+rcx*2]
       mov       r8d,edi
       sub       r8d,[rsp+50]
       movsxd    rcx,dword ptr [rsp+50]
       lea       r9,[r15+rcx*2]
       sub       r13d,[rsp+50]
       mov       [rsp+20],r13d
       mov       dword ptr [rsp+28],1
       mov       rcx,rbx
       call      qword ptr [7FFEE1B0F1B0]
       xor       ecx,ecx
       mov       [rsp+40],rcx
       mov       [rsp+48],rcx
       jmp       near ptr M02_L08
M02_L19:
       mov       ecx,edi
       call      System.String.FastAllocateString(Int32)
       mov       r15,rax
       test      r14,r14
       je        short M02_L23
       lea       rcx,[r15+0C]
       mov       eax,[r15+8]
       mov       r13d,r14d
       cmp       edi,r13d
       jae       short M02_L21
M02_L20:
       mov       ecx,21
       call      qword ptr [7FFEE1BD5B18]
       int       3
M02_L21:
       add       rsi,0C
       mov       rdx,rsi
       cmp       r13d,eax
       ja        short M02_L22
       mov       r8d,r13d
       add       r8,r8
       call      qword ptr [7FFEE19F5B78]; System.Buffer.Memmove(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M02_L23
M02_L22:
       call      qword ptr [7FFEE1BD57D0]
       int       3
M02_L23:
       test      r15,r15
       jne       short M02_L24
       xor       r9d,r9d
       jmp       short M02_L25
M02_L24:
       lea       r9,[r15+0C]
       mov       [rsp+58],r9
       mov       r9,[rsp+58]
M02_L25:
       mov       edx,[r15+8]
       sub       edx,r14d
       mov       [rsp+20],edx
       mov       dword ptr [rsp+28],1
       lea       rdx,[rbp+r14*2]
       mov       r8d,edi
       sub       r8d,r14d
       lea       r9,[r9+r14*2]
       mov       rcx,rbx
       call      qword ptr [7FFEE1B0F1B0]
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
; Total bytes of code 838
```
**Extern method**
System.String.FastAllocateString(Int32)

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; ShortDayOfWeek.Benchmarks.GetDayOfWeekSwitchExpression()
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       xor       ebx,ebx
       mov       rsi,[rcx+8]
       mov       edi,[rsi+14]
       xor       ebp,ebp
       jmp       short M00_L01
M00_L00:
       call      qword ptr [7FFEE1DCD308]; ShortDayOfWeek.DateTimeExtensions.ToShortDayOfWeekSwitchExpression(System.DateTime)
       mov       eax,[rax+8]
       add       rbx,rax
M00_L01:
       mov       rcx,rsi
       cmp       edi,[rcx+14]
       jne       short M00_L02
       cmp       ebp,[rsi+10]
       jae       short M00_L03
       mov       rcx,[rsi+8]
       cmp       ebp,[rcx+8]
       jae       short M00_L04
       mov       eax,ebp
       mov       rcx,[rcx+rax*8+10]
       inc       ebp
       jmp       short M00_L00
M00_L02:
       call      qword ptr [7FFEE1BE5DD0]
       int       3
M00_L03:
       mov       rax,rbx
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M00_L04:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 91
```
```assembly
; ShortDayOfWeek.DateTimeExtensions.ToShortDayOfWeekSwitchExpression(System.DateTime)
       push      rbx
       sub       rsp,20
M01_L00:
       mov       rdx,3FFFFFFFFFFFFFFF
       and       rdx,rcx
       mov       rcx,28B8FFC778816079
       mov       rax,rdx
       mul       rcx
       shr       rdx,25
       lea       ecx,[rdx+1]
       mov       rdx,2492492492492493
       mov       eax,ecx
       mul       rdx
       imul      eax,edx,7
       sub       ecx,eax
       cmp       ecx,6
       ja        short M01_L02
       mov       eax,ecx
       lea       rcx,[7FFEE1988BC8]
       mov       ecx,[rcx+rax*4]
       lea       rdx,[M01_L00]
       add       rcx,rdx
       jmp       rcx
       mov       rax,1ED8030B650
M01_L01:
       add       rsp,20
       pop       rbx
       ret
       mov       rax,1ED8030B5F0
       jmp       short M01_L01
       mov       rax,1ED8030B690
       jmp       short M01_L01
       mov       rax,1ED8030B670
       jmp       short M01_L01
       mov       rax,1ED8030B630
       jmp       short M01_L01
       mov       rax,1ED8030B5D0
       jmp       short M01_L01
       mov       rax,1ED8030B610
       jmp       short M01_L01
M01_L02:
       mov       rcx,offset MT_System.ArgumentOutOfRangeException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       rcx,rbx
       call      qword ptr [7FFEE1A0D440]
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 214
```

## .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
```assembly
; ShortDayOfWeek.Benchmarks.GetDayOfWeekLookup()
       sub       rsp,28
       xor       r8d,r8d
       mov       rcx,[rcx+8]
       mov       eax,[rcx+14]
       xor       r10d,r10d
       jmp       short M00_L01
M00_L00:
       mov       rax,21B64C01E50
       mov       r9,[rax]
       mov       rax,3FFFFFFFFFFFFFFF
       and       rdx,rax
       mov       r11,28B8FFC778816079
       mov       rax,rdx
       mul       r11
       shr       rdx,25
       lea       r11d,[rdx+1]
       mov       rdx,2492492492492493
       mov       eax,r11d
       mul       rdx
       imul      eax,edx,7
       sub       r11d,eax
       cmp       r11d,[r9+8]
       jae       short M00_L03
       mov       eax,r11d
       mov       rax,[r9+rax*8+10]
       mov       eax,[rax+8]
       add       r8,rax
M00_L01:
       cmp       r10d,[rcx+10]
       jae       short M00_L02
       mov       rax,[rcx+8]
       cmp       r10d,[rax+8]
       jae       short M00_L03
       mov       edx,r10d
       mov       rdx,[rax+rdx*8+10]
       inc       r10d
       jmp       short M00_L00
M00_L02:
       mov       rax,r8
       add       rsp,28
       ret
M00_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 154
```

