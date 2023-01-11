using Logic;
using Database;

namespace UI;

public class MembersUI
{
    public static void Show()
    {
        Menu subMenu = new();

        subMenu.AddMenuItem("New Member", () => NewMember());
        subMenu.AddMenuItem("Update Membership", null);
        subMenu.AddMenuItem("Delete Member", null);

        subMenu.Show();
    }

    private static void NewMember()
    {
        Member newMember = new();

        Console.Clear();
        Console.Write("Personal number: ");
        newMember.PersonalNumber = Console.ReadLine();
        Console.Write("First name: ");
        newMember.FirstName = Console.ReadLine();
        Console.Write("Last name: ");
        newMember.LastName = Console.ReadLine();
        Console.Write("Address: ");
        newMember.Address = Console.ReadLine();
        Console.Write("Phone nr: ");
        newMember.Phone = Console.ReadLine();

        MemberDB.Add(newMember);
        // Add member. if success
        // Add new card
        // Update memeber with card id
        
    }
}