namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using global::Benchmark;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private readonly string _connstring = "Server=.; Integrated Security=sspi; Initial Catalog=AdventureWorks2019;Encrypt=false";
    private SqlConnection _conn;
    private AdventureWorks2019Context _dbcontext;

    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _conn = new SqlConnection(_connstring);
        _conn.Open();

        var contextOptions = new DbContextOptionsBuilder<AdventureWorks2019Context>()
            .UseSqlServer(_connstring)
            .Options;

        _dbcontext = new AdventureWorks2019Context(contextOptions);
    }

    [Benchmark(Baseline = true)]
    public List<short> ReadDataUsingDataReader()
    {
        var sql = "select OrderQty from Sales.SalesOrderDetail";
        using var cmd = new SqlCommand(sql, _conn);
        using var reader = cmd.ExecuteReader();

        var result = new List<short>();

        while (reader.Read())
        {
            result.Add(reader.GetInt16(0));
        }

        return result;
    }

    [Benchmark]
    public List<short> ReadDataUsingDataSet()
    {
        var sql = "select OrderQty from Sales.SalesOrderDetail";

        var ds = new DataSet();
        var adapter = new SqlDataAdapter(sql, _conn);
        adapter.Fill(ds);

        var result = new List<short>();

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            result.Add((short)row[0]);
        }

        return result;
    }

    [Benchmark]
    public List<short> ReadDataUsingEntityFramework()
    {
        return _dbcontext.SalesOrderDetails.Select(x => x.OrderQty).ToList();
    }
}
