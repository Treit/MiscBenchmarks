var readme = "README.md";
var tmp = $"{readme}.tmp";
var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
var projectName = dir.Name;

var resultsPath = Path.Combine(dir.FullName, @"BenchmarkDotNet.Artifacts\results\Test.Benchmark-report-github.md");
var resultsAsmPath = Path.Combine(dir.FullName, @"BenchmarkDotNet.Artifacts\results\Test.Benchmark-asm.md");

if (!File.Exists(resultsPath))
{
    Console.WriteLine("No results!");
    return;
}

if (!File.Exists(readme))
{
    File.Create(readme);
    return;
}

using (var sr = new StreamReader(readme))
using (var sw = new StreamWriter(tmp))
{

    var linecount = 0;

    while (sr.ReadLine() is string line)
    {
        linecount++;

        if (line.StartsWith("```"))
        {
            break;
        }

        sw.WriteLine(line);
    }

    if (linecount == 0)
    {
        sw.WriteLine($"# {projectName}");
    }

    using var resultsSr = new StreamReader(resultsPath);
    while (resultsSr.ReadLine() is string line)
    {
        sw.WriteLine(line);
    }

    if (File.Exists(resultsAsmPath))
    {
        using var resultsAsmSr = new StreamReader(resultsAsmPath);
        while (resultsAsmSr.ReadLine() is string line)
        {
            sw.WriteLine(line);
        }
    }
}

File.Copy(tmp, readme, true);

try
{
    File.Delete(tmp);
}
catch
{
}

Console.WriteLine($"Updated {readme}.");