namespace UI;

public class EquipmentUI
{
    public static void Show()
    {
        Menu subMenu = new();

        subMenu.AddMenuItem("Create Equipment", null);
        subMenu.AddMenuItem("Add Equipment", null);
        subMenu.AddMenuItem("Remove Equipment", null);

        subMenu.Show();
    }
}