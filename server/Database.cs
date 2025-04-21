using server.Enums;

namespace server;

using Npgsql;

public class Database
{

    private readonly string _host = "localhost";
    private readonly string _port = "5432";
    private readonly string _username = "postgres";
    private readonly string _password = "pablo";
    private readonly string _database = "postgres";

    private NpgsqlDataSource _connection;

    
    public NpgsqlDataSource Connection()
    {
        return _connection;
    }

    public Database()
    {
        string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Tosspoppe2004;Database=postgres";
        }

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.MapEnum<Role>("role");
        dataSourceBuilder.MapEnum<IssueState>("issue_state");
        dataSourceBuilder.MapEnum<Sender>("sender");
        _connection = dataSourceBuilder.Build();
    }

}