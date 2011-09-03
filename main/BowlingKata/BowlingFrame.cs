namespace BowlingKata
{
    public class BowlingFrame : IBowlingFrame
    {
        public BowlingFrame(int first, int second = 0)
        {
            this.First = first;
            this.Second = second;
        }

        public int First { get; private set; }

        public int Second { get; private set; }

        public bool IsStrike
        {
            get { return this.First == 10; }
        }
    }
}