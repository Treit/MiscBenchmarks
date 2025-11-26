namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Jobs;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(10_000)]
    public int Count { get; set; }

    public int MaxDepth { get; set; } = 100;

    public int Min { get; set; } = 100;

    public int Max { get; set; } = 1000;

    public string BaseDir { get; set; } = "tmp";

    [GlobalSetup]
    public void GlobalSetup()
    {

        if (Directory.Exists(BaseDir))
        {
            Directory.Delete(BaseDir, true);
        }

        Directory.CreateDirectory(BaseDir);

        try
        {
            var random = new Random(Count);
            int count = Count;
            int total = 0;

            CreateDummyFiles(BaseDir, ref count, MaxDepth, ref total, Min, Max, random);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }

    [Benchmark]
    public long TraverseRecursive()
    {
        return DoTraverseRecursive(BaseDir);

        long DoTraverseRecursive(string folder)
        {
            long result = 0;

            var files = Directory.GetFiles(folder);

            foreach (var file in files)
            {
                result++;
            }

            var dirs = Directory.GetDirectories(folder);
            foreach (var dir in dirs)
            {
                result += DoTraverseRecursive(dir);
            }

            return result;
        }
    }

    [Benchmark]
    public long TraverseWithStack()
    {
        long result = 0;
        var stack = new Stack<string>(Count);
        stack.Push(BaseDir);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            var dirs = Directory.GetDirectories(current);
            foreach (var dir in dirs)
            {
                stack.Push(dir);
            }

            var files = Directory.GetFiles(current);

            foreach (var file in files)
            {
                result++;
            }
        }

        return result;
    }

    [Benchmark]
    public long TraverseWithGetFileSystemEntries()
    {
        long result = 0;
        var entries = Directory.GetFileSystemEntries(BaseDir, "*.txt", SearchOption.AllDirectories);
        foreach (var entry in entries)
        {
            result++;
        }

        return result;
    }

    [Benchmark]
    public long TraverseWithEnumerateFileSystemEntries()
    {
        long result = 0;
        var entries = Directory.EnumerateFileSystemEntries(BaseDir, "*.txt", SearchOption.AllDirectories);
        foreach (var entry in entries)
        {
            result++;
        }

        return result;
    }

    [Benchmark]
    public long TraverseWithEnumerateFileSystemEntriesParallelLinq()
    {
        long result = 0;
        var entries = Directory.EnumerateFileSystemEntries(BaseDir, "*.txt", SearchOption.AllDirectories).AsParallel();
        foreach (var entry in entries)
        {
            result++;
        }

        return result;
    }

    static void CreateDummyFiles(
        string currentDirectory,
        ref int remainingFiles,
        int maxDepth,
        ref int totalCreated,
        int min,
        int max,
        Random random)
    {
        if (remainingFiles <= 0 && totalCreated < min)
        {
            remainingFiles = min - totalCreated;
        }

        if (remainingFiles <= 0 || maxDepth <= 0 || totalCreated >= max)
        {
            return;
        }

        int filesToCreate = random.Next(1, remainingFiles);
        for (int i = 0; i < filesToCreate; i++)
        {
            string fileName = Path.Combine(currentDirectory, $"DummyFile{i + 1}.txt");
            File.Create(fileName).Dispose();
            totalCreated++;
            remainingFiles--;
        }

        if (remainingFiles <= 0)
        {
            return;
        }

        int subDirsToCreate = random.Next(1, remainingFiles);
        for (int i = 0; i < subDirsToCreate; i++)
        {
            string subDirName = Path.Combine(currentDirectory, $"Subdir{i + 1}");
            Directory.CreateDirectory(subDirName);

            CreateDummyFiles(subDirName, ref remainingFiles, maxDepth - 1, ref totalCreated, min, max, random);

            if (remainingFiles <= 0 && totalCreated < min)
            {
                remainingFiles = min - totalCreated;
            }

            if (remainingFiles <= 0)
            {
                break;
            }
        }
    }
}
