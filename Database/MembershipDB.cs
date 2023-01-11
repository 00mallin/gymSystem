using Logic;
using Dapper;

namespace Database;

public class MembershipDB
{
    private static ConnectDB db = new();

    public static List<MembershipType> GetAll()
    {
        return db.Connection.Query<MembershipType>("SELECT id, name, price_per_month AS PricePerMonth FROM membership_type").ToList();
    }


    public static bool Add(Member member, MembershipType membershipType)
    {
        return false;
    }
}
