# Properties vs. Fields

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
  DefaultJob : .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT


```
|      Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |
|------------ |----------:|----------:|----------:|------:|--------:|----------:|
| GetProperty |  1.683 ns | 0.2391 ns | 0.7050 ns |  1.00 |    0.00 |      38 B |
|    GetField |  2.550 ns | 0.3015 ns | 0.8891 ns |  1.77 |    0.95 |      35 B |
| SetProperty | 31.574 ns | 0.9662 ns | 2.8488 ns | 22.42 |    9.80 |     170 B |
|    SetField | 32.898 ns | 0.9553 ns | 2.8166 ns | 23.44 |   10.46 |     160 B |


## .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
```assembly
; Test.Benchmark.GetProperty()
       push      rdi
       push      rsi
       mov       rsi,rdx
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       mov       rdi,[rcx+10]
       mov       rdx,[rdx+8]
       mov       rcx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       [rsi+8],rdi
       mov       rax,rsi
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 38
```

## .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
```assembly
; Test.Benchmark.GetField()
       push      rdi
       push      rsi
       mov       rsi,rdx
       mov       rdx,[rcx+8]
       mov       rdi,[rdx+10]
       mov       rdx,[rdx+8]
       mov       rcx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       [rsi+8],rdi
       mov       rax,rsi
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 35
```

## .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
```assembly
; Test.Benchmark.SetProperty()
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
       mov       rdi,[rsi+8]
       call      System.DateTime.get_UtcNow()
       mov       [rdi+10],rax
       mov       rdx,[rsi+8]
       mov       [rsp+20],rdx
       mov       rcx,204374A6690
       mov       rdx,[rcx]
       mov       rcx,[rsp+20]
       lea       rcx,[rcx+8]
       call      CORINFO_HELP_ASSIGN_REF
       nop
       add       rsp,28
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 66
```
```assembly
; System.DateTime.get_UtcNow()
       push      rbp
       push      rdi
       push      rsi
       sub       rsp,30
       lea       rbp,[rsp+40]
       lea       rcx,[rbp+0FFE8]
       mov       rax,7FFDA1181FE0
       call      rax
       mov       rsi,[rbp+0FFE8]
       mov       rax,204374A1230
       mov       rdi,[rax]
       sub       rsi,[rdi+8]
       cmp       dword ptr [7FFC2B0F59FC],0
       jne       short M01_L02
M01_L00:
       mov       eax,0B2D05E00
       cmp       rsi,rax
       jae       short M01_L01
       mov       rax,rsi
       add       rax,[rdi+10]
       add       rsp,30
       pop       rsi
       pop       rdi
       pop       rbp
       ret
M01_L01:
       call      System.DateTime.UpdateLeapSecondCacheAndReturnUtcNow()
       nop
       add       rsp,30
       pop       rsi
       pop       rdi
       pop       rbp
       ret
M01_L02:
       call      CORINFO_HELP_POLL_GC
       jmp       short M01_L00
; Total bytes of code 104
```

## .NET Core 6.0.7 (CoreCLR 6.0.722.32202, CoreFX 6.0.722.32202), X64 RyuJIT
```assembly
; Test.Benchmark.SetField()
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
       mov       rdi,[rsi+8]
       call      System.DateTime.get_UtcNow()
       mov       [rdi+10],rax
       mov       rdx,[rsi+8]
       lea       rcx,[rdx+8]
       mov       rdx,1DCAF619FE8
       mov       rdx,[rdx]
       call      CORINFO_HELP_ASSIGN_REF
       nop
       add       rsp,28
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 56
```
```assembly
; System.DateTime.get_UtcNow()
       push      rbp
       push      rdi
       push      rsi
       sub       rsp,30
       lea       rbp,[rsp+40]
       lea       rcx,[rbp+0FFE8]
       mov       rax,7FFDA1181FE0
       call      rax
       mov       rsi,[rbp+0FFE8]
       mov       rax,1DCAF611230
       mov       rdi,[rax]
       sub       rsi,[rdi+8]
       cmp       dword ptr [7FFC2B0F59FC],0
       jne       short M01_L02
M01_L00:
       mov       eax,0B2D05E00
       cmp       rsi,rax
       jae       short M01_L01
       mov       rax,rsi
       add       rax,[rdi+10]
       add       rsp,30
       pop       rsi
       pop       rdi
       pop       rbp
       ret
M01_L01:
       call      System.DateTime.UpdateLeapSecondCacheAndReturnUtcNow()
       nop
       add       rsp,30
       pop       rsi
       pop       rdi
       pop       rbp
       ret
M01_L02:
       call      CORINFO_HELP_POLL_GC
       jmp       short M01_L00
; Total bytes of code 104
```

