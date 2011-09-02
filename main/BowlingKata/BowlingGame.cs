namespace BowlingKata
{
    public class BowlingGame
    {
        private readonly IFrameKeeper _frameKeeper;

        public BowlingGame(IFrameKeeper frameKeeper)
        {
            _frameKeeper = frameKeeper;
        }

        public int Score()
        {
            return 0;
        }

        public void Roll(int pins)
        {
            this._frameKeeper.Keep(pins);
        }
    }
}