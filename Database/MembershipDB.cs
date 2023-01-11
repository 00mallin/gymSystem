using Logic;
using Dapper;

namespace Database;

public class MembershipDB
{
    private static ConnectDB db = new();

    public static List<MembershipType> GetAllTypes()
    {
        return db.Connection.Query<MembershipType>("SELECT id, name, days, price_per_month AS PricePerMonth FROM membership_type").ToList();
    }


    public static bool AddOrEdit(Member member, MembershipType membershipType, int gymId)
    {
        Card card = CardDB.Get(member);
        List<Membership> activeMemberships = MembershipDB.GetCurrent(member);

        // Remove already existing membership from DB 
        // if there is already an existing membership at current gym
        foreach (var membership in activeMemberships)
        {
            if(membership != null && membership.GymId == gymId)
            {
                Remove(membership.Id);
            }
        }

        int id = db.Connection.QuerySingleOrDefault<int>($"INSERT INTO membership(start_date, end_date, membership_type_id, gym_id) VALUES ('{DateTime.Now.ToString("yyyy-MM-dd")}', '{DateTime.Now.AddDays(membershipType.Days).ToString("yyyy-MM-dd")}', {membershipType.Id}, {gymId}); SELECT LAST_INSERT_ID()");

        if (id > 0)
        {
            db.Connection.Execute($"INSERT INTO membership_card(membership_id, card_id) VALUES ({id}, {member.CardId})");
            return true;
        }
        
        return false;
    }

    public static List<Membership> GetCurrent(Member member)
    {
        return db.Connection.Query<Membership>($"SELECT membership.id, membership.start_date AS StartDate, membership.end_date AS EndDate, membership.membership_type_id AS MembershipTypeId, membership.gym_id AS GymId FROM member INNER JOIN membership_card ON member.card_id = membership_card.card_id INNER JOIN membership ON membership_card.membership_id = membership.id WHERE member.id = {member.Id}").ToList();
    }

    public static bool Remove(int id)
    {
        var result = db.Connection.Execute($"DELETE FROM membership WHERE id = {id}");

        if(result > 0)
        {
            return true;
        }
        return false;
    }
}
