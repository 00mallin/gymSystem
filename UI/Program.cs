using System;
using Logic;
using Database;

namespace UI;
internal class Program
{
    private static void Main(string[] args)
    {
        Member newMember = new();
        newMember.PersonalNumber = "0009085010";
        newMember.FirstName = "Malte";
        newMember.LastName = "Lindh";
        newMember.Address = "Kinna";
        newMember.Phone = "076341568";

        Console.WriteLine(MemberDB.Add(newMember));

        Console.ReadLine();

        // Menu mainMenu = new();

        // List<Gym> listOfGyms = GymDB.GetAll();

        // foreach (var gym in listOfGyms)
        // {
        //     MenuItem mi = new();
        //     mi.Name = gym.Name;
        //     mi.Method = () => { GymUI.Show(gym.Id); };
        //     mainMenu.AddMenuItem(mi);
        // }

        // mainMenu.AddMenuItem("Exit", () => {Environment.Exit(0);});

        // mainMenu.Show();       
    }
}