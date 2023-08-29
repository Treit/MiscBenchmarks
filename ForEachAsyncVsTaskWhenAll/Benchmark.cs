namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    public class Benchmark
    {
        static readonly List<string> s_files = new();

        [Params(10, 1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var buffer = new byte[1024 * 10];
            var r = new Random(Count);
            r.NextBytes(buffer);

            for (int i = 0; i < Count; i++)
            {
                using var fs = new FileStream($"{i}.bin", FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                s_files.Add(fs.Name);
            }
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            for (int i = 0; i < Count; i++)
            {
                if (File.Exists(s_files[i]))
                {
                    File.Delete(s_files[i]);
                }
            }
        }

        [Benchmark(Baseline = true)]
        public async Task<long> ReadFilesAsyncWithTakWhenAll()
        {
            var result = 0L;
            var tasks = new List<Task<byte[]>>();

            foreach (var file in s_files)
            {
                var t = File.ReadAllBytesAsync(file);
                tasks.Add(t);
            }

            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                result += task.Result.Length;
            }

            return result;
        }

        [Benchmark]
        public async Task<long> ReadFilesAsyncWithParallelForEachAsync()
        {
            long result = 0;

            await Parallel.ForEachAsync(s_files, async (file, ct) =>
            {
                var bytes = await File.ReadAllBytesAsync(file);
                Interlocked.Add(ref result, bytes.Length);
            });

            return result;
        }

        [Benchmark]
        public long ReadFilesSyncWithParallelForEach()
        {
            long result = 0;

            Parallel.ForEach(s_files, file =>
            {
                var bytes = File.ReadAllBytes(file);
                Interlocked.Add(ref result, bytes.Length);
            });

            return result;
        }
    }
}
