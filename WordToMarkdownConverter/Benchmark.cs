namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;


    [ShortRunJob]
    public class Benchmark
    {

        private static string s_targetDir = @"c:\temp\andy";
        [GlobalSetup]
        public void GlobalSetup()
        {
            // delete all markdown files in the target directory
            string[] files = Directory.GetFiles(s_targetDir, "*.md");
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        bool ConvertToMarkdown(string inputFile, string outputFile)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "pandoc",
                Arguments = $"\"{inputFile}\" -t markdown -o \"{outputFile}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo)!)
            {
                process.WaitForExit();
                if (process.ExitCode == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to convert {inputFile}");
                    return false;
                }
            }
        }
        public async Task<bool> ConvertToMarkdownAsync(string inputFile, string outputFile)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "pandoc",
                Arguments = $"\"{inputFile}\" -t markdown -o \"{outputFile}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo)!)
            {
                await process.WaitForExitAsync();
                if (process.ExitCode == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to convert {inputFile}");
                    return false;
                }
            }
        }
        [Benchmark(Baseline = true)]
        public bool ConvertPandocParallelForEach()
        {
            string[] files = Directory.GetFiles(s_targetDir, "*.docx");

            Parallel.ForEach(files, file =>
            {
                string markdownFile = Path.ChangeExtension(file, ".md");
                ConvertToMarkdown(file, markdownFile);
            });
            return true;
        }
        [Benchmark]
        public async Task<bool> ConvertPandocParallelForEachAsync()
        {
            string[] files = Directory.GetFiles(s_targetDir, "*.docx");

            await Parallel.ForEachAsync(files, async (file, _) =>
            {
                string markdownFile = Path.ChangeExtension(file, ".md");
                await ConvertToMarkdownAsync(file, markdownFile);
            });
            return true;
        }        

         [Benchmark]
        public bool ConvertPandocForEach()
        {
            string[] files = Directory.GetFiles(s_targetDir, "*.docx");

            foreach (string file in files)
            {
                string markdownFile = Path.ChangeExtension(file, ".md");
                ConvertToMarkdown(file, markdownFile);
            };
            return true;
        }
    }
}
