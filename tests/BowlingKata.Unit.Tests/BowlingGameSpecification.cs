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
        public IFrameKeeper FrameKeeper { get; set; }

        protected override BowlingGame CreateSut()
        {
            return new BowlingGame(this.FrameKeeper);
        }
    }
}