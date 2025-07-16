namespace Test;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

[Serializable]
public class TestClass
{
    public List<string> StringValues { get; set; }
    public int Id { get; set; }
    public bool SomeFlag { get; set; }
}

public class Benchmark
{
    [Params(10, 1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var list = new List<TestClass>();

        for (int i = 0; i < Count; i++)
        {
            var item = new TestClass
            {
                StringValues = new List<string>(),
                Id = i,
                SomeFlag = i % 2 == 0
            };

            for (int j = 0; j < Count; j++)
            {
                item.StringValues.Add(Guid.NewGuid().ToString());
            }

            list.Add(item);
        }

        var serializer = new XmlSerializer(typeof(List<TestClass>));
        using var fs = new FileStream("TestInput.xml", FileMode.Create);
        serializer.Serialize(fs, list);
    }

    [Benchmark]
    public long CountElementsWithXDocument()
    {
        var result = 0L;
        using var fs = new FileStream("TestInput.xml", FileMode.Open);
        var doc = XDocument.Load(fs);
        var elements = doc.Descendants(XName.Get("string"));

        foreach (var x in elements)
        {
            result++;
        }

        return result;
    }

    [Benchmark]
    public long CountElementsWithXmlDocument()
    {
        var result = 0L;
        using var fs = new FileStream("TestInput.xml", FileMode.Open);
        var doc = new XmlDocument();
        doc.Load(fs);
        var elements = doc.SelectNodes("//string");

        foreach (var x in elements)
        {
            result++;
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public long CountElementsWithXmlReader()
    {
        var result = 0L;
        using var fs = new FileStream("TestInput.xml", FileMode.Open);
        using var reader = XmlReader.Create(fs);

        while (reader.Read())
        {
            if (reader.Name == "string" && reader.IsStartElement())
            {
                result++;
            }
        }

        return result;
    }
}
