
using System.Data;
using System.Data.SQLite;
using System.Net.WebSockets;


namespace FastFood.Services;

public class SqlHelper : ISqlHelper
{

    private readonly string _connectionString;

    private SQLiteConnection _connection;

    public SqlHelper(string connectionString) {
        _connectionString = connectionString;
    }


    public void CreateConnection() {
        // Create a new database connection:
        this._connection = new SQLiteConnection(_connectionString);
        this._connection.Open();
    }

    public void CloseConnection() {
        _connection.Close();
    }

    public bool IsConnectionOpen() {
        return _connection.State == ConnectionState.Open;
    }


    public DataTable GetAll(string query) {
        CreateConnection();

        if (!IsConnectionOpen()) {
            throw new Exception("Connection was no opened");
        }

        var cmd = _connection.CreateCommand();
        cmd.CommandText = query;

        var reader = cmd.ExecuteReader();
        var dt = new DataTable();

        dt.Load(reader);

        CloseConnection();

        return dt;
    }
}