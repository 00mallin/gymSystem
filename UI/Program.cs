using System;
using Logic;
using Database;

namespace UI;
internal class Program
{
    public static Menu mainMenu = new();
    private static void Main(string[] args)
    {


        Dictionary<Gym, int> listOfGyms = GymDB.GetAll();

        foreach (var gym in listOfGyms)
        {
            MenuItem mi = new();
            mi.Name = $"{gym.Key.Name} ({gym.Value})";
            mi.Method = () => { GymUI.Show(gym.Key.Id); };
            mainMenu.AddMenuItem(mi);
        }

        mainMenu.AddMenuItem("Exit", () => {Environment.Exit(0);});

        mainMenu.Show("Gymsystem Friskis");       
    }
}