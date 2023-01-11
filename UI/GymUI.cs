using Database;
using Logic;

namespace UI;
public class GymUI
{
    public static void Show(int gymId)
    {
        Menu subMenu = new();

        subMenu.AddMenuItem("Members", () => MembersUI.Show(gymId));
        subMenu.AddMenuItem("Equipment", () => EquipmentUI.Show());

        subMenu.Show($"{GymDB.Get(gymId).Name}");
    }
}