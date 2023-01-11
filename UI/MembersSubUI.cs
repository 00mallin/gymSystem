using Logic;
using Database;

namespace UI;

public class MembersSubUI
{
    public static void Show(int gymId)
    {
        Menu subMenu = new();

        subMenu.AddMenuItem("Edit Membership", () => EditMembership(gymId));
        subMenu.AddMenuItem("Cancel Membership", () => CancelMembership());
        subMenu.AddMenuItem("Remove Member", () => RemoveMember());


        subMenu.Show();
    }
}