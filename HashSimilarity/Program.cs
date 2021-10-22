namespace Test
{
    using BenchmarkDotNet.Running;
using System.Runtime.InteropServices;
using System;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.GlobalSetup();
            b.Count = 100_000;
            string testhashA = "bbfddebe5fb59d67eba9d75b77596d5a5999597a5d65b9daffebb6bfb99a5a6ee67ebfed9e7da6a6d97b9f5bdfeffbde656b5b65b5fbeffba9569ddef5e7aa56";
            string testhashB = "bafdddbe5fb59d67eba9d75b77596d5a5989597a5d65b9daffebb6bfb99a5a6ee67ebfed9e7da6a6d97b9f5bdfeffbde656b5b65b5fbeffba9569ddef5e7aa54";
            var bytesA = Convert.FromHexString(testhashA);
            var bytesB = Convert.FromHexString(testhashB);
            var first = MemoryMarshal.Cast<byte, ushort>(bytesA);
            var second = MemoryMarshal.Cast<byte, ushort>(bytesB);
            var confidence = LSHash.ConfidenceSauceControlUnrolledHugeLookup(first, second);
            var confidence2 = LSHash.ConfidenceSauceControlSecondAvx2(bytesA, bytesB);
            Console.WriteLine(confidence);
            Console.WriteLine(confidence2);
            //b.CheckHashesOriginal();
#endif

        }
    }
}
