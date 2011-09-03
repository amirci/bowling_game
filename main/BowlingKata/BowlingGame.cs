namespace BowlingKata
{
    public class BowlingGame
    {
        private readonly IFrameKeeper _frameKeeper;
        private readonly IScoreCalculator _calculator;

        public BowlingGame(IFrameKeeper frameKeeper, IScoreCalculator calculator)
        {
            _frameKeeper = frameKeeper;
            _calculator = calculator;
        }

        public int Score()
        {
            return this._calculator.Calculate(this._frameKeeper.Frames);
        }

        public void Roll(int pins)
        {
            this._frameKeeper.Keep(pins);
        }
    }
}