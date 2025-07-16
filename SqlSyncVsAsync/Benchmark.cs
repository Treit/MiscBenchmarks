namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

[MemoryDiagnoser]
public class Benchmark
{
    private SqlConnection _conn;

    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _conn = new SqlConnection("Server=.; Integrated Security=sspi; Initial Catalog=AdventureWorks2019;Encrypt=false");
        _conn.Open();
    }

    [Benchmark]
    public long SynchronousExecuteAndSynchronousReadAllRows()
    {
        var sql = "select * from Sales.SalesOrderDetail";
        using var cmd = new SqlCommand(sql, _conn);
        using var reader = cmd.ExecuteReader();

        var result = 0L;
        var ordinal = reader.GetOrdinal("OrderQty");

        while (reader.Read())
        {
            result += reader.GetInt16(ordinal);
        }

        return result;
    }

    [Benchmark(Baseline = true)]
    public async Task<long> AsynchronousExecuteAndSynchronousReadAllRows()
    {
        var sql = "select * from Sales.SalesOrderDetail";
        using var cmd = new SqlCommand(sql, _conn);
        using var reader = await cmd.ExecuteReaderAsync();

        var result = 0L;
        var ordinal = reader.GetOrdinal("OrderQty");

        while (reader.Read())
        {
            result += reader.GetInt16(ordinal);
        }

        return result;
    }

    [Benchmark]
    public async Task<long> AsynchronousExecuteAndAsynchronousReadAllRows()
    {
        var sql = "select * from Sales.SalesOrderDetail";
        using var cmd = new SqlCommand(sql, _conn);
        using var reader = await cmd.ExecuteReaderAsync();

        var result = 0L;
        var ordinal = reader.GetOrdinal("OrderQty");

        while (await reader.ReadAsync())
        {
            result += reader.GetInt16(ordinal);
        }

        return result;
    }
}
