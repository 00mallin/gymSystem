namespace UI;

public class MembersUI
{
    public static void Show()
    {
        Menu subMenu = new();

        subMenu.AddMenuItem("New Member", null);
        subMenu.AddMenuItem("Update Membership", null);
        subMenu.AddMenuItem("Delete Member", null);

        subMenu.Show();
    }

    private static void NewMember()
    {
        Console.Clear();
        Console.Write("Personal number: ");
        Console.Write("First name: ");
        Console.Write("Last name: ");
        Console.Write("Address: ");
        Console.Write("Phone nr: ");
    }
}