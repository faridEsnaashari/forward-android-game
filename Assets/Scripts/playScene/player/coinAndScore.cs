public class coin
{
    public static coin instance = new coin();
    private coin()
    {
        _coinAmount = 0;
    }

    public int _coinAmount;

    public int coinAmount
    {
        get {return _coinAmount;}
    }

    public void incCoinAmount()
    {
        _coinAmount++;
    }
    public void resetCoin()
    {
        _coinAmount = 0;
    }
}

public class Score
{
    public static Score instance = new Score();
    private Score()
    {
        _score = 0;
    }

    public int _score;

    public int score
    {
        get {return _score;}
    }

    public void incScore()
    {
        _score++;
    }
    public void resetScore()
    {
        _score = 0;
    }
}
