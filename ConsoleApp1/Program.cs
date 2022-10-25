// See https://aka.ms/new-console-template for more information

using ConsoleApp1.game;

namespace ConsoleApp1;

class Program
{
    public static void Main(string[] args)
    {
        var gameAccount1 = new GameAccount("Oleg", 3);
        var gameAccount2 = new GameAccount("Dan", 3);

        Console.WriteLine("Current rate of " + gameAccount1.UserName + ": " + gameAccount1.CurrentRating);
        Console.WriteLine("Current rate of " + gameAccount2.UserName + ": " + gameAccount2.CurrentRating);

        gameAccount1.Play(gameAccount2, 3);
        Console.WriteLine("Current rate of " + gameAccount1.UserName + ": " + gameAccount1.CurrentRating);
        Console.WriteLine("Current rate of " + gameAccount2.UserName + ": " + gameAccount2.CurrentRating);

        gameAccount2.Play(gameAccount1, 1);
        Console.WriteLine("Current rate of " + gameAccount1.UserName + ": " + gameAccount1.CurrentRating);
        Console.WriteLine("Current rate of " + gameAccount2.UserName + ": " + gameAccount2.CurrentRating);

        gameAccount1.Play(gameAccount2, 5);
        Console.WriteLine("Current rate of " + gameAccount1.UserName + ": " + gameAccount1.CurrentRating);
        Console.WriteLine("Current rate of " + gameAccount2.UserName + ": " + gameAccount2.CurrentRating);

        Console.WriteLine("Statistics: ");
        Console.WriteLine(gameAccount2.GetStats());

        /*
        List<GameAccount> accounts = new List<GameAccount>();
        accounts.Add(gameAccount1);
        Console.WriteLine(accounts[0].UserName);
        Console.WriteLine(gameAccount1.UserName);
        
        Console.WriteLine((accounts[0].UserName = "Oleg"));
        Console.WriteLine(gameAccount1.UserName);
        
        Console.WriteLine((gameAccount1.UserName = "De"));
        Console.WriteLine(accounts[0].UserName);

        gameAccount1 =  new GameAccount("1", 3);
        Console.WriteLine(gameAccount1.UserName);
        Console.WriteLine(accounts[0].UserName);
        */
    }
}