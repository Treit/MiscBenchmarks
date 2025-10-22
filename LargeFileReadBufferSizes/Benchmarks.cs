namespace LargeFileReadBufferSizes
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class Benchmark
    {
        public const long FileSizeBytes = 5L * 1024 * 1024 * 1024;
        private const int IntSizeBytes = sizeof(int);
        private const int GenerationChunkSizeBytes = 4 * 1024 * 1024;

        private static readonly object FileLock = new();
        private static readonly string DataFilePath = Path.Combine(Path.GetTempPath(), "LargeFileReadBufferSizes.bin");
        private static bool _cleanupRegistered;

        private static readonly int[] BufferSizesValues =
        {
            4 * 1024,
            1 * 1024 * 1024,
            16 * 1024 * 1024,
            24 * 1024 * 1024,
            1024 * 1024 * 1024,
        };

        [ParamsSource(nameof(BufferSizes))]
        public int BufferSizeBytes { get; set; }

        public static IEnumerable<int> BufferSizes => BufferSizesValues;

        [GlobalSetup]
        public void GlobalSetup()
        {
            EnsureDataFile();
        }

        [Benchmark(Baseline = true)]
        public long ReadFileBuffered()
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(BufferSizeBytes);
            long sum = 0;

            try
            {
                using FileStream stream = new FileStream(
                    DataFilePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read,
                    bufferSize: BufferSizeBytes,
                    FileOptions.SequentialScan);

                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, BufferSizeBytes)) > 0)
                {
                    ReadOnlySpan<byte> data = new ReadOnlySpan<byte>(buffer, 0, bytesRead);
                    int intsToProcess = bytesRead / IntSizeBytes;
                    if (intsToProcess == 0)
                    {
                        continue;
                    }

                    ReadOnlySpan<int> ints = MemoryMarshal.Cast<byte, int>(data[..(intsToProcess * IntSizeBytes)]);
                    for (int i = 0; i < ints.Length; i++)
                    {
                        sum += ints[i];
                    }
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            return sum;
        }

        public static void DeleteGeneratedFile()
        {
            lock (FileLock)
            {
                if (File.Exists(DataFilePath))
                {
                    try
                    {
                        File.Delete(DataFilePath);
                    }
                    catch (IOException)
                    {
                        // File may still be in use; the process-exit hook will retry.
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Ignore failures; the OS will eventually clean up the temp file.
                    }
                }
            }
        }

        private static void EnsureDataFile()
        {
            lock (FileLock)
            {
                if (File.Exists(DataFilePath))
                {
                    FileInfo info = new FileInfo(DataFilePath);
                    if (info.Length == FileSizeBytes)
                    {
                        RegisterCleanup();
                        return;
                    }

                    File.Delete(DataFilePath);
                }

                GenerateDataFile();
                RegisterCleanup();
            }
        }

        private static void RegisterCleanup()
        {
            if (_cleanupRegistered)
            {
                return;
            }

            AppDomain.CurrentDomain.ProcessExit += (_, _) => DeleteGeneratedFile();
            _cleanupRegistered = true;
        }

        private static void GenerateDataFile()
        {
            byte[] chunk = GC.AllocateUninitializedArray<byte>(GenerationChunkSizeBytes);
            long bytesRemaining = FileSizeBytes;

            using FileStream stream = new FileStream(
                DataFilePath,
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None,
                bufferSize: chunk.Length,
                FileOptions.SequentialScan);

            while (bytesRemaining > 0)
            {
                int bytesToWrite = (int)Math.Min(chunk.Length, bytesRemaining);
                RandomNumberGenerator.Fill(chunk.AsSpan(0, bytesToWrite));
                stream.Write(chunk, 0, bytesToWrite);
                bytesRemaining -= bytesToWrite;
            }

            stream.Flush(true);
        }
    }
}
