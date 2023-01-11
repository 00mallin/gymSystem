using Logic;
using Database;

namespace UI;

public class MembersSubUI
{
    public static void Show()
    {
        Menu subMenu = new();

        subMenu.AddMenuItem("Edit Membership", () => EditMembership());
        subMenu.AddMenuItem("Cancel Membership", () => CancelMembership());
        subMenu.AddMenuItem("Remove Member", () => RemoveMember());


        subMenu.Show();
    }
}