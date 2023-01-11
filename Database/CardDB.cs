using Logic;
using Dapper;

namespace Database;

public class CardDB
{
    private static ConnectDB db = new();

    public static int Add()
    {
        int id = 0;
        var paramaters = new { ActivationDate = DateTime.Now.ToString("yyyy-MM-dd") };

        try 
        {
            id = db.Connection.QuerySingle<int>("INSERT INTO card(activation_date) VALUES (@ActivationDate); SELECT LAST_INSERT_ID()", paramaters);
            return id;
        }
        catch { return 0; }
    }

    public static Card Get(Member member)
    {
        return db.Connection.QuerySingleOrDefault<Card>($"SELECT id, activation_date AS ActivationDate FROM `card` WHERE id = {member.CardId}");
    }
}
