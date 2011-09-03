using MavenThought.Commons.Extensions;

namespace BowlingKata.Acceptance.Tests
{
    public class GameBuilder
    {
        private readonly BowlingGame _game;

        public GameBuilder()
        {
            _game = new BowlingGame(new FrameKeeper(), new ScoreCalculator());
        }

        public BowlingGame Build()
        {
            return this._game;
        }

        public GameBuilder WithZeroScore()
        {
            20.Times(() => this._game.Roll(0));

            return this;
        }

        public GameBuilder WithPerfectGame()
        {
            12.Times(() => this._game.Roll(10));
            
            return this;
        }
    }
}