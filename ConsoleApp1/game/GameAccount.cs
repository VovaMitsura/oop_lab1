namespace ConsoleApp1;

public class GameAccount
{
    public static decimal TotalGameCount;
    public string UserName { get; set; }
    public short CurrentRating { get; set; }
    private List<Game> gameList;

    public GameAccount(string userName, short currentRating)
    {
        UserName = userName;
        CurrentRating = currentRating;
        gameList = new List<Game>();
    }

    private void WinGame(string opponentName, short rating)
    {
        if (rating <= 0)
        {
            throw new ArgumentException(nameof(rating), "Rating cannot be lower 1");
        }

        if (CurrentRating + rating < 32767)
        {
            this.CurrentRating++;
        }
        else
            this.CurrentRating = 32767;

        gameList.Add(new Game(this.UserName, opponentName, rating));
    }

    private void LoseGame(string opponentName, short rating)
    {
        if (rating <= 0)
        {
            throw new ArgumentException(nameof(rating), "Rating cannot be lower 1");
        }

        if (CurrentRating - rating > 0)
        {
            this.CurrentRating -= rating;
        }
        else
            this.CurrentRating = 1;

        gameList.Add(new Game(opponentName, UserName, rating));
    }

    public void Play(GameAccount secondOpponent, short bidRate)
    {
        if (bidRate < 0)
        {
            throw new ArgumentException(nameof(bidRate), "Bid rate cannot be negative");
        }

        int firstUserCloseToWin = Math.Abs(this.CurrentRating - bidRate);
        int secondUserCloseToWin = Math.Abs(secondOpponent.CurrentRating - bidRate);

        if (firstUserCloseToWin < secondUserCloseToWin)
        {
            SetWinner(this, secondOpponent, bidRate);
        }
        else if (firstUserCloseToWin > secondUserCloseToWin)
        {
            SetWinner(secondOpponent, this, bidRate);
        }
        else
        {
            Random random = new Random();
            int winner = (int)random.NextInt64(0, 2);

            if (winner == 0)
            {
                SetWinner(this, secondOpponent, bidRate);
            }
            else
            {
                SetWinner(secondOpponent, this, bidRate);
            }
        }

        TotalGameCount++;
    }

    private void SetWinner(GameAccount opponent1, GameAccount opponent2, short rate)
    {
        opponent1.WinGame(opponent2.UserName, rate);
        opponent2.LoseGame(opponent1.UserName, rate);
    }

    public string GetStats()
    {
        var report = new System.Text.StringBuilder();

        report.AppendLine("Game Number\tWinner\tLoser\tBit Rate");


        for (int i = 0; i < gameList.Count; i++)
        {
            report.AppendLine($"{i + 1}\t\t{gameList[i].FirstOpponent}" +
                              $"\t{gameList[i].SecondOpponent}\t" +
                              $"{gameList[i].GameRate}");
        }

        return report.ToString();
    }
}
