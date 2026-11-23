namespace Test;

using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100, 10_000)]
    public int RowCount { get; set; }

    [Params(10, 100)]
    public int ColumnCount { get; set; }

    private object[][] _rows;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _rows = new object[RowCount][];

        for (var row = 0; row < RowCount; row++)
        {
            _rows[row] = new object[ColumnCount];

            for (var column = 0; column < ColumnCount; column++)
            {
                _rows[row][column] = $"{row:D6}:{column:D3}".PadRight(64, 'x');
            }
        }
    }

    [Benchmark(Baseline = true)]
    public List<string> BuildTsvWithConcat()
    {
        var reply = new List<string>();

        foreach (var row in _rows)
        {
            var text = string.Empty;

            for (var field = 0; field < row.Length; field++)
            {
                text += row[field].ToString() + "\t";
            }

            reply.Add(text.TrimEnd('\t'));
        }

        return reply;
    }

    [Benchmark]
    public List<string> BuildTsvWithStringBuilder()
    {
        var reply = new List<string>();
        var builder = new StringBuilder();

        foreach (var row in _rows)
        {
            builder.Clear();

            for (var field = 0; field < row.Length; field++)
            {
                builder.Append(row[field].ToString()).Append('\t');
            }

            reply.Add(builder.ToString().TrimEnd('\t'));
        }

        return reply;
    }
}
