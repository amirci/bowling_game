namespace BowlingKata
{
    public interface IBowlingFrame
    {
        int First { get; }

        int Second { get; }

        bool IsStrike { get; }

        int Score { get; }
    }
}