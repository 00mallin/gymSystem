using Logic;
using Database;

namespace UI;

public class MembersSubUI
{
    public static void Show(int gymId, Member member)
    {
        Console.WriteLine(member.FirstName);
        Menu subMenu = new();

        subMenu.AddMenuItem("Edit Membership", () => EditMembership(gymId, member));
        // subMenu.AddMenuItem("Cancel Membership", () => CancelMembership());
        // subMenu.AddMenuItem("Remove Member", () => RemoveMember());


        subMenu.Show();
    }

    private static void EditMembership(int gymId, Member member)
    {
        Console.Clear();
        List<MembershipType> memberships = MembershipDB.GetAll();

        for (int i = 0; i < memberships.Count; i++)
        {
            Console.WriteLine($"{i+1}. {memberships[i].Name} ({memberships[i].PricePerMonth} SEK)");
        }
        Console.Write("Select membership: ");
        int selection = int.Parse(Console.ReadLine());

        MembershipType membershipType = memberships[selection-1];

        if(MembershipDB.Add(member, membershipType, gymId))
        {
            Console.Write("Membership succesfully started!...");
            Console.ReadKey();
        }
    }
}