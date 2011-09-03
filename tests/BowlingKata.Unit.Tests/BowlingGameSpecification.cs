using FakeItEasy;

namespace BowlingKata.Unit.Tests
{
    /// <summary>
    /// Base specification for BowlingGame
    /// </summary>
    public abstract class BowlingGameSpecification
        : SpecificationBaseWithNoContract<BowlingGame>
    {
        [Fake]
        protected IFrameKeeper FrameKeeper { get; set; }

        [Fake]
        protected IScoreCalculator ScoreCalculator { get; set; }

        protected override BowlingGame CreateSut()
        {
            return new BowlingGame(this.FrameKeeper, this.ScoreCalculator);
        }

    }
}