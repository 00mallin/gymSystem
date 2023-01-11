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

    public static Dictionary<Gym, int> GetAll()
    {
        Dictionary<Gym, int> dictonaryGym = new();
        List<Gym> listOfGyms = db.Connection.Query<Gym>("SELECT * FROM gym").ToList();

        foreach (var gym in listOfGyms)
        {
            int memberCount = db.Connection.QuerySingleOrDefault<int>($"SELECT COUNT(0) FROM membership WHERE gym_id = '{gym.Id}'");
            dictonaryGym.Add(gym, memberCount); 
        }

        return dictonaryGym;
    }

    public static void Update(Gym item)
    {
        throw new NotImplementedException();
    }
}
