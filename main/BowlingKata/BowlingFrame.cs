namespace BowlingKata
{
    public class BowlingFrame : IBowlingFrame
    {
        public BowlingFrame(int pins)
        {
            this.First = pins;
        }

        public int First { get; private set; }
    }
}