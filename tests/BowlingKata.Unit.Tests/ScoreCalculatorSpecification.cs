
using System.Collections.Generic;
using FakeItEasy;
using MavenThought.Commons.Extensions;

namespace BowlingKata.Unit.Tests
{
    /// <summary>
    /// Base specification for ScoreCalculator
    /// </summary>
    public abstract class ScoreCalculatorSpecification
        : SpecificationBaseWithContract<IScoreCalculator, ScoreCalculator>
    {
        protected IEnumerable<IBowlingFrame> Frames { get; set; }
        protected int Actual { get; set; }
        public int Expected { get; set; }

        public override void Given()
        {
            base.Given();

            this.Frames = A.CollectionOfFake<IBowlingFrame>(10);
        }

        protected override IScoreCalculator CreateSut()
        {
            return new ScoreCalculator();
        }

        protected void AddExtraFrame(int first, int second = 0)
        {
            var extraFrame = A.Fake<IBowlingFrame>();

            A.CallTo(() => extraFrame.First).Returns(first);
            A.CallTo(() => extraFrame.Second).Returns(second);

            this.Frames = this.Frames.Concat(extraFrame);
        }
    }
}