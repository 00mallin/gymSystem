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
        catch{ return false; }

        int cardId = CardDB.Add();

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
}
