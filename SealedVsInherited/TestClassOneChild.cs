using System;
using System.Runtime.CompilerServices;

namespace Test;
internal class TestClassOneChild
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long DoWork(int seed)
    {
        long result = 0;
        var r = new Random(seed);

        for (int i = 0; i < seed; i++)
        {
            result += r.Next(100_000);
        }

        return result;
    }
}

internal class Child1 : TestClassOneChild
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long DoWork(int seed)
    {
        long result = 0;
        var r = new Random(seed);

        for (int i = 0; i < seed; i++)
        {
            result += r.Next(100_000);
        }

        return result;
    }
}
