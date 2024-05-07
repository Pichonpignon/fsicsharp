using Npgsql;
using System.Configuration;

public class DatabaseConnection
{
    private static readonly string _connectionString;
    private static readonly NpgsqlConnection _connection;

    static DatabaseConnection()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        _connection = new NpgsqlConnection(_connectionString);
    }

    private DatabaseConnection() { }

    public static string ConnectionString => _connectionString;

    public static NpgsqlConnection GetConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Open)
        {
            _connection.Open();
        }
        return _connection;
    }
}
