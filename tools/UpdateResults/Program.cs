var readme = "README.md";
var tmp = $"{readme}.tmp";
var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
var projectName = dir.Name;

var resultsDir = new DirectoryInfo(Path.Combine(dir.FullName, @"BenchmarkDotNet.Artifacts\results"));
var resultFiles = resultsDir.GetFiles("*.md");

var resultsPath = resultFiles.FirstOrDefault(x => x.Name.Contains("Benchmark-report-github.md"))?.FullName;
var resultsAsmPath = resultFiles.FirstOrDefault(x => x.Name.Contains("Benchmark-asm.md"))?.FullName;

if (!File.Exists(resultsPath))
{
    Console.WriteLine("No results!");
    return;
}

if (!File.Exists(readme))
{
    File.Create(readme).Close();
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

    sw.WriteLine();
    using var resultsSr = new StreamReader(resultsPath);
    while (resultsSr.ReadLine() is string line)
    {
        sw.WriteLine(line);
    }

    if (File.Exists(resultsAsmPath))
    {
        sw.WriteLine();

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