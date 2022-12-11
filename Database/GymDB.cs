using Logic;
using Dapper;

namespace Database;

public class GymDB
{
    private static ConnectDB db = new();

    public static void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public static void Insert(Gym item)
    {
        throw new NotImplementedException();
    }

    public static List<Gym> GetAll()
    {
        return db.Connection.Query<Gym>("SELECT * FROM gym").ToList();
    }

    public static void Update(Gym item)
    {
        throw new NotImplementedException();
    }
}
