namespace UI;
public class Menu
{
    public ConsoleKey upKey = ConsoleKey.UpArrow;
    public ConsoleKey downKey = ConsoleKey.DownArrow;
    public ConsoleKey backKey = ConsoleKey.Escape;
    public ConsoleKey confirmKey = ConsoleKey.Enter;

    int currentMenuIndex = 0;
    List<MenuItem> menuItems = new();

    public void Show(string title)
    {
        while (true)
        {
            Console.CursorVisible = false;

            RenderMenu(title);

            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == upKey) SetCurrentMenuIndex(-1);
            else if (key == downKey) SetCurrentMenuIndex(1);
            else if (key == confirmKey) menuItems[currentMenuIndex].Method();
            else if (key == backKey) return;
        }
    }

    public void AddMenuItem(MenuItem mi) => menuItems.Add(mi);

    public void AddMenuItem(string name, Action method)
    {
        MenuItem newMenuItem = new();
        newMenuItem.Name = name;
        newMenuItem.Method = method;
        menuItems.Add(newMenuItem);
    }

    void RenderMenu(string title)
    {
        Console.Clear();
        Console.WriteLine(title + Environment.NewLine);
        menuItems.ForEach((item) => item.Render(menuItems.IndexOf(item) == currentMenuIndex));
        Console.ResetColor();
    }


    void SetCurrentMenuIndex(int i)
    {
        currentMenuIndex = Math.Clamp(currentMenuIndex + i, 0, menuItems.Count - 1);
    }
}      