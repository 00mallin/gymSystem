using Logic;
using Database;

namespace UI;

public class MembersSubUI
{
    public static void Show(int gymId, Member member)
    {
        Menu subMenu = new();

        subMenu.AddMenuItem("Edit Membership", () => EditMembership(gymId, member));
        subMenu.AddMenuItem("Cancel Membership", () => CancelMembership(gymId, member));
        subMenu.AddMenuItem("Remove Member", () => RemoveMember(member));


        subMenu.Show($"{member.FirstName} {member.LastName}");
    }

    private static void EditMembership(int gymId, Member member)
    {
        Console.Clear();
        List<MembershipType> memberships = MembershipDB.GetAllTypes();

        for (int i = 0; i < memberships.Count; i++)
        {
            Console.WriteLine($"{i+1}. {memberships[i].Name} ({memberships[i].PricePerMonth} SEK)");
        }
        Console.Write("Select membership: ");
        int selection = int.Parse(Console.ReadLine());

        MembershipType membershipType = memberships[selection-1];

        if(MembershipDB.AddOrEdit(member, membershipType, gymId))
        {
            Console.Clear();
            Console.Write("Membership succesfully started!...");
            Console.ReadKey();
        }
    }

    private static void CancelMembership(int gymId, Member member)
    {
        List<Membership> currentMemberships = MembershipDB.GetCurrent(member);

        foreach (var membership in currentMemberships)
        {
            if(membership.GymId == gymId)
            {
                MembershipDB.Remove(membership.Id);
            }
        }

        Console.Clear();
        Console.Write("Membership has been canceled!...");
        Console.ReadKey();
    }

    private static void RemoveMember(Member member)
    {
        Console.Clear();
        Console.WriteLine($"Are you sure you want to remove {member.FirstName} {member.LastName} from the system.");
        Console.WriteLine("Everything will be removed!");
        Console.Write("Y/N: ");
        string answer = Console.ReadLine().ToLower().Trim();

        if(answer == "y")
        {
            if(MemberDB.Remove(member))
            {
                Console.Clear();
                Console.Write("Member was permanently deleted from the system...");
                Console.ReadKey();
                Program.mainMenu.Show("Gymsystem Friskis");
            }
        }
    }
}