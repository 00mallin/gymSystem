namespace UI;
public class GymUI
{
    public static void Show(int GymId)
    {
        Menu subMenu = new();

        subMenu.AddMenuItem("Members", () => MembersUI.Show());
        subMenu.AddMenuItem("Equipment", () => EquipmentUI.Show());

        subMenu.Show();
    }
}