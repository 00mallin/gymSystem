using MySqlConnector;
using System.Configuration;

namespace Database;

public class ConnectDB
{
    public MySqlConnection Connection { get; private set; }
    public ConnectDB()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
        Connection = new MySqlConnection(connectionString);

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