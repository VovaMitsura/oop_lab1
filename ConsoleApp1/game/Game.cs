namespace ConsoleApp1.game;

public class Game
{
    public string FirstOpponent { get; set; }
    public string SecondOpponent { get; set; }
    public short GameRate { get; set; }

    public Game(string firstOpponent, string secondOpponent, short gameRate)
    {
        FirstOpponent = firstOpponent;
        SecondOpponent = secondOpponent;
        GameRate = gameRate;
    }
}