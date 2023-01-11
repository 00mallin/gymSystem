using Logic;
using Dapper;

namespace Database;

public class MembershipDB
{
    private static ConnectDB db = new();

    public static List<MembershipType> GetAll()
    {
        return db.Connection.Query<MembershipType>("SELECT id, name, days, price_per_month AS PricePerMonth FROM membership_type").ToList();
    }


    public static bool Add(Member member, MembershipType membershipType, int gymId)
    {
        Card card = CardDB.Get(member);
        
        int id = db.Connection.QuerySingleOrDefault<int>($"INSERT INTO membership(start_date, end_date, membership_type_id, gym_id) VALUES ('{DateTime.Now.ToString("yyyy-MM-dd")}', '{DateTime.Now.AddDays(membershipType.Days).ToString("yyyy-MM-dd")}', {membershipType.Id}, {gymId}); SELECT LAST_INSERT_ID()");

        if (id > 0)
        {
            db.Connection.Execute($"INSERT INTO membership_card(membership_id, card_id) VALUES ({id}, {member.CardId})");
            return true;
        }
        
        return false;
    }
}
