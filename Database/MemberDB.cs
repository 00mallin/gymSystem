using Logic;
using Dapper;

namespace Database;

public class MemberDB
{
    private static ConnectDB db = new();

    public static bool Add(Member newMemeber)
    {
        int id = 0;

        try
        {
            var paramaters = new { 
                PersonalNumber = newMemeber.PersonalNumber,
                FirstName = newMemeber.FirstName,
                LastName = newMemeber.LastName,
                Address = newMemeber.Address,
                Phone = newMemeber.Phone
            };
            id = db.Connection.QuerySingle<int>("INSERT INTO member(personal_number, first_name, last_name, address, phone, is_staff, card_id) VALUES (@PersonalNumber, @FirstName, @LastName, @Address, @Phone, 0, NULL); SELECT LAST_INSERT_ID()", paramaters);
        }
        catch{ return false; } // Duplicate entry

        int cardId = CardDB.Add();

        // Connect the created card to new Member
        if(cardId > 0)
        {
            var paramaters = new {
                Id = id,
                CardId = cardId
            };
            db.Connection.Execute("UPDATE member SET card_id=@CardId WHERE id=@Id", paramaters);

            return true;
        }
        return false;
    }

    public static Member Get(string personalNumber)
    {
        var paramaters = new { PersonalNumber = personalNumber};
        return db.Connection.QuerySingleOrDefault<Member>("SELECT id, personal_number AS PersonalNumber, first_name AS FirstName, last_name AS LastName, address, phone, is_staff AS IsStaff, card_id AS CardId FROM member WHERE personal_number = @PersonalNumber", paramaters);
    }

    public static bool Remove(Member member)
    {
        List<Membership> memberships = MembershipDB.GetCurrent(member);
        int result = db.Connection.Execute($"DELETE FROM member WHERE id = {member.Id}; DELETE FROM card WHERE id = {member.CardId}");
        
        foreach (var membership in memberships)
        {
            MembershipDB.Remove(membership.Id);
        }

        if (result > 0)
        {
            return true;
        }

        throw new Exception(message: "Couldn't delete member from DB!");
    }
}
