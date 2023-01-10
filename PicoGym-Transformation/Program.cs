namespace Test
{
    using BenchmarkDotNet.Running;
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
            var v1 = b.DecodeString();
            var v2 = b.DecodeStringChatGPTRecursive();
            var v3 = b.DecodeStringChatGPTLinq();
            var v4 = b.DecodeStringChatGPTStringBuilder();

            Console.WriteLine(v1);
            Console.WriteLine(v2);
            Console.WriteLine(v3);
            Console.WriteLine(v4);
#endif
        }
    }
}
