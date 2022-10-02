// See https://aka.ms/new-console-template for more information

namespace ConsoleApp1;

class Program
{
    public static void Main(string[] args)
    {
        GameAccount gameAccount1 = new GameAccount("1", 3);
        GameAccount gameAccount2 = new GameAccount("2", 3);
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
        Console.WriteLine(gameAccount1.GetStats());
    }
}