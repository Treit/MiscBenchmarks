using System.Reflection;
using System.Reflection.Emit;
using Benchmark;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Bench>();

[MemoryDiagnoser]
public class Bench
{
    public class C
    {
        public int Method(int a, int b) => a + b;
    }

    public object Instance = new C();

    public static readonly MethodInfo instanceMethod = typeof(C).GetMethod("Method")!;

    // the true here disables type checking (very unsafe)
    public static readonly MethodInfoInvokerExtensions.InvokerDelegate instanceMethodInvoker = instanceMethod.GetInvoker(true);

    public static readonly Func<object, int, int, int> instanceMethodFunc = GenerateFunc();
    
    private static Func<object, int, int, int> GenerateFunc()
    {
        var dm = new DynamicMethod("lollmao2", MethodAttributes.Static | MethodAttributes.Public, CallingConventions.Standard, typeof(int),
            new[] { typeof(object), typeof(int), typeof(int) }, typeof(MethodInfoExtensions), true);

        var il = dm.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Castclass, typeof(C));
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Ldarg_2);
        il.Emit(OpCodes.Callvirt, instanceMethod);
        il.Emit(OpCodes.Ret);

        return dm.CreateDelegate<Func<object, int, int, int>>();
    }

    [Benchmark(Baseline = true)]
    public int Reflection()
    {
        var instance = Instance;
        return (int)instance.GetType().GetMethod("Method")!.Invoke(instance, new object[] { 2, 2 })!;
    }

    [Benchmark]
    public int ReflectionCached()
    {
        return (int)instanceMethod.Invoke(Instance, new object[] { 2, 2 })!;
    }

    private static readonly object[] ReflectionArgs = { 2, 2 };
    
    [Benchmark]
    public int ReflectionCachedFully()
    {
        return (int)instanceMethod.Invoke(Instance, ReflectionArgs)!;
    }

    [Benchmark]
    public int WithSpanInvoker()
    {
        int ret = default;
        int arg1 = 2;
        int arg2 = 2;
        var args = new TypedReference2_2(TypedReference2.Create(ref arg1), TypedReference2.Create(ref arg2)).AsSpan();
        instanceMethodInvoker(TypedReference2.Create(ref ret), TypedReference2.Create(ref Instance), args);
        return ret;
    }

    [Benchmark]
    public int GeneratedFunc()
    {
        return instanceMethodFunc(Instance, 2, 2);
    }

    [Benchmark]
    public int Dynamic()
    {
        return (Instance as dynamic).Method(2, 2);
    }
}
