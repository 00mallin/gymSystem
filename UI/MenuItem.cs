namespace UI;
public class MenuItem
{
    public string Name { get; set; }
    public Action Method { get; set; }

    public void Render(bool isActive)
    {
        WriteLineWithColor($"{Name}", isActive ? ConsoleColor.DarkGray : ConsoleColor.Black);
    }

    static void WriteLineWithColor(string output, ConsoleColor bgColor)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = bgColor;
        Console.WriteLine(output);
        Console.ResetColor();
    }
}