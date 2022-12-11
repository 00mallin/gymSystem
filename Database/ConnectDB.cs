using MySqlConnector;

namespace Database;

public class ConnectDB
{
    public MySqlConnection Connection { get; private set; }
    public ConnectDB()
    {
        string connectionString = "Server=familjenlindh.se;Database=gym_system;Uid=gym;Pwd=123gym123";
        Connection = new(connectionString);

        try
        {
            Connection.Open();
        }
        catch 
        {
            throw new Exception(message: "Couldn't connect to database!");
        }
    }
}