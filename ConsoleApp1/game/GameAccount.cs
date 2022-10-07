namespace ConsoleApp1;

public class GameAccount
{
    public static decimal TotalGameCount;
    private const string ExceptionMessageNegativeBidRating = "Bid rate cannot be negative";
    public string UserName { get; set; }
    public short CurrentRating { get; set; }
    private List<Game> _gameList;

    public GameAccount(string userName, short currentRating)
    {
        UserName = userName;
        this.CurrentRating = (short)(IsValidRate(currentRating) ? currentRating : 1);
        _gameList = new List<Game>();
    }

    private Boolean IsValidRate(short rating)
    {
        return rating > 0 && rating < 32767;
    }

    private void WinGame(string opponentName, short rating)
    {
        if (CurrentRating + 1 < 32767)
        {
            this.CurrentRating++;
        }
        else
            this.CurrentRating = 32767;

        _gameList.Add(new Game(this.UserName, opponentName, rating));
    }

    private void LoseGame(string opponentName, short rating)
    {
        if (CurrentRating - rating > 0)
        {
            this.CurrentRating -= rating;
        }
        else
            this.CurrentRating = 1;

        _gameList.Add(new Game(opponentName, UserName, rating));
    }

    public void Play(GameAccount secondOpponent, short bidRate)
    {
        if (bidRate < 0)
        {
            throw new ArgumentException(ExceptionMessageNegativeBidRating, nameof(bidRate));
        }

        var firstUserCloseToWin = Math.Abs(this.CurrentRating - bidRate);
        var secondUserCloseToWin = Math.Abs(secondOpponent.CurrentRating - bidRate);

        if (firstUserCloseToWin < secondUserCloseToWin)
        {
            SetWinnerAndLoser(this, secondOpponent, bidRate);
        }
        else if (firstUserCloseToWin > secondUserCloseToWin)
        {
            SetWinnerAndLoser(secondOpponent, this, bidRate);
        }
        else
        {
            Random random = new Random();
            var winner = random.NextInt64(0, 2);

            if (winner == 0)
            {
                SetWinnerAndLoser(this, secondOpponent, bidRate);
            }
            else
            {
                SetWinnerAndLoser(secondOpponent, this, bidRate);
            }
        }

        TotalGameCount++;
    }

    private void SetWinnerAndLoser(GameAccount opponent1, GameAccount opponent2, short rate)
    {
        opponent1.WinGame(opponent2.UserName, rate);
        opponent2.LoseGame(opponent1.UserName, rate);
    }

    public string GetStats()
    {
        var report = new System.Text.StringBuilder();

        report.AppendLine("Game Number\tWinner\tLoser\tBit Rate");


        for (var i = 0; i < _gameList.Count; i++)
        {
            report.AppendLine($"{i + 1}\t\t{_gameList[i].FirstOpponent}" +
                              $"\t{_gameList[i].SecondOpponent}\t" +
                              $"{_gameList[i].GameRate}");
        }

        return report.ToString();
    }
}