namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public void BuildCodeThatUsesExplicitType()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "explicit.cs");
            BuildCode(path);
        }

        [Benchmark]
        public void BuildCodeThatUsesVar()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "var.cs");
            BuildCode(path);
        }

        private void BuildCode(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            string targetDir = Path.GetDirectoryName(fi.FullName);
            string outFile = Path.Combine(targetDir, fi.Name + ".exe");
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo("csc.exe");
            proc.StartInfo.Arguments = $"{filePath} -Reference:System.dll /out:{outFile}";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();
#if DEBUG
            Console.WriteLine(proc.StandardOutput.ReadToEnd());
            Console.WriteLine(proc.StandardError.ReadToEnd());
#endif
            proc.WaitForExit();
        }
    }
}
